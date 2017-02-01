using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning3
{
    class Program
    {
        static void Main(string[] args)
        {
            Inkapsling();
            Arv();
            Polymorfism();
        }

        private static void Inkapsling()
        {
            Console.WriteLine("3.1 Inkapsling\n");
            PersonHandler personHandler = new PersonHandler();
            Person person = personHandler.CreatePerson(99, "Göran", "Olsson", 78.9, 1.73);
            Console.WriteLine(person);
            Console.WriteLine();

            Console.WriteLine("SetAge och SetWeight på Göran");
            personHandler.SetAge(person, 10);
            personHandler.SetWeight(person,20.3);
            personHandler.AddPerson(person);
            Console.WriteLine(person);
            Console.WriteLine();

            person = personHandler.CreatePerson(56, "Berit", "Andersson", 108.4, 1.52);
            personHandler.AddPerson(person);

            personHandler.PrintList();
            Console.WriteLine();
        }

        private static void Arv()
        {
            Console.WriteLine("3.2 Arv\n");
            List<Animal> animals = new List<Animal>();
            animals.Add(new Bird("Alactraz", true));
            animals.Add(new Hedgehog("Sonic", 1234, 109));
            animals.Add(new Horse("Polly", 230));
            animals.Add(new Worm("Bob", 10));
            animals.Add(new Dog("Ocelot", 60));

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

            //3.2.9 - Detta funkar inte då Horse ärver från Animal och inte från Dog.
            //List<Dog> dogs = new List<Dog>();
            //dogs.Add(new Horse("Bobby",100));

            //3.2.12 Vilken typ måste listan lagra för att dessa tre nya klasser ska kunna lagras tillsammans?
            //A: Antingen en lista av Animal eller Bird, eftersom de ärver från Bird, och Bird ärver från Animal.
            List<Bird> variousBirds = new List<Bird>();
            variousBirds.Add(new Flamingo());
            variousBirds.Add(new Swan());

            //3.2.13 F: Vilken typ måste listan vara för att alla klasser skall kunna lagras tillsammans?
            //A: Animal, eftersom alla klasser inte ärver från Birds.
            List<Animal> allKindsAnimals = new List<Animal>();
            allKindsAnimals.Add(new Pelican());
            allKindsAnimals.Add(new Hedgehog());
            allKindsAnimals.Add(new Dog());

            //3.2.14 F: Om vi under utvecklingen kommer fram till att samtliga fåglar behöver ett nytt attribut, i
            //vilken klass bör vi lägga det?
            //A: I Bird, om vi lägger i Animal så skulle även Dog, Hedgehog osv. få attributen, vilken vi inte vill göra i detta sammanhang.

            //3.2.15 F: Om alla djur behöver det nya attributet, vart skulle man lägga det då?
            //A: Då lägger vi attributen i Animal så att alla djur klasser kan ärva attributet.
            Console.WriteLine();
        }

        private static void Polymorfism()
        {
            Console.WriteLine("3.3 Polymorfism\n");
            List<UserError> userErrors = new List<UserError>();
            userErrors.Add(new TextInputError());
            userErrors.Add(new NumericInputError());
            userErrors.Add(new OverflowError());
            userErrors.Add(new NullExceptionError());
            userErrors.Add(new DijsktraError());

            foreach (var error in userErrors)
            {
                Console.WriteLine(error.UEMessage());
            }
            Console.WriteLine();

            //3.3.11 F: Varför är polymorfism viktigt att behärska?

            //A: Det tillåter dig att behandla olika typer av objekt
            //som en och samma typ av objekt.
            //Detta tillåter oss att ha flera olika klasser av felmeddelanden
            //men ändå så kan vi lägga in alla objekt i en och samma lista.
            //Istället för att skapa nya listor för varje typ av objekt.

            //3.3.12 F: Hur kan polymorfism förändra och förbättra kod via en bra struktur?

            //A: Det tillåter oss att göra en modulär design, där vi kan
            //byta ut funktionalitet och beteenden utan att göra någon direkt förändring
            //Som t.ex. switcha mellan OpenGL grafikmotor och Direct3D grafikmotor,
            //eller bara mellan olika versioner av dessa under typen GraphicsEngine.

            //Det går att åstadkomma polymorfism utan polymorfism, men då måste
            //man bygga stora multi-conceptual uber klasser som har
            //alla variabler och överlagrade implementationer i en och samma klass...
            //Väldigt bloated och ineffektivt.
        }
    }
}
