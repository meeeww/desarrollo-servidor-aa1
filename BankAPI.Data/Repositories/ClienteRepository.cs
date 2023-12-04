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
    public async Task<bool> DeleteCliente(Cliente cliente)
    {
        var db = dbConnection();

        var sql = @"DELETE FROM Clientes WHERE ID_Cliente = @Id ";

        var result = await db.ExecuteAsync(sql, new { cliente.ID_Cliente });

        return result > 0;
    }

    public async Task<Cliente> GetClienteByEmail(string email)
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM Clientes WHERE Email = @Email";

        return await db.QueryFirstOrDefaultAsync<Cliente>(sql, new { Email = email });
    }

    public async Task<Cliente> GetClienteById(int id)
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM Clientes WHERE ID_Cliente = @Id";

        return await db.QueryFirstOrDefaultAsync<Cliente>(sql, new { Id = id });
    }

    public async Task<IEnumerable<Clientes>> GetClientes()
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM Clientes";

        return await db.QueryAsync<Clientes>(sql, new { });
    }

    public async Task<bool> InsertCliente(Cliente cliente)
    {
        var db = dbConnection();

        var sql = @"INSERT INTO Clientes (ID_Cliente , Nombre , Apellido , Email , Telefono , Direccion) VALUES (@Nombre , @Apellido , @Email , @Telefono , @Direccion) ";

        var result = await db.ExecuteAsync(sql, new { cliente.Nombre, cliente.Apellido, cliente.Email, cliente.Telefono, cliente.Direccion });

        return result > 0;
    }

    public async Task<bool> UpdateCliente(Cliente cliente)
    {
        var db = dbConnection();

        var sql = @"UPDATE Clientes SET Nombre = @Nombre , Apellido = @Apellido , Email = @Email , Telefono = @Telefono , Direccion = @Direccion"; // Corrección aquí

        var result = await db.ExecuteAsync(sql, new { cliente.Nombre, cliente.Apellido, cliente.Email, cliente.Telefono, cliente.Direccion });

        return result > 0;
    }
}