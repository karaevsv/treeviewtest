using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace AvaloniaApplication2.Data;

public partial class RoadsContext : DbContext
{
    public RoadsContext()
    {
    }

    public RoadsContext(DbContextOptions<RoadsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Subdivision> Subdivisions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=roads;uid=root;pwd=12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.SubdivisionId, "a_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CabNum).HasMaxLength(10);
            entity.Property(e => e.LastName).HasMaxLength(45);

            entity.HasOne(d => d.Subdivision).WithMany(p => p.Employees)
                .HasForeignKey(d => d.SubdivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("a");
        });

        modelBuilder.Entity<Subdivision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subdivision");

            entity.HasIndex(e => e.SubdivisionId, "sub_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(45);

            entity.HasOne(d => d.SubdivisionNavigation).WithMany(p => p.InverseSubdivisionNavigation)
                .HasForeignKey(d => d.SubdivisionId)
                .HasConstraintName("sub");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
