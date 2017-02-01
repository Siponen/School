using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    class Animal
    {
        string name;
        string says;

        public Animal()
        {
            this.name = "Animal";
            this.says = "...";
        }

        public Animal(string name, string says)
        {
            this.name = name;
            this.says = says;
        }

        protected String Name
        {
            get { return name; }
            set { if (!String.IsNullOrWhiteSpace(value)) name = value; }
        }

        protected string Says
        {
            get { return says; }
            set { if (!String.IsNullOrWhiteSpace(value)) says = value; }
        }

        public void Sound()
        {
            Console.WriteLine("The " + name + " says" + says);
        }

        public override string ToString()
        {
            return $"The animal {name} says {says}";
        }
    }
}
