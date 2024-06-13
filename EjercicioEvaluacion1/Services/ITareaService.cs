using EjercicioEvaluacion1.Data;
using EjercicioEvaluacion1.Models;

namespace EjercicioEvaluacion1.Services{
    public interface ITareaService{
        public Task<Tarea[]> GetAll();
        public Task<Tarea> GetById(int id);
        public Task Add(Tarea area);
        public Task Update(Tarea area);
        public Task Delete(int id);
        public Task DeleteSelection(Tarea[] tareas);
    }
}
