//Hoang Le
//hle2@northeaststate.edu

using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Text;

namespace StringManipulationLab
{
    /// <summary>
    /// Lab04
    /// </summary>
    internal class Program
    {
        #region Part 1: String Manipulation Methods

            /// <summary>
            /// Extracts the domain part from an email address
            /// </summary>
            /// <param name="email">The email address string.</param>
            /// <returns>The domain part or empty string if invalid.</returns>
        static string ExtractDomain(string email)
        {
            // String.IndexOf method:
            // https://learn.microsoft.com/en-us/dotnet/api/system.string.indexof
            int rightAtIndex = email.IndexOf('@');

            // Checks whether "@" was found and is not the last character.
            if (rightAtIndex >= 0 && rightAtIndex < email.Length - 1)
            {
                // String.Substring method:
                // https://learn.microsoft.com/en-us/dotnet/api/system.string.substring
                return email.Substring(rightAtIndex + 1); // Returns the part after '@'
            }

            // String.Empty constant:
            // https://learn.microsoft.com/en-us/dotnet/api/system.string.empty
            return string.Empty; // Return an empty string if "@" is not found or is at the end
        }

        /// <summary>
        /// Replaces a specified word in a sentence with asterisks of the same length.
        /// </summary>
        /// <param name="sentence">The original sentence.</param>
        /// <param name="word">The word to censor.</param>
        /// <returns>The sentence with the specified word censored.</returns>
        static string CensorWord(string sentence, string word)
        {
            // String.IsNullOrEmpty method:
            // https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorempty
            if (string.IsNullOrEmpty(word))
                return sentence; // If no word found to censor, return original

            // MAke a string of "*" repeated "word.Length" times.
            // String constructor (char, int):
            // https://learn.microsoft.com/en-us/dotnet/api/system.string.-ctor#system-string-ctor(system-char-system-int32)
            string censored = new string('*', word.Length);

            return sentence.Replace(word, censored); // Replace "word" with "censored"
        }

        /// <summary>
        /// Splits a comma separated string of names into an array, trimming whitespace.
        /// </summary>
        /// <param name="names">A comma-separated string of names.</param>
        /// <returns>An array of names with whitespace removed.</returns>
        static string[] SplitNames(string names)
        {
            // String.Split method:
            // https://learn.microsoft.com/en-us/dotnet/api/system.string.split
           
            // StringSplitOptions enum:
            // https://learn.microsoft.com/en-us/dotnet/api/system.stringsplitoptions
            return names.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)

                       // LINQ Select method:
                       // https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.select

                       // For each resulting string, trim whitespace
                       .Select(name => name.Trim())

                       // LINQ ToArray method:
                       // https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.toarray
                       .ToArray(); 
                       // Convert the result into a string array
        }

        /// <summary>
        /// Removes leading and trailing whitespace from a string.
        /// </summary>
        /// <param name="text">The input string.</param>
        /// <returns>The string with leading/trailing whitespace removed.</returns>
        static string TrimWhitespace(string text)
        {
            return text.Trim();
        }
        #endregion

        #region Part 2: Regular Expression Methods

        /// <summary>
        /// Validates whether a string is a valid email address using a regex pattern.
        /// </summary>
        /// <param name="email">The string to validate.</param>
        /// <returns>True if the string matches the email pattern, false otherwise.</returns>
        static bool IsValidEmail(string email)
        {
            // Explanation: https://www.owolf.com/blog/decoding-the-regex-for-validating-email-addresses
            // ^                     : Start of the string
            // [a-zA-Z0-9._%+-]+     : One or more allowed characters for the local part (before @)
            // @                     : Literal '@' symbol
            // [a-zA-Z0-9.-]+        : One or more allowed characters for the domain name (letters, numbers, dots, hyphens)
            // \.                    : Literal '.' symbol separating domain and TLD
            // [a-zA-Z]{2,}          : Top-level domain (TLD) with 2 or more letters
            // $                     : End of the string
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Regex.IsMatch method:
            // https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.ismatch
            return Regex.IsMatch(email, pattern);
        }

        /// <summary>
        /// Extracts and prints log entries starting with "[ERROR]" from a multiline string.
        /// </summary>
        /// <param name="logs">The multiline string containing log entries.</param>
        static void ExtractErrorLogs(string logs)
        {
            // Explanation:
            // \[ERROR\] : Matches the literal string "[ERROR]" (brackets need escaping)
            // .*        : Matches any character zero or more time
            // This pattern finds lines starting with "[ERROR]"
            string pattern = @"\[ERROR\].*";

            // Regex.Matches method & RegexOptions enum (Multiline):
            // https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.matches
            // https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regexoptions
            // RegexOptions.Multiline allows ^ and $ to match the start/end of lines, not just the whole string.
           
            MatchCollection matches = Regex.Matches(logs, pattern, RegexOptions.Multiline);
            // MatchCollection Class:
            // https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.matchcollection
            
            
            // Match Class:
            // https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.match
            foreach (Match match in matches)
            {
                // Prints the entire matched line.
                Console.WriteLine(match.Value);
            }
        }
        #endregion

        #region Part 3: StringBuilder Methods

