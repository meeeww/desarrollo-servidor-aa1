using BankAPI.Data.Services;
using BankAPI.Model;
using Dapper;
using MySql.Data.MySqlClient;
namespace BankAPI.Data.Repositories;

public class DetallePedidosRepository : IDetallePedidosRepository
{
    private MySQLConfiguration _connectionString;
    public DetallePedidosRepository(MySQLConfiguration connectionString)
    {
        _connectionString = connectionString;
    }
    protected MySqlConnection dbConnection()
    {
        return new MySqlConnection(_connectionString.ConnectionString);
    }
    public async Task<bool> DeleteDetallePedido(DetallePedido detallePedido)
    {
        var db = dbConnection();

        var sql = @"DELETE FROM DetallePedidos WHERE ID_DetallePedido = @Id ";

        var result = await db.ExecuteAsync(sql, new { detallePedido.ID_DetallePedido });

        return result > 0;
    }

    public async Task<DetallePedido> GetDetallePedidoById(int id)
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM DetallePedidos WHERE ID_DetallePedido = @Id";
        return await db.QueryFirstOrDefaultAsync(sql, new { Id = id });
    }

    public async Task<IEnumerable<DetallePedido>> GetDetallesPedido()
    {
        var db = dbConnection();

        var sql = @"SELECT * FROM DetallePedidos";

        return await db.QueryAsync<DetallePedido>(sql, new { });
    }

    public async Task<bool> InsertDetallePedido(DetallePedido detallePedido)
    {
        var db = dbConnection();
        var sql = @"INSERT INTO DetallePedidos (ID_Pedido , ID_Producto , Cantidad , Subtotal) VALUES (@ID_Pedido , @ID_Producto , @Cantidad , @Subtotal)";
        var result = await db.ExecuteAsync(sql, new { detallePedido.ID_Pedido, detallePedido.ID_Producto, detallePedido.Cantidad, detallePedido.Subtotal });


        return result > 0;
    }

    public async Task<bool> UpdateDetallePedido(DetallePedido detallePedido)
    {
        var db = dbConnection();

        var sql = @"UPDATE DetallePedidos SET ID_Pedido  = @ID_Pedido , ID_Producto  = @ID_Producto , Cantidad = @Cantidad , Subtotal = @Subtotal"; // Corrección aquí

        var result = await db.ExecuteAsync(sql, new { detallePedido.ID_Pedido, detallePedido.ID_Producto, detallePedido.Cantidad, detallePedido.Subtotal });

        return result > 0;
    }
}