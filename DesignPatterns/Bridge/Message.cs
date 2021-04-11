using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Bridge
{
    /// <summary>
    /// Abstraction class
    /// </summary>
   public abstract class Message
    {
        public IMessageSender MessageSender { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public abstract void Send();
    }

    /// <summary>
    /// Refined abstraction
    /// </summary>
    public class SystemMessage : Message
    {
        public override void Send()
        {
            MessageSender.SendMessage(Subject, Body);
        }
    }

    /// <summary>
    /// Bridge Implementor Interface
    /// </summary>
    public interface IMessageSender {

        void SendMessage(string subject, string body);
    }
    //Concrete Implementor 1
    public class TextSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            string messageType = "Text";
            Console.WriteLine($"Subject: {subject} from {messageType}");
        }
    }

    //Concrete Implementor 2
    public class WebServiceSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            string messageType = "Web service";
            Console.WriteLine($"Subject: {subject} from {messageType}");
        }
    }



}
