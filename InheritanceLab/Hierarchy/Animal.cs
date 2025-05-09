namespace InheritanceLab
{
    /// <summary>
    /// Base class which all animals share
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// accessible from anywhere and allow getting and setting animal name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// accessible only within this class and any class that inherits from Animal like mammal or reptile
        /// it'll protects from being accessed outside the inheritance
        /// </summary>
        protected int Age { get; set; }

        /// <summary>
        /// accessible only within the Animal class and used for internal storage
        /// </summary>
        private string _species;

        /// <summary>
        /// Provides access to the private _species field which is Encapsulation
        /// </summary>
        public string Species
        {
            get { return _species; }

            // add validation if needed
            set { _species = value; }
        }

        /// <summary>
        /// Constructor: used to start a new animal object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="species"></param>
        public Animal(string name, int age, string species)
        {
            Name = name;
            Age = age;

            // uses the public property instead of the private field
            Species = species;
        }

        /// <summary>
        /// provide their own specific implementation for overriding
        /// if not then stay at base version
        /// </summary>
        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} says: Demonic sound");
        }


        /// <summary>
        /// virtual method a description
        /// can be override to add more more details
        /// </summary>
        /// <returns></returns>
        public virtual string Describe()
        {
            // protected property of age can be accessed from this class
            return $"Name: {Name}, Age: {Age}, Species: {Species}";
        }

        /// <summary>
        /// Show that code within the animal class can access its oen protected members
        /// inherit member of the base class can also call it
        /// </summary>
        /// <param name="and"></param>
        /// <param name="also"></param>
        /// <param name="it"></param>
        /// <returns></returns>
        public void DisplayAgePrivately()
        {
            Console.WriteLine($"Private protection check - {Name} age: {Age}");
        }
    }
}