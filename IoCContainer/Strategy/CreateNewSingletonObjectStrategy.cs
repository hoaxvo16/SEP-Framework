using IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCContainer.Strategy
{
    class CreateNewSingletonObjectStrategy : IResolveStrategy
    {
        private readonly Dictionary<Type, object> _singletonRegistrations;
        private readonly Type _targetType;
        private readonly MasterResolveStrategy _masterResolveStrategy;

        public CreateNewSingletonObjectStrategy(MasterResolveStrategy masterResolveStrategy, Dictionary<Type, object> singletonRegistrations, Type targetType)
        {
            _singletonRegistrations = singletonRegistrations;
            _targetType = targetType;
            _masterResolveStrategy = masterResolveStrategy;
        }

        public IResolveStrategy IResolveStrategy
        {
            get => default;
            set
            {
            }
        }

        public object Resolve(Type type)
        {
            if (!_singletonRegistrations.TryGetValue(type, out var realObject))
            {
                var newObject = _masterResolveStrategy.Resolve(_targetType);
                _singletonRegistrations.Add(type, newObject);
                return newObject;
            }

            return realObject;
        }
    }
}
