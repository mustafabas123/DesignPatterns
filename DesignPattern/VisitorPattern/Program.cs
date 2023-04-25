using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager1 = new Manager { Name="Mustafa",Salary=20000};
            Manager manager2 = new Manager { Name = "Ali", Salary = 15000 };

            Worker worker1 = new Worker { Name="Merve",Salary=12000};
            Worker worker2 = new Worker { Name = "Akif", Salary = 13500 };
            manager1.Subordinates.Add(manager2);
            manager2.Subordinates.Add(worker1);
            manager2.Subordinates.Add(worker2);

            OrganisationalStructure organisationalStructure=new OrganisationalStructure(manager1);
            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayriseVisitor payriseVisitor=new PayriseVisitor();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payriseVisitor);
            Console.ReadLine();
        }
    }
    class OrganisationalStructure
    {
        public EmployeeBase _employee;
        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            _employee = firstEmployee;
        }
        public void Accept(VisitorBase visitor)
        {
            _employee.Accept(visitor);
        }
    }
    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
    class Manager : EmployeeBase
    {
        public List<EmployeeBase> Subordinates { get; set; }
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }

        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach(var empoyee in Subordinates)
            {
                 empoyee.Accept(visitor);
            }
        }
    }
    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Manager manager);
        public abstract void Visit(Worker worker);
    }
    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1} ",manager.Name,manager.Salary); 
        }

        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}",worker.Name,worker.Salary);
        }
    }
    class PayriseVisitor : VisitorBase
    {
        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1} ", manager.Name, manager.Salary*(decimal)1.2);
        }

        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary*(decimal)1.1);
        }
    }
}
