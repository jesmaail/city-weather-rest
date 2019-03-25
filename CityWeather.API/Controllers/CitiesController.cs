using System;
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

        [HttpPost]
        public ActionResult Add(string name)
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        public ActionResult Update(int id)
        {
            // Want the update data FromBody or in parameters?
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult Search(string name)
        {
            // Want to return multiple matches if applicable
            throw new NotImplementedException();
        }
    }
}
