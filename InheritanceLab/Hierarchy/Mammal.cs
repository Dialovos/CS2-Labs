namespace InheritanceLab
{
    /// <summary>
    /// Mammal, which inherits properties from animal
    /// </summary>
    public class Mammal : Animal 
    {
        /// <summary>
        /// mammals trait and defaulted to true
        /// </summary>
        public bool IsItWarmBlooded { get; set; } = true;

        /// <summary>
        /// parameters from Mammal and base class
        /// : base(name, age, species) calls the constructor of the base class
        /// to initialize the properties that is already defined (constructor chaining)
        /// https://stackoverflow.com/questions/1814953/how-to-do-constructor-chaining-in-c-sharp
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="species"></param>
        public Mammal(string name, int age, string species) : base(name, age, species)
        {
            // IsWarmBlooded is already initialized in its definition
            // so nothing needs to go here
        }

        /// <summary>
        /// replaces the base class virtual method behavior for mammal object
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Mammal sound.");
        }

        /// <summary>
        /// override the base class Describe method with Mammal info
        /// </summary>
        /// <returns></returns>
        public override string Describe()
        {
            // base.Describe() get the Describe method from the base class
            // reusing the base class description and appending new info
            return $"{base.Describe()}, Warm-Blooded: {IsItWarmBlooded}";
        }
    }
}