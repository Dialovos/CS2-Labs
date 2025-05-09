namespace PolymorphismLab
{
    /// <summary>
    /// inheriting from Animal and IMovable
    /// </summary>
    public class Dog : Animal, IMovable
    {
        /// <summary>
        /// abstract Speak method from the Animal class
        /// </summary>
        public override void Speak()
        {
            Console.WriteLine("Woof!");
        }

        /// <summary>
        /// Move method from the IMovable interface
        /// </summary>
        public void Move()
        {
            Console.WriteLine("The dog runs.");
        }
    }
}
