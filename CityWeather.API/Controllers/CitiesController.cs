using CityWeather.Application.Interfaces;
using CityWeather.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CityWeather.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        // TODO:
        // - Rating => TouristRating

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
            try
            {
                _addCityUseCase.Execute(cityDetails);
            }
            catch(ArgumentException argumentEx)
            {
                return BadRequest(argumentEx.Data);
            }

            return Ok();
        }

        [HttpPatch]
        public ActionResult Update(int id, int rating, DateTime established, int estimatedPopulation)
        {
            try
            {
                _updateCityUseCase.Execute(id, rating, established, estimatedPopulation);
            }
            catch(ArgumentException argumentEx)
            {
                return BadRequest(argumentEx.Data);
            }

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
