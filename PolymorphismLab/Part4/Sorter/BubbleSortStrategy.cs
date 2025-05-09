namespace PolymorphismLab
{
    /// <summary>
    /// implement the SortingStrategy interface using the Bubble Sort
    /// </summary>
    public class BubbleSortStrategy : SortingStrategy
    {
        /// <summary>
        /// Sorts the array using the Bubble Sort
        /// https://dotnettutorials.net/lesson/bubble-sort-algorithm-in-csharp/
        /// </summary>
        /// <param name="array"></param>
        public void Sort(int[] array)
        {
            // sorted in descending order
            // check for edge cases
            if (array == null || array.Length < 2)
            {
                // return nothing if there's nothing to sort
                return;
            }

            // if a pass complete with no swap, the array is sorted
            bool flag = true;

            // the loop runs as long as a swap was made
            // i <= (array.Length - 1) ensures up to n-1
            for (int i = 1; (i <= (array.Length - 1)) && flag; i++)
            {
                flag = false; // reset flag for the current pass & assume sorted until a swap

                // iterates from the beginning up to the sec to last element
                for (int j = 0; j < (array.Length - 1); j++)
                {
                    // If the next element is greater than the current one, swap them
                    if (array[j + 1] > array[j])
                    {
                        // swap them
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        // swap happened, so set the flag to true
                        // This show that the array might not be fully sorted yet,
                        // & the outer loop should continue
                        flag = true;
                    }
                }
                // If flag is still false after the inner loop
                // the array is sorted, & the outer loop will stop
            }
        }
    }
}