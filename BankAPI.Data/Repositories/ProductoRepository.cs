using BankAPI.Data.Services;
using BankAPI.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAPI.Data.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public ProductoRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Productos>> GetProductos()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Producto";

            return await db.QueryAsync<Productos>(sql, new { });
        }

        public async Task<Productos> GetProductoById(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Producto WHERE ID_Producto = @Id";

            return await db.QueryFirstOrDefaultAsync<Productos>(sql, new { Id = id });
        }

        public async Task<bool> InsertProducto(Productos producto)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO Producto (Nombre, Descripcion, Precio, Stock) 
                        VALUES (@Nombre, @Descripcion, @Precio, @Stock)";

            var result = await db.ExecuteAsync(sql, new
            {
                producto.Nombre,
                producto.Descripcion,
                producto.Precio,
                producto.Stock
            });

            return result > 0;
        }

        public async Task<bool> UpdateProducto(Productos producto)
        {
            var db = dbConnection();

            var sql = @"UPDATE Producto 
                        SET Nombre = @Nombre, Descripcion = @Descripcion, 
                            Precio = @Precio, Stock = @Stock 
                        WHERE ID_Producto = @Id";

            var result = await db.ExecuteAsync(sql, new
            {
                producto.Nombre,
                producto.Descripcion,
                producto.Precio,
                producto.Stock,
                Id = producto.ID_Producto
            });

            return result > 0;
        }

        public async Task<bool> DeleteProducto(Productos producto)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Producto WHERE ID_Producto = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = producto.ID_Producto });

            return result > 0;
        }
    }
}
