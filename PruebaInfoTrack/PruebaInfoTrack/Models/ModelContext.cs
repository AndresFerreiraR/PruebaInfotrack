using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace PruebaInfoTrack.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<Notas> Notas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=FERREIRA\\ACFERREIRADB;initial catalog=INFOTRACK;user id=sa;password=PruebaTecnica*2019;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("PK_IdAlumno");

                entity.ToTable("Alumno", "STD");

                entity.HasIndex(e => e.Identificacion)
                    .HasName("UQ__Alumno__D6F931E562703112")
                    .IsUnique();

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(18)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.IdMateria)
                    .HasName("PK_IdMateria");

                entity.ToTable("Materia", "ACMY");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Docente)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Notas>(entity =>
            {
                entity.HasKey(e => e.IdMateria)
                    .HasName("PK_IdEstudent");

                entity.ToTable("Notas", "NT");

                entity.Property(e => e.IdMateria).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdNota).ValueGeneratedOnAdd();

                entity.Property(e => e.Nota).HasColumnType("decimal(5, 3)");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Notas)
                    .HasForeignKey(d => d.IdEstudiante)
                    .HasConstraintName("FK_IdEstudent_Nota");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithOne(p => p.Notas)
                    .HasForeignKey<Notas>(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdMateria_Nota");
            });
        }
    }
}
