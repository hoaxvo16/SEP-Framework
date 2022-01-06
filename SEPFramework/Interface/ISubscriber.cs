using System;
using System.Collections.Generic;
using System.Text;

namespace SEPFramework.Interface
{
    public interface ISubscriber<T>
    {
        public void Update(List<T> data);
    }
}
