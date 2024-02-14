using BankAPI.Data;
using BankAPI.Model;
using MySqlX.XDevAPI;

namespace BankAPI.Services
{ 
    public class ProductosService
    {
        private readonly IProductosRepository _productosRepository;

        public ProductosService(IProductosRepository productosRepository)
        {
            _productosRepository = productosRepository;
        }

        public List<Producto> GetProductos()
        {
            return _productosRepository.GetProductos();
        }
        public Producto GetProductoById(int id)
        {
            return _productosRepository.GetProductoById(id);
        }
        public Producto InsertProducto(Producto producto)
        {
            _productosRepository.InsertProducto(producto);

            return producto;
        }
        public void UpdateProducto(Producto producto)
        {
            _productosRepository.UpdateProducto(producto);
        }
        public void DeleteProducto(int id)
        {
            _productosRepository.DeleteProducto(id);
        }
    }
}