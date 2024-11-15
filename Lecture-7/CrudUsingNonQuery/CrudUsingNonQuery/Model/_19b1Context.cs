using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudUsingNonQuery.Model;

public partial class _19b1Context : DbContext
{
    public _19b1Context()
    {
    }

    public _19b1Context(DbContextOptions<_19b1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<MisCourse> MisCourses { get; set; }

    public virtual DbSet<MisStudent> MisStudents { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<VwStudentCourseInnerJoin> VwStudentCourseInnerJoins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(" Server= localhost;Database=19B1;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MisCourse>(entity =>
        {
            entity.ToTable("mis_Courses");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CourseDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MisStudent>(entity =>
        {
            entity.ToTable("mis_Students");

            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Test__3214EC0718AF9A5E");

            entity.ToTable("Test");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<VwStudentCourseInnerJoin>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_StudentCourseInnerJoin");

            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.Cid).HasColumnName("CID");
            entity.Property(e => e.CourseDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
