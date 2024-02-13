using Proyecto_Joyeria.Model;
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
    /// Lógica de interacción para View_ModificarUsuario.xaml
    /// </summary>
    public partial class View_ModificarUsuario : Window
    {

        static Model_Person mp;
        public View_ModificarUsuario(Model_Person p)
        {
            InitializeComponent();

            mp = p;
        }

        private void btnAceptarModificaciones(object sender, RoutedEventArgs e)
        {
            ViewModelModificarUsuario vm = new ViewModelModificarUsuario();

            string pass1 = txtModificarPass1.Password;
            string pass2 = txtModificarPass2.Password;

            if (pass1.Equals(pass2))
            {
                mp.Name = txtModificarUsername.Text;
                mp.Email = txtModificarEmail.Text;
                mp.Pass = pass1;

                if (vm.modificarUsuario(mp))
                {
                    DialogResult = true;
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }       

        }

        public static Model_Person devolverUsuario()
        {
            return mp;
        }
    }

}
