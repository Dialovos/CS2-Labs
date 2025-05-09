namespace ExceptionHandlingLab
{
    /// <summary>
    /// handles reading files 
    /// </summary>
    public static class FileReaderPart1
    {
        /// <summary>
        /// Reads the entire content of a file specified by the file path.
        /// Handles FileNotFoundException if the file doesn't exist.
        /// Ensures the StreamReader is closed using a finally block, regardless of success or failure.
        /// </summary>
        /// <param name="filePath">The path to the file to read.</param>
        public static void ReadFile(string filePath)
        {
            StreamReader reader = null; // define it outside the try block so it's accessible in finally

            try
            {
                // open the file for reading
                reader = new StreamReader(filePath);

                // Read the whole file
                Console.WriteLine($"File Content: {filePath}");
                Console.WriteLine(reader.ReadToEnd());
            }
            catch (FileNotFoundException ex)
            {
                // catch the exception if the file cannot be found at the path
                Console.WriteLine($"Error: File not found.");
            }
            finally
            {
                // resource cleanup
                if (reader != null)
                {
                    reader.Close(); // close file stream to release system resources
                    Console.WriteLine($"File closed.");
                }
                else
                {
                    // indicate if the file was open
                    Console.WriteLine($"No file stream was opened");
                }
                // using (StreamReader reader = new StreamReader(filePath))
                // The using statement automatically calls Dispose() 
            }
        }
    }
}