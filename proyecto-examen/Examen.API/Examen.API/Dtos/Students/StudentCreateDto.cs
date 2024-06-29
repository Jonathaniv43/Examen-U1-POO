using System.ComponentModel.DataAnnotations;

namespace Examen.API.Dtos.Students
{
    public class StudentCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string LastName { get; set; }
    }
}
