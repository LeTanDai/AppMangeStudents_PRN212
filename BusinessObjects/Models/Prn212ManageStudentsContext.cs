using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusinessObjects.Models;

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
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-ND49I6JT;\nDatabase=PRN212_ManageStudents;User Id=sa;Password=123;\nTrusted_Connection=SSPI;Encrypt=false;");

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
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Assign>(entity =>
        {
            entity.HasKey(e => e.AssignId).HasName("PK__Assign__A12B80732D649C89");

            entity.ToTable("Assign");

            entity.Property(e => e.AssignId).HasColumnName("assignID");
            entity.Property(e => e.Idsubject)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDSubject");
            entity.Property(e => e.Idteacher)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDTeacher");
            entity.Property(e => e.NameClass)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nameClass");
            entity.Property(e => e.SchoolYear)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("schoolYear");

            entity.HasOne(d => d.TeacherSubject).WithMany(p => p.Assigns)
                .HasForeignKey(d => new { d.Idteacher, d.Idsubject })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assign_Teacher_Subject");

            entity.HasOne(d => d.Class).WithMany(p => p.Assigns)
                .HasForeignKey(d => new { d.NameClass, d.SchoolYear })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assign_Class");
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

            entity.HasOne(d => d.IdsubjectNavigation).WithMany(p => p.Marks)
                .HasForeignKey(d => d.Idsubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mark_Subject");

            entity.HasOne(d => d.StudentClass).WithMany(p => p.Marks)
                .HasForeignKey(d => new { d.Idstudent, d.NameClass, d.SchoolYear })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mark_Student_Class");
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

            entity.HasOne(d => d.IdstudentNavigation).WithMany(p => p.StudentClasses)
                .HasForeignKey(d => d.Idstudent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Class_Student");

            entity.HasOne(d => d.Class).WithMany(p => p.StudentClasses)
                .HasForeignKey(d => new { d.NameClass, d.SchoolYear })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Class_Class");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Idsubject);

            entity.ToTable("Subject");

            entity.Property(e => e.Idsubject)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDSubject");
            entity.Property(e => e.NameSubject).HasMaxLength(100);
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

            entity.HasOne(d => d.IdsubjectNavigation).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.Idsubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_Subject_Subject");

            entity.HasOne(d => d.IdteacherNavigation).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.Idteacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teacher_Subject_Teacher");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
