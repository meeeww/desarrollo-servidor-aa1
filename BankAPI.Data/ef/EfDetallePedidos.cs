using Microsoft.EntityFrameworkCore;
using BankAPI.Model;

namespace BankAPI.Data;

public class EfDetallePedidos : IDetallePedidosRepository
{
    private readonly BankAPIContext _context;

    public EfDetallePedidos(BankAPIContext context)
    {
        _context = context;
    }

    public List<DetallePedido> GetDetallesPedido()
    {
        return _context.DetallePedidos.ToList();
    }

    public DetallePedido GetDetallePedidoById(int id)
    {
        return _context.DetallePedidos.FirstOrDefault(detallePedido => detallePedido.ID_DetallePedido == id);
    }

    public void InsertDetallePedido(DetallePedido detallePedido)
    {
        _context.DetallePedidos.Add(detallePedido);
        SaveChanges();
    }

    public void UpdateDetallePedido(DetallePedido detallePedido)
    {
        _context.Entry(detallePedido).State = EntityState.Modified;
        SaveChanges();
    }

    public void DeleteDetallePedido(int id)
    {
        var detalle = _context.DetallePedidos.Find(id);
        if (detalle != null)
        {
            _context.DetallePedidos.Remove(detalle);
            SaveChanges();
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }


}
