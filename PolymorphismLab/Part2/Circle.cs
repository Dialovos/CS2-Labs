namespace PolymorphismLab
{
    /// <summary>
    /// overrides the Draw method
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// overrides the base Draw method
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine("Draw a Circle.");
        }
    }
}
