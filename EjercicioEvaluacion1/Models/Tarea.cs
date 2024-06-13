namespace EjercicioEvaluacion1.Models{
    public enum Estado { 
        Planificada = 0,
        Iniciada = 1,
        EnCurso = 2,
        Completada = 3
    }

    public class Tarea{
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public Estado Estado { get; set; }
    }
}