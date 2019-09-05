using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS360;
using EVS360.PropertyHub;
using EVS362.PropertyHub.RESTServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVS362.PropertyHub.RESTServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                CountryModel model = new LocationsHandler().GetCountry(id).ToModel();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //GET   api/Country
        //GET   api/Country?id=1
        //GET   api/Country?city=1
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<CountryModel> models = new LocationsHandler().GetCountries().ToModelList();
                return Ok(models);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //create
        [HttpPost]
        public IActionResult Post(CountryModel model)
        {
            try
            {
                Country entity = new LocationsHandler().AddCountry(model.ToEntity());
                return Created($"/api/Country/{entity.Id}", entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //put <- Update
        [HttpPut("{id}")]
        public IActionResult Put(int id, CountryModel model)
        {
            try
            {
                Country entity = new LocationsHandler().UpdateCountry(id, model.ToEntity());
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //delete the Countries
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Country entity = new LocationsHandler().DeleteCountry(id);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}