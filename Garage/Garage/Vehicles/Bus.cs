using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Bus : Vehicle
    {
        uint NumberOfSeats { get; set; }

        public Bus(int registerNumber, string color, uint numberOfSeats) 
            : base(registerNumber, color, "Bus", 6)
        {
            NumberOfSeats = numberOfSeats;
        }
    }
}
