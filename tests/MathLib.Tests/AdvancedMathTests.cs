using Xunit;
using MathLib;
using System;

namespace MathLib.Tests
{
    public class AdvancedMathTests
    {
        [Fact]
        public void Power_CalculatesPowerCorrectly()
        {
            Assert.Equal(8.0, AdvancedMath.Power(2.0, 3.0));
            Assert.Equal(1.0, AdvancedMath.Power(5.0, 0.0));
            Assert.Equal(0.25, AdvancedMath.Power(2.0, -2.0));
        }

        [Fact]
        public void Sqrt_CalculatesSquareRootCorrectly()
        {
            Assert.Equal(5.0, AdvancedMath.Sqrt(25.0));
            Assert.Equal(0.0, AdvancedMath.Sqrt(0.0));
            Assert.Equal(3.0, AdvancedMath.Sqrt(9.0), 10);
        }

        [Fact]
        public void Cbrt_CalculatesCubeRootCorrectly()
        {
            Assert.Equal(2.0, AdvancedMath.Cbrt(8.0), 10);
            Assert.Equal(0.0, AdvancedMath.Cbrt(0.0), 10);
            Assert.Equal(3.0, AdvancedMath.Cbrt(27.0), 10);
        }

        [Fact]
        public void Factorial_CalculatesFactorialCorrectly()
        {
            Assert.Equal(1.0, AdvancedMath.Factorial(0));
            Assert.Equal(1.0, AdvancedMath.Factorial(1));
            Assert.Equal(2.0, AdvancedMath.Factorial(2));
            Assert.Equal(6.0, AdvancedMath.Factorial(3));
            Assert.Equal(24.0, AdvancedMath.Factorial(4));
            Assert.Equal(120.0, AdvancedMath.Factorial(5));
        }

        [Fact]
        public void Factorial_ThrowsForNegativeInput()
        {
            Assert.Throws<ArgumentException>(() => AdvancedMath.Factorial(-1));
        }

        [Fact]
        public void Gcd_CalculatesGreatestCommonDivisorCorrectly()
        {
            Assert.Equal(6, AdvancedMath.Gcd(12, 18));
            Assert.Equal(1, AdvancedMath.Gcd(17, 13));
            Assert.Equal(5, AdvancedMath.Gcd(25, 15));
            Assert.Equal(12, AdvancedMath.Gcd(12, 0));
        }

        [Fact]
        public void Lcm_CalculatesLeastCommonMultipleCorrectly()
        {
            Assert.Equal(36, AdvancedMath.Lcm(12, 18));
            Assert.Equal(221, AdvancedMath.Lcm(17, 13));
            Assert.Equal(75, AdvancedMath.Lcm(25, 15));
        }

        [Fact]
        public void Log_CalculatesLogarithmCorrectly()
        {
            Assert.Equal(0.0, AdvancedMath.Log(1.0), 10);
            Assert.Equal(1.0, AdvancedMath.Log(Math.E), 10);
            Assert.Equal(2.0, AdvancedMath.Log(Math.E * Math.E), 10);
        }

        [Fact]
        public void Log10_CalculatesBase10LogarithmCorrectly()
        {
            Assert.Equal(0.0, AdvancedMath.Log10(1.0), 10);
            Assert.Equal(1.0, AdvancedMath.Log10(10.0), 10);
            Assert.Equal(2.0, AdvancedMath.Log10(100.0), 10);
        }

        [Fact]
        public void Exp_CalculatesExponentialCorrectly()
        {
            Assert.Equal(1.0, AdvancedMath.Exp(0.0), 10);
            Assert.Equal(Math.E, AdvancedMath.Exp(1.0), 10);
        }
    }
}
