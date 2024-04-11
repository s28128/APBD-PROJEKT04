using Microsoft.AspNetCore.Mvc;
using Projekt.DB;
using Projekt.Models;
namespace Projekt.Controllers;

[ApiController]
[Route("api/visits")]
public class VisitsController : ControllerBase
{
        [HttpGet("{animalId}")]
        public IActionResult GetVisitsByAnimalId(int animalId)
        {
            var visits = Db.Visits.Where(v => v.IdAnimal == animalId).ToList();
            return Ok(visits);
        }

        [HttpPost]
        public IActionResult AddVisit(Appointment appointment)
        {
            Db.Visits.Add(appointment);
            return Created($"/api/visits/{appointment.Id}", appointment);
        }
}
