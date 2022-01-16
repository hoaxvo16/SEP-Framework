using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SEPFramework.Membership;
namespace Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //add some bootstrap or startup logic 
            var identity = true;
            if (identity == true)
            {
                ShowLogin();
            }
            else
            {
                ShowMainWindow();
            }
        }

        private void ShowLogin()
        {
            Login login = new Login();
            login.Closing += Login_Closing;
            login.Show();
        }

        private void ShowMainWindow()
        {
            MainWindow mainView = new MainWindow();
            mainView.Show();
            mainView.Closing += MainView_Closing;
        }

        private void MainView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CheckCloseWindow())
            {
                ShowLogin();
            }
            else
            {
                // Closed some other way.
            }            
        }

        private void Login_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CheckCloseWindow())
            {
                ShowMainWindow();
            }
            else
            {
                // Closed some other way.
            }
            
        }

        private bool CheckCloseWindow()
        {
            return new StackTrace().GetFrames().FirstOrDefault(x => x.GetMethod() == typeof(Window).GetMethod("Close")) != null;
        }
    }
}
