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
                CreateConnection.cerrarConexion();
           }
     }


        public PersonaCollection consultarUsuario(string? dato)
        {
            PersonaCollection personaCollection = new PersonaCollection();

            try
            {
                MySqlConnection connection = CreateConnection.obtenerConexionAbierta();

                if (connection == null)
                {
                    throw new Exception("No hay base de datos que consultar");
                }
                else
                {
                    try
                    {
                        string sql = " ";
                        if (dato != null)
                        {
                            sql = "SELECT p.idPersonas, p.user, p.email, r.isAdmin FROM PERSONAS p, PERFIL r " +
                                "WHERE p.idPersonas = r.idPersonas AND (p.idPersonas LIKE @dato OR p.user LIKE @dato OR " +
                                "p.email LIKE @dato)";
                        }
                        else
                        {
                            listaUsuarios();
                        }

                        using var command = new MySqlCommand(sql, connection);
                        command.Parameters.AddWithValue("@dato", "%" + dato + "%");
                        command.Prepare();

                        using var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                personaCollection.Add(new Model_Person() {

                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2),
                                IsAdmin = reader.GetBoolean(3)
                            });

                            }

                        }
                        else
                        {
                            throw new Exception("No se han encontrado usuarios");
                        }

                    }
                    catch (InvalidOperationException e)
                    {
                        throw new Exception("Problemas al buscar usuarios");
                    }
                }
            }catch(MySqlException e)
            {
                throw new Exception("Problemas en todo");
            }

            return personaCollection;
        }
   

        public PersonaCollection comprobarLogIn(string user, string pass)
    {

        MySqlConnection connec = CreateConnection.obtenerConexionAbierta();
        PersonaCollection personaCollection = new PersonaCollection();

        try
        {
            string sql = "SELECT p.idPersonas, p.user, p.pass, p.email , r.isAdmin FROM PERSONAS p, PERFIL r " +
                                    "WHERE p.idPersonas = r.idPersonas AND p.user LIKE @user AND p.pass LIKE @pass";

            using var command = new MySqlCommand(sql, connec);
            command.Parameters.AddWithValue("@user", user);
            command.Parameters.AddWithValue("@pass", pass);

            using var reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    Model_Person p = new Model_Person();

                    while (reader.Read())
                    {
                        p.Id = reader.GetInt32(0);
                        p.Name = reader.GetString(1);
                        p.Pass = reader.GetString(2);
                        p.Email = reader.GetString(3);
                        p.IsAdmin = reader.GetBoolean(4);

                        personaCollection.Add(p);

                    }

                    return personaCollection;
                }
                else
                {
                    return null;
                }
            }
            catch (InvalidOperationException e)
            {
                return null;
            }


        }
        catch (MySqlException e)
        {
            throw new Exception("ERROR al leer usuarios");
            }
            finally
            {
                CreateConnection.cerrarConexion();
            }
        return null;
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


        public bool personaExiste(string name)
        {
            try
            {
                MySqlConnection connection = CreateConnection.obtenerConexionAbierta();


                if (connection == null)
                {
                    throw new Exception("Error en la conexion");
                }
                else
                {
                    try
                    {
                        string sql = "SELECT * FROM PERSONAS WHERE user = @user";

                        using var command = new MySqlCommand(sql, connection);
                        command.Parameters.AddWithValue("@user", name);
                        command.Prepare();

                        using var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {                          
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    catch (MySqlException e)
                    {
                        throw new Exception("Error en la conexion");
                    }
                }

            }catch (Exception e)
            {
                throw new Exception("Error en la conexion");
            }
            finally
            {
                CreateConnection.cerrarConexion();
            }   

            return false;
        }

        public bool insertPersona(Model_Person person)
        {

            MySqlConnection connection = null;
            MySqlTransaction transaction = null;

            try
            {
                
                int? id = ultimoId();
                connection = CreateConnection.obtenerConexionAbierta();
               
                if (connection == null)
                {
                    throw new Exception("No se ha podido establecer conexion");
                }
                else
                {

                    transaction = connection.BeginTransaction();

                    string sql1 = "INSERT INTO PERSONAS (idPersonas, user, pass, email) VALUES (@id, @user, @pass, @email)";
                    MySqlCommand comman1 = new MySqlCommand(sql1, connection, transaction);
                    comman1.Parameters.AddWithValue("@id", id);
                    comman1.Parameters.AddWithValue("@user", person.Name);
                    comman1.Parameters.AddWithValue("@pass", person.Pass);
                    comman1.Parameters.AddWithValue("@email", person.Email);
                    comman1.ExecuteNonQuery();

                    string sql2 = "INSERT INTO PERFIL (idPersonas, isAdmin) VALUES (@id, @isAdmin)";
                    MySqlCommand comman2 = new MySqlCommand(sql2, connection, transaction);
                    comman2.Parameters.AddWithValue("@id", id);
                    comman2.Parameters.AddWithValue("@isAdmin", 0);
                    comman2.ExecuteNonQuery();

                    transaction.Commit();

                    return true;
                }

            }catch(Exception e)
            {
                if (transaction == null)
                {
                    transaction.Rollback();
                }
                throw new Exception("No se ha podido crear el usuario", e);
            }
            finally
            {
                CreateConnection.cerrarConexion();
            }


            return false;

        }

        public bool eliminarPersona(Model_Person person)
        {

            try
            {

                MySqlConnection connect = CreateConnection.obtenerConexionAbierta();
                MySqlTransaction transaction = null;

                if (connect == null)
                {
                    throw new Exception("No se ha podido establecer conexion");
                }
                else
                {

                    try
                    {

                        transaction = connect.BeginTransaction();

                        string sql2 = "DELETE FROM PERFIL WHERE idPersonas = @id";
                        using var command2 = new MySqlCommand(sql2, connect, transaction);
                        command2.Parameters.AddWithValue("@id", person.Id);
                        command2.ExecuteNonQuery();



                        string sql = "DELETE FROM PERSONAS WHERE idPersonas = @id";

                        using var command = new MySqlCommand(sql, connect ,transaction);

                        command.Parameters.AddWithValue("@id", person.Id);   
                  //      command.Prepare();
                        command.ExecuteNonQuery();


                        transaction.Commit();
                        

                        return true;
                                           
                    }
                    catch (MySqlException e)
                    {
                      
                        throw new Exception("No se ha podido eliminar a la persona ya que tiene productos a su cargo");
                    }
                   
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CreateConnection.cerrarConexion();
            }


           
        }

        public Model_Person buscarPersona(int id)
        {
            Model_Person p = new Model_Person();

            try
            {
                MySqlConnection connection = CreateConnection.obtenerConexionAbierta();

                if (connection == null)
                {
                    throw new Exception("Error en la conexion");
                }
                else
                {
                    try
                    {
                        string sql = "SELECT * FROM PERSONAS WHERE idPersonas = @id";

                        using var command = new MySqlCommand(sql, connection);
                        command.Parameters.AddWithValue("@id", id);
                        command.Prepare();

                        using var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                p.Id = reader.GetInt32(0);
                                p.Name = reader.GetString(1);
                                p.Pass = reader.GetString(2);
                                p.Email = reader.GetString(3);
                            }
                        }
                        else
                        {
                            throw new Exception("No se ha encontrado el usuario");
                        }

                    }
                    catch (MySqlException e)
                    {
                        throw new Exception("Error al buscar el usuario");
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error en la conexion");
            }
            finally
            {
                CreateConnection.cerrarConexion();
            }

            return p;
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
                    String sql = "SELECT * FROM PERSONAS ORDER BY idPersonas DESC LIMIT 1";

                    using var command = new MySqlCommand(sql, connection);  
                    command.ExecuteNonQuery();
                    
                    using var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                        return reader.GetInt32(0) +1; 

                        }

                    }
                    else
                    {
                        throw new Exception("No se encontraron Ids");
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


        public int buscarId(string name, MySqlConnection connect)
        {

            string sql = "SELECT idPersonas FROM PERSONAS WHERE user = @user";

            MySqlCommand command = new MySqlCommand(sql, connect);
            command.Parameters.AddWithValue("@user", name);
            command.Prepare();


            using var reader = command.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                throw new Exception("Error al buscar el id");
            }

            return -1;
        }
        

        public bool modificarUsuario(Model_Person p)
        {
            try
            {
                MySqlConnection connection = CreateConnection.obtenerConexionAbierta();

                if (connection == null)
                {
                    throw new Exception("Error en la conexion");
                }
                else
                {
                    try
                    {
                        string sql = "UPDATE PERSONAS SET user = @user, email = @email, pass = @pass WHERE idPersonas = @id";
                        MySqlCommand command = new MySqlCommand(sql, connection);
                        command.Parameters.AddWithValue("@user", p.Name);
                        command.Parameters.AddWithValue("@email", p.Email);
                        command.Parameters.AddWithValue("@pass", p.Pass);
                        command.Parameters.AddWithValue("@id", p.Id);
                        command.ExecuteNonQuery();

                        return true;
                    }
                    catch (MySqlException e)
                    {
                        throw new Exception("Error al modificar usuario");
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("ERROR FATAL");
            }
            finally
            {
                CreateConnection.cerrarConexion();
            }

            return false;
        }
    
    }
}

