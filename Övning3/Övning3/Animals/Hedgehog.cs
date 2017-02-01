using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    class Hedgehog : Animal
    {
        int numberSpines;
        int numberRings;

        public Hedgehog() : base("Hedgehog", "sniff")
        {
            numberSpines = 5000;
            numberRings = 0;
        }

        public Hedgehog(string name, int numberSpines, int numberRings) :
            base(name,"sniff")
        {
            this.numberSpines = numberSpines;
            this.numberRings = numberRings;
        }

        protected int NumberSpines
        {
            get { return numberSpines; }
            set { if (value >= 0) numberSpines = value; }
        }

        protected int NumberRings
        {
            get { return numberRings; }
            set { if (value >= 0) numberRings = value; }
        }

        public override string ToString()
        {
            return ($"{Name} is a hedgehog with {NumberSpines} spines and picks up " +
                $"{NumberRings} golden rings daily. The hedgehog also make sounds like '{this.Says}'");
        }
    }
}
