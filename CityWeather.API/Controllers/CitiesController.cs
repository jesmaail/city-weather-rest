using CityWeather.Application.Interfaces;
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
        // - Validation on ratings etc.
        // - Try Catch code

        private readonly IAddCityUseCase _addCityUseCase;
        private readonly IDeleteCityUseCase _deleteCityUseCase;
        private readonly ISearchCityUseCase _searchCityUseCase;
        private readonly IUpdateCityUseCase _updateCityUseCase;

        public CitiesController(IAddCityUseCase addCityUsecase, IDeleteCityUseCase deleteCityUseCase, ISearchCityUseCase searchCityUseCase, IUpdateCityUseCase updateCityUseCase)
        {
            _addCityUseCase = addCityUsecase;
            _deleteCityUseCase = deleteCityUseCase;
            _searchCityUseCase = searchCityUseCase;
            _updateCityUseCase = updateCityUseCase;
        }

        [HttpPost]
        public ActionResult Add([FromBody]CityDetails cityDetails)
        {
            _addCityUseCase.Execute(cityDetails);
            return Ok();
        }

        [HttpPatch]
        public ActionResult Update(int id, [FromBody]CityDetails cityDetails)
        {
            _updateCityUseCase.Execute(id, cityDetails);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _deleteCityUseCase.Execute(id);
            return Ok();
        }

        [HttpGet]
        public ActionResult Search(string name)
        {
            var results = _searchCityUseCase.Execute(name);
            return new JsonResult(results);
        }
    }
}
