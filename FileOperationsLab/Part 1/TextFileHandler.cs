namespace FileOperationsLab
{
    /// <summary>
    /// basic text file operation
    /// </summary>
    public static class TextFileHandler
    {
        /// <summary>
        /// text file initial content
        /// StreamWriter for automatic resource management
        /// </summary>
        /// <param name="filePath"></param>
        public static void CreateAndWriteTextFile(string filePath)
        {
            Console.WriteLine($"\nNew Text file: {filePath}");
            try
            {
                // The using statement ensures the StreamWriter is  disposed of
                // even if errors happens
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("File Operations Rules of Thumb:");
                    writer.WriteLine("1. Always handle exceptions.");
                    writer.WriteLine("2. Always close your files.");
                    writer.WriteLine("3. Keep paths consistent across platforms.");
                }
            }
            catch (Exception ex) // Catch other unexpected errors
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Reads the content of a text file & displays it
        /// </summary>
        /// <param name="filePath"></param>
        public static void ReadTextFile(string filePath)
        {
            Console.WriteLine($"\nStreamReader: {filePath}");
            try
            {
                // check if the file exist before trying to read it
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File not found: {filePath}");
                    return;
                }

                // using ensures StreamReader is disposed & closed
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string content;
                    Console.WriteLine("File Content:");
                    while ((content = reader.ReadLine()) != null) // read until end of file
                    {
                        Console.WriteLine(content);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Appends text to text file
        /// </summary>
        /// <param name="filePath"></param>
        public static void UpdateTextFile(string filePath)
        {
            Console.WriteLine($"\nUpdate text file: {filePath}");
            try
            {
                // check if the file exist before appending
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File not found: {filePath}.");
                    return;
                }

                // use StreamWriter to append by setting the second argument to true
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine("4. Use the \"using\" keyword to manage resources efficiently.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes text file after checking if it exists
        /// </summary>
        /// <param name="filePath"></param>
        public static void DeleteTextFile(string filePath)
        {
            Console.WriteLine($"\nDeleting text file: {filePath}");
            try
            {
                // if the file exist delete it, if not then br to the latter
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("Text file deleted.");
                }
                else
                {
                    Console.WriteLine("Text file not found for deletion.");
                }
            }
            catch (IOException ex) // catch errors during deletion
            {
                Console.WriteLine($"Error for deleting text file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }
    }
}