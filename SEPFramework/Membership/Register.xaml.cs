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
using SEPFramework.FactoryMethod;

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
            //Xử lý dữ liệu đăng nhập
            RegisterHandler logInHandler = SignUpFactory.getType("Normal");
            if (logInHandler.Register(this))
            {
                MessageBox.Show("Dang ký thành công");
            }
            else
            {
                MessageBox.Show("Dang ký hất bại");
            }
            
            
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

        public string Email
        {
            get { return txtEmail.Text; }
        }
        public string UserName
        {
            get { return txtUserName.Text; }
        }

        public string Password
        {
            get { return txtPassword.Password; }
        }

        public string ConFirmPassword
        {
            get { return txtConFirmPassword.Password;}
        }
    }
}
