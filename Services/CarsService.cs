using System;
using System.Collections.Generic;
using Gregslist.Data;
using Gregslist.Models;

namespace Gregslist.Services
{
    public class CarsService{
        public List<Car> GetAll()
        {
            return FakeDb.Cars;
        }
        public Car GetCarById(int id)
        {
        return FakeDb.Cars.Find(c => c.Id == id);
        }
        public Car createCar(Car carData)
        {
            var r = new Random();
            carData.Id = r.Next(1000, 99999);
            FakeDb.Cars.Add(carData);
            return carData;
             }
       public Car removeCar(int id)
       {
               var car = FakeDb.Cars.Find(c => c.Id == id);
               if (car == null)
               {
                   throw new Exception("Invalid id");
               }
               FakeDb.Cars.Remove(car);
               return car;
           }
    }
}