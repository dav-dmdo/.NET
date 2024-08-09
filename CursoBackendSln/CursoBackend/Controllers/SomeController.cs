using CursoBackend.Services.Interfaces;
using System.Diagnostics;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController:ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Thread.Sleep(1000);
            Console.WriteLine("Request a DB");

            Thread.Sleep(1000);
            Console.WriteLine("Request a API");

            Thread.Sleep(1000);
            Console.WriteLine("Usar las dos Request");

            stopwatch.Stop();

            return Ok(stopwatch.Elapsed);
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var task1 = new Task<int>(() => {
                Thread.Sleep(1000);
                System.Console.WriteLine("Dentro del Task 1.");
                return 1;
            });

            var task2 = new Task<int>(() => {
                Thread.Sleep(1000);
                System.Console.WriteLine("Dentro del Task 2.");
                return 2 ;
            });

            task1.Start();
            task2.Start();

            System.Console.WriteLine("Fuera del task");

            int res1 = await task1;
            int res2 = await task2;

            System.Console.WriteLine("Termino el metodo");

            stopwatch.Stop();
            return Ok(res1 +" "+ res2 + " " + stopwatch.Elapsed);
        }
    }
}