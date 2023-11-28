using BankAPI.Data.Services;
using BankAPI.Model;
using Dapper;
using MySql.Data.MySqlClient;
namespace BankAPI.Data.Repositories;

public class DetallePedidoRepository : IDetallePedidoRepository
{
    private MySQLConfiguration _connectionString;
    public DetallePedidoRepository(MySQLConfiguration connectionString)
    {
        _connectionString = connectionString;
    }
    protected MySqlConnection dbConnection()
    {
        return new MySqlConnection(_connectionString.ConnectionString);
    }
    public Task<bool> DeleteDetallePedido(DetallePedido detallePedido)
    {
        throw new NotImplementedException();
    }

    public Task<DetallePedido> GetDetallePedidoById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<DetallePedido>> GetDetallesPedido()
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM DetallePedido";

        return await db.QueryAsync<DetallePedido>(sql, new { });
    }

    public Task<bool> InsertDetallePedido(DetallePedido detallePedido)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateDetallePedido(DetallePedido detallePedido)
    {
        throw new NotImplementedException();
    }
}