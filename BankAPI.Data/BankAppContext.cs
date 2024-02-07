using Microsoft.EntityFrameworkCore;
using BankAPI.Model;

namespace BankAPI.Data;

public class BankAppContext : DbContext
{
    public BankAppContext(DbContextOptions<BankAppContext> options)
        : base(options)
    {

    }

    public DbSet<Cliente> Clientes { get; set; }
}