using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    static class Commons
    {
        public static string AskForString(string question)
        {
            bool isDone = false;
            string input;

            while(!isDone)
            {
                Console.Write(question);
                input = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(input)) return input;
                else Console.WriteLine("Invalid input!");
            }

            return "";
        }

        public static int AskForInt(string question)
        {
            bool isDone = false;
            int result;
            string input;

            while(!isDone)
            {
                Console.Write(question);
                input = Console.ReadLine();
                if (Int32.TryParse(input, out result)) return result;
                else Console.WriteLine("Invalid input. Try again.");
            }

            return -1;
        }

        public static uint AskForUInt(string question)
        {
            bool isDone = false;
            uint result;
            string input;

            while(!isDone)
            {
                Console.Write(question);
                input = Console.ReadLine();
                if (UInt32.TryParse(input, out result)) return result;
                else Console.WriteLine("Invalid input. Try again.");
            }
            return 0;
        }

        public static char AskForKey(string question)
        {
            Console.Write(question);
            return Console.ReadKey(true).KeyChar;
        }

        public static void PressKeyToContinue()
        {
            Console.Write("Press any key to continue... ");
            Console.ReadKey();
        }
    }
}
