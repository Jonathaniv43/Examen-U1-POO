using Examen.API.Database.Entities;
using Examen.API.Dtos.Students;
using Examen.API.Services.Interfaces;
using Newtonsoft.Json;
using static Examen.API.Services.StudentsService;

namespace Examen.API.Services
{
    public class StudentsService : IStudentsService
    {

            public readonly string _JSON_FILE;

            public StudentsService()
            {
                _JSON_FILE = "SeedData/students.json";
            }

            public async Task<List<StudentDto>> GetStudentsListAsync()
            {
                return await ReadStudentsFromFileAsync();
            }
            public async Task<StudentDto> GetStudentByIdAsync(Guid id)
            {
                var students = await ReadStudentsFromFileAsync();
                StudentDto student = students.FirstOrDefault(c => c.Id == id);
                return student;
            }
            public async Task<bool> CreateAsync(StudentCreateDto dto)
            {
                var studentsDtos = await ReadStudentsFromFileAsync();

                var studentDto = new StudentDto
                {
                    Id = Guid.NewGuid(),
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                };

                studentsDtos.Add(studentDto);

                var students = studentsDtos.Select(x => new Student
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                }).ToList();

                await WriteStudentsToFileAsync(students);

                return true;
            }
            public async Task<bool> EditAsync(StudentEditDto dto, Guid id)
            {
                var studentDto = await ReadStudentsFromFileAsync();

                var existingStudent = studentDto
                    .FirstOrDefault(student => student.Id == id);
                if (existingStudent is null)
                {
                    return false;
                }

                for (int i = 0; i < studentDto.Count; i++)
                {
                    if (studentDto[i].Id == id)
                    {
                        studentDto[i].FirstName = dto.FirstName;
                        studentDto[i].LastName = dto.LastName;
                    }
                }

                var students = studentDto.Select(x => new Student
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                }).ToList();

                await WriteStudentsToFileAsync(students);
                return true;
            }
            public async Task<bool> DeleteAsync(Guid id)
            {
                var studentsDto = await ReadStudentsFromFileAsync();
                var studentToDelete = studentsDto.FirstOrDefault(x => x.Id == id);

                if (studentToDelete is null)
                {
                    return false;
                }

                studentsDto.Remove(studentToDelete);

                var student = studentsDto.Select(x => new Student
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                }).ToList();

                await WriteStudentsToFileAsync(student);

                return true;
            }

            private async Task<List<StudentDto>> ReadStudentsFromFileAsync()
            {
                if (!File.Exists(_JSON_FILE))
                {
                    return new List<StudentDto>();
                }

                var json = await File.ReadAllTextAsync(_JSON_FILE);

                var students = JsonConvert.DeserializeObject<List<Student>>(json);

                var dtos = students.Select(x => new StudentDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                }).ToList();

                return dtos;
            }

            private async Task WriteStudentsToFileAsync(List<Student> categories)
            {
                var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

                if (File.Exists(_JSON_FILE))
                {
                    await File.WriteAllTextAsync(_JSON_FILE, json);
                }

            }

        }
    }

