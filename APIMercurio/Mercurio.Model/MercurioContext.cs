using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mercurio.Model;

public partial class MercurioContext : DbContext
{
    public MercurioContext()
    {
    }

    public MercurioContext(DbContextOptions<MercurioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<DocumentNumber> DocumentNumbers { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ATENEA; DataBase=Mercurio; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__Category__79D361B654F2EB34");

            entity.ToTable("Category");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoryName");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.RegisDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("regisDate");
        });

        modelBuilder.Entity<DocumentNumber>(entity =>
        {
            entity.HasKey(e => e.IdDocumentNumer).HasName("PK__Document__A6067F54D2485A16");

            entity.ToTable("DocumentNumber");

            entity.Property(e => e.IdDocumentNumer).HasColumnName("idDocumentNumer");
            entity.Property(e => e.LastNumber).HasColumnName("lastNumber");
            entity.Property(e => e.RegisDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("regisDate");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__C26AF4831F2CF608");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("icon");
            entity.Property(e => e.MenuName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("menuName");
            entity.Property(e => e.UrlMenu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("urlMenu");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.IdMenuRol).HasName("PK__MenuRol__9D6D61A4366BFDF0");

            entity.ToTable("MenuRol");

            entity.Property(e => e.IdMenuRol).HasColumnName("idMenuRol");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__MenuRol__idMenu__3C69FB99");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__MenuRol__idRol__3D5E1FD2");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK___Product__5EEC79D1DF019CEC");

            entity.ToTable("_Product");

            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("productName");
            entity.Property(e => e.RegisDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("regisDate");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK___Product__idCate__48CFD27E");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F76589EDC0F");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.RegisDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("regisDate");
            entity.Property(e => e.RolName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rolName");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSale).HasName("PK__Sale__C4AEB19893195F20");

            entity.ToTable("Sale");

            entity.Property(e => e.IdSale).HasColumnName("idSale");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("documentNumber");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("paymentType");
            entity.Property(e => e.RegisDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("regisDate");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.IdSaleDetails).HasName("PK__SaleDeta__BD187EABD2DA1C57");

            entity.Property(e => e.IdSaleDetails).HasColumnName("idSaleDetails");
            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.IdSale).HasColumnName("idSale");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK__SaleDetai__idPro__5441852A");

            entity.HasOne(d => d.IdSaleNavigation).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.IdSale)
                .HasConstraintName("FK__SaleDetai__idSal__534D60F1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK___User__3717C982A047E208");

            entity.ToTable("_User");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.RegisDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("regisDate");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userName");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userPassword");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK___User__idRol__6754599E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
