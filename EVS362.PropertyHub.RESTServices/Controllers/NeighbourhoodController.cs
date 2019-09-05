using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS360.PropertyHub;
using EVS362.PropertyHub.RESTServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVS362.PropertyHub.RESTServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighbourhoodController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                NeighborhoodModel model = new PropertyAdvsHandler().GetNeighborhood(id).ToModel();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //GET   api/neighbourhood
        //GET   api/neighbourhood?id=1
        //GET   api/neighbourhood?city=1
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<NeighborhoodModel> models = new PropertyAdvsHandler().GetNeighborhoods().ToModelList();
                return Ok(models);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpPost]
        public IActionResult Post(NeighborhoodModel model)
        {
            try
            {
                Neighborhood entity = new PropertyAdvsHandler().AddNeighborhood(model.ToEntity());
                return Created($"/api/neighbourhood/{entity.Id}", entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //put <- Update
        [HttpPut("{id}")]
        public IActionResult Put(int id,NeighborhoodModel model)
        {
            try
            {
                Neighborhood entity = new PropertyAdvsHandler().UpdateNeighborhood(id, model.ToEntity());
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Neighborhood entity = new PropertyAdvsHandler().DeleteNeighborhood(id);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


    }
}