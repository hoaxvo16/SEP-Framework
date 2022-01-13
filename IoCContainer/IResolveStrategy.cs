using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    interface IResolveStrategy
    {
        object Resolve(Type type);
    }
}
