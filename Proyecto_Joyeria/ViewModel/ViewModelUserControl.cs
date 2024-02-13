using Proyecto_Joyeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_Joyeria.ViewModel
{
    internal class ViewModelUserControl
    {

        public Model_Person cargarUsuario(string name)
        {
            Model_Person p = new Model_Person();
            try
            {
                p = p.buscarPersona(name);
            }catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuario: " + ex.Message);

            }

            return p;

        }

    }
}
