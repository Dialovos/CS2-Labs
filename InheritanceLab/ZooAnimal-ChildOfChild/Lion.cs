namespace InheritanceLab
{
    /// <summary>
    /// Lion, a sub type of mammal
    /// inherits characteristic from mammal which inherit from animal
    /// </summary>
    public class Lion : Mammal 
    {
        /// <summary>
        ///  feature of lion
        /// </summary>
        public string ManeColor { get; set; }

        /// <summary>
        /// parameters needed for Lion and its base classes of mammal 
        /// Felidae is a family member of mammals
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="maneColor"></param>& animal
        public Lion(string name, int age, string maneColor) : base(name, age, "Felidae")
        {
            ManeColor = maneColor;
        }

        /// <summary>
        /// overriding mammal MakeSound
        /// </summary>
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Roar!");
        }

        /// <summary>
        /// override the description inherited from mammal
        /// </summary>
        /// <returns></returns>
        public override string Describe()
        {
            // call mammal Describe and append Lion info
            return $"{base.Describe()}, Mane Color: {ManeColor}";
        }
    }
}