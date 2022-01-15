using SEPFramework.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SEPFramework.Builder
{
    public class DataGridBuilder<T> : IDataBuilder<T>, IStyleBuilder<T>,IActionBuilder<T>,IControlBuilder<T>
    {
        private SEPDataGrid<T> dataGrid;
   

        public DataGridBuilder<T> BuildFor(SEPDataGrid<T> input)
        {
            dataGrid = input;

            return this;
        }

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

        public DataGridBuilder<T> BuildButtonColumn(string colHeader, string buttonContent, RoutedEventHandler clickEvent, Style buttonStyle=null)
        {

            DataGridTemplateColumn col = ControlFactory.BuilDataGridColButton(colHeader, buttonContent, clickEvent,buttonStyle);
            dataGrid.AddColumn(col);
           
            return this;
        }

        public DataGridBuilder<T> BuildEditButton(string header,string content,Style buttonStyle=null)
        {
        
            BuildButtonColumn(header, content, dataGrid.EditButtonClick, buttonStyle);
            return this;
        }

        public DataGridBuilder<T> BuildDeleteButton(string header, string content, Style buttonStyle=null)
        {
            BuildButtonColumn(header, content, dataGrid.DeleteItemClick, buttonStyle);
     
            return this;
        }

        public DataGridBuilder<T> BuildToolBar(Panel container,Style panelStyle=null)
        {
            dataGrid.ToolBar=ControlFactory.BuildStackPanel(panelStyle);
            container.Children.Add(dataGrid.ToolBar);
            return this;
        }

        public SEPDataGrid<T> GetDataGrid()
        {
            return dataGrid;
        }

        public DataGridBuilder<T> BuildCellStyle(Style style)
        {
            dataGrid.SetCellStyle(style);
            return this;
        }

        public DataGridBuilder<T> BuildHeaderStyle(Style style)
        {
            dataGrid.SetHeaderStyle(style);
            return this;
        }

     
        public DataGridBuilder<T> BuildAddNewButton( string content, Style buttonStyle = null)
        {
            var button = ControlFactory.BuildButton(content,dataGrid.AddNewButtonClick, buttonStyle);

           dataGrid.ToolBar.Children.Add(button);
            return this;
        }

        public DataGridBuilder<T> BuildUndoButton( string content, Style buttonStyle = null)
        {
            var button = ControlFactory.BuildButton(content, dataGrid.UndoClick, buttonStyle);

            dataGrid.ToolBar.Children.Add(button);
            return this;
        }

        public DataGridBuilder<T> BuildRedoButton(string content, Style buttonStyle = null)
        {
            var button = ControlFactory.BuildButton(content, dataGrid.RedoClick, buttonStyle);

            dataGrid.ToolBar.Children.Add(button);
            return this;
        }
    }
}
