using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    class DijsktraError : UserError
    {
        public override string UEMessage()
        {
            return "You tried to cause a filthy Dijsktra. This fired an error!";
        }
    }
}
