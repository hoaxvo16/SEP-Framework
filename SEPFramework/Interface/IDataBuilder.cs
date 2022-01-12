using SEPFramework.Builder;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SEPFramework.Interface
{
    public interface IDataBuilder<T>
    {
        public DataGridBuilder<T> BuildData(List<T> data);

        public SEPDataGrid<T> GetDataGrid();
    }
}
