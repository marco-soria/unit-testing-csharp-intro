using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

//using Xunit;

namespace StringManipulation.Tests
{
    public class StringOperationsTest
    {
        [Fact(Skip = "This test is not available now, TICKET-001")]
        public void ConcatenateStrings()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.ConcatenateStrings("Hello", "World");

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Hello World", result);
        }

        [Fact]
        public void IsPalindrome_True()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.IsPalindrome("madam");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.IsPalindrome("cool");

            //Assert
            Assert.False(result);

        }

        [Fact]
        public void RemoveWhitespace()
        {
            var strStringManipulation = new StringOperations();
            var result = strStringManipulation.RemoveWhitespace("Hello, this is crazy");
            Assert.DoesNotContain(" ", result);
        }

        [Fact]
        public void QuantintyInWords()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.QuantintyInWords("cat", 10);

            //Assert
            Assert.StartsWith("ten", result);
            Assert.Contains("cat", result);

        }

        [Fact]
        public void GetStringLength_Exception()
        {
            var strOperations = new StringOperations();

            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
        }

        [Fact]
        public void GetStringLength()
        {
            //Arrange
            var strStringManipulation = new StringOperations();
            //Act 
            var word = "New word";
            var result = strStringManipulation.GetStringLength(word);
            //Assert
            Assert.Equal(word.Length, result);
        }


        [Fact]
        public void TruncateString_Exception()
        {
            //Arrange
            var strStringManipulation = new StringOperations();
            //Act //Assert
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => strStringManipulation.TruncateString("Test", 0));
        }

        [Theory]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("X", 10)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            var strOperations = new StringOperations();

            var result = strOperations.FromRomanToNumber(romanNumber);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountOccurrences()
        {
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(mockLogger.Object);

            var result = strOperations.CountOccurrences("Hello platzi", 'l');

            Assert.Equal(3, result);
        }

        [Fact]
        public void ReadFile()
        {
            var strOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file");

            var result = strOperations.ReadFile(mockFileReader.Object, "file2.txt");

            Assert.Equal("Reading file", result);
        }
    }
}
