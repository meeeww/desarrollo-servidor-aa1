using BankAPI.Model;
namespace BankAPI.Data.Services;

public interface IProductoRepository
{
    Task<IEnumerable<Producto>> GetProductos();
    Task<Producto> GetProductoById(int id);
    Task<bool> InsertProducto(Producto producto);
    Task<bool> UpdateProducto(Producto producto);
    Task<bool> DeleteProducto(Producto producto);
}