namespace PolymorphismLab
{
    /// <summary>
    /// defines the contract for sorting
    /// </summary>
    public interface SortingStrategy
    {
        /// <summary>
        /// sorts the integer array in place
        /// allow different sorting to be used
        /// </summary>
        /// <param name="array"></param>
        void Sort(int[] array);
    }
}