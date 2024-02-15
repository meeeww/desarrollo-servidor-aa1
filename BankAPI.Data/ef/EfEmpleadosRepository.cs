using Microsoft.EntityFrameworkCore;
using BankAPI.Model;

namespace BankAPI.Data;

public class EfEmpleadosRepository : IEmpleadosRepository
{
    private readonly BankAPIContext _context;

    public EfEmpleadosRepository(BankAPIContext context)
    {
        _context = context;
    }

    public List<Empleado> GetEmpleados()
    {
        return _context.Empleados.ToList();
    }

    public Empleado GetEmpleadoById(int id)
    {
        return _context.Empleados.FirstOrDefault(empleado => empleado.ID_Empleado == id);
    }

    public void InsertEmpleado(Empleado empleado)
    {
        _context.Empleados.Add(empleado);
        SaveChanges();
    }

    public void UpdateEmpleado(Empleado empleado)
    {
        _context.Entry(empleado).State = EntityState.Modified;
        SaveChanges();
    }

    public void DeleteEmpleado(int id)
    {
        var empleado = _context.Empleados.Find(id);
        if (empleado != null)
        {
            _context.Empleados.Remove(empleado);
            SaveChanges();
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
