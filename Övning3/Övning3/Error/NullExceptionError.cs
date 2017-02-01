using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    class NullExceptionError : UserError
    {
        public override string UEMessage()
        {
            return "You tried to cause a null exception. This fired an error!";
        }
    }
}
