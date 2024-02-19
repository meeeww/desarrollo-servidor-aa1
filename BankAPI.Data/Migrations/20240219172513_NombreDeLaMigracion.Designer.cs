﻿// <auto-generated />
using System;
using BankAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankAPI.Data.Migrations
{
    [DbContext(typeof(BankAPIContext))]
    [Migration("20240219172513_NombreDeLaMigracion")]
    partial class NombreDeLaMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BankAPI.Model.Cliente", b =>
                {
                    b.Property<int>("ID_Cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Cliente"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Cliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("BankAPI.Model.DetallePedido", b =>
                {
                    b.Property<int>("ID_Pedido")
                        .HasColumnType("int");

                    b.Property<int>("ID_Producto")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_DetallePedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_DetallePedido"));

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ID_Pedido", "ID_Producto");

                    b.HasIndex("ID_Producto");

                    b.ToTable("DetallePedidos");
                });

            modelBuilder.Entity("BankAPI.Model.Empleado", b =>
                {
                    b.Property<int>("ID_Empleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Empleado"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID_Empleado");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("BankAPI.Model.Pedido", b =>
                {
                    b.Property<int>("ID_Pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Pedido"));

                    b.Property<bool>("Enviado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Cliente")
                        .HasColumnType("int");

                    b.Property<string>("MetodoPago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID_Pedido");

                    b.HasIndex("ID_Cliente");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("BankAPI.Model.Producto", b =>
                {
                    b.Property<int>("ID_Producto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Producto"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ID_Producto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("BankAPI.Model.RegistroVentas", b =>
                {
                    b.Property<int>("ID_RegistroVentas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_RegistroVentas"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_Empleado")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCostos")
                        .HasColumnType("decimal(11, 2)");

                    b.Property<int>("TotalImpuestos")
                        .HasColumnType("int");

                    b.Property<int>("TotalVentas")
                        .HasColumnType("int");

                    b.HasKey("ID_RegistroVentas");

                    b.HasIndex("ID_Empleado");

                    b.ToTable("RegistroVentas");
                });

            modelBuilder.Entity("BankAPI.Model.DetallePedido", b =>
                {
                    b.HasOne("BankAPI.Model.Pedido", "Pedido")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("ID_Pedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankAPI.Model.Producto", "Producto")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("ID_Producto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("BankAPI.Model.Pedido", b =>
                {
                    b.HasOne("BankAPI.Model.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ID_Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("BankAPI.Model.RegistroVentas", b =>
                {
                    b.HasOne("BankAPI.Model.Empleado", "Empleado")
                        .WithMany("RegistroVentas")
                        .HasForeignKey("ID_Empleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("BankAPI.Model.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("BankAPI.Model.Empleado", b =>
                {
                    b.Navigation("RegistroVentas");
                });

            modelBuilder.Entity("BankAPI.Model.Pedido", b =>
                {
                    b.Navigation("DetallePedidos");
                });

            modelBuilder.Entity("BankAPI.Model.Producto", b =>
                {
                    b.Navigation("DetallePedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
