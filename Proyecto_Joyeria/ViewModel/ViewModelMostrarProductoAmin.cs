using Proyecto_Joyeria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Proyecto_Joyeria.ViewModel
{
    internal class ViewModelMostrarProductoAmin : INotifyPropertyChanged
    {

        #region PROPIEDADES
        private string nombre;
        private string descripcion;
        private string categoria;
        private string modificacion;
        private string terminado;
        private string fechaDeposito;
        private string precio;
        private BitmapImage imagen;

        public string Nombre {
            get { return nombre; }

            set
            {
                nombre = value;
                OnPropertyChanged("Nombre");
            }
        }
        public string Descripcion
        {
            get { return descripcion; }

            set
            {
                descripcion = value;
                OnPropertyChanged("Descripcion");
            }
        }
       
        public string Categoria
        {
            get { return categoria; }

            set
            {
                categoria = value;
                OnPropertyChanged("Categoria");
            }
        }
        
        public string Modificacion
        {
            get { return modificacion; }

            set
            {
                modificacion = value;
                OnPropertyChanged("Modificacion");
            }
        }
        public string Terminado
        {
            get { return terminado; }

            set
            {
                terminado = value;
                OnPropertyChanged("Terminado");
            }
        }
        public string FechaDeposito
        {
            get { return fechaDeposito; }

            set
            {
                fechaDeposito = value;
                OnPropertyChanged("FechaDeposito");
            }
        }
        public string Precio
        {
            get { return precio; }

            set
            {
                precio = value;
                OnPropertyChanged("Precio");
            }
        }
        public BitmapImage Imagen
        {
            get { return imagen; }

            set
            {
                imagen = value;
                OnPropertyChanged("Imagen");
            }
        }
     

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        public bool repararProducto(Model_Producto producto, float precio)
        {

            

            producto.Precio = precio;
            producto.Estado = true;
            producto.Terminado = "Reparado";
       
            producto.FechaRecogida = DateTime.UtcNow.ToLocalTime();

          

            try
            {

                if (producto.actualizarProducto(producto))
                {
                    return true;
                }


            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }

            return false;

        }






    }
}
