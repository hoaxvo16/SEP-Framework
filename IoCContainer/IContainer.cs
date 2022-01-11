using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoC
{
    public interface IContainer
    {
        void RegisterType<TInterface, TImplement>() where TImplement: TInterface;
        T Resolve<T>();
        void RegisterInstance<TInterface>(TInterface instance);
    }
}