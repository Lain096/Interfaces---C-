using Proyecto_Joyeria.Model;
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
using System.Windows.Shapes;


namespace Proyecto_Joyeria.View
{
    /// <summary>
    /// Lógica de interacción para View_UsuarioPrincipal.xaml
    /// </summary>
    public partial class View_UsuarioPrincipal : Window
    {
        string nombre;
        Model_Person mp;
        public View_UsuarioPrincipal(Model_Person p)
        {
            InitializeComponent();
            mp = p;
            nombre = p.Name;
           
        }

        private void crlPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_CloseButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_MinimizeButton(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnMostrarCuenta(object sender, RoutedEventArgs e)
        {
         
            ViewModelUsuarioPrincipal p = new ViewModelUsuarioPrincipal();
            //Model_Person mp = p.devolverPersona(nombre);        

           // frameUserPrincipal.NavigationService.Navigate(new View_FrameUserControl(mp));
            frameUserPrincipal.Navigate(new View_FrameUserControl(mp));
        }

        private void btnMostrarReparaciones(object sender, RoutedEventArgs e)
        {
            frameUserPrincipal.Navigate(new View_FrameReparaciones(mp));
           // frameUserPrincipal.NavigationService.Navigate(new View_FrameReparaciones(nombre));
        }

        private void btnLogOut(object sender, RoutedEventArgs e)
        {
            MainWindow v = new MainWindow();
            v.Show();
            this.Close();
        }
    }
}
