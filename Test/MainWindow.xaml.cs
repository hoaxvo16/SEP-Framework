using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SEPFramework;
using SEPFramework.Builder;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class User
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public DateTime Birthday { get; set; }
            public string Address { get; set; }

            public double GPA { get; set; }
        }

        public class Product {
            public int Id { get; set; }

            public string Name { get; set; }

           public int Price { get; set; }   
        }

        public class InheritDataGrid<User>: SEPDataGrid<User>
        {
            public override void FinishAddNew(object newData)
            {
                MessageBox.Show("sdfsdf");
            }

        }

        public InheritDataGrid<User> dataGrid = new InheritDataGrid<User>();

        public MainWindow()
        {
            InitializeComponent();
            //Just init data;
            List<User> users = new List<User>();
            List<Product> products = new List<Product>();
            List<object> data = new List<object>();
            
            data.Add(new Product { Price = 1000, Name = "Product1" });
            data.Add(new Product { Price = 2000, Name = "Product2" });
        
            users.Add(new User() { Id = 1, Name = "Hoa", Birthday = new DateTime(1971, 7, 23), Address = "HCM",GPA= 9.6 });
            users.Add(new User() { Id = 2, Name = "An", Birthday = new DateTime(1974, 1, 17), Address = "DN",GPA=8.5 });
            users.Add(new User() { Id = 3, Name = "Vi", Birthday = new DateTime(1993, 9, 21), Address = "Hue", GPA = 8.8 });
            users.Add(new User() { Id = 4, Name = "Tan", Birthday = new DateTime(1996, 6, 1), Address = "HN", GPA = 9.5 });
            users.Add(new User() { Id = 5, Name = "Duy", Birthday = new DateTime(2001, 12, 13), Address = "CM", GPA = 7.5 });

            DataGridBuilder<User> builder = new DataGridBuilder<User>();

            builder.BuildFor(dataGrid).BuildData(users).BuildToolBar(stackPanel).BuildDeleteButton("Xoa", "Xoa").BuildAddNewButton("Them moi");
          
           
            dataGrid.Render(stackPanel);
           
        }





        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Confirm(object[] result)
        {
            User temp = (User)result[0];
            MessageBox.Show(temp.Name);
            
        }

        private void OnRowEdit(object[] result)
        {
            User temp = (User)result[0];
            MessageBox.Show(temp.Name);
        }


        private void TestClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
            dataGrid.RemoveIfPropertyEqual("Name", "An");
        }


        private void AddCol_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
