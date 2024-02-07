using Microsoft.EntityFrameworkCore;
using BankAPI.Model;

namespace BankAPI.Data;

public class EfClientesRepository : IClientesRepository
{
    private readonly BankAPIContext _context;

    public EfClientesRepository(BankAPIContext context)
    {
        _context = context;
    }

    public List<Cliente> GetClientes()
    {
        return _context.Clientes.ToList();
    }

    public Cliente GetClienteById(int id)
    {
        return _context.Clientes.FirstOrDefault(cliente => cliente.ID_Cliente == id);
    }

    public Cliente GetClienteByEmail(string email)
    {
        return _context.Clientes.FirstOrDefault(cliente => cliente.Email == email);
    }

    public void InsertCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        SaveChanges();
    }

    public void UpdateCliente(Cliente cliente)
    {
        _context.Entry(cliente).State = EntityState.Modified;
        SaveChanges();
    }

    public void DeleteCliente(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            SaveChanges();
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
