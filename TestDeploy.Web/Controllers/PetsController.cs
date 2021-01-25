using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace TestDeploy.Web.Controllers
{
    [ApiController]
    [Route("/pets")]
    public class PetsController : ControllerBase
    {
        private static Pet[] Pets = new Pet[] {
            new Pet{ Name="Dog", TemperatureC=10, DOB= DateTime.Now}
         };

        private readonly ILogger<PetsController> _logger;

        public PetsController(ILogger<PetsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return Pets[id];
        }

        [HttpPost]
        public ActionResult<Pet> Post(Pet pet)
        {

            Pets.Append<Pet>(pet);
            Response.Headers.Add("htr", new StringValues($"/pets/{Pets.Length - 1}"));
            Response.StatusCode = 201;
            return pet;
        }
    }
}
