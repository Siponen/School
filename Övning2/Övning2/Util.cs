using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    /*
     * A collection of refactored utility functions.
     */
    static class HelperFuncs
    {
        public static uint AskForUint(string question)
        {
            uint value;

            Console.Write(question + ": ");
            string stringFromInput = Console.ReadLine();
            uint.TryParse(stringFromInput, out value);

            return value;
        }

        public static string AskForString(string question)
        {
            Console.Write(question + ": ");
            return Console.ReadLine();
        }

        public static void PressKeyToContinue()
        {
            Console.Write("Press any key to continue ");
            Console.ReadKey();
        }
    }
}
