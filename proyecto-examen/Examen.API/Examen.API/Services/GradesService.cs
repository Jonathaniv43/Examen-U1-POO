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

        public GradesService()
        {
            _JSON_FILE = "SeedData/grades.json";
        }
        public async Task<List<GradesDto>> GetGradesListAsync()
        {
            return await ReadGradesFromFileAsync();

        }

       
        public Task<bool> CreateAsync(GradesCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(GradesEditDto dto, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GradesDto> GetGradesByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        private async Task<List<GradesDto>> ReadGradesFromFileAsync()
        {
            if (!File.Exists(_JSON_FILE))
            {
                return new List<GradesDto>();
            }
            var json = await File.ReadAllTextAsync(_JSON_FILE);

            var grades = JsonConvert.DeserializeObject<List<Grades>>(json);
            {
                var dtos = grades.Select(x => new GradesDto
                {
                    Id = x.Id,
                    GradeId = x.GradeId,
                    Asignment = x.Asignment,
                    Grade = x.Grade,


                }).ToList();
                return dtos;

            }
        }

        
    } 
}
