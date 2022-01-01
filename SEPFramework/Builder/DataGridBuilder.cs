using SEPFramework.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SEPFramework.Builder
{
    public class DataGridBuilder<T> : IDataGridBuilder<T>
    {
        private static DataGrid<T> dataGrid = new DataGrid<T>();
        private static StackPanel topPanel;

       

        public  DataGridBuilder<T> BuildData(List<T> data)
        {
            dataGrid.SetDataList(data);
            return this;
        }


        public DataGridBuilder<T> BuildAction(string actionName, Action<object[]> function)
        {
            dataGrid.AddAction(actionName, function);
            return this;
        }

        public DataGridBuilder<T> BuildButtonColumn(string colHeader, string buttonContent, RoutedEventHandler clickEvent, int width)
        {

            DataGridTemplateColumn col = ControlBuilder.BuilDataGridColButton(colHeader, buttonContent, clickEvent, width);
            dataGrid.AddColumn(col);
            return this;
        }

        public DataGridBuilder<T>  BuildDefaultButton()
        {
            BuildButtonColumn("Delete", "Delete", dataGrid.DeleteItemClick, 100);
            BuildButtonColumn("Edit", "Edit", dataGrid.EditButtonClick, 100);
            return this;
        }

        public DataGridBuilder<T>  BuildTopPanel(Panel container)
        {
            var panel = ControlBuilder.BuildStackPanel();
            var addButton = ControlBuilder.BuildButton("Add new", dataGrid.AddNewButtonClick, 100);
            var undoButton = ControlBuilder.BuildButton("Undo", dataGrid.UndoClick, 100);
            var redoButton = ControlBuilder.BuildButton("Redo", dataGrid.RedoClick, 100);
            panel.Children.Add(addButton);
            panel.Children.Add(undoButton);
            panel.Children.Add(redoButton);
            topPanel = panel;
            container.Children.Add(topPanel);
            return this;
        }

        public  DataGrid<T> GetDataGrid()
        {
            return dataGrid;
        }
    }
}
