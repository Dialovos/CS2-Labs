//Hoang Le
//hle2@northeaststate.edu
namespace PolymorphismLab
{
    // <summary>
    /// Lab06
    /// </summary>
    class Program
    {
        /// <summary>
        /// The entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region Part 1
            Console.WriteLine("Part 1: Method Overloading\n");
            Calculator calculator = new Calculator();
            int sumInt = calculator.Add(5, 10);
            double sumDouble = calculator.Add(3.14, 2.71);
            string concatString = calculator.Add("Gus", " Fring");

            Console.WriteLine($"Integer: 5 + 10 = {sumInt}");
            Console.WriteLine($"Double: 3.14 + 2.71 = {sumDouble}");
            Console.WriteLine($"String Concatenate: \"Gus\" + \" Fring\" = \"{concatString}\"");
            Console.WriteLine("------------------------------------");
            #endregion

            #region Part 2
            Console.WriteLine("\n\nPart 2: Method Overriding\n");

            List<Shape> shapes = new List<Shape>
            {
                new Circle(), new Rectangle(), new Shape()
            };

            Console.WriteLine("Draw() on each shape in the list:");

            foreach (Shape shape in shapes)
            {
                // Draw() called based on object type
                shape.Draw();
            }
            Console.WriteLine("------------------------------------");
            #endregion

            #region Part 3
            Console.WriteLine("\n\nPart 3: Abstract Classes & Interfaces\n");
            List<Animal> animals = new List<Animal>
            {
                new Dog(), new Cat()
            };

            Console.WriteLine("Methods on each animal in the list:");
            foreach (Animal animal in animals)
            {
                animal.Speak(); // abstract
                animal.Eat();   // concrete

                // check the animal IMovable then -> Move
                if (animal is IMovable canMoveAnimal)
                {
                    // interface
                    canMoveAnimal.Move();
                }
                else
                {
                    Console.WriteLine("This animal doesn't move.");
                }
            }
            Console.WriteLine("------------------------------------");
            #endregion

            #region Part 4
            Console.WriteLine("\n\nPart 4: Design Pattern");
            // factory matching
            try
            {
                Shape circleFactory = ShapeFactory.CreateShape("Circle");
                Console.Write("Shape created by factory: ");
                circleFactory.Draw();
                Console.WriteLine();

                Shape rectangleFactory = ShapeFactory.CreateShape("Rectangle");
                Console.Write("Shape created by factory: ");
                rectangleFactory.Draw();
                Console.WriteLine();

                // invalid input will throw an exception, testing
                Shape invalidShape = ShapeFactory.CreateShape("Triangle");
                Console.WriteLine("Trying to make invalid shape:");
                invalidShape.Draw();
            }
            catch (ArgumentException error)
            {
                Console.WriteLine($"Factory Error -> {error.Message}");
            }


            // adapter pattern
            OldPrinter oldPrinter = new OldPrinter();
            Printer newPrinter = new PrinterAdapter(oldPrinter);

            Console.Write("Using adapter -> ");
            newPrinter.Print("This text is printed using the adapter.");
            Console.WriteLine();


            // strategy pattern
            int[] testingData = { 5, 1, 4, 2, 8, -3, 9 }; // testing #
            Console.WriteLine($"Original array: [{string.Join(", ", testingData)}]"); // print it horizontally

            // use bubble sort
            Sorter sorter = new Sorter(new BubbleSortStrategy());
            Console.Write("Bubble Sort in Descending order: ");
            sorter.PerformSort(testingData);
            Console.WriteLine($"Output: [{string.Join(", ", testingData)}]"); // print it horizontally

            // reset array for next test
            testingData = new int[] { 5, 1, 4, 2, 8, -3, 9 };

            sorter = new Sorter(new QuickSortStrategy());
            Console.Write("Quick Sort: ");
            sorter.PerformSort(testingData);
            Console.WriteLine($"Output: [{string.Join(", ", testingData)}]"); // print it horizontally
            #endregion

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
