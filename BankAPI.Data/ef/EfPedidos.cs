using Microsoft.EntityFrameworkCore;
using BankAPI.Model;

namespace BankAPI.Data;

public class EfPedidos : IPedidosRepository
{
    private readonly BankAPIContext _context;

    public EfPedidos(BankAPIContext context)
    {
        _context = context;
    }

    public void DeletePedido(int id)
    {
        var pedido = _context.Pedidos.Find(id);
        if (pedido != null)
        {
            _context.Pedidos.Remove(pedido);
            SaveChanges();
        }
    }

    public Pedido GetPedidoByDate(DateTime fecha)
    {
        return _context.Pedidos.FirstOrDefault(pedido => pedido.Fecha == fecha);
    }

    public Pedido GetPedidoById(int id)
    {
        return _context.Pedidos.FirstOrDefault(pedido => pedido.ID_Pedido == id);
    }

    public List<Pedido> GetPedidos()
    {
        return _context.Pedidos.ToList();
    }

    public void InsertPedido(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void UpdatePedido(Pedido pedido)
    {
        _context.Entry(pedido).State = EntityState.Modified;
        SaveChanges();
    }
}
