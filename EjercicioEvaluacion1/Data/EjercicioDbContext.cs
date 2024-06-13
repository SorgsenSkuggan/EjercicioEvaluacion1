using EjercicioEvaluacion1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EjercicioEvaluacion1.Data{
    public class EjercicioDbContext : DbContext{
        public EjercicioDbContext(DbContextOptions<EjercicioDbContext> options) : base(options) {
        }

        public virtual DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            ModelBuilderExtensions.Seed(modelBuilder);
        }

        public override void Dispose(){
            base.Dispose();
        }

        public override ValueTask DisposeAsync(){
            return base.DisposeAsync(); 
        }
    }

    public static class ModelBuilderExtensions {
        public static void Seed(this ModelBuilder modelBuilder) {
            int maxIndex = 100000;
            Tarea[] tareasSeeding = new Tarea[maxIndex];
            Random random = new Random();

            for (int i = 0; i < maxIndex; i++) {
                int estado = random.Next(0, 3);
                tareasSeeding[i] = new Tarea {
                    Id = i,
                    Descripcion = "Tarea nº" + i,
                    Estado = (Estado)estado
                };
            }

            modelBuilder.Entity<Tarea>().HasData(tareasSeeding);
        }
    }
}
