using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Usuario_control.Models;

public partial class ColegioPruebaContext : DbContext
{
    public ColegioPruebaContext()
    {
    }

    public ColegioPruebaContext(DbContextOptions<ColegioPruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<FaltaAsistencium> FaltaAsistencia { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Imparte> Impartes { get; set; }

    public virtual DbSet<InstitucionEducativa> InstitucionEducativas { get; set; }

    public virtual DbSet<Notum> Nota { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pertenece> Perteneces { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<Registra> Registras { get; set; }

    public virtual DbSet<Tutor> Tutors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAPTOP-HNTNC1IL;Database=COLEGIO_Prueba;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Ci).HasName("PK__ALUMNO__32149A7B2679922B");

            entity.ToTable("ALUMNO");

            entity.Property(e => e.Ci)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CI");
            entity.Property(e => e.AnoIngreso)
                .HasColumnType("date")
                .HasColumnName("Ano_Ingreso");
            entity.Property(e => e.ApellidoM)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Apellido_M");
            entity.Property(e => e.ApellidoP)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Apellido_P");
            entity.Property(e => e.CiTutor)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CI_Tutor");
            entity.Property(e => e.FechaNac)
                .HasColumnType("date")
                .HasColumnName("Fecha_Nac");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.CiTutorNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.CiTutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tutor_has_Alumno");
        });

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__ASIGNATU__06370DADE68A33DB");

            entity.ToTable("ASIGNATURA");

            entity.Property(e => e.Codigo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdCurso)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ID_Curso");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Asignaturas)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Curso_has_Asignatura");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CURSO__3214EC27143DCCBC");

            entity.ToTable("CURSO");

            entity.Property(e => e.Id)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Grado)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FaltaAsistencium>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FALTA_ASISTENCIA");

            entity.Property(e => e.CiAlumno)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CI_Alumno");
            entity.Property(e => e.ControlA)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Control_A");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Justificacion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NroClase)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Nro_Clase");

            entity.HasOne(d => d.CiAlumnoNavigation).WithMany()
                .HasForeignKey(d => d.CiAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Alumno_has_Falta_Asistencia");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__HORARIO__06370DAD7C147656");

            entity.ToTable("HORARIO");

            entity.Property(e => e.Codigo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Codigo_Asignatura");
            entity.Property(e => e.Dia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HoraIngreso).HasColumnName("Hora_Ingreso");
            entity.Property(e => e.HoraSalida).HasColumnName("Hora_Salida");

            entity.HasOne(d => d.CodigoAsignaturaNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.CodigoAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Asignatura_has_Horario");
        });

        modelBuilder.Entity<Imparte>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IMPARTE");

            entity.Property(e => e.CiProfesor)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CI_Profesor");
            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Codigo_Asignatura");
            entity.Property(e => e.Gestion).HasColumnType("date");

            entity.HasOne(d => d.CiProfesorNavigation).WithMany()
                .HasForeignKey(d => d.CiProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Profesor_has_Imparte");

            entity.HasOne(d => d.CodigoAsignaturaNavigation).WithMany()
                .HasForeignKey(d => d.CodigoAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Asignatura_has_Imparte");
        });

        modelBuilder.Entity<InstitucionEducativa>(entity =>
        {
            entity.HasKey(e => e.CodigoRue).HasName("PK__INSTITUC__DB4E5A240BE9B822");

            entity.ToTable("INSTITUCION_EDUCATIVA");

            entity.Property(e => e.CodigoRue)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Codigo_RUE");
            entity.Property(e => e.Contactos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaFun)
                .HasColumnType("date")
                .HasColumnName("Fecha_Fun");
            entity.Property(e => e.NombreRs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_RS");
        });

        modelBuilder.Entity<Notum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("NOTA");

            entity.Property(e => e.CiAlumno)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CI_Alumno");
            entity.Property(e => e.CodigoAsignatura)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Codigo_Asignatura");
            entity.Property(e => e.Gestion).HasColumnType("date");
            entity.Property(e => e.Periodo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.CiAlumnoNavigation).WithMany()
                .HasForeignKey(d => d.CiAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Alumno_has_Nota");

            entity.HasOne(d => d.CodigoAsignaturaNavigation).WithMany()
                .HasForeignKey(d => d.CodigoAsignatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Asignatura_has_Nota");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PAGO__3214EC27B637ED3A");

            entity.ToTable("PAGO");

            entity.Property(e => e.Id)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Detalle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pertenece>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PERTENECE");

            entity.Property(e => e.CiAlumno)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CI_Alumno");
            entity.Property(e => e.Gestion).HasColumnType("date");
            entity.Property(e => e.IdCurso)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ID_Curso");

            entity.HasOne(d => d.CiAlumnoNavigation).WithMany()
                .HasForeignKey(d => d.CiAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Alumno_has_Pertenece");

            entity.HasOne(d => d.IdCursoNavigation).WithMany()
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Curso_has_Pertenece");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.Ci).HasName("PK__PROFESOR__32149A7B952703F6");

            entity.ToTable("PROFESOR");

            entity.Property(e => e.Ci)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CI");
            entity.Property(e => e.ApellidoM)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Apellido_M");
            entity.Property(e => e.ApellidoP)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Apellido_P");
            entity.Property(e => e.CorreoE)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Correo_E");
            entity.Property(e => e.Domicilio)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Profecion)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Sueldo).HasColumnType("money");
        });

        modelBuilder.Entity<Registra>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("REGISTRA");

            entity.Property(e => e.CiAlumno)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CI_Alumno");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.IdPago)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ID_Pago");
            entity.Property(e => e.Medio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("money");

            entity.HasOne(d => d.CiAlumnoNavigation).WithMany()
                .HasForeignKey(d => d.CiAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Alumno_has_Registra");

            entity.HasOne(d => d.IdPagoNavigation).WithMany()
                .HasForeignKey(d => d.IdPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Asignatura_has_registra");

            entity.HasOne(d => d.IdPago1).WithMany()
                .HasForeignKey(d => d.IdPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pago_has_Registra");
        });

        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.HasKey(e => e.Ci).HasName("PK__TUTOR__32149A7B3AFA49B0");

            entity.ToTable("TUTOR");

            entity.Property(e => e.Ci)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CI");
            entity.Property(e => e.ApellidoM)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Apellido_M");
            entity.Property(e => e.ApellidoP)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Apellido_P");
            entity.Property(e => e.CorreoE)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Correo_E");
            entity.Property(e => e.Domicilio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Parentesco)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
