namespace FileOperationsLab
{
    /// <summary>
    /// reading files
    /// </summary>
    public static class SafeFileReader
    {
        /// <summary>
        /// read a file using StreamReader & handles FileNotFoundException
        /// </summary>
        /// <param name="filePath"></param>
        public static void ReadFileSafe(string filePath)
        {
            Console.WriteLine($"\nReading file safely: {filePath}");
            try
            {
                // If the file doesn't exist, the StreamReader constructor will throw
                // the FileNotFoundException before the using executes.
                using (StreamReader reader = new StreamReader(filePath))
                {
                    Console.WriteLine("Safe Read:");
                    string? content;
                    while ((content = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(content);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: File not found");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}