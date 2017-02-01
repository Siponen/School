using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    class Flamingo : Bird
    {
        string color;
        protected string Color
        {
            get { return color; }
            set { if (String.IsNullOrWhiteSpace(value)) color = value; }
        }

        public Flamingo() : base("Flamingo",true)
        {
            color = "pink";
        }

        public override string ToString()
        {
            return $"This is a {Name} with color {color} and sounds {Says}";
        }
    }
}
