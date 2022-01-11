using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoC
{
    public class IoCContainer : IContainer
    {
        private readonly Dictionary<Type, Func<object>> regs = new Dictionary<Type, Func<object>>();

        public void RegisterType<TInterface, TImplement>() where TImplement : TInterface
        {
            if (regs.ContainsKey(typeof(TInterface)))
            {
                regs[typeof(TInterface)] = () => Resolve<TImplement>();
            }
            else
            {
                regs.Add(typeof(TInterface), () => Resolve<TImplement>());
            }
        }

        public T Resolve<T>() => (T)GetInstance(typeof(T));
        
        private object GetInstance(Type type)
        {
            if (regs.TryGetValue(type, out Func<object> fac)) return fac();
            else if (!type.IsAbstract) return CreateInstance(type);
            throw new InvalidOperationException("No registration for " + type);
        }

        private object CreateInstance(Type implementationType)
        {
            var ctor = implementationType.GetConstructors().Single();
            var paramTypes = ctor.GetParameters().Select(p => p.ParameterType);
            var dependencies = paramTypes.Select(GetInstance).ToArray();
            return Activator.CreateInstance(implementationType, dependencies);
        }


    }
}