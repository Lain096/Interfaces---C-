using Proyecto_Joyeria.Core;
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
using System.Windows.Shapes;

namespace Proyecto_Joyeria.View
{
    /// <summary>
    /// Lógica de interacción para View_MostrarProductoUsuario.xaml
    /// </summary>
    public partial class View_MostrarProductoUsuario : Window
    {
        private Model_Producto mp;
        public View_MostrarProductoUsuario(Model_Producto p)
        {
            InitializeComponent();
            this.mp = p;
            cargarProducto();
        }

     public void cargarProducto()
        {
            informacionNombre.Text = mp.Nombre;
            informacionInformacion.Text = mp.Informacion;
            informacionModificacion.Text = mp.Modificacion;
            informacionFechaDeposito.Text = mp.FechaDeposito.ToString();
            informacionImagen.Source = Utils.ConvertByteArrayToBitmapImage(mp.Imagen);
        }

        private void btnInformacionRegresar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
