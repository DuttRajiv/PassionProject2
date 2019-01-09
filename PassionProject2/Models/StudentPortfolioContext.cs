using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PassionProject2.Models
{
    public partial class StudentPortfolioContext : DbContext
    {
        public StudentPortfolioContext()
        {
        }

        public StudentPortfolioContext(DbContextOptions<StudentPortfolioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.;Database=StudentPortfolio;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.Property(e => e.AssignmentId).HasColumnName("assignmentID");

                entity.Property(e => e.AssignmentName)
                    .HasColumnName("assignmentName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Course)
                    .HasColumnName("course")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.GradeId)
                    .HasColumnName("gradeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AssignmentId).HasColumnName("assignmentID");

                entity.Property(e => e.Grade1).HasColumnName("grade");

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.Grade)
                    .HasForeignKey(d => d.AssignmentId)
                    .HasConstraintName("gradeFK");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("studentID");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.GradeId).HasColumnName("gradeID");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("studentFK");
            });
        }
    }
}
