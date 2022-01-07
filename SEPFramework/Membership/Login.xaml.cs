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

namespace SEPFramework.Membership
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        public void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!AllowLogin())
                return;
            //Xử lý dữ liệu đăng nhập
        }

        private bool AllowLogin()
        {
            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập username", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Password.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập password", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPassword.Focus();
                return false;
            }
            return true;
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void lblRegister_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Register frm = new Register();
            frm.Show();
        }
    }
}
