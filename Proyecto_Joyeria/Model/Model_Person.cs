using MySqlConnector;
using Proyecto_Joyeria.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace Proyecto_Joyeria.Model
{
    public class PersonaCollection : ObservableCollection<Model_Person>
    {

        public PersonaCollection listaUsuarios()
        {

            PersonaCollection personaCollection = new PersonaCollection();
            MySqlConnection connection = CreateConnection.obtenerConexionAbierta();

            try
            {

                if (connection == null)
                {
                    throw new Exception("Error en la conexion, no se ha podido establecer");
                }
                else
                {
                    try
                    {
                        string sql = "SELECT p.idPersonas, p.user, p.email, r.isAdmin FROM PERSONAS p, PERFIL r WHERE p.idPersonas = r.idPersonas";

                        using var command = new MySqlCommand(sql, connection);
                         var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                personaCollection.Add(new Model_Person()
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Email = reader.GetString(2),
                                    IsAdmin = reader.GetBoolean(3)
                                }
                                    );


                            }

                        }
                        return personaCollection;




                    }
                    catch (MySqlException e)
                    {
                        throw new Exception("Error al ejecutar la consulta");
                    }
                }

            }
            catch (InvalidOperationException e)
            {
                throw new Exception("Error en la base de datos: " + e.Message);
            }
            finally
            {
                connection.Close();
           }
     }

   }



    public class Model_Person
    {
        private int id;
        private string name;
        private string pass;
        private string email;
        private bool isAdmin;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Pass { get =>pass; set => pass = value; }
        public string Email { get => email; set => email = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }

        public Model_Person buscarPersona(string name)
        {

            Model_Person mp = new Model_Person();

            if (mp != null)
            {
                try
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
                            string sql = "SELECT * FROM PERSONAS WHERE user = @user LIMIT 1";

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
                                throw new Exception("No se encontraron usuarios");
                            }

                        }
                        catch (InvalidOperationException ex)
                        {
                            throw new Exception("Error de conexion " + ex.Message);
                        }
                    }
                }
                catch (MySqlException e)
                {
                    throw new Exception("No se pudo buscar en la base de datos");
                }
                finally
                {
                    CreateConnection.cerrarConexion();
                }

                return mp;

            }
            return null;
        } 

        public bool insertPersona(Model_Person person)
        {

            bool insertada = false;

            try
            {

              //  if (person.Id !=)
               // {

               // }

                // CAmpso de las personas
                






            }catch(Exception e)
            {
                throw new Exception("error en la base de datos");
            }


            return false;

        }

        public bool eliminarPersona(Model_Person person)
        {
            bool encontrado = false;
            try
            {

                MySqlConnection connect = CreateConnection.obtenerConexionAbierta();

                if (connect == null)
                {
                    throw new Exception("No se ha podido establecer conexion");
                }
                else
                {

                    try
                    {
                        string sql = " DELETE FROM PERSONA WHERE IdPersona = @id";

                        using var command = new MySqlCommand(sql, connect);

                        command.Parameters.AddWithValue("@id", person.Id);   
                        command.Prepare();


                        command.ExecuteNonQuery();

                        encontrado = true;
                        return encontrado;
                                           
                    }
                    catch (MySqlException e)
                    {
                        throw new Exception("No se ha podido eliminar a la persona");
                    }
                    


                }



            }
            catch (Exception e)
            {
                throw new Exception("ERROR");
            }
            finally
            {
                CreateConnection.cerrarConexion();
            }


            return false;
        }

        #region buscarId
        public int? ultimoId()
        {

           
            
            try
            {
                MySqlConnection connection = CreateConnection.obtenerConexionAbierta();

                if (connection == null)
                {
                    throw new Exception("Fallo en conexion de BdD");
                }
                else
                {
                    String sql = "SELECT * FROM PERSONAS ORDER BY IdPersonas DESC LIMIT 1";

                    using var command = new MySqlCommand(sql, connection);  
                    command.ExecuteNonQuery();

                    using var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                        return reader.GetInt32(0); 

                        }

                    }
                    else
                    {
                        throw new Exception("No se encontraro Id's");
                    }
                    

                }

            }catch(Exception e)
            {
                throw new Exception("No hay empleados");
            }
            finally
            {
                
                CreateConnection.cerrarConexion();

            }
            return null;

        }

        #endregion buscarId

    }
}
