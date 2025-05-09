namespace PolymorphismLab
{
    /// <summary>
    /// It uses an SortingStrategy object to perform sorting
    /// </summary>
    public class Sorter
    {
        // holds a reference
        private readonly SortingStrategy _strategy;

        /// <summary>
        /// new instance of the Sorter class
        /// If strategy isnt null, assign its value to _oldPrinter
        /// If strategy is null, throw an ArgumentNullException & stop the constructor 
        /// </summary>
        /// <param name="strategy"></param>
        public Sorter(SortingStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        /// <summary>
        /// perform the sort on the array
        /// </summary>
        /// <param name="array"></param>
        public void PerformSort(int[] array)
        {
            // assign the sorting task to the strategy
            _strategy.Sort(array);
        }
    }
}