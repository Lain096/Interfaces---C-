using WPF_MVVM_CRUD.Core;
using MySqlConnector;
using System;
using System.Collections.ObjectModel;

namespace WPF_MVVM_CRUD.Models
{
    public class ProductoCollection : ObservableCollection<Producto>
    {
        public ProductoCollection consultar(String dato)
        {

            ProductoCollection lista = new ProductoCollection();

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
                        String consulta = "";

                        if (dato != null)
                        {
                            // comando a ejecutar en la BD
                            consulta =
                            "SELECT p.idProducto AS IdProducto, " +
                                 "p.codigoProducto AS Código, " +
                                 "p.nombre AS Nombre, p.descripcion AS Descripción, " +
                                 "p.precio AS Precio, " +
                                 "p.existencias AS Existencias " +
                                 "FROM productos p " +
                                 "WHERE p.codigoProducto LIKE @dato OR " +
                                 "p.nombre LIKE @dato OR " +
                                 "p.descripcion LIKE @dato " +
                                 "ORDER BY nombre ASC " +
                                 "LIMIT 20";
                        }
                        else
                        {
                            // comando a ejecutar en la BD
                            consulta =
                            "SELECT p.idProducto AS IdProducto, " +
                            "p.codigoProducto AS Código, " +
                            "p.nombre AS Nombre, p.descripcion AS Descripción, " +
                            "p.precio AS Precio, " +
                            "p.existencias AS Existencias " +
                            "FROM productos p " +
                            "ORDER BY nombre ASC " +
                            "LIMIT 20";
                        }

                        using var comando = new MySqlCommand(consulta, conexionBD);
                        comando.Parameters.AddWithValue("@dato", "%" + dato + "%");
                        comando.Prepare();

                        // Ejecución del comando
                        using var reader = comando.ExecuteReader();

                        if (reader.HasRows)
                        {

                            // Obtención del cursor con el resultado de una consulta
                            while (reader.Read())
                            {
                                Producto producto = new Producto();

                                producto.Id = reader.GetInt32("IdProducto");
                                producto.Codigo = reader.GetString("Código");
                                producto.Nombre = reader.GetString("Nombre");
                                producto.Descripcion = reader.GetString("Descripción");
                                producto.Precio = reader.GetDecimal("Precio");
                                producto.Existencias = reader.GetInt32("Existencias");

                                lista.Add(producto);
                            }
                        }
                        else
                        {
                            throw new Exception("No se encontraron productos");
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        throw new Exception("Incidencia en busqueda de productos: " + ex.Message);
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Incidencia al buscar productos: " + ex.Message);
            }
            finally
            {
                // siempre se cierra la conexion
                Conexion.cerrarConexion();
            }
            return lista;
        }
    }

    public class Producto
    {
        #region propiedades
        
        private int id;
        private String codigo;
        private String nombre;
        private String descripcion;
        private byte[] imagen;
        private DateTime fechaAlta;
        private decimal precio;
        private int existencias;
        private int idCategoria;

        #endregion propiedades

        #region metodos

        public Producto()
        {
            id = 0;
            codigo = "";
            nombre = "";
            descripcion = "";
            imagen = null;
            fechaAlta = DateTime.Today;
            precio = 0;
            existencias = 0;
            idCategoria = 0;
        }
        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public int Existencias { get => existencias; set => existencias = value; }
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }

        public Producto buscarProducto(string codigoProducto)
        {

            Producto producto = new Producto();

            if (codigoProducto != "")
            {
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
                                "SELECT idProducto, codigoProducto, " +
                                     "nombre, descripcion, imagen, fechaAlta, precio, " +
                                     "existencias, idCategoria " +
                                     "FROM productos WHERE codigoProducto = " +
                                     "@codProducto LIMIT 1";

                            using var comando = new MySqlCommand(consulta, conexionBD);

                            comando.Parameters.AddWithValue("@codProducto", codigoProducto);
                            comando.Prepare();

                            // Ejecución del comando
                            using var reader = comando.ExecuteReader();

                            if (reader.HasRows)
                            {
                                // Obtención del cursor con el resultado de una consulta
                                while (reader.Read())
                                {
                                    producto.Id = reader.GetInt32(0);
                                    producto.Codigo = reader.GetString(1);
                                    producto.Nombre = reader.GetString(2);
                                    producto.Descripcion = reader.GetString(3);

                                    if (reader.GetValue(4) != DBNull.Value)
                                    {
                                        producto.Imagen = (byte[])reader.GetValue(4);
                                    }

                                    producto.FechaAlta = reader.GetDateTime(5);
                                    producto.Precio = reader.GetDecimal(6);
                                    producto.Existencias = reader.GetInt32(7);
                                    producto.IdCategoria = reader.GetInt32(8);
                                }
                            }
                            else
                            {
                                throw new Exception("No se encontraron productos");

                            }
                        }
                        catch (InvalidOperationException ex)
                        {
                            throw new Exception("Incidencia en busqueda de productos: " + ex.Message);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Incidencia al buscar productos: " + ex.Message);
                }
                finally
                {
                    // siempre se cierra la conexion
                    Conexion.cerrarConexion();
                }
            }
            else
            {
                throw new Exception("Código de producto no introducido. Introducir Código de producto");
            }

