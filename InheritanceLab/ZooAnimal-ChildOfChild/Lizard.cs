namespace InheritanceLab
{
    /// <summary>
    /// Represents, sub type of reptile
    /// </summary>
    public class Lizard : Reptile 
    {
        /// <summary>
        /// Lizard appearance
        /// </summary>
        public string SkinPattern { get; set; }

        /// <summary>
        /// Initializes Lizard and base classes and call the reptile constructor
        /// passing up reptile info including whether it can regrow a tail
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="canRegrowTail"></param>
        /// <param name="skinPattern"></param>
        public Lizard(string name, int age, bool canRegrowTail, string skinPattern)
            : base(name, age, "Squamata", canRegrowTail)
        {
            // initialize lizard property
            SkinPattern = skinPattern;
        }

        // Ignore the override for the reptile sound and use
        // uses the default from the reptile class

        /// <summary>
        /// lizard detail inherited from reptile
        /// </summary>
        /// <returns></returns>
        public override string Describe()
        {
            // Calls Reptile Describe and appends lizard skin pattern info
            return $"{base.Describe()}, Skin Pattern: {SkinPattern}";
        }
    }
}
