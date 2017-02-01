using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    class Dog : Animal
    {
        int barksPerMinute;
        protected int BarksPerMinute
        {
            get { return barksPerMinute; }
            set { if (value >= 0) barksPerMinute = value; }
        }

        public Dog() : base("Dog","woof")
        {
            barksPerMinute = 30;
        }

        public Dog(string name, int barksPerMinute) : base(name,"woof")
        {
            BarksPerMinute = barksPerMinute;
        }

        public override string ToString()
        {
            return $"{Name} is a dog that barks '{Says}' up to the amount of {BarksPerMinute} times per minute!";
        }
    }
}
