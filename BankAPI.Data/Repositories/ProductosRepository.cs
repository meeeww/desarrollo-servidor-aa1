using BankAPI.Data.Services;
using BankAPI.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace BankAPI.Data.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public ProductosRepository(MySQLConfiguration connectionString)
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

            var sql = @"SELECT * FROM Productos";

            return await db.QueryAsync<Productos>(sql, new { });
        }

        public async Task<Productos> GetProductoById(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Productos WHERE ID_Producto = @Id";

            return await db.QueryFirstOrDefaultAsync<Productos>(sql, new { Id = id });
        }

        public async Task<bool> InsertProducto(Productos producto)
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

        public async Task<bool> UpdateProducto(Productos producto)
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

        public async Task<bool> DeleteProducto(Productos producto)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Productos WHERE ID_Producto = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = producto.ID_Producto });

            return result > 0;
        }
    }
}
