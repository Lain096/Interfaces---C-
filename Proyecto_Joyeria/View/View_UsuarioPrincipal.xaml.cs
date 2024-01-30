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
        public View_UsuarioPrincipal()
        {
            InitializeComponent();
           
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

        }
    }
}
