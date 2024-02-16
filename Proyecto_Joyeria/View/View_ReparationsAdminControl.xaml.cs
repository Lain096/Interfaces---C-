using Proyecto_Joyeria.Core;
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
    /// Lógica de interacción para View_ReparationsAdminControl.xaml
    /// </summary>
    public partial class View_ReparationsAdminControl : UserControl
    {
        public View_ReparationsAdminControl()
        {
            InitializeComponent();
            cargarTablaReparaciones();
        }

        public void cargarTablaReparaciones()
        {
            ProductoCollection pc = new ProductoCollection();

            ViewModelReparationAdminControl vm = new ViewModelReparationAdminControl();

            dataGridMostrarProductosAdmin.ItemsSource = null;
            dataGridMostrarProductosAdmin.IsReadOnly = true;

            try
            {
                pc = vm.listaProductos();
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            dataGridMostrarProductosAdmin.ItemsSource = pc;



        }

        private void btnBuscar_Dueño(object sender, RoutedEventArgs e)
        {
            ProductoCollection pc = new ProductoCollection();
            ViewModelReparationAdminControl vm = new ViewModelReparationAdminControl();

            dataGridMostrarProductosAdmin.ItemsSource = null;
            dataGridMostrarProductosAdmin.IsReadOnly = true;
            try
            {

                if(!String.IsNullOrEmpty(txtDueñoBuscar.Text))
                {
                   pc = vm.listaProductosPorNombre(txtDueñoBuscar.Text);
                    dataGridMostrarProductosAdmin.ItemsSource = pc; 
                    
                }
                else
                {
                    cargarTablaReparaciones();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnEliminar_Producto(object sender, RoutedEventArgs e)
        {
            ViewModelReparationAdminControl vm = new ViewModelReparationAdminControl();

            var producto = (Model_Producto)dataGridMostrarProductosAdmin.SelectedItem;
            if (producto != null) { 

                if (producto != null)
                {
                    if (vm.eliminarProducto(producto.IdProducto))
                    {
                        MessageBox.Show("Producto eliminado con éxito");
                        cargarTablaReparaciones();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el producto");
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún producto");
            }

        }

        private void btnGenerar_PDF(object sender, RoutedEventArgs e)
        {
            var producto = (Model_Producto)dataGridMostrarProductosAdmin.SelectedItem;
            ViewModelReparationAdminControl vm = new ViewModelReparationAdminControl();
            if (producto != null)
            {


                if (producto.Estado)
                {
                    Model_Person p = new Model_Person();

                    p = vm.buscarPersona(producto.IdPersona);

                    GeneratePDF pdf = new GeneratePDF();
                    pdf.crearPDF(producto, p);

                }
                else
                {
                    MessageBox.Show("El producto no está reparado");
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún producto");
            }

        }

        private void clickFila(object sender, MouseButtonEventArgs e)
        {
            var producto = (Model_Producto)dataGridMostrarProductosAdmin.SelectedItem;
            View_MostrarProductoAdmin vmp = new View_MostrarProductoAdmin(producto);
            bool? fin=  vmp.ShowDialog();

            if ((bool)fin)
            {
                MessageBox.Show("Cambios confirmados, se ha reparado " + producto.Nombre);
                cargarTablaReparaciones();
            }
            else
            {
                MessageBox.Show("Cambios no confirmados");
            }
        }
    }
}
