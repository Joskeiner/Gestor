using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Gestor.ENTITY.Models;

namespace Gestor.DAL;

public partial class DbBitwiseTraining2Context : DbContext
{
    public DbBitwiseTraining2Context()
    {
    }

    public DbBitwiseTraining2Context(DbContextOptions<DbBitwiseTraining2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Configuracion> Configuracione{ get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<Numerocorrelativo> NumeroCorreLativo { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Venta> Venta  { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categoria_pkey");

            entity.ToTable("categoria");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo).HasColumnName("esactivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
        });

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("configuracion");

            entity.Property(e => e.Propiedad)
                .HasMaxLength(50)
                .HasColumnName("propiedad");
            entity.Property(e => e.Recurso)
                .HasMaxLength(50)
                .HasColumnName("recurso");
            entity.Property(e => e.Valor)
                .HasMaxLength(60)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detalleventa_pkey");

            entity.ToTable("detalleventa");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CategoriaProducto)
                .HasMaxLength(100)
                .HasColumnName("categoriaproducto");
            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(100)
                .HasColumnName("descripcionproducto");
            entity.Property(e => e.MarcaProducto)
                .HasMaxLength(100)
                .HasColumnName("marcaproducto");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.ProductoId).HasColumnName("productoid");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");
            entity.Property(e => e.VentaId).HasColumnName("ventaid");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetallEventa)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("detalleventa_productoid_fkey");

            entity.HasOne(d => d.Venta).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.VentaId)
                .HasConstraintName("detalleventa_ventaid_fkey");
        });

        modelBuilder.Entity<Numerocorrelativo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("numerocorrelativo_pkey");

            entity.ToTable("numerocorrelativo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidaddigitos).HasColumnName("cantidaddigitos");
            entity.Property(e => e.Fechaactualizacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaactualizacion");
            entity.Property(e => e.Gestion)
                .HasMaxLength(100)
                .HasColumnName("gestion");
            entity.Property(e => e.Ultimonumero).HasColumnName("ultimonumero");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("producto_pkey");

            entity.ToTable("producto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categoriaid).HasColumnName("categoriaid");
            entity.Property(e => e.CodigoBarra)
                .HasMaxLength(50)
                .HasColumnName("codigobarra");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.Esactivo).HasColumnName("esactivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .HasColumnName("marca");
            entity.Property(e => e.NombreImagen)
                .HasMaxLength(100)
                .HasColumnName("nombreimagen");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(500)
                .HasColumnName("urlimagen");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Categoriaid)
                .HasConstraintName("producto_categoriaid_fkey");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("venta_pkey");

            entity.ToTable("venta");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DocumentoCliente)
                .HasMaxLength(10)
                .HasColumnName("documentocliente");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(20)
                .HasColumnName("nombrecliente");
            entity.Property(e => e.NumeroVenta)
                .HasMaxLength(6)
                .HasColumnName("numeroventa");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
