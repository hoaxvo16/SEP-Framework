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
        }

        public FormData<User> FormDataGrid = new FormData<User>();
     
        public MainWindow()
        {
            InitializeComponent();
            //Just init data;
            List<User> users = new List<User>();
            users.Add(new User() { Id = 1, Name = "Hoa", Birthday = new DateTime(1971, 7, 23) });
            users.Add(new User() { Id = 2, Name = "An", Birthday = new DateTime(1974, 1, 17) });
            users.Add(new User() { Id = 3, Name = "Vi", Birthday = new DateTime(1993, 9, 21) });
            users.Add(new User() { Id = 3, Name = "Tan", Birthday = new DateTime(1996, 6, 1) });
            users.Add(new User() { Id = 3, Name = "Duy", Birthday = new DateTime(2001, 12, 13) });
      
            FormDataGrid.BuildData(users).BuildAction("onColDelete",Confirm).Render(stackPanel);
        }

      

        

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            FormDataGrid.RemoveAt(0);
        }
        private void Confirm()
        {
            MessageBox.Show("ok");
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            FormDataGrid.Undo();
        }

        private void TestClick(object sender,RoutedEventArgs e)
        {
            MessageBox.Show("Test");
            FormDataGrid.RemoveIfPropertyEqual("Name", "An");
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            FormDataGrid.Redo();
        }

        private void AddCol_Click(object sender, RoutedEventArgs e)
        {
            FormDataGrid.BuildButtonColumn("Test", "Click vo", TestClick,50);
        }
    }
}
