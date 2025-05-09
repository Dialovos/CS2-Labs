//Hoang Le
//hle2@northeaststate.edu.

namespace FileOperationsLab
{
    /// <summary>
    /// Lab08
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        static void Main()
        {
            // define file path
            // using Path.Combine ensures cross-platform
            string textFile = Path.Combine(Environment.CurrentDirectory, "text.txt");
            string binaryFile = Path.Combine(Environment.CurrentDirectory, "data.bin");
            string exampleFile = @"C:\Users\something\text.txt";
            string nonExistentFile = Path.Combine(Environment.CurrentDirectory, "nofile.txt");

            Console.WriteLine("(Part 1)");
            TextFileHandler.CreateAndWriteTextFile(textFile);
            TextFileHandler.ReadTextFile(textFile);
            TextFileHandler.UpdateTextFile(textFile);
            Console.WriteLine("\nUpdated content->");
            TextFileHandler.ReadTextFile(textFile); // read the update
            TextFileHandler.DeleteTextFile(textFile);

            Console.WriteLine("\n\n(Part 2)");
            BinaryFileHandler.WriteBinaryFile(binaryFile);
            BinaryFileHandler.ReadBinaryFile(binaryFile);
            BinaryFileHandler.UpdateBinaryFile(binaryFile);
            Console.WriteLine("\nUpdated content->");
            BinaryFileHandler.ReadBinaryFile(binaryFile); // read the update
            BinaryFileHandler.DeleteBinaryFile(binaryFile);

            Console.WriteLine("\n\n(Part 3)");
            FilePathInfoPrinter.PrintFilePathInfo(exampleFile);

            Console.WriteLine("\nTrying to read a file that doesn't exist->");
            SafeFileReader.ReadFileSafe(nonExistentFile);

            Console.WriteLine("\n\n(Part 4)");
            PathNormalizer.NormalizeAndPrintPath(exampleFile);

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();


            // using:
            // File operations are limited and must be released when you're finished
            // like StreamWriter, StreamReader, FileStream, BinaryWriter, BinaryReader
            // the using statement ensures the Dispose() method
            // is always called on the object declared in the statement
            // even if an exception happened

            // Text vs Binary file
            // Text file store data as readable characters
            // binary files store data as bytes/raw data

            // path class
            // Use Path.GetFileName, Path.GetExtension to manipulate file paths instead of
            // manual string
            // The Path class handles platform differences
        }
    }
}