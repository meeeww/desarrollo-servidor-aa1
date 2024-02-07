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
    public DbSet<DetallePedido> DetallePedidos { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<RegistroVentas> RegistrosVentas { get; set; }
}