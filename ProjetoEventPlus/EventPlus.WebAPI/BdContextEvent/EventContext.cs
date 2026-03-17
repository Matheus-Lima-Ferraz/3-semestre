using System;
using System.Collections.Generic;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.BdContextEvent;

public partial class EventContext : DbContext
{
    public EventContext()
    {
    }

    public EventContext(DbContextOptions<EventContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ComentarioEvento> ComentarioEventos { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Instituicao> Instituicaos { get; set; }

    public virtual DbSet<Presenca> Presencas { get; set; }

    public virtual DbSet<TipoEvento> TipoEventos { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EventPlus;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComentarioEvento>(entity =>
        {
            entity.HasKey(e => e.IdComentarioEvento).HasName("PK__Comentar__4305A1F146CD0958");

            entity.Property(e => e.IdComentarioEvento).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.ComentarioEventos).HasConstraintName("FK__Comentari__IdEve__76969D2E");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ComentarioEventos).HasConstraintName("FK__Comentari__IdUsu__75A278F5");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.IdEvento).HasName("PK__Evento__034EFC04723949BA");

            entity.Property(e => e.IdEvento).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdTipoEventoNavigation).WithMany(p => p.Eventos).HasConstraintName("FK__Evento__IdTipoEv__6C190EBB");

            entity.HasOne(d => d.IdinstituicaoNavigation).WithMany(p => p.Eventos).HasConstraintName("FK__Evento__Idinstit__6D0D32F4");
        });

        modelBuilder.Entity<Instituicao>(entity =>
        {
            entity.HasKey(e => e.IdInstituicao).HasName("PK__Institui__B771C0D8F13D93FB");

            entity.Property(e => e.IdInstituicao).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Presenca>(entity =>
        {
            entity.HasKey(e => e.IdPresenca).HasName("PK__Presenca__50FB6F5DE0D354BE");

            entity.Property(e => e.IdPresenca).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdEventoNavigation).WithMany(p => p.Presencas).HasConstraintName("FK__Presenca__IdEven__71D1E811");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Presencas).HasConstraintName("FK__Presenca__IdUsua__70DDC3D8");
        });

        modelBuilder.Entity<TipoEvento>(entity =>
        {
            entity.HasKey(e => e.IdTipoEvento).HasName("PK__TipoEven__CDB3A3BE05557181");

            entity.Property(e => e.IdTipoEvento).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__TipoUsua__CA04062BFFC86300");

            entity.Property(e => e.IdTipoUsuario).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97EAF32493");

            entity.Property(e => e.IdUsuario).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuarios).HasConstraintName("FK__Usuario__IdTipoU__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
