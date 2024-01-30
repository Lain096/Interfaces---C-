using MySqlConnector;
using Proyecto_Joyeria.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace Proyecto_Joyeria.Model
{
    public class Model_Person
    {
        private int _id;
        private string _name;
        private string _pass;
        private string _email;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Pass { get => _pass; set => _pass = value; }
        public string Email { get => _email; set => _email = value; }



        public Model_Person buscarPersona(string name)
        {

            Model_Person mp = new Model_Person();

            if (mp != null)
            {


                MySqlConnection conn = CreateConnection.obtenerConexionAbierta();


                if (conn == null)
                {
                    throw new Exception("Error en la conexión de la base de datos");
                }
                else
                {
                    try
                    {
                        string sql = "SELECT * FROM PERSONAS WHERE user = @user";

                        using var command = new MySqlCommand(sql, conn);    
                        command.Parameters.AddWithValue("@user", name);
                        command.Prepare();

                        using var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                mp.Id = reader.GetInt32(0);
                                mp.Name = reader.GetString(1);
                                mp.Pass = reader.GetString(2);
                                mp.Email = reader.GetString(3);
                            }


                        }
                        else
                        {
                            throw new 
                        }







                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception("Error de conexion " + ex.Message);
                    }
                }




            }




            return null;
        }
    }
}
