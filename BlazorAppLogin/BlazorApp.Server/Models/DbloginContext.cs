using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Models;

public partial class DbloginContext : DbContext
{
    public DbloginContext()
    {
    }

    public DbloginContext(DbContextOptions<DbloginContext> options)
        : base(options)
    {
    }

    public virtual DbSet<_User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<_User>(entity =>
        {
            entity.HasKey(e => e.id_User);

            entity.ToTable("_User");

            entity.Property(e => e.id_User).HasColumnName("id_User");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
