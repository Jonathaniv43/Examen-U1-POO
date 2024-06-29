using Examen.API.Dtos.Students;
using System.ComponentModel.DataAnnotations;

namespace Examen.API.Dtos.Grades
{
    public class GradesCreateDto : StudentDto
    {
      

        [Display(Name = "Materia")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string Asignment { get; set; }

        [Display(Name = "Nota")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public double Grade { get; set; }
    }
}
