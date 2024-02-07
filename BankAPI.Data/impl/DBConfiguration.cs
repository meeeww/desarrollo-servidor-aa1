using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace BankAPI.Data
{
    public class DBConfiguration
    {
        public DBConfiguration()
        {

            switch (Environment.GetEnvironmentVariable("TIPO_CONEXION"))
            {
                case "MYSQL":
                    ConnectionType = new MySqlConnection(Environment.GetEnvironmentVariable("STRING_CONEXION_MYSQL"));
                    break;
                case "SQLSERVER":
                    ConnectionType = new SqlConnection(Environment.GetEnvironmentVariable("STRING_CONEXION_SQLSERVER"));
                    break;
                default:
                    throw new InvalidOperationException("Tipo de base de datos no soportado");
            }
        }

        public IDbConnection ConnectionType { get; set; }
    }
}
