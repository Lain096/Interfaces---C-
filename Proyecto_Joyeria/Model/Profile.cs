using System.Collections.ObjectModel;
using MySqlConnector;
using Proyecto_Joyeria.Core;
using System;


namespace Proyecto_Joyeria.Model
{
    class Profile
    {
        private int _id;
        private bool _isAdmin;

        public int Id { get => _id; set => _id = value; }
        public bool IsAdmin { get => _isAdmin; set => _isAdmin = value; }
    }

    class ProfileCollection : ObservableCollection<Profile>
    {
    

        public ProfileCollection uploadProfile() {

           
            ProfileCollection pc = new ProfileCollection();

            try
            {
                MySqlConnection profileConnection = CreateConnection.obtenerConexionAbierta();

                if (profileConnection == null)
                {
                    throw new Exception("Conexión a la base de datos no establecida");
                }
                else
                {

                    using var reader = getReader(profileConnection);

                    if (reader.HasRows) {

                        while (reader.Read())
                        {
                            Profile profile = new Profile();

                            profile.IsAdmin = reader.GetBoolean("isAdmin");
                            profile.Id = reader.GetInt32("idPersonas");

                            pc.Add(profile);
                        }
                    }
                    else
                    {
                        throw new Exception("No hay filas que leer");
                    }

                }

            }catch (MySqlException ex)
            {
                throw new Exception("ERROR: " + ex.Message);
            }

            return pc;


        }


        public MySqlDataReader getReader(MySqlConnection con)
        {
            // Esta clase solamente va a tener una consulta, que es comprobar si el usuari oes un administrador o no.

            string sql = "SELECT * FROM PERFIL";

            using var command= new MySqlCommand(sql, con); 
       
            command.Prepare();

            // ejecución del comando

            return command.ExecuteReader();
        }


    }
    
}
