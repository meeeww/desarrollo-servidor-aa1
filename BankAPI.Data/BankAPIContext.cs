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

        modelBuilder.Entity<Cliente>().HasData(new Cliente
        {
            ID_Cliente = 1,
            Nombre = "Juan",
            Apellido = "Perez",
            Email = "juan.perez@example.com",
            Telefono = "1234567890",
            Direccion = "Calle Falsa 123"
        });

        // Sembrando datos para Producto
        modelBuilder.Entity<Producto>().HasData(new Producto
        {
            ID_Producto = 1,
            Nombre = "Laptop",
            Descripcion = "Una laptop muy potente",
            Precio = 1500.00M,
            Stock = 10,
            Imagen = "url_de_la_imagen"
        });

        // Sembrando datos para Empleado
        modelBuilder.Entity<Empleado>().HasData(new Empleado
        {
            ID_Empleado = 1,
            Nombre = "Ana",
            Apellido = "Gomez",
            Cargo = "Vendedor",
            Salario = 1000.00M,
            FechaEntrada = new DateTime(2020, 1, 1),
            FechaSalida = new DateTime(2020, 12, 31)
        });

        // Sembrando datos para Pedido (nota que necesita un Cliente existente)
        modelBuilder.Entity<Pedido>().HasData(new Pedido
        {
            ID_Pedido = 1,
            ID_Cliente = 1,
            Fecha = new DateTime(2021, 1, 1),
            Total = 2000.00M,
            Enviado = true,
            MetodoPago = "Tarjeta"
        });

        // Sembrando datos para DetallePedido (nota que necesita un Pedido y Producto existentes)
        modelBuilder.Entity<DetallePedido>().HasData(new DetallePedido
        {
            ID_DetallePedido = 1,
            ID_Pedido = 1,
            ID_Producto = 1,
            Cantidad = 2,
            Subtotal = 3000.00M,
            FechaCreacion = new DateTime(2021, 1, 1),
            FechaModificacion = new DateTime(2021, 1, 2)
        });

        // Sembrando datos para RegistroVentas (nota que necesita un Empleado existente)
        modelBuilder.Entity<RegistroVentas>().HasData(new RegistroVentas
        {
            ID_RegistroVentas = 1,
            ID_Empleado = 1,
            Fecha = new DateTime(2021, 1, 1),
            TotalVentas = 100,
            TotalCostos = 50,
            TotalImpuestos = 20
        });
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<DetallePedido> DetallePedidos { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<RegistroVentas> RegistrosVentas { get; set; }
}
