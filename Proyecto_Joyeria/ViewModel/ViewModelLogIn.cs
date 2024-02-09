using Proyecto_Joyeria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_Joyeria.ViewModel
{
   public class ViewModelLogIn
    {
       

        public bool isAdminOrUser(string name, string pass)
        {


            PersonaCollection personaCollection = new PersonaCollection();

            personaCollection = personaCollection.comprobarLogIn(name, pass);


            if (personaCollection != null && personaCollection.Count == 1)
            {
                Model_Person mp = new Model_Person();

                foreach (Model_Person p in personaCollection)
                {
                    mp = p;


                    if (p.IsAdmin)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            else
            {

         
                    throw new Exception("No se ha encotnrado a la persona en la base de datos datos");
                
            }

            throw new Exception("ERROR");

        }

      
    }
}
