namespace InheritanceLab
{
    /// <summary>
    /// Reptile, inheriting from animal
    /// Reptile properties and override method
    /// </summary>
    public class Reptile : Animal
    {
        /// <summary>
        /// specific property for reptile
        /// </summary>
        public bool CanRegrowTail { get; set; }

        /// <summary>
        /// parameters for reptile and base of animal
        /// base(name, age, species) to call the animal constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="species"></param>
        /// <param name="canRegrowTail"></param>

        public Reptile(string name, int age, string species, bool canRegrowTail) : base(name, age, species)
        {
            CanRegrowTail = canRegrowTail;
        }

        /// <summary>
        /// override method for reptile sound
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Voice Crack Screech.");
        }

        /// <summary>
        /// Attempt to access one of its protected base member
        /// </summary>
        public void VerifyProtectedAge()
        {
            Console.WriteLine($"Access Check ({Name}): Age is {Age}");
            /* _species is private to animal
               outside of this class hierarchy, trying myReptile.Age
               would cause a compile error (Animal.Age) due to its protection
               protected allows access within the class and sub class,
               but not from outside code
             */
        }

        // append reptile info to the base class
        public override string Describe()
        {
            return $"{base.Describe()}, Can Regrow Tail: {CanRegrowTail}";
        }
    }
}