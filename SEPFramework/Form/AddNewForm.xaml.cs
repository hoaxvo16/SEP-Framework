using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SEPFramework
{
    /// <summary>
    /// Interaction logic for AddNewForm.xaml
    /// </summary>
    public partial class AddNewForm : Window
    {

        private object editData = null;

        private Action<object> finishAction;
        public AddNewForm()
        {
            InitializeComponent();
        }

        public void Init(object a, Action<object> finish)
        {
            editData = Utility.CloneObject(a);
            finishAction = finish;
            var properties = a.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                string textBoxName = properties[i].ToString().Split(' ')[1];
                var textBoxValue = properties[i].GetValue(a);
                if (textBoxValue.GetType() == typeof(DateTime))
                {
                    BuilDatePicker(textBoxName);
                }
                else
                {
                    BuildTextBox(textBoxName);
                }

            }

            this.Show();
        }

        private void BuildTextBox(string textBoxName)
        {
            TextBlock textBlock = ControlBuilder.BuilldTextBlock(textBoxName, 16);
            textBlock.Margin = new Thickness(0, 20, 0, 0);
            TextBox textBox = ControlBuilder.BuilldTextBox(textBoxName, "", 16, TextBox_TextChanged);
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(textBox);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txtBox = sender as TextBox;

            string name = txtBox.Name;
            var value = txtBox.Text;

            var propertyValue = this.editData.GetType().GetProperty(name).GetValue(this.editData, null);
            if (propertyValue.GetType() == typeof(string))
            {
                this.editData.GetType().GetProperty(name).SetValue(this.editData, value);
            }
            else if (propertyValue.GetType() == typeof(int))
            {
                this.editData.GetType().GetProperty(name).SetValue(this.editData, int.Parse(value));
            }
            else
            {
                this.editData.GetType().GetProperty(name).SetValue(this.editData, Utility.ConvertToDouble(value));
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            finishAction(editData);
            this.Close();

        }

        private void BuilDatePicker(string datePickerName)
        {

            TextBlock textBlock = ControlBuilder.BuilldTextBlock(datePickerName, 16);
            textBlock.Margin = new Thickness(0, 20, 0, 0);
            var datePicker = ControlBuilder.BuildDatePicker(DateTime.Now, DatePicker_SelectedDateChanged);
            datePicker.Name = datePickerName;
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(datePicker);
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var datePicker = (DatePicker)sender;
            try
            {
                this.editData.GetType().GetProperty(datePicker.Name).SetValue(this.editData, datePicker.SelectedDate);
            }
            catch
            {

            }
        }
    }
}
