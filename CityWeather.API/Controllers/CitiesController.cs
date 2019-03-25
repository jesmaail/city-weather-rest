using System;
using CityWeather.Application;
using CityWeather.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityWeather.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        // TODO:
        // - SQL Connection
        // - Unit test
        // - Dependency Injection        
        // - Details FromBody or parameters?

        [HttpPost]
        public ActionResult Add([FromBody]CityDetails cityDetails)
        {
            var useCase = new AddCityUseCase();            
            useCase.Execute(cityDetails);
            return Ok();
        }

        [HttpPatch]
        public ActionResult Update(int id, [FromBody]CityDetails cityDetails)
        {
            var useCase = new UpdateCityUseCase();

            useCase.Execute(id, cityDetails);
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var useCase = new DeleteCityUseCase();
            useCase.Execute(id);
            return Ok();
        }

        [HttpGet]
        public ActionResult Search(string name)
        {
            // Want to return multiple matches if applicable
            throw new NotImplementedException();
        }
    }
}
