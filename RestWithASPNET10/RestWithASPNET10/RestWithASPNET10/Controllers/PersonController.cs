using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Model;
using RestWithASPNET10.Services;

namespace RestWithASPNET10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController(IPersonServices personServices) : ControllerBase
    {
        private readonly IPersonServices _personService = personServices;

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            var person = _personService.FindById(id);

            if (person is null) return NotFound($"Pessoa com Id {id} não encontrada.");

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            var createdPerson = _personService.Create(person);

            if (createdPerson is null) return BadRequest("Ocorreu uma falha ao criar a pessoa.");

            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            var updatedPerson = _personService.Update(person);

            if (updatedPerson is null) return BadRequest("Ocorreu uma falha ao criar a pessoa.");

            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var person = _personService.FindById(id);

            if (person is null) return NotFound($"Pessoa com Id {id} não encontrada.");

            _personService.Delete(person.Id);

            return NoContent();
        }
    }
}
