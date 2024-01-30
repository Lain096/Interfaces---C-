using Proyecto_Joyeria.Core;
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


        public ViewModelUserControl VMControl { get; set; }
		public ViewModelReparationControl VMReparationControl { get; set; }

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
			VMControl = new ViewModelUserControl();
			VMReparationControl = new ViewModelReparationControl();
            VMUsersAdminControl = new ViewModelUsersAdminControl();
            VMReparationsAdminControl = new ViewModelReparationAdminControl();
            //CurrentView = VMControl;

			UserControlCommand = new RelayCommand(o =>
			{
				CurrentView = VMControl;
			} );

			UserReparationCommand = new RelayCommand(o =>
			{
				CurrentView = VMReparationControl;
			});
            AdminUsersControlCommand = new RelayCommand(o => {
                CurrentView = VMUsersAdminControl;

            }

              );

            AdminReparationsControlCommand = new RelayCommand(o =>
            {
                CurrentView = VMReparationsAdminControl;
            });



        }

	}
}
