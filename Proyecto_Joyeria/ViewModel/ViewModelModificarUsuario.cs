using Proyecto_Joyeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Joyeria.ViewModel
{
    internal class ViewModelModificarUsuario
    {

        public bool modificarUsuario(Model_Person p)
        {
            try
            {
                if (p.modificarUsuario(p))
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }


            return false;
        }

    }
}
