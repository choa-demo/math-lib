using Xunit;
using MathLib;
using System;

namespace MathLib.Tests
{
    public class VectorTests
    {
        [Fact]
        public void Vector2_CalculatesMagnitudeCorrectly()
        {
            var vector = new Vector2(3, 4);
            Assert.Equal(5.0, vector.Magnitude);
        }

        [Fact]
        public void Vector2_CalculatesDotProductCorrectly()
        {
            var v1 = new Vector2(2, 3);
            var v2 = new Vector2(4, 5);
            Assert.Equal(23.0, v1.Dot(v2));
        }

        [Fact]
        public void Vector2_CalculatesCrossProductCorrectly()
        {
            var v1 = new Vector2(2, 3);
            var v2 = new Vector2(4, 5);
            Assert.Equal(-2.0, v1.Cross(v2));
        }

        [Fact]
        public void Vector2_Addition_WorksCorrectly()
        {
            var v1 = new Vector2(1, 2);
            var v2 = new Vector2(3, 4);
            var result = v1 + v2;
            Assert.Equal(new Vector2(4, 6), result);
        }

        [Fact]
        public void Vector2_Subtraction_WorksCorrectly()
        {
            var v1 = new Vector2(5, 7);
            var v2 = new Vector2(3, 4);
            var result = v1 - v2;
            Assert.Equal(new Vector2(2, 3), result);
        }

        [Fact]
        public void Vector2_ScalarMultiplication_WorksCorrectly()
        {
            var v = new Vector2(2, 3);
            var result = v * 2;
            Assert.Equal(new Vector2(4, 6), result);
        }

        [Fact]
        public void Vector2_Normalized_ReturnsUnitVector()
        {
            var v = new Vector2(3, 4);
            var normalized = v.Normalized;
            Assert.Equal(1.0, normalized.Magnitude, 10);
            Assert.Equal(0.6, normalized.X, 10);
            Assert.Equal(0.8, normalized.Y, 10);
        }

        [Fact]
        public void Vector3_CalculatesMagnitudeCorrectly()
        {
            var vector = new Vector3(2, 3, 6);
            Assert.Equal(7.0, vector.Magnitude);
        }

        [Fact]
        public void Vector3_CalculatesDotProductCorrectly()
        {
            var v1 = new Vector3(1, 2, 3);
            var v2 = new Vector3(4, 5, 6);
            Assert.Equal(32.0, v1.Dot(v2));
        }

        [Fact]
        public void Vector3_CalculatesCrossProductCorrectly()
        {
            var v1 = new Vector3(1, 0, 0);
            var v2 = new Vector3(0, 1, 0);
            var result = v1.Cross(v2);
            Assert.Equal(new Vector3(0, 0, 1), result);
        }

        [Fact]
        public void Vector3_Addition_WorksCorrectly()
        {
            var v1 = new Vector3(1, 2, 3);
            var v2 = new Vector3(4, 5, 6);
            var result = v1 + v2;
            Assert.Equal(new Vector3(5, 7, 9), result);
        }

        [Fact]
        public void Vector3_ScalarMultiplication_WorksCorrectly()
        {
            var v = new Vector3(1, 2, 3);
            var result = v * 3;
            Assert.Equal(new Vector3(3, 6, 9), result);
        }

        [Fact]
        public void Vector3_StaticProperties_HaveCorrectValues()
        {
            Assert.Equal(new Vector3(0, 0, 0), Vector3.Zero);
            Assert.Equal(new Vector3(1, 1, 1), Vector3.One);
            Assert.Equal(new Vector3(1, 0, 0), Vector3.UnitX);
            Assert.Equal(new Vector3(0, 1, 0), Vector3.UnitY);
            Assert.Equal(new Vector3(0, 0, 1), Vector3.UnitZ);
        }
    }
}
