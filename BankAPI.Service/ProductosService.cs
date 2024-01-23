using BankAPI.Data;
using BankAPI.Model;

namespace BankAPI.Services;

public class ProductosService
{
    private readonly IProductosRepository _productosRepository;

    public ProductosService(IProductosRepository productosRepository)
    {
        _productosRepository = productosRepository;
    }

    public Task<IEnumerable<Producto>> GetProductos()
    {
        return _productosRepository.GetProductos();
    }
    public Task<Producto> GetProductoById(int id)
    {
        return _productosRepository.GetProductoById(id);
    }
    public Task<bool> InsertProducto(Producto producto)
    {
        return _productosRepository.InsertProducto(producto);
    }
    public Task<bool> UpdateProducto(Producto producto)
    {
        return _productosRepository.UpdateProducto(producto);
    }
    public Task<bool> DeleteProducto(int id)
    {
        return _productosRepository.DeleteProducto(id);
    }



}