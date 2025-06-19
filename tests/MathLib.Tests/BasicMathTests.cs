using Xunit;
using MathLib;


namespace MathLib.Tests
{
    /// <summary>
    /// Contains unit tests for the BasicMath class functionality.
    /// </summary>
    public class BasicMathTests
    {
        /// <summary>
        /// Tests the Abs method to ensure it returns the absolute value of a number.
        /// Test cases:
        /// - Negative value (-5.0) should return positive (5.0)
        /// - Positive value (5.0) should remain unchanged (5.0)
        /// - Zero (0.0) should return zero (0.0)
        /// </summary>
        [Fact]
        public void Abs_ReturnsAbsoluteValue()
        {
            Assert.Equal(5.0, BasicMath.Abs(-5.0));
            Assert.Equal(5.0, BasicMath.Abs(5.0));
            Assert.Equal(0.0, BasicMath.Abs(0.0));
        }

        /// <summary>
        /// Tests the Max method to ensure it returns the larger of two values.
        /// Test cases:
        /// - First value smaller (5.0, 10.0) should return second value (10.0)
        /// - Second value smaller (10.0, 5.0) should return first value (10.0)
        /// - Equal values (5.0, 5.0) should return that value (5.0)
        /// </summary>
        [Fact]
        public void Max_ReturnsMaximumValue()
        {
            Assert.Equal(10.0, BasicMath.Max(5.0, 10.0));
            Assert.Equal(10.0, BasicMath.Max(10.0, 5.0));
            Assert.Equal(5.0, BasicMath.Max(5.0, 5.0));
        }

        /// <summary>
        /// Tests the Min method to ensure it returns the smaller of two values.
        /// Test cases:
        /// - First value smaller (5.0, 10.0) should return first value (5.0)
        /// - Second value smaller (10.0, 5.0) should return second value (5.0)
        /// - Equal values (5.0, 5.0) should return that value (5.0)
        /// </summary>
        [Fact]
        public void Min_ReturnsMinimumValue()
        {
            Assert.Equal(5.0, BasicMath.Min(5.0, 10.0));
            Assert.Equal(5.0, BasicMath.Min(10.0, 5.0));
            Assert.Equal(5.0, BasicMath.Min(5.0, 5.0));
        }

        /// <summary>
        /// Tests the Clamp method to ensure it restricts a value to a specified range.
        /// Test cases:
        /// - Value below minimum (3.0, min=5.0, max=10.0) should return minimum (5.0)
        /// - Value above maximum (15.0, min=5.0, max=10.0) should return maximum (10.0)
        /// - Value within range (7.5, min=5.0, max=10.0) should return unchanged (7.5)
        /// </summary>
        [Fact]
        public void Clamp_ClampsValueBetweenMinAndMax()
        {
            Assert.Equal(5.0, BasicMath.Clamp(3.0, 5.0, 10.0));
            Assert.Equal(10.0, BasicMath.Clamp(15.0, 5.0, 10.0));
            Assert.Equal(7.5, BasicMath.Clamp(7.5, 5.0, 10.0));
        }

        /// <summary>
        /// Tests the Round method to ensure it rounds values to the nearest integer.
        /// Test cases:
        /// - Value with decimal above 0.5 (4.6) should round up to (5.0)
        /// - Value with decimal below 0.5 (4.4) should round down to (4.0)
        /// - Value with decimal exactly 0.5 (4.5) should round to even (4.0) per Banker's rounding
        /// </summary>
        [Fact]
        public void Round_RoundsToNearestInteger()
        {
            Assert.Equal(5.0, BasicMath.Round(4.6));
            Assert.Equal(4.0, BasicMath.Round(4.4));
            Assert.Equal(4.0, BasicMath.Round(4.5)); // Banker's rounding
        }

        /// <summary>
        /// Tests the Sign method to ensure it returns the sign of a value.
        /// Test cases:
        /// - Positive value (5.0) should return 1
        /// - Negative value (-5.0) should return -1
        /// - Zero (0.0) should return 0
        /// </summary>
        [Fact]
        public void Sign_ReturnsCorrectSign()
        {
            Assert.Equal(1, BasicMath.Sign(5.0));
            Assert.Equal(-1, BasicMath.Sign(-5.0));
            Assert.Equal(0, BasicMath.Sign(0.0));
        }
    }
}