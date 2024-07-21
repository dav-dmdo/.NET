using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public People Get(int id) => Repository.People.First(p => p.Id == id);

        [HttpGet("search/{name}")]
        public People Get(string name) => 
            ;
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
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }


}
