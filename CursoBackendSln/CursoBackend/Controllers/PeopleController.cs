using CursoBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CursoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private IPeopleService _peopleService;

        public PeopleController([FromKeyedServices("peopleService")] IPeopleService peopleService) => _peopleService = peopleService;


        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id) { 
            var person = Repository.People.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound("No ta");
            }
            return Ok(person);
        }

        [HttpGet("search/{name}")]
        public List<People> Get(string name) => 
            Repository.People.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();

        [HttpPost]
        public IActionResult Add(People people)
        {
            
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }

            Repository.People.Add(people);

            return NoContent();
        }
    }

   

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People(){Id = 1, Name = "John", Birthdate = new DateTime(1990, 1, 1)},
            new People(){Id = 2, Name = "Mary", Birthdate = new DateTime(1991, 1, 1)},
            new People(){Id = 3, Name = "Peter", Birthdate = new DateTime(1992, 1, 1)},
            new People(){Id = 4, Name = "Paul", Birthdate = new DateTime(1993, 1, 1)},
        };

    }


    public class People
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Birthdate { get; set; }
    }


}
