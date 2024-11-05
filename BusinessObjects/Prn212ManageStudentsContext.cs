using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessObjects;

public partial class Prn212ManageStudentsContext : DbContext
{
    public Prn212ManageStudentsContext()
    {
    }

    public Prn212ManageStudentsContext(DbContextOptions<Prn212ManageStudentsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Assign> Assigns { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Mark> Marks { get; set; }

    public virtual DbSet<Rule> Rules { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentClass> StudentClasses { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=QCU;Database=PRN212_ManageStudents;User Id=cuong;Password=cuong1234;TrustServerCertificate=true;Trusted_Connection=SSPI;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PassWord)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Assign>(entity =>
        {
            entity.HasKey(e => new { e.Idteacher, e.Idsubject, e.NameClass, e.SchoolYear });

            entity.ToTable("Assign");

            entity.Property(e => e.Idteacher)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDTeacher");
            entity.Property(e => e.Idsubject)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDSubject");
            entity.Property(e => e.NameClass)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nameClass");
            entity.Property(e => e.SchoolYear)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("schoolYear");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => new { e.NameClass, e.SchoolYear });

            entity.ToTable("Class");

            entity.Property(e => e.NameClass)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nameClass");
            entity.Property(e => e.SchoolYear)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("schoolYear");
            entity.Property(e => e.Idteacher)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDTeacher");
        });

        modelBuilder.Entity<Mark>(entity =>
        {
            entity.HasKey(e => new { e.Semester, e.Idstudent, e.Idsubject, e.NameClass, e.SchoolYear }).HasName("PK_Mark_1");

            entity.ToTable("Mark");

            entity.Property(e => e.Semester)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Idstudent)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDStudent");
            entity.Property(e => e.Idsubject)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDSubject");
            entity.Property(e => e.NameClass)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nameClass");
            entity.Property(e => e.SchoolYear)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("schoolYear");
        });

        modelBuilder.Entity<Rule>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rule");

            entity.Property(e => e.MaxAge).HasColumnName("maxAge");
            entity.Property(e => e.MinAge).HasColumnName("minAge");
            entity.Property(e => e.PassScore).HasColumnName("passScore");
            entity.Property(e => e.TotalStudent).HasColumnName("totalStudent");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Idstudent);

            entity.ToTable("Student");

            entity.Property(e => e.Idstudent)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDStudent");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isActive");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PassWord)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StudentClass>(entity =>
        {
            entity.HasKey(e => new { e.Idstudent, e.NameClass, e.SchoolYear });

            entity.ToTable("Student_Class");

            entity.Property(e => e.Idstudent)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDStudent");
            entity.Property(e => e.NameClass)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nameClass");
            entity.Property(e => e.SchoolYear)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("schoolYear");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Idsubject);

            entity.ToTable("Subject");

            entity.Property(e => e.Idsubject)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDSubject");
            entity.Property(e => e.NameSubject).HasMaxLength(70);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Idteacher);

            entity.ToTable("Teacher");

            entity.Property(e => e.Idteacher)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDTeacher");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isActive");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PassWord)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TeacherSubject>(entity =>
        {
            entity.HasKey(e => new { e.Idteacher, e.Idsubject });

            entity.ToTable("Teacher_Subject");

            entity.Property(e => e.Idteacher)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDTeacher");
            entity.Property(e => e.Idsubject)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDSubject");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
