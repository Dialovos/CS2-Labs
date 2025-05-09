namespace InheritanceLab
{
    /// <summary>
    /// Monkey, a sub type of mammal
    /// </summary>
    public class Monkey : Mammal
    {
        /// <summary>
        /// Specific property of monkey
        /// </summary>
        public bool HasPrehensileTail { get; set; }

        /// <summary>
        /// Initializes Monkey and its base classes
        /// get mammal constructor base(name, age, "Primate")
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="hasPrehensileTail"></param>
        public Monkey(string name, int age, bool hasPrehensileTail) : base(name, age, "Primate")
        {
            // initialize Monkey property
            HasPrehensileTail = hasPrehensileTail;
        }

        /// <summary>
        /// Monkey-specific sound
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Ooh ooh aah aahhhhhhhhhhhhhhh! ");
        }

        // Override mammal class and add monkey detail
        public override string Describe()
        {
            return $"{base.Describe()}, Has Prehensile Tail: {HasPrehensileTail}";
        }
    }
}
