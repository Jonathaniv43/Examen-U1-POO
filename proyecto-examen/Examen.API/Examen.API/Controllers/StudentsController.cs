using Examen.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.API.Controllers
{
    [ApiController]
    [Route("api/students")]
    
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            this._studentsService = studentsService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _studentsService.GetStudentsListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var student = await _studentsService.GetStudentByIdAsync(id);
            

            if (student == null)
            {
                return NotFound(new { Message = $"No se encontro el estudiante: {id}" });
            }

            return Ok(student);


        }
    }
}
