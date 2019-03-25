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
        // - Unit test
        // - Dependency Injection        
        // - Details FromBody or parameters?
        // - Validation on ratings etc.
        // - Try Catch code

        private readonly IDeleteCityUseCase _deleteCityUseCase;

        public CitiesController(IDeleteCityUseCase deleteCityUseCase)
        {
            _deleteCityUseCase = deleteCityUseCase;
        }

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
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            //var useCase = new DeleteCityUseCase();
            //useCase.Execute(id);
            _deleteCityUseCase.Execute(id);
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
