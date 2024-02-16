using Microsoft.EntityFrameworkCore;
using BankAPI.Model;
using BankAPI.DTOs;

namespace BankAPI.Data;

public class EfRegistroVentasRepository : IRegistroVentasRepository
{
    private readonly BankAPIContext _context;

    public EfRegistroVentasRepository(BankAPIContext context)
    {
        _context = context;
    }

    public List<RegistroVentas> GetRegistrosVentas()
    {
        return _context.RegistroVentas.ToList();
    }

    public RegistroVentas GetRegistroVentasById(int id)
    {
        return _context.RegistroVentas.FirstOrDefault(registroVenta => registroVenta.ID_RegistroVentas== id);
    }

    public RegistroVentas GetRegistroVentasByIdEmpleado(int id)
    {
        return _context.RegistroVentas.FirstOrDefault(registroVenta => registroVenta.ID_Empleado == id);
    }

    public void InsertRegistroVentas(RegistroVentas registroVenta)
    {
        _context.RegistroVentas.Add(registroVenta);
        SaveChanges();
    }

    public void UpdateRegistroVentas(RegistroVentas registroVenta)
    {
        _context.Entry(registroVenta).State = EntityState.Modified;
        SaveChanges();
    }

    public void DeleteRegistroVentas(int id)
    {
        var registroVenta = _context.RegistroVentas.Find(id);
        if (registroVenta != null)
        {
            _context.RegistroVentas.Remove(registroVenta);
            SaveChanges();
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
