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
    /// Lógica de interacción para View_MostrarProductoAdmin.xaml
    /// </summary>
    public partial class View_MostrarProductoAdmin : Window
    {

        ViewModelMostrarProductoAmin vmmpa = new ViewModelMostrarProductoAmin();
        Model_Producto mp;
        public View_MostrarProductoAdmin(Model_Producto p)
        {
            InitializeComponent();
            this.mp = p;

            

            if (p.Estado)
            {
                txtReparado.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                txtReparado.Foreground = new SolidColorBrush(Colors.Red);
            }

            DataContext = p;
        }

        private void btnInformacionRegresar(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void btnReparado(object sender, RoutedEventArgs e)
        {

            float costo;
            if (!mp.Estado)
            {
                if (float.TryParse(informacionPrecio.Text, out costo))
                {
                   if(vmmpa.repararProducto(mp, costo))
                    {

                    DialogResult = true;
                    this.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("El producto ya ha sido reparado");
            }
        }

        private void infoPrecio(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(informacionPrecio.ToString()))
            {
                informacionPrecio.IsReadOnly = true;
                informacionPrecio.Text = mp.Precio.ToString();
            }
        }
    }
}
