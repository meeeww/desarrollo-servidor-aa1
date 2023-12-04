using BankAPI.Data.Services;
using BankAPI.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace BankAPI.Data.Repositories
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public PedidosRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Pedidos>> GetPedidos()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Pedidos";

            return await db.QueryAsync<Pedidos>(sql, new { });
        }

        public async Task<Pedidos> GetPedidoById(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Pedidos WHERE ID_Pedido = @Id";

            return await db.QueryFirstOrDefaultAsync<Pedidos>(sql, new { Id = id });
        }

        public async Task<Pedidos> GetPedidoByDate(DateTime fecha)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Pedidos WHERE Fecha = @Fecha";

            return await db.QueryFirstOrDefaultAsync<Pedidos>(sql, new { Fecha = fecha });
        }

        public async Task<bool> InsertPedido(Pedidos pedido)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO Pedidos (ID_Cliente, Fecha, Total, Enviado, MetodoPago) 
                        VALUES (@ID_Cliente, @Fecha, @Total, @Enviado, @MetodoPago)";

            var result = await db.ExecuteAsync(sql, new
            {
                pedido.ID_Cliente,
                pedido.Fecha,
                pedido.Total,
                pedido.Enviado,
                pedido.MetodoPago
            });

            return result > 0;
        }

        public async Task<bool> UpdatePedido(Pedidos pedido)
        {
            var db = dbConnection();

            var sql = @"UPDATE Pedidos
                        SET ID_Cliente = @ID_Cliente, Fecha = @Fecha, 
                            Total = @Total, Enviado = @Enviado, MetodoPago = @MetodoPago
                        WHERE ID_Pedido = @Id";

            var result = await db.ExecuteAsync(sql, new
            {
                pedido.ID_Cliente,
                pedido.Fecha,
                pedido.Total,
                pedido.Enviado,
                pedido.MetodoPago,
                Id = pedido.ID_Pedido
            });

            return result > 0;
        }

        public async Task<bool> DeletePedido(Pedidos pedido)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Pedidos WHERE ID_Pedido = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = pedido.ID_Pedido });

            return result > 0;
        }
    }
}
