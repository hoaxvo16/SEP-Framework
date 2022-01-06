using SEPFramework.Builder;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SEPFramework.Interface
{
    internal interface IDataGridBuilder<T>
    {
        public DataGridBuilder<T> BuildData(List<T> data);
        public DataGridBuilder<T> BuildAction(string actionName, Action<object[]> function);
        public DataGridBuilder<T> BuildButtonColumn(string colHeader, string buttonContent, RoutedEventHandler clickEvent, int width);

        public DataGridBuilder<T> BuildDefaultButton();

        public DataGridBuilder<T> BuildTopPanel(Panel container);

        public SEPDataGrid<T> GetDataGrid();

    }
}