        /// <summary>
        /// Generates a formatted report string using StringBuilder for efficiency.
        /// </summary>
        /// <param name="title">The report title.</param>
        /// <param name="names">A list of names to include in the report.</param>
        /// <returns>A formatted report string.</returns>
        static string GenerateReport(string title, List<string> names)
        {
            StringBuilder reportBuilder = new StringBuilder();

            // Appends the title followed by a newline character.
            // StringBuilder.AppendLine method:
            // https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.appendline
            reportBuilder.AppendLine($"Report Title: {title}\n");

            // Loops through the names list and appends each one as a numbered item.
            for (int i = 0; i < names.Count; i++)
            {
                reportBuilder.AppendLine($"{i + 1}. {names[i]}");
            }

            // Append the generation timestamp.
            // DateTime.Now property:
            // https://learn.microsoft.com/en-us/dotnet/api/system.datetime.now
            reportBuilder.AppendLine($"\nReport generated on: {DateTime.Now}");

            // StringBuilder.ToString method:
            // https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.tostring
            // Converts the StringBuilder into a single string.
            return reportBuilder.ToString();
        }

        /// <summary>
        /// Concatenates strings using the inefficient '+' operator in a loop.
        /// Creates many intermediate string objects.
        /// </summary>
        /// <param name="count">The number of strings to concatenate.</param>
        /// <returns>The resulting concatenated string.</returns>
        static string ConcatenateStrings(int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += $"String{i} "; // Each += creates a new string object internally.
            }
            return result;
        }

        /// <summary>
        /// Concatenates strings efficiently using StringBuilder.
        /// Modifies a single buffer internally.
        /// </summary>
        /// <param name="count">The number of strings to concatenate.</param>
        /// <returns>The resulting concatenated string.</returns>
        static string ConcatenateStringsEfficiently(int count)
        {
            // StringBuilder for optimized for multiple append operations.
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                // StringBuilder.Append method:
                // https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.append
                // Appends to the internal buffer
                builder.Append($"String{i} ");
            }
            return builder.ToString();
        }

        /// <summary>
        /// Compares the performance of simple string concatenation (+) vs. StringBuilder.
        /// </summary>
        static void CompareStringConcatenationMethods()
        {
            const int concatNum = 1000;

            // Stopwatch class & Stopwatch.StartNew method:
            // https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch
            // https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.startnew
            Stopwatch stopwatch1 = Stopwatch.StartNew();

            // Run the less efficient method
            ConcatenateStrings(concatNum);
            
            // Stopwatch.Stop method:
            // https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.stop
            stopwatch1.Stop();

            Stopwatch stopwatch2 = Stopwatch.StartNew();
            ConcatenateStringsEfficiently(concatNum);
            // Run the efficient method
            stopwatch2.Stop();

            // Stopwatch.ElapsedMilliseconds property:
            // https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.elapsedmilliseconds
            Console.WriteLine($"ConcatenateStrings execution time: {stopwatch1.ElapsedMilliseconds} ms");
            Console.WriteLine($"ConcatenateStringsEfficiently execution time: {stopwatch2.ElapsedMilliseconds} ms");

            // See how many times faster the StringBuilder method was.
            Console.WriteLine($"Performance improvement: {(double)stopwatch1.ElapsedMilliseconds / stopwatch2.ElapsedMilliseconds:F2}x faster");
        }
        #endregion

        #region Main Program
        static void Main()
        {
            Console.WriteLine("String Manipulation Lab\n\n");

            // Part 1: Demonstrates basic string methods
            Console.WriteLine("Part 1: String Manipulation\n");

            // --- ExtractDomain ---
            string email = "milk@man.com";
            // String interpolation ($""):
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
            Console.WriteLine($"ExtractDomain(\"{email}\"): {ExtractDomain(email)}");

            // --- CensorWord ---
            string sentence = "What is 9 plus 10?";
            string wordToCensor = "plus";
            Console.WriteLine($"CensorWord(\"{sentence}\", \"{wordToCensor}\"): {CensorWord(sentence, wordToCensor)}");

            // --- SplitNames ---
            string names = "sky, tree, lake";
            // String.Join method:
            // https://learn.microsoft.com/en-us/dotnet/api/system.string.join
            Console.WriteLine($"SplitNames(\"{names}\"): [{string.Join(", ", SplitNames(names))}]");

            // --- TrimWhitespace ---
            string textWithWhitespace = " Hello World                ";
            Console.WriteLine($"TrimWhitespace(\"{textWithWhitespace}\"): \"{TrimWhitespace(textWithWhitespace)}\"\n");


            // Part 2: Demonstrates regular expressions
            Console.WriteLine("\nPart 2: Working with Regular Expressions\n");

            // --- IsValidEmail ---
            // List<T> class:
            // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1
            List<string> emailListTest = new List<string>
            {
                "valid@example.com",
                "email",
                "goofy.ahhhh@phantom.tax.co.tn",
                "@gov.com",
                "google.com"
            };

            Console.WriteLine("Email Validation:");
            foreach (var emailTest in emailListTest)
            {
                Console.WriteLine($"IsValidEmail(\"{emailTest}\"): {IsValidEmail(emailTest)}");
            }

            // --- ExtractErrorLogs ---
            Console.WriteLine();
            string sampleLog =@"[INFO] 2024-12-30 10:15:45 - User logged in
[ERROR] 2024-12-30 10:16:00 - Failed to load resource
[INFO] 2024-12-30 10:17:30 - User logged out";

            Console.WriteLine($"Log:\n{sampleLog}");
            Console.WriteLine("\nLog Errors:");
            ExtractErrorLogs(sampleLog);

            // Part 3: Demonstrates StringBuilder
            Console.WriteLine("\n\nPart 3: Using the StringBuilder Class\n");

            // --- GenerateReport ---
            List<string> userNames = new List<string> { "Human2103", "BeachBob", "DoodooBird", "ArkSurvivalGod" };
            Console.WriteLine(GenerateReport("User", userNames));

            // --- Compare string concatenation performance ---
            Console.WriteLine("\nPerformance Comparison:");
            CompareStringConcatenationMethods();

            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
        #endregion
    }
}