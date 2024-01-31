using System;
using System.Collections.Generic;
using System.Data;
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
using WPF_MVVM_CRUD.Models;
using WPF_MVVM_CRUD.ViewModels;

namespace WPF_MVVM_CRUD.Views
{
    /// <summary>
    /// Lógica de interacción para dgProducto.xaml
    /// </summary>
    public partial class dgProducto : Window
    {
        List<Object> lista = new List<Object>();

        public dgProducto()
        {
            InitializeComponent();
            cargarTabla(null);
            limpiar();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string dato = txtCampo.Text;
            cargarTabla(dato);
        }
        private void cargarTabla(string dato)
        {
            ProductoCollection lista = new ProductoCollection();
            DatosProductoViewModel  ctrlProductos = new DatosProductoViewModel();
            DataTable dt = new DataTable();
            dt.Columns.Add("Código");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Descripción");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Existencias");

            dataGrid1.ItemsSource = null;

            try
            {
                lista = ctrlProductos.cargarProductos(dato);
            }
            catch (Exception ex)
            {
                dataGrid1.ItemsSource = dt.DefaultView;

                if (MessageBox.Show(ex.Message) == MessageBoxResult.OK)
                {
                    txtCampo.Text = "";
                }
            }

            foreach (Producto producto in lista)
            {
                dt.Rows.Add(producto.Codigo,
                            producto.Nombre,
                            producto.Descripcion,
                            producto.Precio,
                            producto.Existencias
                            );
            }
            dataGrid1.ItemsSource = dt.DefaultView;

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = new Producto();
            producto.Codigo = txtCodigo.Text;
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Precio = Decimal.Parse(txtPrecio.Text);
            producto.Existencias = Int32.Parse(txtExistencias.Text);

            //verificamos si existe el producto.
            //Si no existe, se guarda el producto, y si existe,
            //se modifica el producto.

            try
            {
                if (!producto.existeProducto(producto.Codigo))
                {
                    producto.guardarProducto(producto);
                    MessageBox.Show("Producto Guardado");
                    limpiar();
                    cargarTabla(null);
                }
                else
                {
                    // si existe el producto
                    producto.actualizarProducto(producto);
                    MessageBox.Show("Producto Actualizado");
                    limpiar();
                    cargarTabla(null);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView filaSeleccionada = dataGrid1.SelectedItem as DataRowView;
            if (filaSeleccionada != null)
            {
                txtCodigo.Text = filaSeleccionada.Row.ItemArray[0].ToString();
                txtNombre.Text = filaSeleccionada.Row.ItemArray[1].ToString();
                txtDescripcion.Text = filaSeleccionada.Row.ItemArray[2].ToString();
                txtPrecio.Text = filaSeleccionada.Row.ItemArray[3].ToString();
                txtExistencias.Text = filaSeleccionada.Row.ItemArray[4].ToString();
            }
            else
            {
                MessageBox.Show("Seleccionar un producto");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView filaSeleccionada = dataGrid1.SelectedItem as DataRowView;
            if (filaSeleccionada != null)
            {
                Producto producto = new Producto();
                producto.Codigo = filaSeleccionada.Row.ItemArray[0].ToString();

                MessageBoxResult resultado =
                    MessageBox.Show("¿Seguro que desea eliminar el Producto: "
                    + producto.Codigo + "?", "Eliminación Producto",
                    MessageBoxButton.YesNoCancel);

                if (resultado == MessageBoxResult.Yes)
                {
                    try
                    {
                        producto.eliminarProducto(producto);
                        MessageBox.Show("Producto Eliminado");
                        cargarTabla(null);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Error: " + exc.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccionar un producto");
            }
        }

        private void limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "0";
            txtExistencias.Text = "0";
        }

    }
}
