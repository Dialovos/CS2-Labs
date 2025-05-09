//Hoang Le
//hle2@northeaststate.edu

namespace ExceptionHandlingLab
{
    /// <summary>
    /// Lab07
    /// </summary>
    class Program
    {
        /// <summary>
        ///  entry point
        /// </summary>
        static void Main()
        {
            #region Part 1
            Console.WriteLine("\nPart 1");

            // DivideByZeroException
            Console.WriteLine("\n(DivideNumbers)");
            DivisionHandler.DivideNumbers(6, 2); 
            DivisionHandler.DivideNumbers(1, 0);

            // IndexOutOfRangeException & ArgumentNullException
            Console.WriteLine("\n(AccessArrayElement)");
            int[] sampleArray = { 21, 60, 666 };
            int[] nullArray = null;

            ArrayAccessor.AccessArrayElement(sampleArray, 1);
            ArrayAccessor.AccessArrayElement(sampleArray, 5);
            ArrayAccessor.AccessArrayElement(nullArray, 0);

            // Finally Block
            Console.WriteLine("\n(ReadFile)");
            string existingFilePath = "temp_file_read.txt";
            string nonExistingFilePath = "non_existent_file.txt";

            // temporary file
            try
            {
                File.WriteAllText(existingFilePath, "Testing file");
                Console.WriteLine($"Temporary file: {existingFilePath}");
                FileReaderPart1.ReadFile(existingFilePath); // Read existing file
            }
            catch (Exception ex) // catch errors during file making
            {
                Console.WriteLine($"Error during test file creation: {ex.Message}");
            }
            finally
            {
                // Clean up the file
                if (File.Exists(existingFilePath))
                {
                    File.Delete(existingFilePath);
                    Console.WriteLine($"Cleaned up file: {existingFilePath}");
                }
            }

            FileReaderPart1.ReadFile(nonExistingFilePath); // try to read a file that doesn't not exist
            #endregion

            #region Part 2
            Console.WriteLine("\n\nPart 2");

            Console.WriteLine("\n(ValidateGrade)");
            try
            {
                GradeValidator.ValidateGrade(85);
                GradeValidator.ValidateGrade(105);
            }
            catch (InvalidGradeException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            try
            {
                GradeValidator.ValidateGrade(-10);
            }
            catch (InvalidGradeException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            #endregion

            #region Part 3
            Console.WriteLine("\n\nPart 3");

            Console.WriteLine("\n(ReadFile with Logging)");

            // Attempt to read a non-existent file to trigger logging
            LoggingFileReader.ReadFile("2nd_non_existent_file.txt");
            Console.WriteLine("Check error_log.txt for logged error");

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
            #endregion
        }
    }
}