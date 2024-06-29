using Examen.API.Database.Entities;
using Examen.API.Dtos.Grades;
using Examen.API.Dtos.Students;
using Examen.API.Services.Interfaces;
using Newtonsoft.Json;

namespace Examen.API.Services
{
    public class GradesService : IGradesService
    {
        public readonly string _JSON_FILE;

        public Task<List<GradesDto>> GetStudentsListAsync()
        {
            if (!File.Exists(_JSON_FILE))
            {
                return new List<GradesDto>();
            }
            var json = await File.ReadAllTextAsync(_JSON_FILE);

            var students = JsonConvert.DeserializeObject<List<GradesDto>>(json);
            {
                var dtos = students.Select(x => new GradesDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    GradeId = x.GradeId,
                    Asignment = x.Asignment,
                    Grade = x.Grade,


                });.ToList();
                return dtos;
            }
        }

            public GradesService()
        {
            _JSON_FILE = "SeedData/students.json";
        }
        public Task<bool> CreateAsync(GradesCreateDto dto)
        {
            
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(GradesEditDto dto, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GradesDto> GetStudentByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        
        }
    }
}
