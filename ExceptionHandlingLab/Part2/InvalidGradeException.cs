namespace ExceptionHandlingLab
{
    /// <summary>
    /// Inherits from the base Exception class.
    /// </summary>
    public class InvalidGradeException : Exception
    {
        /// <summary>
        /// new instance of the InvalidGradeException class
        /// </summary>
        /// <param name="message"></param>
        public InvalidGradeException(string message) : base(message)
        {
            // base(message) passes the message to the constructor of the base Exception 
        }

        /// <summary>
        /// new instance of the InvalidGradeException class
        /// </summary>
        /// <param name="message">explains the reason for the exception</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public InvalidGradeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}