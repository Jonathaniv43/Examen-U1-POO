using Examen.API.Dtos.Students;
using System.ComponentModel.DataAnnotations;

namespace Examen.API.Dtos.Grades
{
    public class GradesDto 
    {
        public Guid Id { get; set; }

        public Guid GradeId { get; set; }
        public string Asignment { get; set; }
        public double Grade { get; set; }
    }
}
