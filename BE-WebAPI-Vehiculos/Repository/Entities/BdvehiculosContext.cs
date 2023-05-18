using System;
using System.Collections.Generic;
using BE_WebAPI_Vehiculos.Common.Models;
using BE_WebAPI_Vehiculos.Repository.Entities.Vistas;
using Microsoft.EntityFrameworkCore;

namespace BE_WebAPI_Vehiculos.Repository.Entities;

public partial class BdvehiculosContext : DbContext
{
    public BdvehiculosContext()
    {
    }

    public BdvehiculosContext(DbContextOptions<BdvehiculosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Combustible> Combustibles { get; set; }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<Entities.Vistas.VistaVehiculos> VistaVehiculosLista { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=BDVehiculos;Trusted_Connection=True;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Combustible>(entity =>
        {
            entity.ToTable("Combustible");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");
            entity.Property(e => e.Monto).HasColumnName("monto");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Marca");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Modelo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdMarca).HasColumnName("idMarca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoVehiculo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TipoVehiculo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.ToTable("Vehiculo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Combustible)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("combustible");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.IdModelo).HasColumnName("idModelo");
            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.Patente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("patente");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });
        

        modelBuilder.Entity<Entities.Vistas.VistaVehiculos>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaVehiculosLista");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.IdModelo).HasColumnName("idModelo");
            entity.Property(e => e.IdMarca).HasColumnName("IdMarca");
            entity.Property(e => e.Combustible).HasColumnName("combustible");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Patente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("patente");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Modelo");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TipoVehiculo");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Marca");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDetalle).HasColumnName("idDetalle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
