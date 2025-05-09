namespace ExceptionHandlingLab
{
    /// <summary>
    /// handles division operation
    /// </summary>
    public static class DivisionHandler
    {
        /// <summary>
        /// a/b & prints the result.
        /// Handles DivideByZeroException if b is 0
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void DivideNumbers(int a, int b)
        {
            try
            {
                int result = a / b;
                Console.WriteLine($"{a} / {b} = {result}");
            }
            catch (DivideByZeroException ex)
            {
                // It's better to catch specific exceptions than a generic Exception
                // so you know exactly what went wrong
                Console.WriteLine($"Error: Cannot divide by zero.");
            }
        }
    }
}