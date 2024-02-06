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
                }

                if (mp.IsAdmin)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }



            return false;
        }

      
    }
}
