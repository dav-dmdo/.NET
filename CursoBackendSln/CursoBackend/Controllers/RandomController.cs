using CursoBackend.Services;
using CursoBackend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CursoBackend.Services.Interfaces;

namespace CursoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController:ControllerBase
    {
        private IRandomService _randomServiceSingleton;
        private IRandomService _randomService2Singleton;
        private IRandomService _randomServiceScoped;
        private IRandomService _randomService2Scoped;
        private IRandomService _randomServiceTransient;
        private IRandomService _randomService2Transient;

        public RandomController(
            [FromKeyedServices("randomSingleton")] IRandomService randomServiceSingleton,
            [FromKeyedServices("randomSingleton")] IRandomService randomService2Singleton,
            [FromKeyedServices("randomScoped")] IRandomService randomServiceScoped,
            [FromKeyedServices("randomScoped")] IRandomService randomService2Scoped,
            [FromKeyedServices("randomTransient")] IRandomService randomServiceTransient,
            [FromKeyedServices("randomTransient")] IRandomService randomService2Transient
        )
        {
            _randomServiceSingleton = randomServiceSingleton;
            _randomService2Singleton = randomService2Singleton;
            _randomServiceScoped = randomServiceScoped;
            _randomService2Scoped = randomService2Scoped;
            _randomServiceTransient = randomServiceTransient;
            _randomService2Transient = randomService2Transient;
        }

        [HttpGet]
        public ActionResult<Dictionary<string, int>> Get()
        {
            var result = new Dictionary<string, int>();
            
            result.Add("Singleton 1", this._randomServiceSingleton.Value);
            result.Add("Singleton 2", this._randomService2Singleton.Value);
            
            result.Add("Scoped 1", this._randomServiceScoped.Value);
            result.Add("Scoped 2", this._randomService2Scoped.Value);
            
            result.Add("Transient 1", this._randomServiceTransient.Value);
            result.Add("Transient 2", this._randomService2Transient.Value);

            return result;
        }
        
    }
    
}