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
    class ViewModelReparacionesUsuarios : INotifyPropertyChanged

    {
        #region Propiedades
        private int idProducto;
        private string nombre;
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


        #endregion


        public Model_Person devolverPersona(string name)
        {
            Model_Person p = new Model_Person();

            return p.buscarPersona(name);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ProductoCollection listaProductosUsuario(int idCliente)
        {
           
            ProductoCollection pc = new ProductoCollection();

            pc = pc.listaProductoCliente(idCliente);

            return pc;
        }

        public ProductoCollection buscarProducto(string dato, int idCliente)
        {
            ProductoCollection pc = new ProductoCollection();

            pc = pc.buscarProductos(dato, idCliente);

            return pc;
        }

    }
}
