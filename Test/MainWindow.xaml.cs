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

        public FormData<User> FormDataGird = new FormData<User>();
     
        public MainWindow()
        {
            InitializeComponent();
            //Just init data;
            List<User> users = new List<User>();
            users.Add(new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            users.Add(new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            users.Add(new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });
            users.Add(new User() { Id = 3, Name = "Sammy Doe1", Birthday = new DateTime(1991, 9, 2) });
            users.Add(new User() { Id = 3, Name = "Sammy Doe2", Birthday = new DateTime(1991, 9, 2) });
            users.Add(new User() { Id = 3, Name = "Sammy Doe3", Birthday = new DateTime(1991, 9, 2) });
            FormDataGird.BuildData(users).Render(stackPanel);
        }

      

        

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            FormDataGird.RemoveAt(0);
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            FormDataGird.Undo();
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            FormDataGird.Redo();
        }
    }
}
