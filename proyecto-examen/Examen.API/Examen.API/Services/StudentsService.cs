using Examen.API.Database.Entities;
using Examen.API.Dtos.Students;
using Examen.API.Services.Interfaces;
using Newtonsoft.Json;

namespace Examen.API.Services
{
    public class StudentsService : IStudentsService
    {
        public readonly string _JSON_FILE;

        public StudentsService()
        {
            _JSON_FILE = "SeedData/students.json";
        }
        public async Task<StudentDto> GetStudentByIdAsync(Guid id)
        {

            var students = await ReadStudentsFromFileAsync();
            StudentDto student = students.FirstOrDefault(c => c.Id == id);
            return student;

        }

        public async Task<List<StudentDto>> GetStudentsListAsync()
        {
            return await ReadStudentsFromFileAsync();

        }
        public Task<bool> CreateAsync(StudentCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(StudentEditDto dto, Guid id)
        {
            throw new NotImplementedException();
        }


        private async Task<List<StudentDto>> ReadStudentsFromFileAsync()
        {
            if (!File.Exists(_JSON_FILE))
            {
                return new List<StudentDto>();
            }

            var json = await File.ReadAllTextAsync(_JSON_FILE);

            var students = JsonConvert.DeserializeObject<List<Student>>(json);
            {
                var dtos = students.Select(x => new StudentDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                }).ToList();
                return dtos;


            }

        }
    }
}
