using Examen.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Examen.API.Controllers
{
    [ApiController]
    [Route("api/calificaciones")]
    public class GradesController: ControllerBase

    {
        private readonly IGradesService _gradesService;

        public GradesController(IGradesService gradesService)
        {
            this._gradesService = gradesService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _gradesService.GetGradesListAsync());
        }

    }
}
