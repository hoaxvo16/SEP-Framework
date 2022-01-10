using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.Dynamic;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FrameworkElementFactory panel = new FrameworkElementFactory(typeof(StackPanel));
        public MainWindow()
        {
            InitializeComponent();
            DataGirdTest.IsReadOnly = true;
            List<string> list = new List<string>();
            list.Add("Vo Xuan Hoa");
            list.Add("ABC");
            list.Add("1");
            var row = new DataGridRow();
            row.SetValue(DataGridRow.ItemProperty, list[0]);

            DataGirdTest.MouseDoubleClick += DataGirdTest_MouseDoubleClick;
            for(int i = 0; i < 5; i++)
            {
                var border = new FrameworkElementFactory(typeof(Border));
                border.SetValue(Border.BorderThicknessProperty, new Thickness(1));
                border.SetValue(Border.BorderBrushProperty, (Brush)(new BrushConverter().ConvertFrom("#FF2463AE")));
                 
                var txt = new FrameworkElementFactory(typeof(TextBlock));
                border.AppendChild(txt);
                txt.SetValue(TextBlock.TextProperty, "dasds");
              
                panel.AppendChild(border);
            }
     
        

            DataGirdTest.Columns.Add(BuilDataGridColText("Ho ten", list[0],100));
            DataGirdTest.Items.Add(1);


        }

        private void DataGirdTest_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(DataGirdTest.SelectedValue.ToString());
        }

        public  DataGridTemplateColumn BuilDataGridColText(string header, string content, int width)
        {
            DataGridTemplateColumn col = new DataGridTemplateColumn();

            col.Width = width;

            col.Header = header;

     

            DataTemplate cellTemplate = new DataTemplate();
            cellTemplate.VisualTree = panel;
            col.CellTemplate = cellTemplate;

            return col;

        }
        public class FlexibleObject
        {

        }
    }
}
