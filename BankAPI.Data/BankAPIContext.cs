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
            .Property(p => p.Subtotal)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Empleado>()
            .Property(p => p.Salario)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Pedido>()
            .Property(p => p.Total)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Producto>()
            .Property(p => p.Precio)
            .HasColumnType("decimal(18,2)");

        // Relación Cliente-Pedido (uno a muchos)
        modelBuilder.Entity<Cliente>()
            .HasMany(c => c.Pedidos)
            .WithOne(p => p.Cliente)
            .HasForeignKey(p => p.ID_Cliente);

        // Relación Pedido-DetallePedido (uno a muchos)
        modelBuilder.Entity<Pedido>()
            .HasMany(p => p.DetallePedidos)
            .WithOne(dp => dp.Pedido)
            .HasForeignKey(dp => dp.ID_Pedido);

        // Relación Producto-DetallePedido (uno a muchos)
        modelBuilder.Entity<Producto>()
            .HasMany(pr => pr.DetallePedidos)
            .WithOne(dp => dp.Producto)
            .HasForeignKey(dp => dp.ID_Producto);

        // Relación Empleado-RegistroVentas (uno a muchos)
        modelBuilder.Entity<Empleado>()
            .HasMany(e => e.RegistroVentas)
            .WithOne(rv => rv.Empleado)
            .HasForeignKey(rv => rv.ID_Empleado);
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<DetallePedido> DetallePedidos { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<RegistroVentas> RegistrosVentas { get; set; }
}
