using Microsoft.EntityFrameworkCore;
using BankAPI.Model;

namespace BankAPI.Data;

public class BankAPIContext : DbContext
{
    public BankAPIContext(DbContextOptions<BankAPIContext> options)
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