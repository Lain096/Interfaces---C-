using Proyecto_Joyeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Joyeria.ViewModel
{
    internal class ViewModelUsuarioPrincipal
    {

        public Model_Person devolverPersona(string name)
        {
            Model_Person p = new Model_Person();
            try
            {
                p = p.buscarPersona(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar usuario: " + ex.Message);

            }

            return p;
        }
    }
}
