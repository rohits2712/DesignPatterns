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
            //Decorator - Using Composition to limit inheritance and simplify object relationships easier to maintain and manage.
            Car sampleCar = new CompactCar();
            sampleCar = new LeatherSeats(sampleCar);
            Console.WriteLine(sampleCar.GetDescription());
            Console.WriteLine($"{sampleCar.GetCarPrice():C2}");
            Console.ReadLine();
        }
    }
}
