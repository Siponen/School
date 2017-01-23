using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Airplane : Vehicle
    {
        uint NumberOfEngines { get; set; }

        public Airplane(int registerNumber, string color, uint numberOfEngines )
            : base(registerNumber,color,"Airplane", 2)
        {
            NumberOfEngines = numberOfEngines;
        }
    }
}
