using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageManager = new EmailSender();
            customerManager.UpdateCustomer();
            Console.ReadLine();
        }
    }
    abstract class MessageManagerBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved");
        }
        public abstract void SendSms(Body body);
    }
    internal class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    class SmsSender : MessageManagerBase
    {


        public override void SendSms(Body body)
        {
            Console.WriteLine("{0} was sent via smsSender",body.Title);
        }
    }
    class EmailSender : MessageManagerBase
    {
        public override void SendSms(Body body)
        {
            Console.WriteLine("{0} was sent via emailSender",body.Title);
        }
    }
    class CustomerManager
    {
        public MessageManagerBase MessageManager { get; set; }
        public void UpdateCustomer()
        {
            MessageManager.SendSms(new Body { Title="About the course"});
            Console.WriteLine("Customer updated");
        }
    }
}
