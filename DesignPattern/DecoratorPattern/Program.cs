﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var personelCar = new PersonelCar { Make = "Audi", Model = "3.20", HirePrice = 3000 };
            SpecialOffer specialOffer=new SpecialOffer(personelCar);
            specialOffer.DiscountPercentage = 90;
            Console.WriteLine("Concerete : {0}", personelCar.HirePrice);
            Console.WriteLine("Special Offer :{0}", specialOffer.HirePrice);

            Console.ReadKey();
        }
    }
    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }

    }
    class PersonelCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;
        public CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }
    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        private readonly CarBase _carBase;
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice
        {
            get { return _carBase.HirePrice * DiscountPercentage / 100; }
            set
            {

            }
        }
    }
}
