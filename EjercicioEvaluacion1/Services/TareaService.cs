using EjercicioEvaluacion1.Data;
using EjercicioEvaluacion1.Models;
using Microsoft.EntityFrameworkCore;

namespace EjercicioEvaluacion1.Services{
    public class TareaService : ITareaService{
        private readonly IDbContextFactory<EjercicioDbContext> _context;

        public TareaService(IDbContextFactory<EjercicioDbContext> context) {
            _context = context;
        }

        public Task Add(Tarea area){
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSelection(Tarea[] tareas)
        {
            throw new NotImplementedException();
        }

        public Task<Tarea[]> GetAll(){
            using (var context = _context.CreateDbContext()) {
                return Task.FromResult(context.Tareas.Select(t => t).ToArray());
            }
        }

        public Task<Tarea> GetById(int id){
            using (var context = _context.CreateDbContext()) {
                return Task.FromResult(context.Tareas.Where(t => t.Id == id).First());
            }
        }

        public Task Update(Tarea area)
        {
            throw new NotImplementedException();
        }
    }
}
