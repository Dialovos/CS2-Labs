namespace InheritanceLab
{
    /// <summary>
    /// amphibian, inheriting from base class
    /// become base class (mammal & reptile) for sub amphibian like salamander
    /// </summary>
    public class Amphibian : Animal
    {
        /// <summary>
        /// characteristic property of amphibian defaulted to true.
        /// </summary>
        public bool CanLiveOnLandAndWater { get; set; } = true;

        /// <summary>
        /// Initializes the base class part and sets amphibian properties
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="species"></param>
        public Amphibian(string name, int age, string species) : base(name, age, species)
        {
        }

        /// <summary>
        /// default sound for amphibian class
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: BRRRRRR RATATATATA");
        }

        // Override base class info for amphibian info
        public override string Describe()
        {
            // base.Describe gets the description string from the base class
            return $"{base.Describe()}, Lives on Land and/or Water: {CanLiveOnLandAndWater}";
        }
    }
}