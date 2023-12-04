﻿using BankAPI.Data.Services;
using BankAPI.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAPI.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public PedidoRepository(MySQLConfiguration connectionString)
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

            var sql = @"SELECT * FROM Pedido";

            return await db.QueryAsync<Pedidos>(sql, new { });
        }

        public async Task<Pedidos> GetPedidoById(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Pedido WHERE ID_Pedido = @Id";

            return await db.QueryFirstOrDefaultAsync<Pedidos>(sql, new { Id = id });
        }

        public async Task<Pedidos> GetPedidoByDate(DateTime fecha)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Pedido WHERE Fecha = @Fecha";

            return await db.QueryFirstOrDefaultAsync<Pedidos>(sql, new { Fecha = fecha });
        }

        public async Task<bool> InsertPedido(Pedidos pedido)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO Pedido (ID_Cliente, Fecha, Total) 
                        VALUES (@ID_Cliente, @Fecha, @Total)";

            var result = await db.ExecuteAsync(sql, new
            {
                pedido.ID_Cliente,
                pedido.Fecha,
                pedido.Total
            });

            return result > 0;
        }

        public async Task<bool> UpdatePedido(Pedidos pedido)
        {
            var db = dbConnection();

            var sql = @"UPDATE Pedido 
                        SET ID_Cliente = @ID_Cliente, Fecha = @Fecha, 
                            Total = @Total 
                        WHERE ID_Pedido = @Id";

            var result = await db.ExecuteAsync(sql, new
            {
                pedido.ID_Cliente,
                pedido.Fecha,
                pedido.Total,
                Id = pedido.ID_Pedido
            });

            return result > 0;
        }

        public async Task<bool> DeletePedido(Pedidos pedido)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Pedido WHERE ID_Pedido = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = pedido.ID_Pedido });

            return result > 0;
        }
    }
}