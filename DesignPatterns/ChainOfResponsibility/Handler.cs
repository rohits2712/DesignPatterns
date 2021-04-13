using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ChainOfResponsibility
{

    /// <summary>
    /// Approver- (Handler) is the person who approves a request
    /// </summary>

    abstract class Approver
    {
        //Approver with reference to another approver
        protected Approver _approver;
        public void SetSuccessor(Approver approver)
        {
            this._approver = approver;
        }
        public abstract void ProcessRequest(Purchase purchase);
    }
    //Concrete Handler 1
    class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000)
            {
                Console.WriteLine($"{this.GetType().Name} approved request {purchase.Number}");
            }
            else if (_approver != null) { _approver.ProcessRequest(purchase); }
        }


    }
    //Concrete Handler 2
    class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 15000)
            {
                Console.WriteLine($"{this.GetType().Name} approved request {purchase.Number}");
            }
            else if (_approver != null) { _approver.ProcessRequest(purchase); }
        }
    }
    //Concrete Handler 3
    class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000)
            {
                Console.WriteLine($"{this.GetType().Name} approved request {purchase.Number}");
            }
            else { Console.WriteLine("Meeting called"); }
        }
    }


    public class Purchase
    {
        public int Amount { get; internal set; }
        public int Number { get; internal set; }
    }
}
