using Xunit;
using MathLib;

namespace MathLib.Tests
{
    public class BasicMathTests
    {
        [Fact]
        public void Abs_ReturnsAbsoluteValue()
        {
            Assert.Equal(5.0, BasicMath.Abs(-5.0));
            Assert.Equal(5.0, BasicMath.Abs(5.0));
            Assert.Equal(0.0, BasicMath.Abs(0.0));
        }

        [Fact]
        public void Max_ReturnsMaximumValue()
        {
            Assert.Equal(10.0, BasicMath.Max(5.0, 10.0));
            Assert.Equal(10.0, BasicMath.Max(10.0, 5.0));
            Assert.Equal(5.0, BasicMath.Max(5.0, 5.0));
        }

        [Fact]
        public void Min_ReturnsMinimumValue()
        {
            Assert.Equal(5.0, BasicMath.Min(5.0, 10.0));
            Assert.Equal(5.0, BasicMath.Min(10.0, 5.0));
            Assert.Equal(5.0, BasicMath.Min(5.0, 5.0));
        }

        [Fact]
        public void Clamp_ClampsValueBetweenMinAndMax()
        {
            Assert.Equal(5.0, BasicMath.Clamp(3.0, 5.0, 10.0));
            Assert.Equal(10.0, BasicMath.Clamp(15.0, 5.0, 10.0));
            Assert.Equal(7.5, BasicMath.Clamp(7.5, 5.0, 10.0));
        }

        [Fact]
        public void Round_RoundsToNearestInteger()
        {
            Assert.Equal(5.0, BasicMath.Round(4.6));
            Assert.Equal(4.0, BasicMath.Round(4.4));
            Assert.Equal(4.0, BasicMath.Round(4.5)); // Banker's rounding
        }

        [Fact]
        public void Sign_ReturnsCorrectSign()
        {
            Assert.Equal(1, BasicMath.Sign(5.0));
            Assert.Equal(-1, BasicMath.Sign(-5.0));
            Assert.Equal(0, BasicMath.Sign(0.0));
        }
    }
}
