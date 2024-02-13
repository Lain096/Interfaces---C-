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
    /// Lógica de interacción para View_CrearCuenta.xaml
    /// </summary>
    public partial class View_CrearCuenta : Window
    {
        public View_CrearCuenta()
        {
            InitializeComponent();
        }

        private void btnCrear_Cuenta(object sender, RoutedEventArgs e)
        {
            string nombre = txtCrearUserName.Text;
            string email = txtCrearEmail.Text;
            string pass1 = txtCrearPass1.Password;
            string pass2 = txtCrearPass2.Password;

            if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(pass1) || String.IsNullOrEmpty(pass2))
            {
                MessageBox.Show("Por favor llene todos los campos");
            }
            else
            {
                if (pass1 == pass2)
                {
                    ViewModelCrearCuenta vm = new ViewModelCrearCuenta();
                    try
                    {
                        if (vm.comprobarUsuario(nombre))
                        {
                            if (vm.insertarUsuario(nombre,email, pass1))
                            {
                                
                                DialogResult =true;
                                Close();
                        
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }   
            }


        }

        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Click_Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

       
    }
}