            return producto;
        }

        public bool existeProducto(string codigoProducto)
        {
            bool existe = false;

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
                        // Para modificar, verificar primero que exista el producto.
                        // comando a ejecutar en la BD
                        String consulta =
                            "SELECT idProducto " +
                                 "FROM productos WHERE codigoProducto = " +
                                 "@codigoProducto LIMIT 1";

                        using var comando = new MySqlCommand(consulta, conexionBD);

                        comando.Parameters.AddWithValue("@codigoProducto", codigoProducto);
                        comando.Prepare();

                        // Ejecución del comando
                        using var reader = comando.ExecuteReader();

                        if (reader.HasRows)
                        {
                            existe = true;
                        }
                        return existe;
                    }
                    catch (InvalidOperationException ex)
                    {
                        throw new Exception("Incidencia en busqueda de producto: " + ex.Message);
                    }
                    finally
                    {

                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Incidencia al buscar producto: " + ex.Message);
            }
            finally
            {
                // siempre se cierra la conexion
                Conexion.cerrarConexion();
            }
        }

        public bool guardarProducto(Producto producto)
        {
            bool operacion_ok = false;
            try
            {
                // No permitir guardar registros con datos vacios
                if (producto.Codigo      != ""   &&
                    producto.Nombre      != ""   &&
                    producto.Descripcion != ""   &&
                    producto.FechaAlta   != null &&
                    producto.Precio      != 0    &&
                    producto.Existencias != 0    &&
                    producto.IdCategoria != 0)
                {
                    // Verificar si existe el registro. No se puede dar de alta
                    // un registro si ya existe
                    try
                    {
                        if (!existeProducto(producto.Codigo))
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
                                    string sql = "INSERT INTO productos (codigoProducto, " +
                                        "nombre, descripcion, imagen, fechaAlta, precio, existencias, " +
                                        "idCategoria) VALUES (@codigoProducto, @nombre, @descripcion, " +
                                        "@imagen, @fechaAlta, @precio, @existencias, @idCategoria)";

                                    // comando a ejecutar en la BD
                                    using var comando = new MySqlCommand(sql, conexionBD);
                                    comando.Parameters.AddWithValue("@codigoProducto", producto.Codigo);
                                    comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                                    comando.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                                    comando.Parameters.AddWithValue("@imagen", producto.Imagen);
                                    comando.Parameters.AddWithValue("@fechaAlta", producto.FechaAlta);
                                    comando.Parameters.AddWithValue("@precio", producto.Precio);
                                    comando.Parameters.AddWithValue("@existencias", producto.Existencias);
                                    comando.Parameters.AddWithValue("@idCategoria", producto.IdCategoria);
                                    comando.Prepare();

                                    // Ejecución del comando
                                    comando.ExecuteNonQuery();

                                    operacion_ok = true;
                                    return operacion_ok;

                                }
                                catch (MySqlException ex)
                                {
                                    throw new Exception("Incidencia al guardar producto: " + ex.Message);
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("Imposible guardar - Producto ya existe");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception("Incidencia: " + ex.Message);
                    }
                    finally
                    {
                        // siempre se cierra la conexion
                        Conexion.cerrarConexion();
                    }
                }
                else
                {
                    throw new Exception("Algunos datos vacios. Introducir todos los datos");
                }
            }
            catch (FormatException fex)
            {
                throw new Exception("Datos incorrectos: " + fex.Message);
            }
        }

        public bool actualizarProducto(Producto producto)
        {
            Producto productoEnBD = new Producto();

            bool operacion_ok = false;

            // No permitir modificar registros con datos vacios
            if (producto.Codigo      != ""   && producto.Nombre      != "" &&
                producto.Descripcion != ""   && producto.Precio      != 0  &&
                producto.FechaAlta   != null && producto.Existencias != 0  &&
                producto.IdCategoria != 0)
            {
                if (existeProducto(producto.Codigo))
                {
                    // Modificar datos si no son identicos a los que existen en la BD.
                    productoEnBD = buscarProducto(producto.Codigo);

                    if (producto.Codigo      != productoEnBD.Codigo      ||
                        producto.Nombre      != productoEnBD.Nombre      ||
                        producto.Descripcion != productoEnBD.Descripcion ||
                        producto.FechaAlta   != productoEnBD.FechaAlta   ||
                        producto.Precio      != productoEnBD.Precio      ||
                        producto.Existencias != productoEnBD.Existencias ||
                        producto.IdCategoria != productoEnBD.IdCategoria ||
                        Utils.ByteArrayCompare(producto.Imagen, productoEnBD.Imagen) == false)
                    {
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
                                    string sql = "UPDATE productos SET " +
                                    "codigoProducto=@codigoProducto, " +
                                    "nombre=@nombre, descripcion=@descripcion, " +
                                    "imagen=@imagen, fechaAlta=@fechaAlta, " +
                                    "precio=@precio, " +
                                    "existencias=@existencias, " +
                                    "idCategoria=@idCategoria " +
                                    "WHERE codigoProducto=@codigoProducto;";
                                    // comando a ejecutar en la BD
                                    using var comando = new MySqlCommand(sql, conexionBD);

                                    comando.Parameters.AddWithValue("@codigoProducto", producto.Codigo);
                                    comando.Parameters.AddWithValue("@nombre", producto.Nombre);
                                    comando.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                                    comando.Parameters.AddWithValue("@imagen", producto.Imagen);
                                    comando.Parameters.AddWithValue("@fechaAlta", producto.FechaAlta);
                                    comando.Parameters.AddWithValue("@precio", producto.Precio);
                                    comando.Parameters.AddWithValue("@existencias", producto.Existencias);
                                    comando.Parameters.AddWithValue("@idCategoria", producto.IdCategoria);
                                    comando.Prepare();

                                    // Ejecución del comando
                                    comando.ExecuteNonQuery();

                                    operacion_ok = true;
                                    return operacion_ok;
                                }
                                catch (MySqlException ex)
                                {
                                    throw new Exception("Incidencia al modificar producto: " + ex.Message);
                                }
                            }
                        }
                        catch (MySqlException ex)
                        {
                            throw new Exception("Incidencia: " + ex.Message);
                        }
                        finally
                        {
                            // siempre se cierra la conexion
                            Conexion.cerrarConexion();
                        }
                    }
                    else
                    {
                        throw new Exception("Producto no modificado. Mismos datos en Base de Datos");
                    }
                }
                else
                {
                    throw new Exception("Imposible modificación - Producto no existe");
                }
            }
            else
            {
                throw new Exception("Datos vacios. No se puede modificar producto");
            }
        }

        public bool eliminarProducto(Producto producto)
        {
            bool operacion_ok = false;

            // No se puede eliminar producto si codigo vacio
            if (producto.Codigo != "")
            {
                if (existeProducto(producto.Codigo))
                {
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
                                string sql = "DELETE FROM productos " +
                                    "WHERE codigoProducto=@codigoProducto;";
                                // comando a ejecutar en la BD
                                using var comando = new MySqlCommand(sql, conexionBD);

                                comando.Parameters.AddWithValue("@codigoProducto", producto.Codigo);
                                comando.Prepare();

                                // Ejecución del comando
                                comando.ExecuteNonQuery();

                                operacion_ok = true;
                                return operacion_ok;
                            }
                            catch (MySqlException ex)
                            {
                                throw new Exception("Incidencia al eliminar producto: " + ex.Message);
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception("Incidencia: " + ex.Message);
                    }
                    finally
                    {
                        // siempre se cierra la conexion
                        Conexion.cerrarConexion();
                    }
                }
                else
                {
                    throw new Exception("Imposible eliminación - Producto no existe");
                }
            }
            else
            {
                throw new Exception("Datos vacios. No se puede eliminar producto");
            }
        }
        #endregion metodos

    }
}

