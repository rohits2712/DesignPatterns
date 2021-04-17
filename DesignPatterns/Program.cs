using DesignPatterns.Bridge;
using DesignPatterns.Builder;
using DesignPatterns.ChainOfResponsibility;
using DesignPatterns.Command;
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
            Decorator.Component.Car sampleCar = new CompactCar();
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

            #region Builder Pattern- Separate and reuse a specific process to build an object /use when constructing a complex object
            //Director- construct ()
            //Builder - Build part
            //CarBuilder to construct two types of cars
            //override the method of building a car in separate classes which derive from an abstract carbuilder
            //create a list of carbuilder objects to specify the current known types of cars that can be built
            //create a factory
            var superBuilder = new SuperCarBuilder();
            var notSoSsuperBuilder = new NotSoSuperCarBuilder();

            var factory = new CarFactory();
            var builders = new List<CarBuilder> { superBuilder, notSoSsuperBuilder };

            foreach (var b in builders)
            {

                var c = factory.Build(b);
                Console.WriteLine($"The car requested by " + $"{b.GetType().Name}:" + Environment.NewLine 
                            + $"Horse Power: {c.HorsePower}" + Environment.NewLine
                            + $"Impressive feature: {c.MostImpressiveFeature}" + Environment.NewLine
                            + $"Top speed: {c.TopSpeedMPH} mph" + Environment.NewLine);
            }
            #endregion

            #region Bridge Pattern- Used to separate an abstraction from its implementation so both can be modified independently
            //Sending messages from sms or service without each affecting the other 
            IMessageSender text = new TextSender();
            IMessageSender web = new WebServiceSender();

            Message message = new SystemMessage(text);
            message.Subject = "A message";
            message.Body = "hi there, please know this";
            message.MessageSender = text;
            message.Send();
           
            message.MessageSender = web;
            message.Send();

            #endregion

            #region Chain of responsibility- Chain the receiving objects and pass the request along the chain until an object handles it.
            //Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request
            Approver Bobby = new Director();
            Approver Sunny = new VicePresident();
            Approver Dharam = new President();

            Bobby.SetSuccessor(Sunny);
            Sunny.SetSuccessor(Dharam);

            Purchase P = new Purchase() { Amount = 10000, Number = 1 };
            Bobby.ProcessRequest(P);


            #endregion

            #region Command - Wrap request as an object to be implemented later or invoke at different points in time.
            //Encapsulate a request as an object, thereby letting you parameterize clients with different requests -queue or log  and support undoable operations
            //Use an object to store required information to perform an action at any point in time.
            var user = new User();
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            //undo
            user.Undo(4);

            //Redo 
            user.Redo(3);
            #endregion
            Console.ReadLine();
        }
    }
}
