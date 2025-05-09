
namespace PolymorphismLab
{
    /// <summary>
    /// abstract method Speak and concrete method Eat
    /// </summary>
    public abstract class Animal
    {
        /// <summary>
        /// representing the sound the animal make
        /// </summary>
        public abstract void Speak();

        /// <summary>
        /// Concrete method representing the animal eating
        /// </summary>
        public void Eat()
        {
            Console.WriteLine("This animal is eating.");
        }
    }
}
