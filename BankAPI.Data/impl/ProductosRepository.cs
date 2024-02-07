﻿using BankAPI.Model;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BankAPI.Data
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductosRepository()
        {
            var dbConfig = new DBConfiguration();
            _dbConnection = dbConfig.ConnectionType;
        }

        protected IDbConnection dbConnection()
        {
            return _dbConnection;
        }

        public async Task<IEnumerable<Producto>> GetProductos()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Productos";

            return await db.QueryAsync<Producto>(sql, new { });
        }

        public async Task<Producto> GetProductoById(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Productos WHERE ID_Producto = @Id";

            return await db.QueryFirstOrDefaultAsync<Producto>(sql, new { Id = id });
        }

        public async Task<bool> InsertProducto(Producto producto)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, Imagen) 
                        VALUES (@Nombre, @Descripcion, @Precio, @Stock, @Imagen)";

            var result = await db.ExecuteAsync(sql, new
            {
                producto.Nombre,
                producto.Descripcion,
                producto.Precio,
                producto.Stock,
                producto.Imagen
            });

            return result > 0;
        }

        public async Task<bool> UpdateProducto(Producto producto)
        {
            var db = dbConnection();

            var sql = @"UPDATE Productos 
                        SET Nombre = @Nombre, Descripcion = @Descripcion, 
                            Precio = @Precio, Stock = @Stock , Imagen = @Imagen
                        WHERE ID_Producto = @Id";

            var result = await db.ExecuteAsync(sql, new
            {
                producto.Nombre,
                producto.Descripcion,
                producto.Precio,
                producto.Stock,
                producto.Imagen,
                Id = producto.ID_Producto
            });

            return result > 0;
        }

        public async Task<bool> DeleteProducto(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Productos WHERE ID_Producto = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }
    }
}
