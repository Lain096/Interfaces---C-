using Proyecto_Joyeria.Model;
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

namespace Proyecto_Joyeria.View
{
    /// <summary>
    /// Lógica de interacción para View_FrameUserControl.xaml
    /// </summary>
    public partial class View_FrameUserControl : Page
    {
        private bool btnPass;
        private string pass;
        private Model_Person p;
        public View_FrameUserControl(Model_Person p)
        {
            InitializeComponent();
            this.p = p;
            this.ShowsNavigationUI = false;
            cargarUsuario();
        }

        public void cargarUsuario()
        {
            try
            {
                if (p == null)
                {
                    throw new Exception("No se encontró el usuario");
                }
                else
                {
                    txtMostrarEmail.Text = p.Email;
                    txtMostrarUserName.Text = p.Name;
                    txtMostrarPassword.Text = new string('*', p.Pass.Length);
                    pass = p.Pass;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos del usuario: " + ex.Message);
            }



        }

        private void btnMostrarPassword_Click(object sender, RoutedEventArgs e)
        {
            btnPass = !btnPass;
            if (btnPass)
            {
                txtMostrarPassword.Text = pass;
            }
            else
            {
                txtMostrarPassword.Text = new string('*', pass.Length);
            }
        }

        private void btnModificar(object sender, RoutedEventArgs e)
        {
            View_ModificarUsuario v = new View_ModificarUsuario(p);

            bool? fin = v.ShowDialog();

            if ((bool)fin)
            {
                this.p = View_ModificarUsuario.devolverUsuario();
                cargarUsuario();
                MessageBox.Show("Usuario modificado con exito");
            }


        }
    }
}
