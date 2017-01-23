using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Boat : Vehicle
    {
        uint Length { get; set; }

        public Boat(int registerNumber, string color, uint length ) :
            base(registerNumber, color, "Boat", 0)
        {
            Length = length;
        }
    }
}
