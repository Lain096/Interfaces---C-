using Proyecto_Joyeria.Core;
using Proyecto_Joyeria.Model;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Joyeria.ViewModel
{
    internal class ViewModelChanges : ObservableObject
    {
        public RelayCommand UserControlCommand { get; set; }
        public RelayCommand UserReparationCommand { get; set; }
        public RelayCommand AdminUsersControlCommand { get; set; }
        public RelayCommand AdminReparationsControlCommand { get; }


        public ViewModelUsersAdminControl VMUsersAdminControl { get; set; }
        public ViewModelReparationAdminControl VMReparationsAdminControl { get; set; }
		private Model_Person personaSeleccionada;


      

		private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set 
			{ 
				_currentView = value; 
				OnPropertyChanged();
			}
		}
		public ViewModelChanges()
		{
			
            VMUsersAdminControl = new ViewModelUsersAdminControl();
            VMReparationsAdminControl = new ViewModelReparationAdminControl();
            //CurrentView = VMControl;

		
            AdminUsersControlCommand = new RelayCommand(o => {
                CurrentView = VMUsersAdminControl;

            }

              );

            AdminReparationsControlCommand = new RelayCommand(o =>
            {
                CurrentView = VMReparationsAdminControl;
            });



        }

		public Model_Person PersonaSeleccionada
		{
            get { return personaSeleccionada; }
            set
			{
                personaSeleccionada = value;
                OnPropertyChanged(nameof(personaSeleccionada));
            }
        }


	}
}
