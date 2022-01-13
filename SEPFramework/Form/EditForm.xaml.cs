using System;
using System.Collections.Generic;
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
    /// Interaction logic for EditForm.xaml
    /// </summary>
    public partial class EditForm : Window
    {

        private object editData = null;

        private Action<object> finishAction;
        public EditForm()
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
                    BuilDatePicker(textBoxName,(DateTime)textBoxValue);
                }
                else
                {
                    BuildTextBox(textBoxName, textBoxValue.ToString());
                }
            }
           

            this.Show();
        }

        private void BuildTextBox(string textBoxName, string texBoxDefaultValue)
        {
            TextBlock textBlock = ControlFactory.BuilldTextBlock(textBoxName, 16);
            textBlock.Margin = new Thickness(0, 20, 0, 0);
            TextBox textBox = ControlFactory.BuilldTextBox(textBoxName, texBoxDefaultValue, 16, TextBox_TextChanged);
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(textBox);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
            
        {
            try
            {
                var txtBox = sender as TextBox;

                string name = txtBox.Name;
                var value = txtBox.Text;

                var propertyValue = this.editData.GetType().GetProperty(name).GetValue(this.editData, null);

                //Handle each type ....hmmmmm
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
            catch (Exception ex)
            {

            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            finishAction(editData);
            this.Close();
        }

        private void BuilDatePicker(string datePickerName,DateTime initDate)
        {
            
            TextBlock textBlock = ControlFactory.BuilldTextBlock(datePickerName, 16);
            textBlock.Margin = new Thickness(0, 20, 0, 0);
            var datePicker = ControlFactory.BuildDatePicker(initDate, DatePicker_SelectedDateChanged);
            datePicker.Name = datePickerName;
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(datePicker);
        }

        private  void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
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
