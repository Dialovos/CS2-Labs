namespace PolymorphismLab
{
    /// <summary>
    /// implement the SortingStrategy interface using the Quick Sort
    /// </summary>
    public class QuickSortStrategy : SortingStrategy
    {
        /// <summary>
        /// Sorts the array using Quick Sort
        /// </summary>
        /// <param name="array"></param>
        public void Sort(int[] array)
        {
            // check for edge cases before starting
            if (array == null || array.Length < 2)
            {
                // return nothing if there's nothing to sort
                return;
            }
            // start the QuickSort
            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// recursive helper method
        /// https://code-maze.com/csharp-quicksort-algorithm/
        /// </summary>
        /// <param name="array"></param>
        /// <param name="leftIndex"></param>
        /// <param name="rightIndex"></param>
        private void QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            // track the boundaries
            var i = leftIndex;
            var j = rightIndex;

            // choose a pivot element
            var pivot = array[leftIndex];

            while (i <= j)
            {
                // find element from the left side that is >= pivot
                while (array[i] < pivot)
                {
                    i++;
                }

                // find element from the right side that is <= pivot
                while (array[j] > pivot)
                {
                    j--;
                }

                // if the left index hasn't crossed the right index, swap them
                if (i <= j)
                {
                    // swap array[i] & array[j]
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;

                    i++;
                    j--;
                }
            } // end loop (while i <= j)

            // if there are elements to the left of the pivot's final position j
            if (leftIndex < j)
                QuickSort(array, leftIndex, j);

            // if there are elements to the right of the pivot's final position i
            if (i < rightIndex)
                QuickSort(array, i, rightIndex);
        }
    }
}