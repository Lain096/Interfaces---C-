using Proyecto_Joyeria.Core;
using Proyecto_Joyeria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Media.Imaging;

namespace Proyecto_Joyeria.ViewModel
{
    class ViewModelAñadirProducto : INotifyPropertyChanged
    {

        private BitmapImage? image;

        public BitmapImage? Image
        {
            get { return image; }

            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public ComboBox cargarComboBox(ComboBox cb)
        {

            

            TipoProductoCollection tpc = new TipoProductoCollection();

            try
            {

               tpc = tpc.listaTipos();

                foreach (Model_TipoProducto tp in tpc)
                {
                    ComboBoxItem cbi = new ComboBoxItem();
                    TextBlock tb = new TextBlock();
                    tb.Text = tp.NombreTipoProducto;

                    cbi.Content = tb;

                    cb.Items.Add(cbi);
                }

                return cb;
            }
            catch (Exception e)
            {
                throw new Exception("Error al cargar la lista de tipos");
            }




            return null;

        }


        public bool insertarProductos(Model_Producto mp, int idCliente, string nombreCategoria)
        {
            Model_TipoProducto mtp = new Model_TipoProducto();
            int idTipoProducto = mtp.getIdTipoProducto(nombreCategoria);


            if (idTipoProducto == -1)
            {
                System.Windows.MessageBox.Show("Error al obtener el id del tipo de producto");
            }
            else
            {

                Model_Producto mp2 = new Model_Producto();

                if (mp2.insertarProducto(mp, mp.IdPersona, idTipoProducto))
                {
                    return true;
                }
                
            }

            return false;
        }

        public BitmapImage? cargarImagen(Model_Producto pp)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Seleccionar imagen";
            openFileDialog.Filter = "Imagenes| *.jpg; *.jpeg; *.png; *.gif";
            openFileDialog.InitialDirectory =
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
          
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                Image = new BitmapImage(fileUri);

                if (Image != null)
                {
                    pp.Imagen = Utils.ConvertBitmapImageToByteArray(Image);
                }

                return Image;
            }
            else
            {
                return null;
            }
        }
    }
}
