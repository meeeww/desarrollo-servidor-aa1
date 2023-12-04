using BankAPI.Model;
namespace BankAPI.Data.Services;

public interface IProductosRepository
{
    Task<IEnumerable<Productos>> GetProductos();
    Task<Productos> GetProductoById(int id);
    Task<bool> InsertProducto(Productos producto);
    Task<bool> UpdateProducto(Productos producto);
    Task<bool> DeleteProducto(Productos producto);
}