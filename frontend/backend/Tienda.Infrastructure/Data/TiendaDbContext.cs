using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Domain.Entities;

namespace Tienda.Infrastructure.Data;

public class TiendaDbContext : DbContext
{
    public TiendaDbContext(DbContextOptions<TiendaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<DetalleVenta> DetallesVenta { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<ProductoProveedor> ProductoProveedores { get; set; }
    public DbSet<Stock> Stocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // --- MAPEO EXACTO A LAS TABLAS DE TU SQL ---
        modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        modelBuilder.Entity<Rol>().ToTable("Roles");
        modelBuilder.Entity<Producto>().ToTable("Productos");
        modelBuilder.Entity<Venta>().ToTable("Ventas");
        modelBuilder.Entity<DetalleVenta>().ToTable("Detalle_Venta"); // Arregla el error de "DetallesVenta"
        modelBuilder.Entity<Proveedor>().ToTable("Proveedores");
        modelBuilder.Entity<ProductoProveedor>().ToTable("Producto_Proveedor"); // Arregla el de "ProductoProveedores"
        modelBuilder.Entity<Stock>().ToTable("Stock"); // Arregla el de "Stocks"
        // -------------------------------------------

        modelBuilder.Entity<DetalleVenta>()
            .HasKey(dv => dv.IdDetalleVenta);

        modelBuilder.Entity<Producto>()
            .HasKey(p => p.IdProducto);

        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Rol)
            .WithMany(r => r.Usuarios)
            .HasForeignKey(u => u.IdRol);

        modelBuilder.Entity<Producto>()
            .HasOne(p => p.Stock)
            .WithOne(s => s.Producto)
            .HasForeignKey<Stock>(s => s.IdProducto);

        modelBuilder.Entity<ProductoProveedor>()
            .HasOne(pp => pp.Producto)
            .WithMany(p => p.ProductoProveedores)
            .HasForeignKey(pp => pp.IdProducto);

        modelBuilder.Entity<ProductoProveedor>()
            .HasOne(pp => pp.Proveedor)
            .WithMany(p => p.ProductoProveedores)
            .HasForeignKey(pp => pp.IdProveedor);

        modelBuilder.Entity<Venta>()
            .HasOne(v => v.Usuario)
            .WithMany()
            .HasForeignKey(v => v.IdUsuario);


        modelBuilder.Entity<DetalleVenta>()
            .HasOne(dv => dv.Venta)
            .WithMany(v => v.Detalles)
            .HasForeignKey(dv => dv.IdVenta);

        modelBuilder.Entity<DetalleVenta>()
            .HasOne(dv => dv.Producto)
            .WithMany(p => p.DetallesVenta)
            .HasForeignKey(dv => dv.IdProducto);
    }
}