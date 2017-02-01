using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    class Person
    {
        string firstName;
        string lastName;
        int age;
        double height;
        double weight;

        public Person() {}

        public Person(string firstName, string lastName, int age,
            double height, double weight)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.height = height;
            this.weight = weight;
        }

        public string FirstName
        {
            get { return firstName; }
            set { if (!String.IsNullOrWhiteSpace(value)) firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { if (!String.IsNullOrWhiteSpace(value)) lastName = value; }
        }

        public int Age
        {
            get { return age; }
            set { if (value > 0) age = value; }
        }

        public double Height
        {
            get { return height; }
            set { if (value > 0) height = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { if (value > 0) weight = value; }
        }

        public override string ToString()
        {
            return ($"Name: {firstName} {lastName}\t age: {age}\t " +
                $"weight: {weight}\t height: {height}");
        }
    }
}
