using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CursoBackend.Services.Interfaces;

namespace CursoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }

        [HttpPost]
        public decimal Sub(
            Numbers numbers, 
            [FromHeader] string Host, 
            [FromHeader(Name = "Content-Length")] string ContentLength,
            [FromHeader(Name = "X-Some")] string Some)
        {
            Console.WriteLine(Host);
            Console.WriteLine(ContentLength);
            Console.WriteLine(Some);
            return numbers.A - numbers.B;
        }

        [HttpPut]
        public decimal Mul(decimal a, decimal b)
        {
            return a * b;
        }

        [HttpDelete]   
        public decimal Div(decimal a, decimal b)
        {
            return a / b;
        }
    }

    public class Numbers
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
    }

}
