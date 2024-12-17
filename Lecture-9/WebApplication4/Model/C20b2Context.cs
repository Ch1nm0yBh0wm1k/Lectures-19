using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Model;

public partial class C20b2Context : DbContext
{
    public C20b2Context()
    {
    }

    public C20b2Context(DbContextOptions<C20b2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Emp> Emps { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Std> Stds { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<VwGetStudentWithCourse> VwGetStudentWithCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=C20B2;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.InstructorName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Subject)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Emp>(entity =>
        {
            entity.ToTable("emp");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("product");
        });

        modelBuilder.Entity<Std>(entity =>
        {
            entity.ToTable("std");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sid).HasColumnName("SId");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("Teacher");
        });

        modelBuilder.Entity<VwGetStudentWithCourse>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_GetStudentWithCourses");

            entity.Property(e => e.InstructorName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
