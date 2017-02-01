using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    class Horse : Animal
    {
        protected uint HorsePower
        {
            get; set;
        }

        public Horse() : base("Horse","neeeigh")
        {
            HorsePower = 100;
        }

        public Horse(string name, uint horsePower) : base(name,"neeeigh")
        {
            HorsePower = horsePower;
        }

        public override string ToString()
        {
            return $"{Name} is a horse that says {Says} and runs with a speed of {HorsePower} km/h!";
        }
    }
}
