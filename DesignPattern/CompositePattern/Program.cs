using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Empoloyee mustafa = new Empoloyee { Name = "Mustafa Baş" };
            Empoloyee merve = new Empoloyee { Name = "Merve Baş" };
            Empoloyee Yagmur = new Empoloyee { Name = "Yagmur Atıl" };
            mustafa.AddSubordinate(merve);
            mustafa.AddSubordinate(Yagmur);// Mustafa'nı alt elemanları merve ve yagmur'dur

            Console.WriteLine(mustafa.Name);
            foreach(Empoloyee manager in mustafa)
            {
                Console.WriteLine(manager.Name);
                foreach(Empoloyee people in manager)
                {
                    Console.WriteLine(people.Name);
                }
            }
            Console.ReadLine();
        }
    }
    interface IPerson
    {
        string Name { get; }
    }
    class Empoloyee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();
        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (IPerson person in _subordinates)
            {
                yield return person;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
