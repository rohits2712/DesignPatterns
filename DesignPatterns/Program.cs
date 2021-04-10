using DesignPatterns.Decorator.Component;
using DesignPatterns.Decorator.ConcreteComponent;
using DesignPatterns.Decorator.ConcreteDecorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Decorator - Using Composition to limit inheritance and simplify object relationships easier to maintain and manage.
            //Inside ConcreteDecorator any number of features can be added to the car and price for the car can be updated.
            Car sampleCar = new CompactCar();
            sampleCar = new LeatherSeats(sampleCar);
            Console.WriteLine(sampleCar.GetDescription());
            Console.WriteLine($"{sampleCar.GetCarPrice():C2}");
            #endregion

            Console.ReadLine();
        }
    }
}
