using BankAPI.Data.Services;
using BankAPI.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace BankAPI.Data.Repositories;

public class EmpleadoRepository : IEmpleadoRepository
{
    private MySQLConfiguration _connectionString;
    public EmpleadoRepository(MySQLConfiguration connectionString)
    {
        _connectionString = connectionString;
    }
    protected MySqlConnection dbConnection()
    {
        return new MySqlConnection(_connectionString.ConnectionString);
    }
    public async Task<bool> DeleteEmpleado(Empleados empleado)
    {
        var db = dbConnection();

        var sql = @"DELETE FROM Empleados WHERE ID_Empleado = @Id ";

        var result = await db.ExecuteAsync(sql, new { });

        return result > 0;
    }

    public async Task<Empleados> GetEmpleadoById(int id)
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM Empleados WHERE ID_Empleados = @Id";

        return await db.QueryFirstOrDefaultAsync<Empleados>(sql, new { Id = id });
    }

    public async Task<IEnumerable<Empleados>> GetEmpleados()
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM Empleados";

        return await db.QueryAsync<Empleados>(sql, new { });
    }

    public async Task<bool> InsertEmpleado(Empleados Empleados)
    {
        var db = dbConnection();

        var sql = @"INSERT INTO Empleados (Nombre , Apellido , Cargo , Salario) VALUES (@Nombre , @Apellido , @Cargo , @Salario)";

        var result = await db.ExecuteAsync(sql, new { });

        return result > 0;
    }

    public async Task<bool> UpdateEmpleado(Empleados empleado)
    {
        var db = dbConnection();

        var sql = @"UPDATE Empleados SET Nombre = @Nombre , Apellido = @Apellido , Cargo = @Cargo , Salario = @Salario"; // Corrección aquí

        var result = await db.ExecuteAsync(sql, new { empleado.Nombre, empleado.Apellido, empleado.Cargo, empleado.Salario });

        return result > 0;
    }
}