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
        public ActionResult<List<Car>> GetCars()
        {
            try
            {
                var cars = _cs.GetAll();
                return Ok(cars);
            }
            catch (System.Exception e)
            {
                
                return BadRequest(e.Message);
            }
            
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
                var car = _cs.CreateCar(carData);
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

        [HttpPut("{id}")]
        
        public ActionResult<Car> EditCar([FromBody] Car carData, int id)
        {
            try
            {
                 Car car  = _cs.updateCar(carData, id);
                return Ok(car);
            }
            catch (System.Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }
    }
}