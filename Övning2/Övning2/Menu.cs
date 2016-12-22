using System;
using Util;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{ 
    class Menu
    {
        private bool isDone = false;

        public void Run()
        {
            while (!isDone)
            {
                Console.Clear();
                DisplayMenuHeader();

                Console.Write("Select your option: ");
                char option = Console.ReadKey().KeyChar;

                Console.Clear();
                MenuActions(option);

                if(!isDone)
                    HelperFuncs.PressKeyToContinue();
            }
        }

        private void DisplayMenuHeader()
        {
            Console.WriteLine("Welcome to DotA2 cinema\n\n" +
                "Main menu:\n" +
                "3. Split sentence\n" +
                "2. Spam message\n" +
                "1. Buy tickets\n" +
                "0. Quit\n");
        }

        private void MenuActions(char input)
        {
            switch (input)
            {
                case '0':
                    isDone = true;
                    break;
                case '1':
                    BuyTicket();
                    break;
                case '2':
                    SpamMessage(10);
                    break;
                case '3':
                    SplitSentence();
                    break;
                default:
                    Console.WriteLine("Unrecognizable option. Please use one of the available numbers.\n");
                    break;
            }
        }

        private void BuyTicket()
        {
            uint age;
            Console.WriteLine("Let's buy a ticket.\n");

            age = HelperFuncs.AskForUint("How old are you?");
            if (age == 0)
            {
                Console.WriteLine("Invalid age or you are a monster to bring a 0 year old to a loud cinema!\n");
                return;
            }

            CalculateTicketCost(age);
        }

        private uint CalculateTicketCost(uint age)
        {
            const uint highestYouthAge = 20;
            const uint lowestRetiredAge = 64;
            const uint youthCost = 80;
            const uint retiredCost = 90;
            const uint normalCost = 120;

            if (age < highestYouthAge)
            {
                PrintTicketCost("Ungdomspris", youthCost);
                return youthCost;
            }
            else if (age > lowestRetiredAge)
            {
                PrintTicketCost("Pensionärspris", retiredCost);
                return retiredCost;
            }
            else
            {
                PrintTicketCost("Standardpris", normalCost);
                return normalCost;
            }
        }

        private void PrintTicketCost(string costType, uint cost)
        {
            Console.WriteLine("\n" + costType + ": " + cost + "kr\n");
        }

        private void SpamMessage(int numTimes)
        {
            string message = HelperFuncs.AskForString("Write a message");

            if (String.IsNullOrEmpty(message))
            {
                Console.WriteLine("Error! You didn't write a message!");
                HelperFuncs.PressKeyToContinue();
                return;
            }

            Console.Write("Output: ");
            for (int i = 0; i < numTimes; i++)
            {
                Console.Write(message);
            }

            Console.WriteLine("\n");
        }

        private void SplitSentence()
        {
            const int thirdWord = 2;
            Tokenizer tokenizer = new Tokenizer();

            string sentence = HelperFuncs.AskForString("Write a sentence with at least three words");
            tokenizer.Split(sentence, ' ');
            string word = tokenizer.GetToken(thirdWord);

            if (String.IsNullOrEmpty(word))
                Console.WriteLine("\nError! Please write a sentence with at least three words\n");

            else
                Console.WriteLine("The third word is " + word);
        }
    }
}
