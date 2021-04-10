using DesignPatterns.Decorator.Component;
using DesignPatterns.Decorator.ConcreteComponent;
using DesignPatterns.Decorator.ConcreteDecorator;
using DesignPatterns.Observer.ConcreteObserver;
using DesignPatterns.Observer.ConcreteSubject;
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

            #region Observer - Change in one object causes a change or action in another. 
            var trump = new Trump("I love my wife");
            var firstFan = new Fan("Rohit");
            var secondFan = new Fan("Ram");
            trump.AddFollower(firstFan);
            trump.AddFollower(secondFan);
            trump.Tweet = "I hate media";
            #endregion
            Console.ReadLine();
        }
    }
}
