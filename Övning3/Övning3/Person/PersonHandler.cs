using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    /* This class's purpose is to create and manage Person objects
     * for some unknown reason.
     */
    class PersonHandler
    {
        List<Person> persons;

        public PersonHandler()
        {
            persons = new List<Person>();
        }

        public Person CreatePerson(int age, string firstName, string lastName,
            double height, double weight)
        {
            return new Person(firstName,lastName, age, height,weight);
        }

        public void AddPerson(Person person)
        {
            if (person?.FirstName != null)
                persons.Add(person);
        }

        public void SetAge(Person person, int age)
        {
            person.Age = age;
        }

        public void SetWeight(Person person, double weight)
        {
            person.Weight = weight;
        }

        public void PrintList()
        {
            Console.WriteLine("List of people:");
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
