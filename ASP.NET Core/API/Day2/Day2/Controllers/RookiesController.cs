using Day2.Models;
using Day2.WebApp.Models;
using Day2.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Day2.WebApp.Areas.NashTech.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RookiesController : Controller
    {
        private readonly IPersonService _personService;

        public RookiesController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Person> people = _personService.GetAll();
            return Ok(people);
        }

        /// <summary>
        /// Create new person
        /// </summary>
        /// <param name="personDTO"></param>
        /// <returns></returns>
        /// <remarks>Format of DateOfBirth: dd/MM/yyyy</remarks>
        [HttpPost]
        public IActionResult Create([FromBody] PersonDTO personDTO)
        {
            if (!DateTime.TryParseExact(personDTO.DateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dob))
            {
                return BadRequest("Invalid date format. Please use dd/MM/yyyy format.");
            }

            var createdPerson = _personService.Create(personDTO);

            return CreatedAtAction(nameof(Create), new { id = createdPerson.Id }, createdPerson);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PersonDTO personDTO)
        {
            if (!DateTime.TryParseExact(personDTO.DateOfBirth, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dob))
            {
                return BadRequest("Invalid date format. Please use dd/MM/yyyy format.");
            }

            var result = _personService.Update(id, personDTO);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Detail(int id)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _personService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
