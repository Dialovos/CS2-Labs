namespace PolymorphismLab
{
    /// <summary>
    /// basic calculation through method overloading
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Add 2 integer together
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Add(int a, int b)
        {
            Console.WriteLine("-> Add(int a, int b)");
            return a + b;
        }

        /// <summary>
        /// Add 2 double precision floating point #
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Add(double a, double b)
        {
            Console.WriteLine("-> Add(double a, double b)");
            return a + b;
        }

        /// <summary>
        /// Concatenates 2 string
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string Add(string a, string b)
        {
            Console.WriteLine("-> Add(string a, string b)");
            return a + b;
        }
    }
}
