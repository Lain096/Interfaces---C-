using System;
using System.Windows;
using System.Windows.Controls;
using WPF_MVVM_CRUD.ViewModels;
using WPF_MVVM_CRUD.Models;
using System.Windows.Input;

namespace WPF_MVVM_CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatosProductoViewModel datosProductoViewModel = new DatosProductoViewModel();

        Categoria categoria = new Categoria();

        CategoriaCollection obsCategorias = new CategoriaCollection();

        public MainWindow()
        {
            InitializeComponent();

            // Preparación del contexto de la vista
            DataContext = datosProductoViewModel;

            // Utilizado para que aparezca información en la
            // consola de Visual Studio
            System.Diagnostics.Debug.WriteLine("Inicio Aplicación");

            cargarCategorias();

            datosProductoViewModel.limpiar();
            cbCategoria.SelectedIndex = 0;
        }

        private void ComprobarBuscar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (txtCodProducto.Text != "");
        }

        private void EjecutarBuscar(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                btnBuscar.Focus();

                datosProductoViewModel.buscarProducto();

                asignarCategoria(datosProductoViewModel.IdCategoria);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void ComprobarCargarImagen(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void EjecutarCargarImagen(object sender, ExecutedRoutedEventArgs e)
        {
            btnCargarImagen.Focus();
            datosProductoViewModel.CargarImagen();
        }
        private void ComprobarGuardar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (txtCodProducto.Text != "") &&
                           (txtNombre.Text != "") &&
                           (txtDescripcion.Text != "") &&
                           (txtIdCategoria.Text != "0") &&
                           (txtPrecio.Text != "0") &&
                           (txtPrecio.Text != "") &&
                           (txtExistencias.Text != "0")&&
                           (txtExistencias.Text != "");

        }
        private void EjecutarGuardar(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                btnGuardar.Focus();
                datosProductoViewModel.guardarProducto();
                MessageBox.Show("Producto Guardado");
                datosProductoViewModel.limpiar();
                cbCategoria.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }
        private void ComprobarActualizar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (txtCodProducto.Text != "") &&
               (txtNombre.Text != "") &&
               (txtDescripcion.Text != "") &&
               (txtIdCategoria.Text != "0") &&
               (txtPrecio.Text != "0") &&
               (txtPrecio.Text != "") &&
               (txtExistencias.Text != "0") &&
               (txtExistencias.Text != "");
        }
        private void EjecutarActualizar(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                btnActualizar.Focus();
                datosProductoViewModel.actualizarProducto();
                MessageBox.Show("Producto Actualizado");
                datosProductoViewModel.limpiar();
                cbCategoria.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void ComprobarEliminar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (txtCodProducto.Text != "");
        }
        private void EjecutarEliminar(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                btnEliminar.Focus();
                datosProductoViewModel.eliminarProducto();
                MessageBox.Show("Producto Eliminado");
                datosProductoViewModel.limpiar();
                cbCategoria.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void ComprobarLimpiar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void EjecutarLimpiar(object sender, ExecutedRoutedEventArgs e)
        {
            btnLimpiar.Focus();
            datosProductoViewModel.limpiar();
            cbCategoria.SelectedIndex = 0;
        }

       private void cbCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
       {
           ComboBox categorias = (ComboBox)sender;

           if (categorias.SelectedIndex != 0)
           {
                datosProductoViewModel.IdCategoria = 
                    obsCategorias[categorias.SelectedIndex - 1].Id;
               txtIdCategoria.Text = datosProductoViewModel.IdCategoria.ToString();
           }
           else
           {
                datosProductoViewModel.IdCategoria = 0;
               txtIdCategoria.Text = datosProductoViewModel.IdCategoria.ToString();
            }
       }

        private void cargarCategorias()
        {
            // limpiar el combobox
            cbCategoria.Items.Clear();

            obsCategorias = datosProductoViewModel.cargarCategorias();

            if (obsCategorias != null)
            {
                // la primera categoria estará vacia.
                ComboBoxItem nuevaCategoriaVacia = new ComboBoxItem();
                TextBlock contenidoVacio = new TextBlock();
                contenidoVacio.Text = "";
                nuevaCategoriaVacia.Content = contenidoVacio;
                cbCategoria.Items.Add(nuevaCategoriaVacia);

                foreach (var i in obsCategorias)
                {
                    // Añadir las categorias a items del ComboBox
                    ComboBoxItem nuevaCategoria = new ComboBoxItem();
                    TextBlock contenido = new TextBlock();
                    contenido.Text = i.Nombre;
                    nuevaCategoria.Content = contenido;
                    cbCategoria.Items.Add(nuevaCategoria);
                }
            }
            else
            {
                MessageBox.Show("No se encontraron categorías");
            }
        }

        private void asignarCategoria(int idCat)
        {
            // Recorrer el combobox y seleccionar la categoria que coincida con
            // la categoria pasada por parámetro.
            int indice = 1;

            if (obsCategorias != null)
            {

                foreach (var i in obsCategorias)
                {
                    if (i.Id == idCat)
                    {
                        cbCategoria.SelectedIndex = indice;
                    }
                    indice++;
                }
            }
        }
    }
}
