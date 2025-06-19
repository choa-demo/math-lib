using System;

namespace MathLib
{
    /// <summary>
    /// Provides advanced mathematical functions including power, exponential, and logarithmic operations
    /// </summary>
    public static class AdvancedMath
    {
        /// <summary>
        /// Calculates x raised to the power of y
        /// </summary>
        /// <param name="x">The base</param>
        /// <param name="y">The exponent</param>
        /// <returns>x^y</returns>
        public static double Power(double x, double y) => Math.Pow(x, y);

        /// <summary>
        /// Calculates the square root of a number
        /// </summary>
        /// <param name="value">The input value</param>
        /// <returns>The square root</returns>
        public static double Sqrt(double value) => Math.Sqrt(value);

        /// <summary>
        /// Calculates the cube root of a number
        /// </summary>
        /// <param name="value">The input value</param>
        /// <returns>The cube root</returns>
        public static double Cbrt(double value) => Math.Pow(value, 1.0 / 3.0);

        /// <summary>
        /// Calculates the nth root of a number
        /// </summary>
        /// <param name="value">The input value</param>
        /// <param name="n">The root degree</param>
        /// <returns>The nth root</returns>
        public static double NthRoot(double value, double n) => Math.Pow(value, 1.0 / n);

        /// <summary>
        /// Calculates e raised to the power of x
        /// </summary>
        /// <param name="x">The exponent</param>
        /// <returns>e^x</returns>
        public static double Exp(double x) => Math.Exp(x);

        /// <summary>
        /// Calculates the natural logarithm (base e) of a number
        /// </summary>
        /// <param name="value">The input value</param>
        /// <returns>ln(value)</returns>
        public static double Log(double value) => Math.Log(value);

        /// <summary>
        /// Calculates the logarithm of a number in a specified base
        /// </summary>
        /// <param name="value">The input value</param>
        /// <param name="baseValue">The logarithm base</param>
        /// <returns>log_base(value)</returns>
        public static double Log(double value, double baseValue) => Math.Log(value, baseValue);

        /// <summary>
        /// Calculates the base-10 logarithm of a number
        /// </summary>
        /// <param name="value">The input value</param>
        /// <returns>log10(value)</returns>
        public static double Log10(double value) => Math.Log10(value);

        /// <summary>
        /// Calculates the base-2 logarithm of a number
        /// </summary>
        /// <param name="value">The input value</param>
        /// <returns>log2(value)</returns>
        public static double Log2(double value) => Math.Log2(value);

        /// <summary>
        /// Calculates the factorial of a non-negative integer
        /// </summary>
        /// <param name="n">The input value</param>
        /// <returns>n!</returns>
        /// <exception cref="ArgumentException">Thrown when n is negative</exception>
        public static double Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Factorial is not defined for negative numbers", nameof(n));
            
            if (n == 0 || n == 1)
                return 1;
            
            double result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        /// <summary>
        /// Calculates the gamma function for positive real numbers
        /// </summary>
        /// <param name="x">The input value</param>
        /// <returns>Γ(x)</returns>
        public static double Gamma(double x)
        {
            // Approximation using Stirling's formula for demonstration
            // For production use, consider more accurate implementations
            if (x < 0.5)
                return Math.PI / (Math.Sin(Math.PI * x) * Gamma(1 - x));
            
            x--;
            double result = 0.99999880;
            result += 57.15623566 / (x + 1);
            result += -59.59796035 / (x + 2);
            result += 14.13629841 / (x + 3);
            result += -0.49084936 / (x + 4);
            result += 0.00033994 / (x + 5);
            result += 0.00046917 / (x + 6);
            
            return Math.Sqrt(2 * Math.PI) * Math.Pow(x + 5.5, x + 0.5) * Math.Exp(-(x + 5.5)) * result;
        }

        /// <summary>
        /// Calculates the greatest common divisor of two integers
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <returns>GCD(a, b)</returns>
        public static int Gcd(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Calculates the least common multiple of two integers
        /// </summary>
        /// <param name="a">First integer</param>
        /// <param name="b">Second integer</param>
        /// <returns>LCM(a, b)</returns>
        public static int Lcm(int a, int b)
        {
            return Math.Abs(a * b) / Gcd(a, b);
        }
    }
}
