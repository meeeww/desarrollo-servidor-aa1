using BankAPI.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace BankAPI.Data;

public class EmpleadosRepository : IEmpleadosRepository
{
    private MySQLConfiguration _connectionString;
    public EmpleadosRepository(MySQLConfiguration connectionString)
    {
        _connectionString = connectionString;
    }
    protected MySqlConnection dbConnection()
    {
        return new MySqlConnection(_connectionString.ConnectionString);
    }
    public async Task<bool> DeleteEmpleado(int id)
    {
        var db = dbConnection();

        var sql = @"DELETE FROM Empleados WHERE ID_Empleado = @Id ";

        var result = await db.ExecuteAsync(sql, new { Id = id });

        return result > 0;
    }

    public async Task<Empleado> GetEmpleadoById(int id)
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM Empleados WHERE ID_Empleado = @Id";

        return await db.QueryFirstOrDefaultAsync<Empleado>(sql, new { Id = id });
    }

    public async Task<IEnumerable<Empleado>> GetEmpleados()
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM Empleados";

        return await db.QueryAsync<Empleado>(sql, new { });
    }

    public async Task<bool> InsertEmpleado(Empleado empleado)
    {
        var db = dbConnection();

        var sql = @"INSERT INTO Empleados (Nombre , Apellido , Cargo , Salario , FechaEntrada , FechaSalida) VALUES (@Nombre , @Apellido , @Cargo , @Salario , @FechaEntrada , @FechaSalida)";

        var result = await db.ExecuteAsync(sql, new { empleado.Nombre, empleado.Apellido, empleado.Cargo, empleado.Salario, empleado.FechaEntrada, empleado.FechaSalida });

        return result > 0;
    }

    public async Task<bool> UpdateEmpleado(Empleado empleado)
    {
        var db = dbConnection();

        var sql = @"UPDATE Empleados SET Nombre = @Nombre , Apellido = @Apellido , Cargo = @Cargo , Salario = @Salario , FechaEntrada = @FechaEntrada , FechaSalida =  @FechaSalida"; // Corrección aquí

        var result = await db.ExecuteAsync(sql, new { empleado.Nombre, empleado.Apellido, empleado.Cargo, empleado.Salario, empleado.FechaEntrada, empleado.FechaSalida });

        return result > 0;
    }
}