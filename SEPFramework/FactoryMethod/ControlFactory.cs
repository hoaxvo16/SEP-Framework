using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace SEPFramework
{
    internal class ControlFactory
    {
        public static DataGridTemplateColumn BuilDataGridColButton(string header,string buttonContent,RoutedEventHandler clickEvent,Style buttonStyle)
        {
            DataGridTemplateColumn col = new DataGridTemplateColumn();
           
         
    
            col.Header = header;
            
            FrameworkElementFactory button = new FrameworkElementFactory(typeof(Button));
            button.SetValue(Button.ContentProperty, buttonContent);
            button.AddHandler(Button.ClickEvent, new RoutedEventHandler(clickEvent));
            if(buttonStyle != null)
            {
                button.SetValue(Button.StyleProperty, buttonStyle);
            }
            DataTemplate cellTemplate = new DataTemplate();
            cellTemplate.VisualTree = button;
            col.CellTemplate = cellTemplate;

            return col;
        }



        public static DataGridTemplateColumn BuilDataGridColText(string header, string content, Style textStyle)
        {
            DataGridTemplateColumn col = new DataGridTemplateColumn();

        

            col.Header = header;

            FrameworkElementFactory textBlock = new FrameworkElementFactory(typeof(TextBlock));
            textBlock.Text = content;
            if (textStyle != null)
            {
                textBlock.SetValue(TextBlock.StyleProperty, textStyle);
            }
         
            DataTemplate cellTemplate = new DataTemplate();
            cellTemplate.VisualTree = textBlock;
            col.CellTemplate = cellTemplate;

            return col;
        }

        public static Button BuildButton(string buttonContent,RoutedEventHandler clickEvent,Style buttonStyle)
        {
            var button = new Button();

            button.Content = buttonContent;
            if(buttonStyle != null)
            {
                button.Style = buttonStyle;
            }
            button.Click += clickEvent;

            return button;
        }

        public static StackPanel BuildStackPanel (Style stackPanelStyle)
        {
            var panel = new StackPanel();
            if (stackPanelStyle != null)
            {
                panel.Style = stackPanelStyle;
            }
           
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

        public static DatePicker BuildDatePicker(DateTime selectedDate, EventHandler<SelectionChangedEventArgs> onChange)
        {
            var datePicker = new DatePicker();
            datePicker.SelectedDate = selectedDate;
            datePicker.SelectedDateChanged += onChange;
            return datePicker;
        }

      
    }
}
