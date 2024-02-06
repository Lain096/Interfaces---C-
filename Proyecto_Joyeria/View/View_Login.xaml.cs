using Proyecto_Joyeria.View;
using Proyecto_Joyeria.ViewModel;
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

namespace Proyecto_Joyeria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Click_Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CLick_CheckUser(object sender, RoutedEventArgs e)
        {
            string user = txtID.Text;
            string pass = txtPass.ToString();

           ViewModelLogIn vmlog = new ViewModelLogIn();

            if (vmlog.isAdminOrUser(user, pass))
            {
             View_AdminPrincipal admin = new View_AdminPrincipal();   
                        admin.Show();
            }
            else
            {
                View_UsuarioPrincipal windowUser = new View_UsuarioPrincipal();
                windowUser.Show();
            }

          

        }

        private void Click_CreateUser(object sender, RoutedEventArgs e)
        {

        }
    }
}
