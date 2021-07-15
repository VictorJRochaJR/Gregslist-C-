using System.Data;
using Dapper;
using Gregslist.Models;
using System.Collections.Generic;
using System.Linq;

namespace Gregslist.Data{
    public class CarsRepository{
        private readonly IDbConnection _db;

        public CarsRepository(IDbConnection db)
        {
            _db = db;
        }
        public List<Car> GetAll()
        {
            var sql = "SELECT * FROM  cars";
            return _db.Query<Car>(sql).ToList();
        }
        public Car Create(Car carData)
        {
            var sql = @"
            INSERT INTO cars(make, model, year, price)
            VALUES(@Make, @Model, @Year, @Price);
            SELECT  LAST_INSERT_ID();
            ";
            
            int id = _db.ExecuteScalar<int>(sql, carData);
            carData.Id = id;
            return carData;
        }
    }
}