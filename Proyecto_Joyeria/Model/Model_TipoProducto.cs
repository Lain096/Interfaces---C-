using MySqlConnector;
using Proyecto_Joyeria.Core;
using System;
using System.Collections.ObjectModel;

namespace Proyecto_Joyeria.Model
{
    public class Model_TipoProducto
    {

        private int idTipoProducto;
        private string nombreTipoProducto;

        public int IdTipoProducto { get => idTipoProducto; set => idTipoProducto = value; }
        public string NombreTipoProducto { get => nombreTipoProducto; set => nombreTipoProducto = value; }



        public int getIdTipoProducto(string nombre)
        {
            try
            {
                MySqlConnection conn = CreateConnection.obtenerConexionAbierta();

                if (conn == null)
                {
                    throw new Exception("No se pudo abrir la base de datos tipo_producto");
                }
                else
                {
                    string sql = "SELECT idTipo FROM tipo_producto WHERE nombre = @nombre";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    try
                    {
                        using var reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return reader.GetInt32(0);
                            }
                        }
                        else
                        {
                            throw new Exception("No hay categorias disponibles");
                        }
                    }
                    catch (InvalidOperationException e)
                    {
                        throw new Exception("Error al ejecutar el reader en TIpo_Porducto");
                    }

                    return -1;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error en la base de datos de Tipo_Producto");
            }
            finally
            {
                CreateConnection.cerrarConexion();
            }


        }
    }


    public class TipoProductoCollection : ObservableCollection<Model_TipoProducto>
    {


        public TipoProductoCollection listaTipos()
        {

            TipoProductoCollection tpc = new TipoProductoCollection();
            try
            {
                MySqlConnection conn = CreateConnection.obtenerConexionAbierta();

                if (conn == null)
                {
                    throw new Exception("No se pudo abrir la base de datos");
                }
                else
                {
                    string sql = "SELECT * FROM tipo_producto";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);


                    try
                    {
                        using var reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {


                            while (reader.Read())
                            {
                                Model_TipoProducto tp = new Model_TipoProducto();
                                tp.NombreTipoProducto = reader.GetString(0);
                                tp.IdTipoProducto = reader.GetInt32(1);
                                tpc.Add(tp);
                            }
                        }
                        else
                        {
                            throw new Exception("No hay categorias disponibles");
                        }

                        return tpc;
                    }
                    catch (InvalidOperationException e)
                    {
                        throw new Exception("Error al ejecutar el reader");
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("ERROR en la base de datos");
            }



            return null;



        }
    }
}
