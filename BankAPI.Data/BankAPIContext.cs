using Microsoft.EntityFrameworkCore;
using BankAPI.Model;

namespace BankAPI.Data;

public class BankAPIContext : DbContext
{
    public BankAPIContext(DbContextOptions<BankAPIContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Ejemplo de configuración para la entidad Cliente
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ID_Cliente);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            // Agregar más configuraciones según sea necesario
        });

        // Configuraciones adicionales para otras entidades
        // Repetir el patrón para DetallePedidos, Empleados, Pedidos, Productos, RegistrosVentas, etc.
    }


    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<DetallePedido> DetallePedidos { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<RegistroVentas> RegistrosVentas { get; set; }
}