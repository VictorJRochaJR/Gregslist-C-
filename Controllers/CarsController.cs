using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Gregslist.Models;
using Gregslist.Services;


namespace Gregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarsService _cs;
        public CarsController(CarsService cs)
        {
            _cs = cs;
        }
        [HttpGet]
        public List<Car> GetCars()
        {
            return _cs.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCar(int id)
        {
            try
            {
                var car = _cs.GetCarById(id);
                if (car == null)
                {
                    return BadRequest("Invald Id");
                }
                return Ok(car);
            }
            catch (System.Exception e)
            {   
                return Forbid(e.Message);
            }
        }
        [HttpPost]
        public ActionResult<Car> CreateCar([FromBody] Car carData)
        {
            try
            {
                var car = _cs.createCar(carData);
                return Created("api/cars/" + car.Id, car);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Car> DeleteCar(int id)
        {
            try
            {
                var car = _cs.removeCar(id);
                return Ok(car);     
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}