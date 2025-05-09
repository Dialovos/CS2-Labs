namespace ExceptionHandlingLab
{
    /// <summary>
    /// dandle access to array 
    /// </summary>
    public static class ArrayAccessor
    {
        /// <summary>
        /// Handles IndexOutOfRangeException if the index is invalid &
        /// ArgumentNullException if the array is null
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public static void AccessArrayElement(int[] array, int index)
        {
            try
            {
                // Check for null array 
                if (array == null)
                {
                    throw new ArgumentNullException(nameof(array), "The array cannot be null.");
                }

                // try to access the array
                Console.WriteLine($"Array element at index {index}: {array[index]}");
            }
            catch (IndexOutOfRangeException ex)
            {
                // catch the exception for accessing an index outside of range
                Console.WriteLine($"Error: Index is out of range.");
            }
            catch (ArgumentNullException ex)
            {
                // catch the exception if the array passed in is null
                Console.WriteLine($"Error: Array is null.");
            }
        }
    }
}