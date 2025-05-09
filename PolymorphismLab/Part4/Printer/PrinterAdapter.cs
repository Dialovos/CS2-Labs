using System.Reflection.Metadata;

namespace PolymorphismLab
{
    /// <summary>
    /// Adapts the OldPrinter class to conform to Printer 
    /// </summary>
    public class PrinterAdapter : Printer
    {
        // Holds a reference to the object being adapted 
        private readonly OldPrinter _oldPrinter;

        /// <summary>
        /// new instance of the PrinterAdapter
        /// If oldPrinter isnt null, assign its value to _oldPrinter
        /// If oldPrinter is null, throw an ArgumentNullException & stop the constructor 
        /// </summary>
        /// <param name="oldPrinter"></param>
        public PrinterAdapter(OldPrinter oldPrinter)
        {
            // throws a specific type of exception
            // bc the constructor was called with a null argument & it require a non null value
            _oldPrinter = oldPrinter ?? throw new ArgumentNullException(nameof(oldPrinter));

            // nameof(oldPrinter) just tell the error message which parameter was null
        }

        /// <summary>
        ///  calls the appropriate method on the adapted OldPrinter object
        /// </summary>
        /// <param name="text"></param>
        public void Print(string text)
        {
            // assign the call to the Adapte
            _oldPrinter.PrintOld(text);
        }
    }
}