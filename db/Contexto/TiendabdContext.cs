using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using db.Modelos;

namespace db.Contexto;

public partial class TiendabdContext : DbContext
{
    public TiendabdContext()
    {
    }

    public TiendabdContext(DbContextOptions<TiendabdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditoriaProducto> AuditoriaProductos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Detalleing> Detalleings { get; set; }

    public virtual DbSet<Detalleventum> Detalleventa { get; set; }

    public virtual DbSet<Ingreso> Ingresos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Provee> Provees { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Tipoprod> Tipoprods { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Usuariorol> Usuariorols { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(local); Initial Catalog=TIENDABD; Integrated Security=True; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditoriaProducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__auditori__3213E83FF40DE46A");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK__CLIENTE__1EA344C2743BDBAF");

            entity.HasOne(d => d.IdpersonaNavigation).WithMany(p => p.Clientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CLIENTE__IDPERSO__47DBAE45");
        });

        modelBuilder.Entity<Detalleing>(entity =>
        {
            entity.HasKey(e => e.Iddetalleing).HasName("PK__DETALLEI__A9727BC239E24BA1");

            entity.ToTable("DETALLEING", tb => tb.HasTrigger("ACTUALIZARPRECIO"));

            entity.HasOne(d => d.IdingresoNavigation).WithMany(p => p.Detalleings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLEIN__IDING__5CD6CB2B");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.Detalleings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLEIN__IDPRO__5DCAEF64");
        });

        modelBuilder.Entity<Detalleventum>(entity =>
        {
            entity.HasKey(e => e.Iddetalleventa).HasName("PK__DETALLEV__BB16C854E824DAD2");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.Detalleventa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLEVE__IDPRO__59FA5E80");

            entity.HasOne(d => d.IdventaNavigation).WithMany(p => p.Detalleventa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLEVE__IDVEN__59063A47");
        });

        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.HasKey(e => e.Idingreso).HasName("PK__INGRESO__A9999DE3FE4F0A51");

            entity.HasOne(d => d.IdproveedorNavigation).WithMany(p => p.Ingresos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INGRESO__IDPROVE__4AB81AF0");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Idmarca).HasName("PK__MARCA__C8C2A4AAD1F2BD80");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Idpersona).HasName("PK__PERSONA__76CA73C8FE7E3014");

            entity.ToTable("PERSONA", tb => tb.HasTrigger("DELETECASCADA"));
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__PRODUCTO__7D8DC0F19CB6736D");

            entity.HasOne(d => d.IdmarcaNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCTO__IDMARC__52593CB8");

            entity.HasOne(d => d.IdtipoprodNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCTO__IDTIPO__5165187F");
        });

        modelBuilder.Entity<Provee>(entity =>
        {
            entity.HasKey(e => e.Idprovee).HasName("PK__PROVEE__A24D5EEA4186DD64");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.Provees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PROVEE__IDPRODUC__5535A963");

            entity.HasOne(d => d.IdproveedorNavigation).WithMany(p => p.Provees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PROVEE__IDPROVEE__5629CD9C");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Idproveedor).HasName("PK__PROVEEDO__4EB245E44359A5D3");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Idrol).HasName("PK__ROL__A686519E75606C52");
        });

        modelBuilder.Entity<Tipoprod>(entity =>
        {
            entity.HasKey(e => e.Idtipoprod).HasName("PK__TIPOPROD__B2DD7484459CC5C4");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__USUARIO__98242AA9B35749B3");

            entity.HasOne(d => d.IdpersonaNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USUARIO__IDPERSO__412EB0B6");
        });

        modelBuilder.Entity<Usuariorol>(entity =>
        {
            entity.HasKey(e => e.Idusuariorol).HasName("PK__USUARIOR__8546DCD9B99EE326");

            entity.HasOne(d => d.IdrolNavigation).WithMany(p => p.Usuariorols)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USUARIORO__IDROL__44FF419A");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Usuariorols)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USUARIORO__IDUSU__440B1D61");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.Idventa).HasName("PK__VENTA__2849CB577E005618");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VENTA__IDCLIENTE__4D94879B");

            entity.HasOne(d => d.IdvendedorNavigation).WithMany(p => p.Venta).HasConstraintName("FK__VENTA__IDVENDEDO__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
