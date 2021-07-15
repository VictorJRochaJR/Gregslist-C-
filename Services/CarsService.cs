using System;
using System.Collections.Generic;
using Gregslist.Data;
using Gregslist.Models;

namespace Gregslist.Services
{
    public class CarsService
    {
        private readonly CarsRepository  _carsRepo;

        public CarsService(CarsRepository carsRepo)
        {
            _carsRepo = carsRepo;
        }



        public List<Car> GetAll()
        {
            return _carsRepo.GetAll();
        }

        public Car CreateCar(Car carData
        ){
            return _carsRepo.Create(carData);
        }
        public Car GetCarById(int id)
        {
        return FakeDb.Cars.Find(c => c.Id == id);
        }
        // public Car createCar(Car carData)
        // {
        //     var r = new Random();
        //     carData.Id = r.Next(1000, 99999);
        //     FakeDb.Cars.Add(carData);
        //     return carData;
        // }
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

        public Car updateCar(Car carData, int id)
        {
            Car original = FakeDb.Cars.Find(c => c.Id == id);
            original.Make = carData.Make;
            original.Model = carData.Model;
            original.Year = carData.Year;
            original.Price = carData.Price;

            return original;
        }
    }
}