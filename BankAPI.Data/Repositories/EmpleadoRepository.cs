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
    public Task<bool> DeleteEmpleado(Empleado empleado)
    {
        throw new NotImplementedException();
    }

    public Task<Empleado> GetEmpleadoById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Empleado>> GetEmpleados()
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM Empleado";

        return await db.QueryAsync<Empleado>(sql, new { });
    }

    public Task<bool> InsertEmpleado(Empleado empleado)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateEmpleado(Empleado empleado)
    {
        throw new NotImplementedException();
    }
}