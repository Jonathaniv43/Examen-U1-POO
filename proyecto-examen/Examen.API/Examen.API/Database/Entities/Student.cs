using System.ComponentModel.DataAnnotations;

namespace Examen.API.Database.Entities
{
    public class Student
    {
        public Guid Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El {0} de la categoría es requerido.")]
        public string LastName { get; set; }



    }
}
