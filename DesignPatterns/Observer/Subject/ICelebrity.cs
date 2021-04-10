using DesignPatterns.Observer.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer.Subject
{
    public interface ICelebrity
    {
        string FullName { get; }
        string Tweet { get; set; }
        void Notify(string Tweet);
        void AddFollower(IFan fan);
        void RemoveFollower(IFan fan);
    }
}
