using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{

    public class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer {  FirstName="Mustafa" , LastName="Baş" , City="İstanbul" , Id=1 };
            Customer customer2 = (Customer)customer.Clone();
            customer2.FirstName = "Merve";

            Console.WriteLine(customer2.FirstName);
            Console.WriteLine(customer.FirstName);
            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Emplooyee : Person
    {
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
