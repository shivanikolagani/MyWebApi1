using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyWebApi1.Models;

public partial class MyWebApiContext : DbContext
{
    public MyWebApiContext()
    {
    }

    public MyWebApiContext(DbContextOptions<MyWebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SHIVANI\\SQLEXPRESS;Initial Catalog=MyWebApi;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId);

            entity.ToTable("Department");

            entity.Property(e => e.DeptId)
                .ValueGeneratedNever()
                .HasColumnName("DeptID");
            entity.Property(e => e.DeptName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId).ValueGeneratedNever();
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LibraryId).HasColumnName("Library_Id");

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK_Employee_Department");

            entity.HasOne(d => d.Library).WithMany(p => p.Employees)
                .HasForeignKey(d => d.LibraryId)
                .HasConstraintName("FK_Employee_Library");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.LibraryId).HasName("PK__Library__A55098316C12A07F");

            entity.ToTable("Library");

            entity.Property(e => e.LibraryId)
                .ValueGeneratedNever()
                .HasColumnName("Library_Id");
            entity.Property(e => e.LibraryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Library_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
