namespace PolymorphismLab
{
    /// <summary>
    /// virtual method for drawing
    /// </summary>
    public class Shape
    {
        /// <summary>
        /// representation of the shape to the console
        /// allowing derived classes to override it
        /// </summary>
        public virtual void Draw()
        {
            Console.WriteLine("Drawing a generic shape.");
        }
    }
}
