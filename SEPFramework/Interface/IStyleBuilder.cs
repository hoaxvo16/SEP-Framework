using SEPFramework.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace SEPFramework.Interface
{
    public interface IStyleBuilder<T>
    {
        public DataGridBuilder<T> BuildCellStyle(Style style);


        public DataGridBuilder<T> BuildHeaderStyle(Style style);
    }
}
