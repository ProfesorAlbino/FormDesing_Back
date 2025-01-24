using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FormDesing.Models.DB;

public partial class FormDesingContext : DbContext
{
    public FormDesingContext()
    {
    }

    public FormDesingContext(DbContextOptions<FormDesingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DatoFormulario> DatoFormularios { get; set; }

    public virtual DbSet<Formulario> Formularios { get; set; }

    public virtual DbSet<FormularioInput> FormularioInputs { get; set; }

    public virtual DbSet<TipoInput> TipoInputs { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=FormDesing.mssql.somee.com; Database=FormDesing; User Id=Jeykel8765_SQLLogin_1; Password=hbcgtvw67e; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatoFormulario>(entity =>
        {
            entity.HasKey(e => e.IdDatoFormulario).HasName("PK__DatoForm__B490F918F609B9C4");

            entity.ToTable("DatoFormulario");

            entity.Property(e => e.IdDatoFormulario).HasDefaultValueSql("(newid())");
            entity.Property(e => e.FechaIngreso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdFormularioInputNavigation).WithMany(p => p.DatoFormularios)
                .HasForeignKey(d => d.IdFormularioInput)
                .HasConstraintName("FK__DatoFormu__IdFor__656C112C");
        });

        modelBuilder.Entity<Formulario>(entity =>
        {
            entity.HasKey(e => e.IdFormulario).HasName("PK__Formular__090ED3C5100C64D2");

            entity.ToTable("Formulario");

            entity.Property(e => e.IdFormulario).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Formularios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Formulari__IdUsu__59063A47");
        });

        modelBuilder.Entity<FormularioInput>(entity =>
        {
            entity.HasKey(e => e.IdFormularioInput).HasName("PK__Formular__5424DFA72F143563");

            entity.ToTable("FormularioInput");

            entity.Property(e => e.IdFormularioInput).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Etiqueta).HasMaxLength(100);
            entity.Property(e => e.NombreInput).HasMaxLength(100);

            entity.HasOne(d => d.IdFormularioNavigation).WithMany(p => p.FormularioInputs)
                .HasForeignKey(d => d.IdFormulario)
                .HasConstraintName("FK__Formulari__IdFor__60A75C0F");

            entity.HasOne(d => d.IdTipoInputNavigation).WithMany(p => p.FormularioInputs)
                .HasForeignKey(d => d.IdTipoInput)
                .HasConstraintName("FK__Formulari__IdTip__619B8048");
        });

        modelBuilder.Entity<TipoInput>(entity =>
        {
            entity.HasKey(e => e.IdTipoInput).HasName("PK__TipoInpu__381F026D87A6F47B");

            entity.ToTable("TipoInput");

            entity.Property(e => e.IdTipoInput).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF973DD68A73");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A19FF40B4E9").IsUnique();

            entity.Property(e => e.IdUsuario).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
