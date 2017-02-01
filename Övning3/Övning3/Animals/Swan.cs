using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    class Swan : Bird
    {
        int protectNumberBabies;
        int ProtectNumberBabies
        {
            get { return protectNumberBabies; }
            set { if (value >= 0) protectNumberBabies = value; }
        }

        public Swan() : base("Swan",true)
        {
            protectNumberBabies = 3;
        }

        public override string ToString()
        {
            return $"{Name} protects {ProtectNumberBabies} number of babies.";
        }
    }
}
