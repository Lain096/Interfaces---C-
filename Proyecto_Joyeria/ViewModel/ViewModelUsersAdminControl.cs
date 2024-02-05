using Proyecto_Joyeria.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_Joyeria.ViewModel
{
    public class ViewModelUsersAdminControl : INotifyPropertyChanged
    {
       

        private string id;
        private string name;
        private string email;
        private bool isAdmin;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public Boolean IsAdmin
        {
            get { return isAdmin; }
            set
            {
                isAdmin = value;
                OnPropertyChanged("IsAdmin");
            }
        }

        public void buscarPersona(string name)
        {
           Model_Person mp = new Model_Person();

            mp = mp.buscarPersona(name);

            if (mp != null)
            {
                Id = mp.Id.ToString();
                Name = mp.Name;
                Email = mp.Email;
                IsAdmin = mp.IsAdmin;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public void eliminarPersona(string name)
        {
            Model_Person mp = new Model_Person();
           
            mp = mp.buscarPersona(name);

            if (!mp.IsAdmin)
            {
                if (mp.eliminarPersona(mp))
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("No se ha podido eliminar al usuario " + mp.Name, "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("No puede eliminar a un administrador", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        public PersonaCollection cargarUsuarios()
        {
              PersonaCollection collection = new PersonaCollection();
              collection = collection.listaUsuarios();
                
            return collection;
        }


   
    
    
    }
}
