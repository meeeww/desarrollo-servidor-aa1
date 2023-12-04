using BankAPI.Data.Services;
using BankAPI.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace BankAPI.Data.Repositories;

public class ClienteRepository : IClienteRepository
{

    private MySQLConfiguration _connectionString;
    public ClienteRepository(MySQLConfiguration connectionString)
    {
        _connectionString = connectionString;
    }
    protected MySqlConnection dbConnection()
    {
        return new MySqlConnection(_connectionString.ConnectionString);
    }
    public Task<bool> DeleteCliente(Clientes cliente)
    {
        throw new NotImplementedException();
    }

    public Task<Clientes> GetClienteByEmail(string DNI)
    {
        throw new NotImplementedException();
    }

    public Task<Clientes> GetClienteById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Clientes>> GetClientes()
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM Cliente";

        return await db.QueryAsync<Clientes>(sql, new { });
    }

    public Task<bool> InsertarCliente(Clientes cliente)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateCliente(Clientes cliente)
    {
        throw new NotImplementedException();
    }
}