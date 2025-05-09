// File: CoolCodingStyleLab.Tests/BugTests.cs
using Lab02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoolCodingStyleLab.Tests
{
    [TestClass]
    public class BugTests
    {
        [TestMethod]
        public void TestBugDescription()
        {
            // Arrange
            Bug testBug = new Bug("Ant", 6);

            // Act
            string description = testBug.DescribeBug();

            // Assert
            Assert.AreEqual("This bug is a Ant and has 6 legs.", description);
        }

        [TestMethod]
        public void TestTotalBugCount()
        {
            // Arrange - Create initial count
            int initialCount = Bug.TotalBugCount;

            // Act - Create new bug
            Bug newBug = new Bug("Beetle", 6);

            // Assert - Check if count increased by 1
            Assert.AreEqual(initialCount + 1, Bug.TotalBugCount);
        }

        // Note: Testing console output requires more advanced techniques
        // In a real application, we would modify CountBugs to return a string
        // or use a StringBuilder to make it more testable
    }
}