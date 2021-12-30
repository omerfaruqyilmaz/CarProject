using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        private List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    CarId = 1, BrandId = 2, ColorId = 3, DailyPrice = 100, Description = "Sedan", ModelYear = "20120"
                },
                new Car
                {
                    CarId = 2, BrandId = 3, ColorId = 2, DailyPrice = 100, Description = "Coupe", ModelYear = "2007"
                },
                new Car
                {
                    CarId = 3, BrandId = 4, ColorId = 1, DailyPrice = 100, Description = "Suv", ModelYear = "2013"
                },
                new Car
                {
                    CarId = 4, BrandId = 5, ColorId = 5, DailyPrice = 100, Description = "Super Sport",
                    ModelYear = "2020"
                },
                new Car
                {
                    CarId = 5, BrandId = 6, ColorId = 6, DailyPrice = 100, Description = "Ticari", ModelYear = "2021"
                },
            };
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        

        

        public void Add(Car car)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId ==brandId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Car GetCarsByBrandId(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Car GetCarsByColorId(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
