using SEPFramework.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEPFramework.Interface
{
    public interface IActionBuilder<T>
    {
        public DataGridBuilder<T> BuildAction(string actionName, Action<object[]> function);
    }
}
