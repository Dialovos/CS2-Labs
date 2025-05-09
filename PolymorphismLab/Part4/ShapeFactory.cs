namespace PolymorphismLab
{
    /// <summary>
    /// uses the Factory Method to match pattern
    /// </summary>
    public static class ShapeFactory
    {
        /// <summary>
        /// creates a Shape object based on the type name
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        public static Shape CreateShape(string shapeType)
        {
            if (string.Equals(shapeType, "Circle"))
            {
                Console.WriteLine("Factory creating Circle");
                return new Circle();
            }

            else if (string.Equals(shapeType, "Rectangle"))
            {
                Console.WriteLine("Factory creating Rectangle");
                return new Rectangle();
            }

            else
            {
                // Handle unknown types, return null so there's no error
                throw new ArgumentException($"Unknown shape: {shapeType}");
            }
        }
    }
}
