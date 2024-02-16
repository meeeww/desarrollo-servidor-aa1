using Microsoft.EntityFrameworkCore;
using BankAPI.Model;
using BankAPI.DTOs;

namespace BankAPI.Data;

public class EfProductosRepository : IProductosRepository
{
    private readonly BankAPIContext _context;

    public EfProductosRepository(BankAPIContext context)
    {
        _context = context;
    }

    public List<Producto> GetProductos()
    {
        return _context.Productos.ToList();
    }

    public Producto GetProductoById(int id)
    {
        return _context.Productos.FirstOrDefault(producto => producto.ID_Producto == id);
    }

    public void InsertProducto(Producto producto)
    {
        _context.Productos.Add(producto);
        SaveChanges();
    }

    public void UpdateProducto(Producto producto)
    {
        _context.Entry(producto).State = EntityState.Modified;
        SaveChanges();
    }

    public void DeleteProducto(int id)
    {
        var producto = _context.Productos.Find(id);
        if (producto != null)
        {
            _context.Productos.Remove(producto);
            SaveChanges();
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
