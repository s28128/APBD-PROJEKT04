using Microsoft.AspNetCore.Mvc;
using Projekt.DB;
using Projekt.Models;

namespace Projekt.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalController : ControllerBase
{
       [HttpGet("")]
       public IActionResult GetAllAnimals()
       {
              return Ok(Db.Animals);
       }

       [HttpGet("{id}")]
       public IActionResult GetAnimalById(int id)
       {
              var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
              if (animal == null)
              {
                     return NotFound();
              }

              return Ok(animal);
       }

       [HttpPost]
       public IActionResult AddAnimal(Animal animal)
       {
              Db.Animals.Add(animal);
              return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
       }

       [HttpPut("{id}")]
       public IActionResult UpdateAnimal(int id, Animal updatedAnimal)
       {
              var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
              if (animal == null)
              {
                     return NotFound();
              }

              animal.Imie = updatedAnimal.Imie;
              animal.Masa = updatedAnimal.Masa;
              animal.Kolor_siersci = updatedAnimal.Kolor_siersci;
              animal.Kategoria = updatedAnimal.Kategoria;

              return NoContent();
       }

       [HttpDelete("{id}")]
       public IActionResult DeleteAnimal(int id)
       {
              var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
              if (animal == null)
              {
                     return NotFound();
              }

              Db.Animals.Remove(animal);
              return NoContent();
       }
       
}