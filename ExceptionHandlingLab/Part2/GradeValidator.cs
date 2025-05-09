namespace ExceptionHandlingLab
{
    /// <summary>
    /// validate student grade
    /// </summary>
    public static class GradeValidator
    {
        /// <summary>
        /// Throws an InvalidGradeException if the grade is outside of 0 to 100
        /// </summary>
        /// <param name="grade"></param>
        /// <exception cref="InvalidGradeException"></exception>
        public static void ValidateGrade(int grade)
        {
            // check if the grade is outside of the range
            if (grade < 0 || grade > 100)
            {
                // if invalid, throw the custom exception
                throw new InvalidGradeException($"Grade must be between 0 and 100. Invalid grade: {grade}");
            }

            // If the grade is valid then print the grade
            Console.WriteLine($"Grade {grade} is valid.");
        }
    }
}