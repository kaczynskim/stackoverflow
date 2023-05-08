namespace Stackoverflow.Tests
{
    using NUnit.Framework;
    using StackOverflow;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class DistinctValuesFinderTests
    {
        private static int[][]? _arrays;

        [SetUp]
        public void Setup()
        {
            _arrays = new int[][]
            {
            new int[] { 1, 2, 3 },
            new int[] { 3, 4, 5 },
            new int[] { 5, 6, 7 },
            new int[] { 7, 8, 9 }
            };
        }

        [Test]
        public void FindDistinctValuesLazy_ReturnsDistinctValues()
        {
            // Arrange
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = DistinctValuesFinder.FindDistinctValuesLazy(_arrays);

            // Assert
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void FindDistinctValuesEager_ReturnsDistinctValues()
        {
            // Arrange
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = DistinctValuesFinder.FindDistinctValuesEager(_arrays);

            // Assert
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void FindDistinctValuesSplit_ReturnsDistinctValues()
        {
            // Arrange
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = DistinctValuesFinder.FindDistinctValuesSplit(_arrays);

            // Assert
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void FindDistinctValuesWithoutLinq_ReturnsDistinctValues()
        {
            // Arrange
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = DistinctValuesFinder.FindDistinctValuesWithoutLinq(_arrays);

            // Assert
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void GetDistinctValuesUnionOnly_ReturnsDistinctValues()
        {
            // Arrange
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            var result = DistinctValuesFinder.GetDistinctValuesUnionOnly(_arrays);

            // Assert
            Assert.That(result, Is.EquivalentTo(expected));
        }
    }
}