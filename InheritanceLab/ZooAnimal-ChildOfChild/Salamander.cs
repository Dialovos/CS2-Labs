namespace InheritanceLab
{
    /// <summary>
    /// Salamander, sub type of amphibian and inherit from amphibian & animal.
    /// </summary>
    public class Salamander : Amphibian
    {
        /// <summary>
        /// Specific characteristic
        /// </summary>
        public bool IsNocturnal { get; set; }

        /// <summary>
        /// Initializes Salamander and its base classes
        /// Calls amphibian constructor from mammal class, base(name, age, "Caudata")
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="isNocturnal"></param>
        public Salamander(string name, int age, bool isNocturnal)
            : base(name, age, "Caudata")
        {
            // initialize Salamander property
            IsNocturnal = isNocturnal;
        }

        /// <summary>
        /// overriding amphibian sound
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} stays silent.");
        }

        // overriding Method amphibian Describe
        public override string Describe()
        {
            // get amphibian Describe and append nocturnal info.
            return $"{base.Describe()}, Is Nocturnal: {IsNocturnal}";
        }
    }
}
