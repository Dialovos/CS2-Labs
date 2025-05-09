namespace PolymorphismLab
{
    /// <summary>
    /// inheriting from Animal and IMovable
    /// </summary>
    public class Cat : Animal, IMovable
    {
        /// <summary>
        /// abstract Speak method from the Animal class
        /// </summary>
        public override void Speak()
        {
            Console.WriteLine("Meow!");
        }

        /// <summary>
        /// 
        /// </summary>
        public void Move()
        {
            Console.WriteLine("The cat prowls.");
        }
    }
}
