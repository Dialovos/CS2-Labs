namespace Lab02
{
    internal class Bug
    {
        // Instance properties
        public string Name { get; set; }    // Name of the bug
        public int LegCount { get; set; }   // Number of legs the bug has

        // Static member to track total bugs created
        public static int TotalBugCount { get; private set; } = 0;

        /*
         * Why static vs instance members?
         * - TotalBugCount is static because it needs to track ALL bugs created across the program
         *   It's a property that belongs to the class itself, not individual bug instances
         * - DescribeBug is an instance method because it needs to access specific properties
         *   of each individual bug (Name, LegCount) to create its description
         */

        // Constructor
        public Bug(string name, int legCount)
        {
            Name = name;
            LegCount = legCount;
            TotalBugCount++;  // Increment total bug count when new bug is created
        }

        // Instance method to describe the bug
        public string DescribeBug()
        {
            return $"This bug is a {Name} and has {LegCount} legs.";
        }

        // Method to print bug countdown song
        public void CountBugs(int startCount)
        {
            // Loop from startCount down to 1
            for (int i = startCount; i > 0; i--)
            {
                Console.WriteLine($"{i} scary, gross bugs on the wall.");
                Console.WriteLine($"{i} scary, gross bugs!");
                Console.WriteLine("Take one down, pass it around,");
                Console.WriteLine($"{i - 1} scary, gross bugs on the wall!");
                Console.WriteLine();  // Empty line for readability
            }
        }
    }
}
