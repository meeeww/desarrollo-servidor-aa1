using BankAPI.Model;

namespace BankAPI.Data
{
    public interface IProductosRepository
    {
        List<Producto> GetProductos();
        Producto GetProductoById(int id);
        void InsertProducto(Producto producto);
        void UpdateProducto(Producto producto);
        void DeleteProducto(int id);
    }
}