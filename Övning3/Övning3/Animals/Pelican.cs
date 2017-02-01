using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    class Pelican : Bird
    {
        int numberBabiesInMouth;
        protected int NumberBabiesInMouth
        {
            get { return numberBabiesInMouth; }
            set { if (value >= 0) numberBabiesInMouth = value; }
        }

        public Pelican() : base("Pelican",true)
        {
            NumberBabiesInMouth = 1;
        }

        public override string ToString()
        {
            return $"The {Name} has {NumberBabiesInMouth} number of babies in its mouth!";
        }
    }
}
