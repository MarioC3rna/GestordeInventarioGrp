using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Proyecto_Base_de_Datos
{
    /// <summary>
    /// Clase centralizada para manejar la conexión a la base de datos
    /// </summary>
  public static class DatabaseConnection
    {
        // ?? Cadena de conexión principal
        private static readonly string _connectionString = "Data Source=SRV-BD\\MYISTANCE;Initial Catalog=Db_EmpresaDev;User ID=admin_inventario;Password=Adm!n2025$;Encrypt=True;TrustServerCertificate=True;";

    /// <summary>
        /// Obtiene la cadena de conexión configurada
 /// </summary>
        public static string ConnectionString => _connectionString;

        /// <summary>
        /// Crea una nueva conexión SqlConnection configurada
        /// </summary>
        /// <returns>Nueva instancia de SqlConnection</returns>
        public static SqlConnection CreateConnection()
   {
      return new SqlConnection(_connectionString);
        }

 /// <summary>
        /// Prueba la conexión a la base de datos
        /// </summary>
        /// <returns>True si la conexión es exitosa, False en caso contrario</returns>
    public static bool TestConnection()
        {
            try
            {
      using (var connection = CreateConnection())
            {
            connection.Open();
                  return true;
            }
            }
            catch (Exception)
          {
    return false;
            }
        }

        /// <summary>
      /// Prueba la conexión y retorna información detallada
        /// </summary>
   /// <returns>Mensaje con el resultado de la prueba</returns>
   public static string TestConnectionWithDetails()
{
      try
     {
      using (var connection = CreateConnection())
   {
         connection.Open();
           
              // Obtener información del servidor
           string serverVersion = connection.ServerVersion;
       string database = connection.Database;
       string dataSource = connection.DataSource;
  
       connection.Close();
  
        return $"? Conexión exitosa\n" +
     $"Servidor: {dataSource}\n" +
          $"Base de datos: {database}\n" +
           $"Versión: {serverVersion}";
       }
    }
            catch (SqlException sqlEx)
       {
         return $"? Error de SQL Server:\n" +
        $"Código: {sqlEx.Number}\n" +
    $"Mensaje: {sqlEx.Message}";
     }
     catch (Exception ex)
       {
            return $"? Error de conexión:\n{ex.Message}";
            }
        }

     /// <summary>
        /// Ejecuta una consulta SELECT y retorna un SqlDataReader
        /// IMPORTANTE: El caller debe cerrar el reader y la conexión
        /// </summary>
   /// <param name="query">Consulta SQL a ejecutar</param>
        /// <param name="parameters">Parámetros de la consulta (opcional)</param>
        /// <returns>Tupla con SqlConnection y SqlDataReader</returns>
        public static (SqlConnection connection, SqlDataReader reader) ExecuteReader(string query, params SqlParameter[] parameters)
        {
            var connection = CreateConnection();
            
            try
            {
  connection.Open();
              var command = new SqlCommand(query, connection);
       
     if (parameters != null)
      {
            command.Parameters.AddRange(parameters);
           }
       
    var reader = command.ExecuteReader();
      return (connection, reader);
            }
         catch
     {
         connection?.Dispose();
        throw;
            }
        }

        /// <summary>
        /// Ejecuta una consulta que no retorna datos (INSERT, UPDATE, DELETE)
        /// </summary>
        /// <param name="query">Consulta SQL a ejecutar</param>
      /// <param name="parameters">Parámetros de la consulta (opcional)</param>
        /// <returns>Número de filas afectadas</returns>
        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
   {
         using (var connection = CreateConnection())
    {
    connection.Open();
       using (var command = new SqlCommand(query, connection))
          {
      if (parameters != null)
      {
           command.Parameters.AddRange(parameters);
         }
            
      return command.ExecuteNonQuery();
      }
  }
}

        /// <summary>
     /// Ejecuta una consulta que retorna un valor único (COUNT, MAX, etc.)
  /// </summary>
        /// <param name="query">Consulta SQL a ejecutar</param>
        /// <param name="parameters">Parámetros de la consulta (opcional)</param>
/// <returns>Valor único retornado por la consulta</returns>
        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
    using (var connection = CreateConnection())
            {
 connection.Open();
        using (var command = new SqlCommand(query, connection))
     {
       if (parameters != null)
       {
                command.Parameters.AddRange(parameters);
       }
   
    return command.ExecuteScalar();
       }
    }
        }

        /// <summary>
        /// Crea un SqlParameter de forma simplificada
        /// </summary>
   /// <param name="name">Nombre del parámetro (incluir @)</param>
        /// <param name="value">Valor del parámetro</param>
        /// <returns>SqlParameter configurado</returns>
      public static SqlParameter CreateParameter(string name, object value)
        {
    return new SqlParameter(name, value ?? DBNull.Value);
        }
    }
}