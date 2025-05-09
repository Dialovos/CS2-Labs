namespace FileOperationsLab
{
    /// <summary>
    /// basic binary file operation
    /// </summary>
    public static class BinaryFileHandler
    {
        /// <summary>
        /// binary file & writes many different data types
        /// </summary>
        /// <param name="filePath"></param>
        public static void WriteBinaryFile(string filePath)
        {
            Console.WriteLine($"\nNew Binary file: {filePath}");
            try
            {
                // https://www.geeksforgeeks.org/basics-of-filestream-in-c-sharp/
                // use FileStream to create & write new file
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                using (BinaryWriter writer = new BinaryWriter(fileStream))
                {
                    writer.Write(42);
                    writer.Write(3.14159);
                    writer.Write("Binary files are efficient!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Reads data from a binary file
        /// </summary>
        /// <param name="filePath"></param>
        public static void ReadBinaryFile(string filePath)
        {
            Console.WriteLine($"\nReading Binary file: {filePath}");
            try
            {
                // check if the file exist before reading it
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File not found: {filePath}");
                    return;
                }

                // use FileStream to open and read
                using (FileStream FileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (BinaryReader reader = new BinaryReader(FileStream))
                {
                    Console.WriteLine("Binary File Content:");
                    int intInput = reader.ReadInt32();
                    double doubleInput = reader.ReadDouble();
                    string stringInput = reader.ReadString();

                    Console.WriteLine($"Integer: {intInput}");
                    Console.WriteLine($"Double: {doubleInput}");
                    Console.WriteLine($"String: {stringInput}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates binary file with new data
        /// </summary>
        /// <param name="filePath">The path of the file to overwrite.</param>
        public static void UpdateBinaryFile(string filePath)
        {
            Console.WriteLine($"\nOverwriting Binary file: {filePath}");
            try
            {
                // creates a new file
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                using (BinaryWriter writer = new BinaryWriter(fileStream))
                {
                    // Write new data
                    writer.Write(666);
                    writer.Write(1.61803);
                    writer.Write("New Binary data");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes the binary file after checking if it exists.
        /// </summary>
        /// <param name="filePath">The path of the file to delete.</param>
        public static void DeleteBinaryFile(string filePath)
        {
            Console.WriteLine($"\nDeleting binary file: {filePath}");
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("Binary file deleted");
                }
                else
                {
                    Console.WriteLine("Binary file not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}