using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    class Bird : Animal
    {
        protected bool CanFly
        {
            get; set;
        }

        public Bird() : base("Bird","chirp")
        {
            CanFly = true;
        }

        public Bird(string name, bool canFly) : base(name,"chirp")
        {
            CanFly = canFly;
        }

        public virtual void Fly()
        {
            Console.WriteLine($"{Name} is flying!");
        }

        public override string ToString()
        {
            string canFly = (CanFly ? "can" : "can't");
            return ($"{this.Name} is a glorious bird that {canFly} fly and make sounds like {this.Says}");
        }
    }
}
