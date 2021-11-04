using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

using TerrainGenerator.Builders;

namespace TerrainGenerator.Tests.Builders
{
    [TestClass]
    public class TerrainGeneratorBuilderTests
    {
        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(0, 1)]
        [DataRow(1, 0)]
        [DataRow(-5, -5)]
        [DataRow(-5, 10)]
        [DataRow(15, -99)]
        public void InvalidSizeShouldThrowException(int width, int height)
        {
            var builder = new TerrainGeneratorBuilder();

            Assert.ThrowsException<ArgumentException>(() =>
            {
                builder.SetSize(width, height);
            });
        }
    }
}
