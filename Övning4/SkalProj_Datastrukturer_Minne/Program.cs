using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    /*
        Övning 4.
        
        F1.Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess
        grundläggande funktion

        A: Stacken är ett block av minne som används för alla variabler och instruktioner i det nuvarande
        metodsanropen. Man kan se det som en lista med lådor (minnesplatser).

        Eftersom stacken är relativt liten så kan vi inte lagra hela programmet i den, och därför är det vanligt att se
        stackoverflows med långa rekursioner.

        Heapen är vanligtvis ett större block minne från RAM-minnet (Random access memory),
        "kombination av serie och parallell kopplade kopparledningar till minnesplatser"? som leder till
        random access accessibility av minne.

        Heapen används för att spara större block av minne som inte får plats i den lilla stacken.
        Detta gör vi med new operatorn.      
        Exempel: Vertex[] vertex = new Vertex[10];
        
        F2.Vad är Value Types repsektive Reference Types och vad skiljer dem åt?
        
        A: Value types består av primitiva datatyper och structs, alla deras fält blir kopierade
        när vi passerar vår value type som argument till metoder, och sparas på stacken.

        Reference types håller en referens (minnesaddress) till självaste objektet som ligger någonstans på heapen,
        hanterad av CLR. När den sista referenstypen förstörs, så blir den instansierade objektet på heapen
        garbage collected av CLR.

        Vi passerar reference types genom att kopiera referensen istället för hela objektet.
        class, abstract classes, interfaces är olika reference types.

        F3.Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3,    
        den andra returnerar 4, varför?

        ReturnValue()
        A: Vi skapar ett heltal x som är en value type, kopierar över x till y, och returnerar sedan x's heltal.
        Check, vi får ut 3 som förväntat.

        ReturnValue2()
        MyInt x instansieras och läggs på heapen, vi sätter dess värde till 3, eftersom MyInt är en referenstyp
        så kopierar vi referensen till y som också är referenstypad, när detta händer försvinner
        MyInt y's gamla referens och dess instansierad objekt kommer eventuellt bli garbage collected
        med CLR då alla referenser till y's gamla objektet är borta.

        Så när vi kallar på y.MyValue som pekar mot MyInt x's objekt, så ändrar vi
        om på det objektets värde. Och därför returneras 4'a.
        Pekare är gudomligt roliga!
     */


    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Please navigate through the menu by inputting the number (0-9) of your choice\n"
                +"\n1. Examine a List"
                +"\n2. Examine a Queue"
                +"\n3. Examine a Stack"
                +"\n4. CheckParanthesis"
                +"\n5. CheckRecursive"
                +"\n6. CheckFibonacci"
                +"\n7. IterativeEven"
                +"\n8. CheckIterative"
                +"\n9. IterativeFibonacci"
                +"\n0. Exit the application");
            char input = ' '; //Creates the character input to be used with the switch-case below.
            input = Console.ReadKey().KeyChar; //Tries to set input to the first char in an input line

            Console.Clear();
            switch (input)
            {
                case '1':
                    ExamineList();
                    break;
                case '2':
                    ExamineQueue();
                    break;
                case '3':
                    ExamineStack();
                    break;
                case '4':
                    CheckParanthesis();
                    break;
                case '5':
                    CheckRecursive();
                    break;
                case '6':
                    CheckFibonacci();
                    break;
                case '7':
                    CheckIterative();
                    break;
                case '8':
                    CheckIterativeFibonacci();
                    break;
                case '0':
                    Console.WriteLine("Quitting...");
                    return;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                    break;
            }
            PressToContinue();
            Main();
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            /*
            Övning 1: Listor

            2-3. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
            A: När vi når kapacititen så dubblas kapaciteten (4,8,16,32,64 osv)

            4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
            A:För att expandera List så måste vi kopiera den fyllda arrayen
            till en ny array som har en ökad kapacitet. Därför vill List undvika
            att expandera för ofta, då allokering till en ny array blir dyrt väldigt fort.

            5. Minskar kapaciteten när element tas bort ur listan?
            A: Nej, jag förväntade mig faktiskt att den skulle minska på capacity i samma takt som den ökade.

            6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
            A: a) När vi inte behöver dynamisk insättning och borttagning samtidigt som vi vet hur många
            element som vi faktiskt kommer arbeta med, då är Array fördelaktig.

            Vi vill använda List när vi håller på med dynamisk tilläggning och borttagning av element eller
            när vi inte vet exakt hur många element som vi ska använda oss av.
            */
            Console.Clear();
            List<string> theList = new List<string>();
            bool isDone = false;
            do
            {
                Console.WriteLine();
                Console.WriteLine($"List Count: {theList.Count}, List Capacity: {theList.Capacity}");

                Console.Write("Please write 'q' to quit or '+', '-' and then a name: ");
                string input = Console.ReadLine();

                if(String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error empty string!");
                    continue;
                }

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        break;
                    case '-':
                        theList.Remove(value);
                        break;
                    case 'q':
                        isDone = true;
                        break;
                    default:
                        Console.WriteLine("Use only '+' or '-'");
                        break;
                }
            } while (!isDone);
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            //Övning 2: Köer (Queues)

            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Console.Clear();
            bool isDone = false;

            Queue<string> theQueue = new Queue<string>();
            do
            {
                //Print menu
                Console.WriteLine("Welcome to Examine Queue!\n");
                Console.WriteLine("1 - Add user to queue.");
                Console.WriteLine("2 - Poll user.");
                Console.WriteLine("0 - Quit.\n");
                Console.Write("Input number and then name: ");

                //Input
                string input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error empty string!");
                    continue;
                }

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '1':
                        theQueue.Enqueue(value);
                        break;
                    case '2':
                        if(theQueue.Count > 0)
                            theQueue.Dequeue();
                        else
                            Console.WriteLine("The queue is already empty!\n");
                        Console.WriteLine("");
                        break;
                    case '0':
                        isDone = true;
                        break;
                    default:
                        break;
                }

                //Display the queue
                Console.Write("Queue: ");
                foreach (var item in theQueue)
                {
                    Console.Write($"{item}, ");
                }
                Console.WriteLine();

            } while (!isDone);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
            Övning 3: Stackar (Stack)
            1. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. Varför är 
            det inte så smart att använda en stack i det här fallet?
            A: En stack fungerar ungefär som en hög med tallrikar, första instoppade tallriken
            kommer ut när alla andra tallrikar har plockats bort.

            Detta fungerar ju naturligtvis inte för köer, då den första kunden kommer bli den sista kunden. Stackarn.
            */
            Console.Clear();
            Stack<string> theStack = new Stack<string>();

            Console.WriteLine("Welcome to Examine Stack!\n");
            Console.Write("Write a sentence: ");
            string input = Console.ReadLine();

            //Split and Add words to the stack. FILO style
            //var words = input.Split(' ');
            foreach (char letter in input)
            {
                theStack.Push(letter.ToString());
            }

            //Write the stack to screen.
            Console.Write("Reversed sentence: ");
            while (theStack.Count != 0)
            {
                Console.Write(theStack.Pop() + " " );
            }
            Console.WriteLine();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})]
             * Example of incorrect: (()]), [), {[()}]
            */

            /*
            Övning 4: Kontrollera Paranteser
            Skapa med hjälp av er nya kunskap funktionalitet för att kontrollera en
            välformad sträng på papper. Vilken datastruktur använder du?
            A: Jag använder mig av Stack för att lagra start symboler,
            när vi arbetar med nästlade start symboler, så fungerar FIFO
            naturligt.
            */

            Console.Clear();

            //Console.WriteLine("These should be true:");
            ValidateSyntax(Console.ReadLine());
            //ValidateSyntax("{}");
            //ValidateSyntax("[({})]");
            //ValidateSyntax("([{}]({}))");
            //Console.WriteLine("These should be false: ");
            //ValidateSyntax("(()])");
            //ValidateSyntax("[)");
            //ValidateSyntax("{[()}]");
            //ValidateSyntax("{{{");
            //ValidateSyntax("}}}");


        }

        //Algorithm
        //Insert start symbols ([{ into stack
        //1. Is the next element a start symbol? Yes, push it to stack.
        //No? Pop from the stack, compare the symbols.
        //If they match, we continue, otherwise, it's not a valid strong.
        private static bool ValidateSyntax(string validString)
        {
            Stack<char> syntaxOrder = new Stack<char>();
            char[] chars = validString.ToCharArray();
            bool isValid = false;
            for (int i = 0; i < chars.Length; ++i)
            {
                char element = chars[i];

                //Add starting symbols to stack
                if (IsStartingSymbol(element))
                    syntaxOrder.Push(element);

                else
                {
                    if (syntaxOrder.Count != 0)
                    {
                        //Check if the correct stop symbol is used.
                        char startSymbol = syntaxOrder.Pop();
                        if (CompareSymbols(startSymbol, element))
                            isValid = true;
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }

                    //If there's a stop clause but no open clause in the Stack, then it's an invalid string.
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            Console.WriteLine($"{validString} is " + isValid);

            return isValid;
        }

        private static bool CompareSymbols(char startSymbol, char element)
        {
            bool result = false;
            if ((startSymbol == '(') && (element == ')'))
                result = true;
            else if ((startSymbol == '{') && (element == '}'))
                result = true;
            else if ((startSymbol == '[') && (element == ']'))
                result = true;

            return result;
        }

        private static bool IsStartingSymbol(char element)
        {
            return (element == '(') || (element == '{') || (element == '[');
        }

        private static void CheckRecursive()
        {
            Console.WriteLine("Welcome to Check Recursive!\n");
            Console.Write("Write a number: ");
            string input = Console.ReadLine();

            if(String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error empty string!");
                return;
            }

            int result;
            if(int.TryParse(input, out result) == false )
            { 
                Console.WriteLine("Error invalid input!");
                return;
            }

            int sum = RecursiveEven(result);
            Console.WriteLine($"sum of RecursiveEven({result}) is {sum}");
        }

        private static int RecursiveEven(int n)
        {
            if (n == 0)
                return 0;

            return RecursiveEven(n - 1) + 2;
        }

        private static void CheckFibonacci()
        {
            Console.WriteLine("Welcome to Check Fibonacci!\n");
            Console.Write("Write a number: ");
            string input = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error empty string!");
                return;
            }

            int result;
            if (int.TryParse(input, out result) == false)
            {
                Console.WriteLine("Error invalid input!");
                return;
            }

            //Fibonacci
            if (result >= 0)
            {
                int sum = Fibonacci(result);
                Console.WriteLine($"sum of Fibonacci({result}) is {sum}");
            }
            else
                Console.WriteLine("Error! Negative numbers not allowed");
        }

        private static int Fibonacci(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;

            return Fibonacci(n-1) + Fibonacci(n-2);
        }

        private static void CheckIterative()
        {
            Console.WriteLine("Welcome to Check Iterative!\n");
            Console.Write("Write a number: ");
            string input = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error empty string!");
                return;
            }

            int result;
            if (int.TryParse(input, out result) == false)
            {
                Console.WriteLine("Error invalid input!");
                return;
            }

            if (result >= 0)
            {
                int sum = IterativeEven(result);
                Console.WriteLine($"sum of IterativeEven({result}) is {sum}");
            }
            else
            {
                Console.WriteLine("Please use a non-negative input!");
            }

        }

        private static int IterativeEven(int n)
        {
            if (n == 0) return 0;
            int result = 0;
            for(int i = 0; i < n; i++)
            {
                result += 2;
            }

            return result;
        } 

        private static void CheckIterativeFibonacci()
        {
            Console.WriteLine("Welcome to Check Iterative Fibonacci!\n");
            Console.Write("Write a number: ");
            string input = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error empty string!");
                return;
            }

            int result;
            if (!int.TryParse(input, out result))
            {
                Console.WriteLine("Error invalid input!");
                return;
            }

            if(result < 0)
            {
                Console.WriteLine("Error! Dont use negative values!");
                return;
            }

            int sum = IterativeFibonacci(result);
            Console.WriteLine($"sum of IterativeFibonacci({result}) is {sum}");
        }

        /*
        Iteration, Rekursion, Minneshantering
         */
        private static int IterativeFibonacci(int n)
        {
            int previousValue = 0;
            int currentValue = 1;
            int newCurrentValue = 0;

            if (n == 0) return 0;

            int counter = 1;
            do
            {
                newCurrentValue = previousValue + currentValue;
                previousValue = currentValue;
                currentValue = newCurrentValue;
                counter++;
            } while (counter < n);

            return newCurrentValue;
        }

        private static void PressToContinue()
        {
            Console.WriteLine("Press any key to continue: ");
            Console.ReadKey();
        }
    }
}
