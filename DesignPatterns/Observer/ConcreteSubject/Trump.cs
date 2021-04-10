using DesignPatterns.Observer.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer.ConcreteSubject
{
    public class Trump : ICelebrity
    {
        private readonly List<IFan> _fans = new List<IFan>();
        private string _tweet;

        public Trump(string tweet)
        {
            _tweet = tweet;

        }
        public string FullName => "Donald Trump";
        public string Tweet { get { return _tweet; } set { Notify(value); } }


        public void AddFollower(IFan fan)
        {
            _fans.Add(fan);
        }

        public void Notify(string tweet)
        {
            _tweet = tweet;
            foreach (var fan in _fans)
            {
                fan.Update(this);
            }
        }

        public void RemoveFollower(IFan fan)
        {
            _fans.Remove(fan);
        }
    }
}
