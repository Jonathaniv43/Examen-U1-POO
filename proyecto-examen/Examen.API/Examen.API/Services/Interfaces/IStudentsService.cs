using Examen.API.Dtos.Students;

namespace Examen.API.Services.Interfaces
{
    public interface IStudentsService
    {
        Task<List<StudentDto>> GetStudentsListAsync();
        Task<StudentDto> GetStudentByIdAsync(Guid id);
        Task<bool> CreateAsync(StudentCreateDto dto);
        Task<bool> EditAsync(StudentEditDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
