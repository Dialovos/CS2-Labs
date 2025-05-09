namespace FileOperationsLab
{
    /// <summary>
    /// path normalization for cross-platform
    /// </summary>
    public static class PathNormalizer
    {
        /// <summary>
        /// Converts a Windows path to a Unix path
        /// </summary>
        /// <param name="filePath"></param>
        public static void NormalizeAndPrintPath(string filePath)
        {
            // replace backslashes with forward slash
            string normalizedPath = filePath.Replace('\\', '/');

            Console.WriteLine($"Original Path: {filePath}");
            Console.WriteLine($"Normalized Path: {normalizedPath}");
        }
    }
}