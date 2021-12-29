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
                string textBoxValue = properties[i].GetValue(a).ToString();

                BuildTextBox(textBoxName, textBoxValue);
            }

            this.Show();
        }

        private void BuildTextBox(string textBoxName, string texBoxDefaultValue)
        {
            var textBlock = new TextBlock();
            textBlock.FontSize = 16;
            textBlock.Margin = new Thickness(0, 10, 0, 0);
            textBlock.Text = textBoxName;
            var textBox = new TextBox();
            textBox.FontSize = 16;
            textBox.TextChanged += TextBox_TextChanged;
            textBox.Name = textBoxName;
            textBox.Text = texBoxDefaultValue;
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(textBox);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
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
            else
            {

                if (propertyValue.GetType() == typeof(int))
                {
                    this.editData.GetType().GetProperty(name).SetValue(this.editData, int.Parse(value));
                }

                if (propertyValue.GetType() == typeof(DateTime))
                {
                    try
                    {
                        this.editData.GetType().GetProperty(name).SetValue(this.editData, DateTime.Parse(value));
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            finishAction(editData);
            this.Close();
        }
    }
}
