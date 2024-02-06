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
            DataTable dt = new DataTable();


            //dt.Columns.Add("idPersonas");
            //dt.Columns.Add("Nombre");
            //dt.Columns.Add("Email");
            //dt.Columns.Add("isAdmin");


            //dataGridAdmin.Columns.Add(new DataGridTextColumn { Header = "Id", Width = 50 });
            //dataGridAdmin.Columns.Add(new DataGridTextColumn { Header = "Usuario", Width = 150 });
            //dataGridAdmin.Columns.Add(new DataGridTextColumn { Header = "Email", Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            //dataGridAdmin.Columns.Add(new DataGridTextColumn { Header = "Admin", Width = 100 });

            //dataGridAdmin.Columns.Add(new DataGridTextColumn { Header = "Id", Width = 50, Binding = new Binding("Id") });
            //dataGridAdmin.Columns.Add(new DataGridTextColumn { Header = "Usuario", Width = 150, Binding = new Binding("Name") });
            //dataGridAdmin.Columns.Add(new DataGridTextColumn { Header = "Correo Electrónico", Width = new DataGridLength(1, DataGridLengthUnitType.Star), Binding = new Binding("Email") });
            //dataGridAdmin.Columns.Add(new DataGridTextColumn { Header = "Admin", Width = 100, Binding = new Binding("IsAdmin") });

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



            //foreach (Model_Person p in pc)
            //{

            //    //DataRow row = dt.NewRow();

            //    //row["Id"] = p.Id;
            //    //row["Nombre"] = p.Name;
            //    //row["Email"] = p.Email;
            //    //row["Admin"] = p.IsAdmin;
            //    //dt.Rows.Add(row);


            //    dt.Rows.Add
            //    (
            //        p.Id,
            //        p.Name,
            //        p.Email,
            //        p.IsAdmin
            //     );



            //}
            dataGridAdmin.ItemsSource =pc;


        }
    }
}
