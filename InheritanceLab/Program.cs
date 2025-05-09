//Hoang Le
//hle2@northeaststate.edu

namespace InheritanceLab
{
    /// <summary>
    /// Lab05
    /// </summary>
    class Program
    {
        /// <summary>
        /// Creates list of different animal and uses the PrintZoo method.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Hierarchy & Zoo Animal\n");

            // instances of base types 
            Animal genericAnimal = new Animal("Mystery Creature", 10, "Unknown");
            Mammal genericMammal = new Mammal("Warm Body", 5, "Mammalia");
            Reptile genericReptile = new Reptile("Cold Blooded", 8, "Reptilia", false);

            // instances for zoo animal (child of child class)
            Lion simba = new Lion("Simba", 5, "Golden Brown");
            // Has a prehensile tail
            Monkey harambe = new Monkey("Harambe", 3, true);
            // Can regrow tail
            Lizard godzilla = new Lizard("Godzilla", 2, true, "Blue Scale");
            // Is nocturnal
            Salamander bruni = new Salamander("Bruni", 1, true);

            // showing MakeSound
            Console.WriteLine("\nMakeSound Call:");
            genericAnimal.MakeSound();
            genericMammal.MakeSound();
            genericReptile.MakeSound();
            simba.MakeSound(); // override
            harambe.MakeSound(); // override
            godzilla.MakeSound();
            bruni.MakeSound(); // override
            Console.WriteLine("-------------------");

            /*
               Protected Access: Still can't access age from Main.
               genericReptile.VerifyProtectedAge; Call method within derived class
               simba.DisplayAgePrivately(); Call inherited method from base class
            */
            Console.WriteLine("\nProtected Access");
            genericReptile.VerifyProtectedAge(); 
            simba.DisplayAgePrivately();          
            Console.WriteLine("-------------------");


            Console.WriteLine("\n***Zoo***");

            // making a list that'll hold any type of animal
            List<Animal> zoo = new List<Animal>();

            zoo.Add(simba);
            zoo.Add(harambe);
            zoo.Add(godzilla);
            zoo.Add(bruni);

            zoo.Add(genericAnimal);
            zoo.Add(genericMammal);
            zoo.Add(genericReptile);

            // new animal
            zoo.Add(new Lion("Nala", 4, "Tan"));


            PrintZoo(zoo);
            // The PrintZoo method worked without change for the provided Zoo animal
            // Adding a new animal just requires only a new class and instances

            Console.WriteLine("\nPress the power off button to exit.");
            Console.ReadLine();
        }

        /// <summary>
        /// prints detail for a list of animal objects
        /// https://stackoverflow.com/questions/25363759/c-sharp-printing-a-list
        /// </summary>
        /// <param name="animals">A list containing objects of animal</param>
        public static void PrintZoo(List<Animal> animals)
        {
            if (animals.Count == 0)
            {
                // Check if there is any animal in the zoo
                Console.WriteLine("The zoo is broke");
                return;
            }

            foreach (Animal animal in animals)
            {
                // loop through all thee animal in the list
                // Polymorphism for Describe
                // animal type is called automatically
                Console.WriteLine(animal.Describe());

                // Polymorphism for MakeSound
                animal.MakeSound();
                Console.WriteLine();
            }
            Console.WriteLine("End of Zoo so go back home");
        }
    }
}
