using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace SEPFramework
{
    internal class ControlBuilder
    {
        public static DataGridTemplateColumn BuilDataGridColButton(string header,string buttonContent,RoutedEventHandler clickEvent,int width)
        {
            DataGridTemplateColumn col = new DataGridTemplateColumn();
            col.Width = width;
    
            col.Header = header;
            
            FrameworkElementFactory button = new FrameworkElementFactory(typeof(Button));
            button.SetValue(Button.ContentProperty, buttonContent);
            button.AddHandler(Button.ClickEvent, new RoutedEventHandler(clickEvent));
            DataTemplate cellTemplate = new DataTemplate();
            cellTemplate.VisualTree = button;
            col.CellTemplate = cellTemplate;

            return col;
        }



        public static void BuilDataGridColText()
        {

        }
    }
}
