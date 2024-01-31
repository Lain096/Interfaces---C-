using WPF_MVVM_CRUD.Core;
using MySqlConnector;
using System;
using System.Collections.ObjectModel;

namespace WPF_MVVM_CRUD.Models
{
    public class CategoriaCollection : ObservableCollection<Categoria>
    {
        public CategoriaCollection cargarCategorias()
        {
            CategoriaCollection obsCategorias = new CategoriaCollection();

            try
            {
                // Obtener una conexión abierta a la BD
                MySqlConnection conexionBD = Conexion.obtenerConexionAbierta();
                if (conexionBD == null)
                {
                    throw new Exception("Fallo en Conexion a BD");
                }
                else
                {
                    try
                    {
                        // comando a ejecutar en la BD
                        String consulta =
                            "SELECT id, nombre FROM categorias ORDER BY nombre ASC;";

                        using var comando = new MySqlCommand(consulta, conexionBD);

                        // Ejecución del comando
                        using var reader = comando.ExecuteReader();

                        if (reader.HasRows)
                        {
                            // Obtención del cursor con el resultado de una consulta
                            while (reader.Read())
                            {
                                obsCategorias.Add(new Categoria()
                                {
                                    Id = reader.GetInt32(0),
                                    Nombre = reader.GetString(1)
                                });
                            }
                        }
                        return obsCategorias;

                    }
                    catch (InvalidOperationException ex)
                    {
                        throw new Exception("Error al cargar las categorías: " + ex.Message);
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error al buscar categorías: " + ex.Message);
            }
            finally
            {
                // siempre se cierra la conexion
                Conexion.cerrarConexion();
            }
        }
    }

    public class Categoria
    {
        #region propiedades
        
        private int id;
        private string nombre;
        
        #endregion propiedades

        #region metodos
        
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        #endregion metodos
    }
}