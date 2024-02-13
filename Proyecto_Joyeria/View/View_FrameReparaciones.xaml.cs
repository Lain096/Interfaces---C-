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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Proyecto_Joyeria.Model.Model_Producto;

namespace Proyecto_Joyeria.View
{
    /// <summary>
    /// Lógica de interacción para View_FrameReparaciones.xaml
    /// </summary>
    public partial class View_FrameReparaciones : Page
    {
        Model_Person p;

        public View_FrameReparaciones(Model_Person mp)
        {
            InitializeComponent();

            p = mp;
            cargarTablaReparaciones();
            
        }


        public Model_Person devolverPersona(string name)
        {
            ViewModelReparacionesUsuarios p = new ViewModelReparacionesUsuarios();

           
            return p.devolverPersona(name);
        }

        public void cargarTablaReparaciones()
        {
            ProductoCollection pc = new ProductoCollection();
            ViewModelReparacionesUsuarios vm = new ViewModelReparacionesUsuarios();


            dataGridMostrarProductosUsuarios.ItemsSource = null;
            dataGridMostrarProductosUsuarios.IsReadOnly = true;
            try
            {
                pc = vm.listaProductosUsuario(p.Id);
            }
            catch (Exception e)
            {
                MessageBox.Show("No se han podido mostrar los datos");
            }

            dataGridMostrarProductosUsuarios.ItemsSource = pc;


        }

        private void clickFila(object sender, MouseButtonEventArgs e)
        {
            var producto = (Model_Producto)dataGridMostrarProductosUsuarios.SelectedItem;

            View_MostrarProductoUsuario vmp = new View_MostrarProductoUsuario(producto);
            vmp.ShowDialog();


        }

        private void buscarProducto(object sender, RoutedEventArgs e)
        {
            string? dato = txtBuscarProducto.Text;
            if (!String.IsNullOrEmpty(dato))
            {

                ProductoCollection pc = new ProductoCollection();
                ViewModelReparacionesUsuarios vm = new ViewModelReparacionesUsuarios();
                dataGridMostrarProductosUsuarios.ItemsSource = null;
                dataGridMostrarProductosUsuarios.IsReadOnly = true;
                try
                {
                    pc = vm.buscarProducto(dato, p.Id);
                    dataGridMostrarProductosUsuarios.ItemsSource = pc;

                }catch(Exception een)
                {

                   throw new Exception("No se han podido mostrar los datos" + een.Message);
                }



            }
            else
            {
                cargarTablaReparaciones();
            }
        }

        private void btnAñadirProducto(object sender, RoutedEventArgs e)
        {
            View_AñadirProductoUser vmp = new View_AñadirProductoUser(p);

             bool? fin = vmp.ShowDialog();

            if ((bool)fin)
            {
                MessageBox.Show("El producto se ha añadido correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                cargarTablaReparaciones();
            }
            else
            {
                MessageBox.Show("Cancelado", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
