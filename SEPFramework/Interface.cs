using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace SEPFramework
{
    class Interface<T>
    {

       public interface IFormBuilder
        {
            FormData<T> BuildData(List<T> dataList);
            void Render(Panel container);
           
        }
    }
}
