namespace FileOperationsLab
{
    /// <summary>
    /// displaying file path information
    /// </summary>
    public static class FilePathInfoPrinter
    {
        /// <summary>
        /// Prints the directory: file name & extension
        /// </summary>
        /// <param name="filePath"></param>
        public static void PrintFilePathInfo(string filePath)
        {
            Console.WriteLine($"\nFile path info: {filePath}");
            try
            {
                string? directory = Path.GetDirectoryName(filePath); // returns the directory info
                string? fileName = Path.GetFileNameWithoutExtension(filePath); // returns the file name part
                string? extension = Path.GetExtension(filePath); // returns the extension

                Console.WriteLine($"Directory: {directory}");
                Console.WriteLine($"File Name: {fileName}");
                Console.WriteLine($"Extension: {extension}");
            }
            catch (ArgumentException ex) // catch errors with invalid char in the path
            {
                Console.WriteLine($"Invalid path format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}