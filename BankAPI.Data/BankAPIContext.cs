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

        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Pedidos)
            .WithOne(p => p.Cliente)
            .HasForeignKey(p => p.ID_Cliente);

        modelBuilder.Entity<DetallePedido>()
            .Property(p => p.ID_DetallePedido)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<DetallePedido>()
            .HasKey(pi => new { pi.ID_Pedido, pi.ID_Producto });

        modelBuilder.Entity<DetallePedido>()
            .HasOne(pi => pi.Pedido)
            .WithMany(p => p.DetallePedidos)
            .HasForeignKey(pi => pi.ID_Pedido);

        modelBuilder.Entity<DetallePedido>()
            .HasOne(pi => pi.Producto)
            .WithMany(i => i.DetallePedidos)
            .HasForeignKey(pi => pi.ID_Producto);

        modelBuilder.Entity<DetallePedido>()
            .Property(p => p.Subtotal)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<RegistroVentas>()
            .HasKey(pi => new { pi.ID_Empleado });

        modelBuilder.Entity<RegistroVentas>()
            .HasOne(pi => pi.Empleado)
            .WithMany(i => i.RegistroVentas)
            .HasForeignKey(pi => pi.ID_Empleado);

        modelBuilder.Entity<Empleado>()
            .Property(p => p.Salario)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Pedido>()
            .Property(p => p.Total).HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Producto>()
            .Property(p => p.Precio)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<RegistroVentas>()
            .Property(r => r.TotalCostos)
            .HasColumnType("decimal(11, 2)");
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<DetallePedido> DetallePedidos { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<RegistroVentas> RegistroVentas { get; set; }

}