using Microsoft.EntityFrameworkCore;
using CUR.Api.Models;

namespace CUR.Api.Data
{
    public class CurDbContext : DbContext
    {
        public CurDbContext(DbContextOptions<CurDbContext> options) : base(options)
        {
        }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<PlanEstudio> PlanesEstudio { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Modalidad> Modalidades { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<TipoDocente> TiposDocente { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<NumeroEncuentro> NumerosEncuentro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Alumno>()
                .HasOne(a => a.Carrera)
                .WithMany()
                .HasForeignKey(a => a.CarreraId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Alumno>()
                .HasOne(a => a.Direccion)
                .WithMany()
                .HasForeignKey(a => a.DireccionId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Alumno>()
                .HasOne(a => a.Genero)
                .WithMany()
                .HasForeignKey(a => a.GeneroId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Alumno>()
                .HasOne(a => a.NumeroEncuentro)
                .WithMany()
                .HasForeignKey(a => a.NumeroEncuentroId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
