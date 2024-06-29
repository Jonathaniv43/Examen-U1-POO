using System.ComponentModel.DataAnnotations;

namespace Examen.API.Database.Entities
{
    public class Grades
    {
        public Guid Id { get; set; }

        public Guid GradeId { get; set; }

        [Display(Name = "Materia")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string Asignment { get; set; }

        [Display(Name = "Nota")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public double Grade { get; set; }
    }
}
