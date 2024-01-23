using BankAPI.Model;

namespace BankAPI.Services
{
    public interface IProductosRepository
    {
        Task<IEnumerable<Producto>> GetProductos();
        Task<Producto> GetProductoById(int id);
        Task<bool> InsertProducto(Producto producto);
        Task<bool> UpdateProducto(Producto producto);
        Task<bool> DeleteProducto(int id);
    }
}