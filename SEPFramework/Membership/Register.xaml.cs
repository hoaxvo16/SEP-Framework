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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckInputControl())
            {
                return;
            }
            MessageBox.Show("Dang ký thành công");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool CheckInputControl()
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
            if (txtConFirmPassword.Password.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập confirm password", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtConFirmPassword.Focus();
                return false;
            }
            if (txtPassword.Password != txtConFirmPassword.Password)
            {
                MessageBox.Show("Confirm password không giống password", "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        private void lblLogin_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();

        }
    }
}
