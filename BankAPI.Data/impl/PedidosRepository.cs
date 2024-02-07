using BankAPI.Model;
using BankAPI.Data;
using Dapper;
using System.Data.Common;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

namespace BankAPI.Data
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly IDbConnection _dbConnection;

        public PedidosRepository()
        {
            var dbConfig = new DBConfiguration();
            _dbConnection = dbConfig.ConnectionType;
        }

        protected IDbConnection dbConnection()
        {
            return _dbConnection;
        }

        public async Task<IEnumerable<Pedido>> GetPedidos()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Pedidos";

            return await db.QueryAsync<Pedido>(sql, new { });
        }

        public async Task<Pedido> GetPedidoById(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Pedidos WHERE ID_Pedido = @Id";

            return await db.QueryFirstOrDefaultAsync<Pedido>(sql, new { Id = id });
        }

        public async Task<Pedido> GetPedidoByDate(DateTime fecha)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Pedidos WHERE Fecha = @Fecha";

            return await db.QueryFirstOrDefaultAsync<Pedido>(sql, new { Fecha = fecha });
        }

        public async Task<bool> InsertPedido(Pedido pedido)
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

        public async Task<bool> UpdatePedido(Pedido pedido)
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

        public async Task<bool> DeletePedido(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Pedidos WHERE ID_Pedido = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }
    }
}
