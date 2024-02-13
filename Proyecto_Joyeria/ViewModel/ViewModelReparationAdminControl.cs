using Proyecto_Joyeria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Proyecto_Joyeria.Model.Model_Producto;

namespace Proyecto_Joyeria.ViewModel
{
    class ViewModelReparationAdminControl : INotifyPropertyChanged
    {
        #region Propiedades
        private int idProducto;
        private string nombre;
        private string nombrePersona;
        private DateTime fechaDeposito;
        private bool estado;
        private string terminado;

        public int IdProducto
        {
            get { return idProducto; }
            set
            {
                idProducto = value;
                OnPropertyChanged("IdProducto");
            }
        }


        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged("Nombre");
            }
        }
        public DateTime FechaDeposito
        {
            get { return fechaDeposito; }
            set
            {
                fechaDeposito = value;
                OnPropertyChanged("FechaDeposito");
            }
        }
        public bool Estado
        {
            get { return estado; }
            set
            {
                estado = value;
                OnPropertyChanged("Estado");

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

        public string NombrePersona
        {
            get { return nombrePersona; }
            set
            {
                nombrePersona = value;
                OnPropertyChanged("NombreDueño");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public ProductoCollection listaProductos()
        {
            ProductoCollection pc = new ProductoCollection();

            pc = pc.listaProductos();

            return pc;


        }

        public ProductoCollection listaProductosPorNombre(string text)
        {
            ProductoCollection  pc = new ProductoCollection();

            return pc.buscarProductoDueño(text);
        }


        public bool eliminarProducto(int id)
        {
            Model_Producto p = new Model_Producto();
            if (p.eliminarProducto(id))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}
