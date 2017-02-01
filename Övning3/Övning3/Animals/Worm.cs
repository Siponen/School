using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    class Worm : Animal
    {
        int numberNinjaRope;
        protected int NumberNinjaRope
        {
            get { return numberNinjaRope; }
            set { if (value >= 0) numberNinjaRope = value; }
        }

        public Worm() : base("Worm","...")
        {
            numberNinjaRope = 1;
        }

        public Worm(string name, int numberNinjaRope) :
            base (name,"...")
        {
            this.numberNinjaRope = numberNinjaRope;
        }

        public override string ToString()
        {
            return $"{Name} is a worm and makes sounds like {Says} it also carries around {numberNinjaRope} ninja ropes! Beware!";
        }
    }
}
