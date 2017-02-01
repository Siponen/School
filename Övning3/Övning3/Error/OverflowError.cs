using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    class OverflowError : UserError
    {
        public override string UEMessage()
        {
            return "You tried to overflow an array. This fired an error!";
        }
    }
}
