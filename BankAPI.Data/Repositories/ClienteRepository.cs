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
    public Task<bool> DeleteCliente(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public Task<Cliente> GetClienteByEmail(string DNI)
    {
        throw new NotImplementedException();
    }

    public Task<Cliente> GetClienteById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Cliente>> GetClientes()
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM Cliente";

        return await db.QueryAsync<Cliente>(sql, new { });
    }

    public Task<bool> InsertarCliente(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateCliente(Cliente cliente)
    {
        throw new NotImplementedException();
    }
}