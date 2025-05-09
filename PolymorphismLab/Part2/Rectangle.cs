namespace PolymorphismLab
{
    /// <summary>
    /// overrides the Draw method
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// overrides the base Draw method
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine("Drawing a Rectangle.");
        }
    }
}
