using SEPFramework.Builder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SEPFramework.Interface
{
    public interface IControlBuilder<T>
    {
        public DataGridBuilder<T> BuildButtonColumn(string colHeader, string buttonContent, RoutedEventHandler clickEvent, Style buttonStyle = null);

        public DataGridBuilder<T> BuildDeleteButton(string header,string content,Style buttonStyle = null);

        public DataGridBuilder<T> BuildEditButton(string header,string content,Style buttonStyle = null);

        public DataGridBuilder<T> BuildToolBar(Panel container, Style panelStyle = null);

        public DataGridBuilder<T> BuildAddNewButton(string content,Style buttonStyle = null);   

        public DataGridBuilder<T> BuildUndoButton(string content,Style buttonStyle = null);
        public DataGridBuilder<T> BuildRedoButton(string content, Style buttonStyle = null);


    }
}
