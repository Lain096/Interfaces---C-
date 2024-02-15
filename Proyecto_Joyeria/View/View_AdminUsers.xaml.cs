using Proyecto_Joyeria.Model;
using Proyecto_Joyeria.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Proyecto_Joyeria.View
{
    /// <summary>
    /// Lógica de interacción para View_AdminUsers.xaml
    /// </summary>
    public partial class View_AdminUsers : UserControl
    {
        List<Object> users = new List<Object>();
        public View_AdminUsers()
        {
            InitializeComponent();
            cargarTablaUsuarios();
        }

        private void cargarTablaUsuarios()
        {

            PersonaCollection pc = new PersonaCollection();
            ViewModelUsersAdminControl vm = new ViewModelUsersAdminControl();
          

            dataGridAdmin.ItemsSource = null;
            dataGridAdmin.IsReadOnly = true;
            try
            {
                pc = vm.cargarUsuarios();

            }
            catch (Exception e)
            {
                MessageBox.Show("No se han podido mostrar los datos");
            }
            dataGridAdmin.ItemsSource = pc;


        }

        private void btnBuscar_Usuario(object sender, RoutedEventArgs e)
        {
            try
            {
                string? dato = txtNombreBuscar.Text;

                if (!String.IsNullOrEmpty(dato))
                {

                    PersonaCollection pc = new PersonaCollection();
                    ViewModelUsersAdminControl vm = new ViewModelUsersAdminControl();
                    dataGridAdmin.ItemsSource = null;
                    dataGridAdmin.IsReadOnly = true;

                    try
                    {
                        pc = vm.buscarUsuario(dato);

                        dataGridAdmin.ItemsSource = pc;
                    }
                    catch (Exception)
                    {
                        throw new Exception("No existe un usuario con esos datos");
                    }

                }
                else
                {
                    cargarTablaUsuarios();
                }
            }
            catch (Exception ex)
            {
                
            }


        }

        private void btnEliminar_Usuario(object sender, RoutedEventArgs e)
        {

            ViewModelUsersAdminControl vm = new ViewModelUsersAdminControl();
            var mp = (Model_Person)dataGridAdmin.SelectedItem;

            if (mp != null)
            {

                vm.eliminarPersona(mp);
                cargarTablaUsuarios();
            }
        }
    }
    
 }

