using DesignPatterns.Observer.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer.ConcreteObserver
{
    public class Fan : IFan
    {
        public string Name { get; }
        public Fan(string name)
        {
            Name = name;
        }
        public void Update(ICelebrity celebrity)
        {
            Console.WriteLine($"Fan notified - {Name}. Tweet of {celebrity.FullName} : {celebrity.Tweet}");
        }
    }
}
