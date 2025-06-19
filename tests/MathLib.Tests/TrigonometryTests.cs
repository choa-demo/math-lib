using Xunit;
using MathLib;
using System;

namespace MathLib.Tests
{
    public class TrigonometryTests
    {
        [Fact]
        public void ToRadians_ConvertsDegreesToRadians()
        {
            Assert.Equal(0.0, Trigonometry.ToRadians(0.0), 10);
            Assert.Equal(Math.PI / 2, Trigonometry.ToRadians(90.0), 10);
            Assert.Equal(Math.PI, Trigonometry.ToRadians(180.0), 10);
            Assert.Equal(2 * Math.PI, Trigonometry.ToRadians(360.0), 10);
        }

        [Fact]
        public void ToDegrees_ConvertsRadiansToDegrees()
        {
            Assert.Equal(0.0, Trigonometry.ToDegrees(0.0), 10);
            Assert.Equal(90.0, Trigonometry.ToDegrees(Math.PI / 2), 10);
            Assert.Equal(180.0, Trigonometry.ToDegrees(Math.PI), 10);
            Assert.Equal(360.0, Trigonometry.ToDegrees(2 * Math.PI), 10);
        }

        [Fact]
        public void Sin_CalculatesSineCorrectly()
        {
            Assert.Equal(0.0, Trigonometry.Sin(0.0), 10);
            Assert.Equal(1.0, Trigonometry.Sin(Math.PI / 2), 10);
            Assert.Equal(0.0, Trigonometry.Sin(Math.PI), 10);
            Assert.Equal(-1.0, Trigonometry.Sin(3 * Math.PI / 2), 10);
        }

        [Fact]
        public void Cos_CalculatesCosineCorrectly()
        {
            Assert.Equal(1.0, Trigonometry.Cos(0.0), 10);
            Assert.Equal(0.0, Trigonometry.Cos(Math.PI / 2), 10);
            Assert.Equal(-1.0, Trigonometry.Cos(Math.PI), 10);
            Assert.Equal(0.0, Trigonometry.Cos(3 * Math.PI / 2), 10);
        }

        [Fact]
        public void Tan_CalculatesTangentCorrectly()
        {
            Assert.Equal(0.0, Trigonometry.Tan(0.0), 10);
            Assert.Equal(1.0, Trigonometry.Tan(Math.PI / 4), 10);
            Assert.Equal(0.0, Trigonometry.Tan(Math.PI), 10);
        }

        [Fact]
        public void Asin_CalculatesArcSineCorrectly()
        {
            Assert.Equal(0.0, Trigonometry.Asin(0.0), 10);
            Assert.Equal(Math.PI / 2, Trigonometry.Asin(1.0), 10);
            Assert.Equal(-Math.PI / 2, Trigonometry.Asin(-1.0), 10);
        }

        [Fact]
        public void Acos_CalculatesArcCosineCorrectly()
        {
            Assert.Equal(Math.PI / 2, Trigonometry.Acos(0.0), 10);
            Assert.Equal(0.0, Trigonometry.Acos(1.0), 10);
            Assert.Equal(Math.PI, Trigonometry.Acos(-1.0), 10);
        }

        [Fact]
        public void Atan_CalculatesArcTangentCorrectly()
        {
            Assert.Equal(0.0, Trigonometry.Atan(0.0), 10);
            Assert.Equal(Math.PI / 4, Trigonometry.Atan(1.0), 10);
            Assert.Equal(-Math.PI / 4, Trigonometry.Atan(-1.0), 10);
        }

        [Fact]
        public void Sec_CalculatesSecantCorrectly()
        {
            Assert.Equal(1.0, Trigonometry.Sec(0.0), 10);
            Assert.Equal(-1.0, Trigonometry.Sec(Math.PI), 10);
        }

        [Fact]
        public void Csc_CalculatesCosecantCorrectly()
        {
            Assert.Equal(1.0, Trigonometry.Csc(Math.PI / 2), 10);
            Assert.Equal(-1.0, Trigonometry.Csc(3 * Math.PI / 2), 10);
        }

        [Fact]
        public void Cot_CalculatesCotangentCorrectly()
        {
            Assert.Equal(1.0, Trigonometry.Cot(Math.PI / 4), 10);
            Assert.Equal(-1.0, Trigonometry.Cot(3 * Math.PI / 4), 10);
        }
    }
}
