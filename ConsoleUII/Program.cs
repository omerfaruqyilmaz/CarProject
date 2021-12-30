using System;
using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.InMemory.EntityFramework;

namespace ConsoleUII
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //BrandAddTest();

            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User
            //{
            //    UserId = 3,
            //    FirstName = "Meva",
            //    LastName = "Yılmaz",
            //    Email = "mevayilmaz25@gmail.com",
            //    Password = "321435423"
            //}) ;
            //foreach (var user in userManager.GetAll().Data)
            //{
            //    Console.WriteLine("Ad   "+user.FirstName+"   Soyad   "+user.LastName+"    Şifre    "+user.Password);
            //}




            //BrandTest();
            //ColorTest();

        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 9, BrandName = "Honda" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("ID = " + brand.BrandId + "--  Marka ismi  " + brand.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId+color.ColorName);
            }
        }

        private static void BrandTest()
        {

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName + brand.BrandId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void CarTest()
        {
            Console.WriteLine("1000-2500 ARASI ARAÇLARIMIZ ");
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + " / MARKA:" + car.BrandName + " / Renk:" + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }


    }
        
    }

