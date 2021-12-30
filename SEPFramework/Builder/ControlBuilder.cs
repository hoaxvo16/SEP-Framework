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

        public static Button BuildButton(string buttonContent,RoutedEventHandler clickEvent,int width)
        {
            var button = new Button();

            button.Content = buttonContent;
            button.Width = width;
            button.Click += clickEvent;

            return button;
        }

        public static StackPanel BuildStackPanel ()
        {
            var panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            return panel;
        }

        public static TextBlock BuilldTextBlock(string textBlockContent,  int fontSize)
        {

            var textBlock = new TextBlock();
            textBlock.Text = textBlockContent;
            textBlock.FontSize = fontSize;
            return textBlock;

        }

        public static TextBox BuilldTextBox(string textBoxName, string textBoxContent, int fontSize, TextChangedEventHandler onChange)
        {

            var textBox = new TextBox();
            textBox.Text = textBoxContent;
            textBox.Name = textBoxName;
            textBox.FontSize = fontSize;
            textBox.TextChanged += onChange;
            return textBox;

        }
    }
}
