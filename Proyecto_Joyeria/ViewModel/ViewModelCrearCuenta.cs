using Proyecto_Joyeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Joyeria.ViewModel
{
    internal class ViewModelCrearCuenta
    {

        public bool comprobarUsuario(string nombre)
        {
            Model_Person mp = new Model_Person();
            try
            {
                if (mp.personaExiste(nombre)) { 
                    throw new Exception("El usuario ya existe");
                }
                else
                {
                    return true;
                }

              
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return false;
        }




        public bool insertarUsuario(string nombre, string email, string pass)
        {

            Model_Person mp = new Model_Person()
            {
                Name = nombre,
                Email = email,  
                Pass = pass
            };

            try
            {
                if (mp.insertPersona(mp))
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return false;


        }
    }
}
