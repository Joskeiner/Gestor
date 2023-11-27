using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gestor.ENTITY.Models;

public partial class DbBitwiseTraining2Context : DbContext
{
    public DbBitwiseTraining2Context()
    {
    }

    public DbBitwiseTraining2Context(DbContextOptions<DbBitwiseTraining2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Configuracion> Configuracions { get; set; }

    public virtual DbSet<Detalleventum> Detalleventa { get; set; }

    public virtual DbSet<Numerocorrelativo> Numerocorrelativos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DbBitwiseTraining2;Username=postgres;Password=M2102J20");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categoria_pkey");

            entity.ToTable("categoria");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.Esactivo).HasColumnName("esactivo");
            entity.Property(e => e.Fecharegistro)
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

        modelBuilder.Entity<Detalleventum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detalleventa_pkey");

            entity.ToTable("detalleventa");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Categoriaproducto)
                .HasMaxLength(100)
                .HasColumnName("categoriaproducto");
            entity.Property(e => e.Descripcionproducto)
                .HasMaxLength(100)
                .HasColumnName("descripcionproducto");
            entity.Property(e => e.Marcaproducto)
                .HasMaxLength(100)
                .HasColumnName("marcaproducto");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Productoid).HasColumnName("productoid");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");
            entity.Property(e => e.Ventaid).HasColumnName("ventaid");

            entity.HasOne(d => d.Producto).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.Productoid)
                .HasConstraintName("detalleventa_productoid_fkey");

            entity.HasOne(d => d.Venta).WithMany(p => p.Detalleventa)
                .HasForeignKey(d => d.Ventaid)
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
            entity.Property(e => e.Codigobarra)
                .HasMaxLength(50)
                .HasColumnName("codigobarra");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.Esactivo).HasColumnName("esactivo");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .HasColumnName("marca");
            entity.Property(e => e.Nombreimagen)
                .HasMaxLength(100)
                .HasColumnName("nombreimagen");
            entity.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Urlimagen)
                .HasMaxLength(500)
                .HasColumnName("urlimagen");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Categoriaid)
                .HasConstraintName("producto_categoriaid_fkey");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("venta_pkey");

            entity.ToTable("venta");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Documentocliente)
                .HasMaxLength(10)
                .HasColumnName("documentocliente");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Nombrecliente)
                .HasMaxLength(20)
                .HasColumnName("nombrecliente");
            entity.Property(e => e.Numeroventa)
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
