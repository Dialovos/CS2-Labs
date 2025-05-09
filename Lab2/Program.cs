using Lab02;
using System.Diagnostics.CodeAnalysis;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new bug instance
            Bug spider = new Bug("Spider", 8);

            // Test the bug description
            Console.WriteLine(spider.DescribeBug());

            // Start the countdown from 100
            spider.CountBugs(100);

            // Display total number of bugs created
            Console.WriteLine($"Total bugs created: {Bug.TotalBugCount}");
        }
    }
}

