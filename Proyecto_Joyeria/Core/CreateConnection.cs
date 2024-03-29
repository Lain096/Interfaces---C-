﻿using System;
using System.Data;
using MySqlConnector;

namespace Proyecto_Joyeria.Core
{
    class CreateConnection
    {
        /*
         * Devuleve una conexión MySQL abierta, por patrón singleton.
         * Si la conexión es null, la crea y, si está cerrada, la abre.
         */
        private static MySqlConnectionStringBuilder builder = null;
        private static MySqlConnection conn = null;
        private static String SERVIDOR = "localhost";
        private static uint PUERTO = 3306;
        private static String BD = "joyeria";
        private static String USUARIO = "root";
        private static String PASSWORD = "admin";

        private CreateConnection()
        {
            // Constructor vacio
        }

        private static MySqlConnectionStringBuilder getBuilder()
        {
            if (builder == null)
            {
                try
                {
                    builder = new MySqlConnectionStringBuilder();
                }
                catch (Exception)
                {
                    builder = null;
                }
            }
            return builder;
        }

        public static MySqlConnection obtenerConexionAbierta()
        {
            if (conn == null)
            {
                if (getBuilder() == null)
                {
                    return null;
                }
                builder.Server = SERVIDOR;
                builder.Port = PUERTO;
                builder.UserID = USUARIO;
                builder.Password = PASSWORD;
                builder.Database = BD;
                try
                {
                    conn = new MySqlConnection(builder.ToString());
                    conn.Open();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            else if (conn.State != ConnectionState.Open)
            {
                try
                {
                    //conn.Close();
                    conn.Open();
                }
                catch (Exception e)
                {
                 
                    return null;
                }
            }

            if (conn.State == ConnectionState.Open)
            {
                // Console.Write("Conexión a la BD establecida\n");
            }
            return conn;
        }

        public static void cerrarConexion()
        {
            if (conn != null)
            {
                try
                {
                    conn.Close();

                    if (conn.State == ConnectionState.Closed)
                    {
                        //     Console.Write("BD desconectada\n");
                    }
                }
                finally
                {
                }
            }
        }
    }
}
