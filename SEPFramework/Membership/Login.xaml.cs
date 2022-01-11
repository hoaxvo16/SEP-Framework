using System.Windows;
using System.Windows.Input;
using SEPFramework.Factory;

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
            LogInHandler logInHandler = LogInFactory.getType("Normal");
            logInHandler.Login(this);
            if (logInHandler.IsLogin)
            {
                // Xử lý khi đã đăng nhập thành công
            }
            
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

        public string UserName
        {
            get { return txtUserName.Text; }
        }

        public string Password
        {
            get { return txtPassword.Password; }
        }

        private void lblForgotPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ForgotPassword frm = new ForgotPassword();
            frm.Show();
        }
    }
}
