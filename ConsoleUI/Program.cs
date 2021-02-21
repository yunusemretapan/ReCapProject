using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            //CarGetCarsByBrandIdTest();
            //CarGetCarsByColorIdTest();
            //CarGetByIdTest();
            //CarGetAllTest();
            //CarAddTest();
            //CarUpdateTest();
            //CarGetCarDetails();

            //ColorGetByIdTest();
            //ColorGetAllTest();
            //ColorAddTest();
            //ColorUpdateTest();

            //BrandGetByIdTest();
            //BrandGetAllTest();
            //BrandAddTest();
            //BrandUpdateTest();

            //RentalGetByIdTest();
            //RentalGetAllTest();
            //RentalAddTest();
            //RentalUpdateTest();

        }

        #region Car
        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 100500, ModelYear = 2001, Description = "2001 Model Araba" });
        }

        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { Id = 5, BrandId = 3, ColorId = 2, DailyPrice = 120500, ModelYear = 2005, Description = "2005 Model Araba" });
        }

        private static void CarGetByIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.GetById(2);
        }

        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void CarGetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarId + "/" + car.ColorName + "/" + car.BrandName + "/" + car.DailyPrice);
            }
        }

        private static void CarGetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void CarGetCarsByColorIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(car.Description);
            }
        }
        #endregion

        #region Color
        private static void ColorGetAllTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void ColorAddTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Name = "Brown" });
        }

        private static void ColorUpdateTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color { Id = 5, Name = "Brown" });
        }

        private static void ColorGetByIdTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.GetById(2);
        }
        #endregion

        #region Brand
        private static void BrandGetAllTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Name = "Toyota" });
        }

        private static void BrandUpdateTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Update(new Brand { Id = 5, Name = "Renault" });
        }

        private static void BrandGetByIdTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.GetById(2);
        }
        #endregion

        #region Rental
        private static void RentalGetAllTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.RentDate);
            }
        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental { RentDate = DateTime.Now });
        }

        private static void RentalUpdateTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Update(new Rental { Id = 1, RentDate = DateTime.Now });
        }

        private static void RentalGetByIdTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.GetById(2);
        }
        #endregion
    }
}
