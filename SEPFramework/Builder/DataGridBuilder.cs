﻿using SEPFramework.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SEPFramework.Builder
{
    public class DataGridBuilder<T> : IDataBuilder<T>, IStyleBuilder<T>,IActionBuilder<T>,IControlBuilder<T>
    {
        private  SEPDataGrid<T> dataGrid;

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

            DataGridTemplateColumn col = ControlBuilder.BuilDataGridColButton(colHeader, buttonContent, clickEvent,buttonStyle);
            dataGrid.AddColumn(col);
           
            return this;
        }

        public DataGridBuilder<T> BuildDefaultButton(Style buttonStyle)
        {
            BuildButtonColumn("Delete", "Delete", dataGrid.DeleteItemClick, buttonStyle);
            BuildButtonColumn("Edit", "Edit", dataGrid.EditButtonClick, buttonStyle);
            return this;
        }

        public DataGridBuilder<T> BuildTopPanel(Panel container,Style panelStyl=null, Style buttonStyle=null)
        {
            var panel = ControlBuilder.BuildStackPanel();
            var addButton = ControlBuilder.BuildButton("Add new", dataGrid.AddNewButtonClick, buttonStyle);
            var undoButton = ControlBuilder.BuildButton("Undo", dataGrid.UndoClick, buttonStyle);
            var redoButton = ControlBuilder.BuildButton("Redo", dataGrid.RedoClick, buttonStyle);
            panel.Children.Add(addButton);
            panel.Children.Add(undoButton);
            panel.Children.Add(redoButton);
            container.Children.Add(panel);
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

   
    }
}
