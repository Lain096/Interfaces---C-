using MySqlConnector;
using Proyecto_Joyeria.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Joyeria.Model
{
    public class Model_Producto
    {
        private int idProducto;
        private string nombre;
        private string informacion;
        private bool estado;
        private int idPersona;
        private string nombrePersona;
        private int idCategoria;
        private string nombreCategoria;
        private DateTime fechaDeposito;
        private float precio;
        private string terminado;
        private string modificacion;
        private DateTime fechaRecogida;
        private byte[]? imagen;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Informacion { get => informacion; set => informacion = value; }
        public bool Estado { get => estado; set => estado = value; }
        public int IdPersona { get => idPersona; set => idPersona = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public DateTime FechaDeposito { get => fechaDeposito; set => fechaDeposito = value; }
        public float Precio { get => precio; set => precio = value; }
        public string Modificacion { get => modificacion; set => modificacion = value; }
        public DateTime FechaRecogida { get => fechaRecogida; set => fechaRecogida = value; }
        public byte[]? Imagen { get => imagen; set => imagen = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }
        public string Terminado { get => terminado; set => terminado = value; }
        public string NombrePersona { get => nombrePersona; set => nombrePersona = value; }

        public bool eliminarProducto(int id)
        {
            try
            {
                MySqlConnection conn = CreateConnection.obtenerConexionAbierta();



                if (conn == null)
                {
                    throw new Exception("Error al intentar establecer conexion con la base de datos");
                }
                else
                {

                    string sql = "DELETE FROM PRODUCTO WHERE idProducto = @id";

                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                    return true;

                }

            }
            catch (Exception e)
            {
                throw new Exception("ERROR");
            }


            return false;
        }

        public bool actualizarProducto(Model_Producto mp)
        {
            try
            {
                MySqlConnection conn = CreateConnection.obtenerConexionAbierta();

                if (conn == null)
                {
                    throw new Exception("No se ha podido conectar a la base de datos ");
                }
                else
                {

                    string sql = "UPDATE PRODUCTO SET estado = @estado, precio = @precio, fecharecogida = @fecha WHERE idProducto = @id";

                    MySqlCommand command = new MySqlCommand(sql, conn); 
                    command.Parameters.AddWithValue("@estado", 1);
                    command.Parameters.AddWithValue("@precio", mp.Precio);
                    command.Parameters.AddWithValue("@fecha", mp.FechaRecogida);
                    command.Parameters.AddWithValue("@id", mp.IdProducto);

                    command.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }      
        }

        public Model_Producto buscarProducto(int id)
        {
            Model_Producto model_Producto = new Model_Producto();

            try
            {
                MySqlConnection conn = CreateConnection.obtenerConexionAbierta();

                if (conn == null)
                {
                    throw new Exception("No se pudo conectar a la base de datos");
                }
                else
                {
                   string sql=  "SELECT p.idProducto, p.nombre, p.informacion, p.estado, p.idPersonas,p.idTipo, t.nombre, p.fechaDeposito, p.precio, p.modificacion, p.fecharecogida, p.imagen FROM producto p, tipo_producto t WHERE p.idTipo = t.idTipo";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@dato", "%" + id + "%");

                    using var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model_Producto.IdProducto = reader.GetInt32(0);
                            model_Producto.Nombre = reader.GetString(1);
                            model_Producto.Informacion = reader.GetString(2);
                            model_Producto.Estado = reader.GetBoolean(3);
                            model_Producto.IdPersona = reader.GetInt32(4);
                            model_Producto.IdCategoria = reader.GetInt32(5);
                            model_Producto.NombreCategoria = reader.GetString(6);
                            model_Producto.FechaDeposito = reader.GetDateTime(7);
                            model_Producto.Precio = reader.GetFloat(8);
                            model_Producto.Modificacion = reader.GetString(9);
                            model_Producto.FechaRecogida = reader.GetDateTime(10);
                            model_Producto.Imagen = (byte[])reader.GetValue(11);


                        }
                    }

                    return model_Producto;

                }

            }
            catch (Exception e)
            {
                throw new Exception("ERROR");
            }

            return null;
            //}







        }


        public bool insertarProducto(Model_Producto mp, int idCliente, int idTipo)
        {
            try
            {
                MySqlConnection conn = CreateConnection.obtenerConexionAbierta();

                if (conn == null)
                {
                    throw new Exception("No se pudo abrir la base de datos Model_Product");
                }
                else
                {

                    string sql = "INSERT INTO PRODUCTO (nombre, informacion, estado, idPersonas, idTipo, fechaDeposito, modificacion, imagen) VALUES(@nombre, @informacion, @estado, @idPersonas, @idTipo, @fechaDeposito, @modificacion, @imagen)";

                    MySqlCommand command = new MySqlCommand(sql, conn); 
                    command.Parameters.AddWithValue("@nombre", mp.Nombre);
                    command.Parameters.AddWithValue("@informacion", mp.Informacion);
                    command.Parameters.AddWithValue("@estado", 0);
                    command.Parameters.AddWithValue("@idPersonas", idCliente);
                    command.Parameters.AddWithValue("@idTipo", idTipo);
                    command.Parameters.AddWithValue("@fechaDeposito", mp.FechaDeposito);
                    command.Parameters.AddWithValue("@modificacion", mp.Modificacion);
                    command.Parameters.AddWithValue("@imagen", mp.Imagen);

                    command.ExecuteNonQuery();
                    return true;

                }
                


            }
            catch (Exception e)
            {
                throw new Exception("Error con la base de datos de Model_Product");
            }
            finally
            {
                CreateConnection.cerrarConexion();
                
            }

            
        }

        public class ProductoCollection : ObservableCollection<Model_Producto>
        {

            public ProductoCollection listaProductos()
            {

                ProductoCollection productoCollection = new ProductoCollection();
                try
                {
                    MySqlConnection conn = CreateConnection.obtenerConexionAbierta();

                    if (conn == null)
                    {
                        throw new Exception("No se pudo conectar a la base de datos");
                    }
                    else
                    {
                        try
                        {
                            string sql = "SELECT p.idProducto, p.nombre, p.informacion, p.estado, p.idPersonas,p.idTipo, t.nombre, p.fechaDeposito, p.precio, p.modificacion, p.fecharecogida, p.imagen, ps.user   FROM producto p, tipo_producto t, personas ps WHERE p.idTipo = t.idTipo AND ps.idPersonas = p.idPersonas";

                            MySqlCommand command = new MySqlCommand(sql, conn);
                            

                            using var reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Model_Producto model_Producto = new Model_Producto();
                                    model_Producto.IdProducto = reader.GetInt32(0);
                                    model_Producto.Nombre = reader.GetString(1);
                                    model_Producto.Informacion = reader.GetString(2);
                                    model_Producto.Estado = reader.GetBoolean(3);
                                    model_Producto.IdPersona = reader.GetInt32(4);
                                    model_Producto.IdCategoria = reader.GetInt32(5);
                                    model_Producto.NombreCategoria = reader.GetString(6);
                                    model_Producto.FechaDeposito = reader.GetDateTime(7);
                                    if (!reader.IsDBNull(8))
                                    {

                                    model_Producto.Precio = reader.GetFloat(8);
                                    }
                                    model_Producto.Modificacion = reader.GetString(9);
                                    // model_Producto.FechaRecogida = reader.GetDateTime(10);

                                    if (!reader.IsDBNull(11))
                                    {
                                    model_Producto.Imagen = (byte[])reader.GetValue(11);

                                    }
                                    model_Producto.NombrePersona = reader.GetString(12);

                                    if (model_Producto.Estado)
                                    {
                                        model_Producto.Terminado = "Reparado";
                                    }
                                    else
                                    {
                                           model_Producto.Terminado = "En Reparacion";
                                    }

                                    productoCollection.Add(model_Producto);
                                }
                            }
                            else
                            {
                                throw new Exception("No se encontraron productos");
                            }
                        }
                        catch (InvalidOperationException e)
                        {
                            throw new Exception("Problemas al buscar los productos");
                        }

                        return productoCollection;

                    }

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }


            public ProductoCollection buscarProductos(string dato, int idCliente)
            {

                ProductoCollection productoCollection = new ProductoCollection();
                try
                {
                    MySqlConnection conn = CreateConnection.obtenerConexionAbierta();

                    if (conn == null)
                    {
                        throw new Exception("No se pudo conectar a la base de datos");
                    }
                    else
                    {
                        try
                        {
                            // string sql = "SELECT * FROM producto WHERE nombre LIKE @dato OR informacion LIKE @dato OR modificacion LIKE @dato";
                            string sql = "SELECT p.idProducto, p.nombre, p.informacion, p.estado, p.idPersonas, p.idTipo, t.nombre, p.fechaDeposito, p.precio, p.modificacion, p.fecharecogida, p.imagen FROM producto p, tipo_producto t WHERE p.idTipo = t.idTipo AND p.idPersonas = @id AND (p.nombre LIKE @dato OR p.informacion LIKE @dato OR p.modificacion LIKE @dato)";
                            MySqlCommand command = new MySqlCommand(sql, conn);
                            command.Parameters.AddWithValue("@dato", "%" + dato + "%");
                            command.Parameters.AddWithValue("@id", idCliente);

                            using var reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Model_Producto model_Producto = new Model_Producto();
                                    model_Producto.IdProducto = reader.GetInt32(0);
                                    model_Producto.Nombre = reader.GetString(1);
                                    model_Producto.Informacion = reader.GetString(2);
                                    model_Producto.Estado = reader.GetBoolean(3);
                                    model_Producto.IdPersona = reader.GetInt32(4);
                                    model_Producto.IdCategoria = reader.GetInt32(5);
                                    model_Producto.NombreCategoria = reader.GetString(6);
                                    model_Producto.FechaDeposito = reader.GetDateTime(7);
                                    if (!reader.IsDBNull(8))
                                    {
                                    model_Producto.Precio = reader.GetFloat(8);

                                    }

                                    model_Producto.Modificacion = reader.GetString(9);
                                    // model_Producto.FechaRecogida = reader.GetDateTime(10);

                                    if (!reader.IsDBNull(11))
                                    {
                                        model_Producto.Imagen = (byte[])reader.GetValue(11);
                                    }
                                    if (model_Producto.Estado)
                                    {
                                        model_Producto.Terminado = "Reparado";
                                    }
                                    else
                                    {
                                        model_Producto.Terminado = "En Reparacion";
                                    }


                                    productoCollection.Add(model_Producto);
                                }
                            }
                            else
                            {
                                throw new Exception("No se encontraron productos");
                            }
                        }
                        catch (InvalidOperationException e)
                        {
                            throw new Exception("Problemas al buscar los productos");
                        }

                        return productoCollection;

                    }

                }
                catch (Exception e)
                {
                    throw new Exception("ERROR");
                }
            }


            public ProductoCollection listaProductoCliente(int idCliente)
            {

                ProductoCollection productoCollection = new ProductoCollection();

                try
                {
                    MySqlConnection conn = CreateConnection.obtenerConexionAbierta();


                    if(conn == null)
                    {
                        throw new Exception("Error al intentar acceder a la base de datos");
                    }
                    else
                    {

                        string sql = "SELECT p.idProducto, p.nombre, p.informacion, p.estado, p.idPersonas, p.idTipo, t.nombre, p.fechaDeposito, p.precio, p.modificacion, p.fechaRecogida, p.imagen FROM producto p, tipo_producto t WHERE p.idTipo = t.idTipo AND p.idPersonas = @idCliente";

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue("@idCliente", idCliente);
                        try
                        {

                            using var reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Model_Producto mp = new Model_Producto();

                                    mp.IdProducto = reader.GetInt32(0);
                                       mp.Nombre = reader.GetString(1);
                                        mp.Informacion = reader.GetString(2);
                                        mp.Estado = reader.GetBoolean(3);
                                        mp.IdPersona = reader.GetInt32(4);
                                        mp.IdCategoria = reader.GetInt32(5);
                                        mp.NombreCategoria = reader.GetString(6);
                                        mp.FechaDeposito = reader.GetDateTime(7);
                                    if (!reader.IsDBNull(8))
                                    {
                                        mp.Precio = reader.GetFloat(8);
                                    }
                                        
                                        mp.Modificacion = reader.GetString(9);

                                    if (!reader.IsDBNull(11))
                                    {

                                    mp.Imagen = (byte[])reader.GetValue(11);
                                    }



                                    if (mp.Estado)
                                    {
                                        mp.Terminado = "Reparado";
                                    }
                                    else
                                    {
                                        mp.Terminado = "En Reparacion";
                                    }

                                    productoCollection.Add(mp);

                                }
                            }

                            return productoCollection;


                        }
                        catch (InvalidOperationException e)
                        {
                            throw new Exception("Error al intentar buscar los productos");    
                        }
                       



                    }


                }catch(Exception e){
                    throw new Exception("ERROR FATAL" + e.Message);

                }


            }

            public ProductoCollection buscarProductoDueño(string dueño)
            {

                ProductoCollection productoCollection = new ProductoCollection();

                try
                {
                    MySqlConnection conn = CreateConnection.obtenerConexionAbierta();


                    if (conn == null)
                    {
                        throw new Exception("Error al intentar acceder a la base de datos");
                    }
                    else
                    {

                        string sql = "SELECT p.idProducto, p.nombre, p.informacion, p.estado, p.idPersonas, p.idTipo, t.nombre, p.fechaDeposito, p.precio, p.modificacion, p.fechaRecogida, p.imagen, ps.user FROM producto p, tipo_producto t, personas ps WHERE p.idTipo = t.idTipo AND p.idPersonas = ps.idPersonas AND ps.user LIKE @dueño";

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue("@dueño", "%" + dueño + "%");
                        try
                        {

                            using var reader = command.ExecuteReader();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Model_Producto mp = new Model_Producto();

                                    mp.IdProducto = reader.GetInt32(0);
                                    mp.Nombre = reader.GetString(1);
                                    mp.Informacion = reader.GetString(2);
                                    mp.Estado = reader.GetBoolean(3);
                                    mp.IdPersona = reader.GetInt32(4);
                                    mp.IdCategoria = reader.GetInt32(5);
                                    mp.NombreCategoria = reader.GetString(6);
                                    mp.FechaDeposito = reader.GetDateTime(7);
                                    if (!reader.IsDBNull(8))
                                    {
                                        mp.Precio = reader.GetFloat(8);
                                    }

                                    mp.Modificacion = reader.GetString(9);

                                    if (!reader.IsDBNull(11))
                                    {

                                        mp.Imagen = (byte[])reader.GetValue(11);
                                    }



                                    if (mp.Estado)
                                    {
                                        mp.Terminado = "Reparado";
                                    }
                                    else
                                    {
                                        mp.Terminado = "En Reparacion";
                                    }

                                    mp.NombrePersona = reader.GetString(12);

                                    productoCollection.Add(mp);

                                }
                            }

                            return productoCollection;


                        }
                        catch (InvalidOperationException e)
                        {
                            throw new Exception("Error al intentar buscar los productos");
                        }




                    }


                }
                catch (Exception e)
                {
                    throw new Exception("ERROR FATAL" + e.Message);

                }


            }


        }
    }
}
