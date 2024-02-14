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
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ID_Cliente);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
        });
        modelBuilder.Entity<DetallePedido>()
          .Property(p => p.Subtotal);

          modelBuilder.Entity<Empleado>()
           .Property(p => p.Salario)
           .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Pedido>()
           .Property(p => p.Total).HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Producto>()
           .Property(p => p.Precio)
           .HasColumnType("decimal(18,2)");
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<DetallePedido> DetallePedidos { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<RegistroVentas> RegistrosVentas { get; set; }

}