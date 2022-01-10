using SEPFramework.Builder;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SEPFramework.Interface
{
    public interface IDataGridBuilder<T>
    {
        public IDataGridBuilder<T> BuildData(List<T> data);

        public IDataGridBuilder<T> BuildAction(string actionName, Action<object[]> function);

        public IDataGridBuilder<T> BuildButtonColumn(string colHeader, string buttonContent, RoutedEventHandler clickEvent, Style buttonStyle=null);

        public IDataGridBuilder<T> BuildDefaultButton(Style buttonStyle = null);

        public IDataGridBuilder<T> BuildTopPanel(Panel container, Style panelStyle=null, Style buttonStyle=null);


        public IDataGridBuilder<T> BuildCellStyle(Style style);


        public IDataGridBuilder<T> BuildHeaderStyle(Style style);


        public SEPDataGrid<T> GetDataGrid();

    }
}
