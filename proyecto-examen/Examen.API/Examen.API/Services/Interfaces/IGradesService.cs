using Examen.API.Dtos.Grades;

namespace Examen.API.Services.Interfaces
{
    public interface IGradesService
    {
        Task<List<GradesDto>> GetStudentsListAsync();
        Task<GradesDto> GetStudentByIdAsync(Guid id);
        Task<bool> CreateAsync(GradesCreateDto dto);
        Task<bool> EditAsync(GradesEditDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
