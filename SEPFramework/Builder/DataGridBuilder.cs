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
        private static SEPDataGrid<T> dataGrid = new SEPDataGrid<T>();
        private static StackPanel topPanel;

       

        public  IDataGridBuilder<T> BuildData(List<T> data)
        {
            dataGrid.SetDataList(data);
          
            return this;
        }


        public IDataGridBuilder<T> BuildAction(string actionName, Action<object[]> function)
        {
            dataGrid.AddAction(actionName, function);
            return this;
        }

        public IDataGridBuilder<T> BuildButtonColumn(string colHeader, string buttonContent, RoutedEventHandler clickEvent, Style buttonStyle=null)
        {

            DataGridTemplateColumn col = ControlBuilder.BuilDataGridColButton(colHeader, buttonContent, clickEvent,buttonStyle);
            dataGrid.AddColumn(col);
           
            return this;
        }

        public IDataGridBuilder<T>  BuildDefaultButton(Style buttonStyle)
        {
            BuildButtonColumn("Delete", "Delete", dataGrid.DeleteItemClick, buttonStyle);
            BuildButtonColumn("Edit", "Edit", dataGrid.EditButtonClick, buttonStyle);
            return this;
        }

        public IDataGridBuilder<T>  BuildTopPanel(Panel container,Style panelStyle, Style buttonStyle)
        {
            var panel = ControlBuilder.BuildStackPanel();
            var addButton = ControlBuilder.BuildButton("Add new", dataGrid.AddNewButtonClick, buttonStyle);
            var undoButton = ControlBuilder.BuildButton("Undo", dataGrid.UndoClick, buttonStyle);
            var redoButton = ControlBuilder.BuildButton("Redo", dataGrid.RedoClick, buttonStyle);
            panel.Children.Add(addButton);
            panel.Children.Add(undoButton);
            panel.Children.Add(redoButton);
            topPanel = panel;
            container.Children.Add(topPanel);
            return this;
        }

        public SEPDataGrid<T> GetDataGrid()
        {
            return dataGrid;
        }

        public IDataGridBuilder<T> BuildCellStyle(Style style)
        {
            dataGrid.SetCellStyle(style);
            return this;
        }

        public IDataGridBuilder<T> BuildHeaderStyle(Style style)
        {
            dataGrid.SetHeaderStyle(style);
            return this;
        }
    }
}
