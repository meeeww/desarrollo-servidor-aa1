using BankAPI.Services;
using BankAPI.Model;
using BankAPI.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace BankAPI.Repositories
{
    public class RegistroVentasRepository : IRegistroVentasRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public RegistroVentasRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<RegistroVentas>> GetRegistrosVentas()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM RegistroVentas";

            return await db.QueryAsync<RegistroVentas>(sql, new { });
        }

        public async Task<RegistroVentas> GetRegistroVentasById(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM RegistroVentas WHERE ID_RegistroVentas = @Id";

            return await db.QueryFirstOrDefaultAsync<RegistroVentas>(sql, new { Id = id });
        }

        public async Task<RegistroVentas> GetRegistroVentasByIdEmpleado(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM RegistroVentas WHERE ID_Empleado = @Id";

            return await db.QueryFirstOrDefaultAsync<RegistroVentas>(sql, new { Id = id });
        }

        public async Task<bool> InsertRegistroVentas(RegistroVentas registroVentas)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO RegistroVentas (ID_Empleado, Fecha, TotalVentas, TotalCostos, TotalImpuestos) VALUES (@ID_Empleado, @Fecha, @TotalVentas, @TotalCostos, @TotalImpuestos)";

            var result = await db.ExecuteAsync(sql, new { registroVentas.ID_Empleado, registroVentas.Fecha, registroVentas.TotalVentas, registroVentas.TotalCostos, registroVentas.TotalImpuestos });

            return result > 0;
        }

        public async Task<bool> UpdateRegistroVentas(RegistroVentas registroVentas)
        {
            var db = dbConnection();

            var sql = @"UPDATE RegistroVentas SET ID_Empleado = @ID_Empleado, Fecha = @Fecha, TotalVentas = @TotalVentas, TotalCostos = @TotalCostos, TotalImpuestos = @TotalImpuestos WHERE ID_RegistroVentas = @ID_RegistroVentas";

            var result = await db.ExecuteAsync(sql, new { registroVentas.ID_Empleado, registroVentas.Fecha, registroVentas.TotalVentas, registroVentas.TotalCostos, registroVentas.TotalImpuestos, registroVentas.ID_RegistroVentas });

            return result > 0;
        }

        public async Task<bool> DeleteRegistroVentas(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM RegistroVentas WHERE ID_RegistroVentas = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }
    }
}
