using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Motorcycle : Vehicle
    {
        uint CylinderVolume { get; set; }

        public Motorcycle(int registerNumber, string color, uint cylinderVolume)
            : base(registerNumber, color, "Motorcycle",2)
        {
            CylinderVolume = cylinderVolume;
        }
    }
}
