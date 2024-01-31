using BankAPI.Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BankAPI.Data
{
    public class DetallePedidosRepository : IDetallePedidosRepository
    {
        private readonly IDbConnection _dbConnection;

        public DetallePedidosRepository()
        {
            var dbConfig = new DBConfiguration();
            _dbConnection = dbConfig.ConnectionType;
        }

        protected IDbConnection dbConnection()
        {
            return _dbConnection;
        }

        public async Task<bool> DeleteDetallePedido(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM DetallePedidos WHERE ID_DetallePedido = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = id });

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
            var sql = @"INSERT INTO DetallePedidos (ID_Pedido , ID_Producto , Cantidad , Subtotal, FechaCreacion , FechaModificacion) VALUES (@ID_Pedido , @ID_Producto , @Cantidad , @Subtotal , @FechaCreacion, @FechaModificacion)";
            var result = await db.ExecuteAsync(sql, new { detallePedido.ID_Pedido, detallePedido.ID_Producto, detallePedido.Cantidad, detallePedido.Subtotal, detallePedido.FechaCreacion, detallePedido.FechaModificacion });

            return result > 0;
        }

        public async Task<bool> UpdateDetallePedido(DetallePedido detallePedido)
        {
            var db = dbConnection();

            var sql = @"UPDATE DetallePedidos SET ID_Pedido  = @ID_Pedido , ID_Producto  = @ID_Producto , Cantidad = @Cantidad , Subtotal = @Subtotal , FechaCreacion = @FechaCreacion , FechaModificacion = @FechaModificacion"; // Corrección aquí

            var result = await db.ExecuteAsync(sql, new { detallePedido.ID_Pedido, detallePedido.ID_Producto, detallePedido.Cantidad, detallePedido.Subtotal, detallePedido.FechaCreacion, detallePedido.FechaModificacion });

            return result > 0;
        }
    }
}