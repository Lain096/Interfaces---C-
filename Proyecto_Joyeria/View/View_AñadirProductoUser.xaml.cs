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
    /// Lógica de interacción para View_AñadirProductoUser.xaml
    /// </summary>
    public partial class View_AñadirProductoUser : Window
    {

        ViewModelAñadirProducto vmap;
        Model_Person pp;
        Model_Producto mp;
        public View_AñadirProductoUser(Model_Person p)
        {
            InitializeComponent();
            this.pp = p;
            vmap = new ViewModelAñadirProducto();
            mp = new Model_Producto();
            cargarComboBox();


        }

        private void btnAñadirProducto(object sender, RoutedEventArgs e)
        {

            if (comprobarCampos())
            {
                
                mp.Nombre = añadirNombreProducto.Text;
                mp.FechaDeposito = DateTime.Now;
                mp.Modificacion = añadirModificacionProducto.Text;
                mp.Informacion = añadirInformacionProducto.Text;
                mp.Estado = false;
                mp.IdPersona = pp.Id;
                string nombreCategoria = cbAñadirTipoProducto.Text;  
               

                if (vmap.insertarProductos(mp, mp.IdPersona, nombreCategoria))
                {
                    DialogResult = true;
                    this.Close();
                }

            }
            else { 
                MessageBox.Show("Por favor, rellena todos los campos");
            }



        }

        public bool comprobarCampos()
        {
            if (String.IsNullOrEmpty(añadirNombreProducto.Text) || String.IsNullOrEmpty(añadirInformacionProducto.Text) || String.IsNullOrEmpty(añadirModificacionProducto.Text))
            {
                MessageBox.Show("El campo de nombre no puede estar vacio");
                return false;
            }
            return true;
        }


        private void cargarComboBox()
        {
            ViewModelAñadirProducto vmap = new ViewModelAñadirProducto();
            cbAñadirTipoProducto = vmap.cargarComboBox(cbAñadirTipoProducto);
            cbAñadirTipoProducto.SelectedIndex = 0;
        }

        private void btnRegresar(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnAñadirImagen(object sender, RoutedEventArgs e)
        {
            btnBuscarImagen.Focus();
            añadirImagenProducto.Source=  vmap.cargarImagen(mp);
        }
    }
}
