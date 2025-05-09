namespace ExceptionHandlingLab
{
    /// <summary>
    /// Handles reading files
    /// </summary>
    public static class LoggingFileReader
    {
        /// <summary>
        /// define log file name as error_log.txt
        /// </summary>
        private const string LogFileName = "error_log.txt";

        /// <summary>
        /// reads the whole file
        /// Handle FileNotFoundException and logs it to a file
        /// </summary>
        /// <param name="filePath"></param>
        public static void ReadFile(string filePath)
        {
            StreamReader reader = null;

            try
            {
                reader = new StreamReader(filePath);
                Console.WriteLine($"Reading content from {filePath}");
                Console.WriteLine(reader.ReadToEnd());
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: File not found -> {filePath}.");
                LogError(ex, $"Trying to read file: {filePath}");
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    Console.WriteLine($"File closed.");
                }
            }
            // Avoid Generic Exception Handling bc we don't know what kind of error happened
            // Catching them broadly can hide these problems make debugging harder
        }

        /// <summary>
        /// Logs exception details
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="contextMessage"></param>
        private static void LogError(Exception ex, string contextMessage = "")
        {
            try
            {
                string logEntry = $"{DateTime.Now}: {ex.Message}{Environment.NewLine}";

                File.AppendAllText(LogFileName, logEntry);
                Console.WriteLine($"Error logged to {LogFileName}");
            }
            catch (Exception logEx)
            {
                // If logging fails, catch it to avoid repeating loop / hidden errors.
                Console.WriteLine($"Failed to write to log file {LogFileName} -> Log Error: {logEx.Message}");
                Console.WriteLine($"Original Error: {ex.Message}");
            }
        }
    }
}