using System;

namespace MathLib
{
    /// <summary>
    /// Provides basic mathematical operations and functions
    /// </summary>
    public static class BasicMath
    {
        /// <summary>
        /// Calculates the absolute value of a number
        /// </summary>
        /// <param name="value">The input value</param>
        /// <returns>The absolute value</returns>
        public static double Abs(double value) => Math.Abs(value);

        /// <summary>
        /// Calculates the ceiling of a number
        /// </summary>
        /// <param name="value">The input value</param>
        /// <returns>The smallest integer greater than or equal to the value</returns>
        public static double Ceiling(double value) => Math.Ceiling(value);

        /// <summary>
        /// Calculates the floor of a number
        /// </summary>
        /// <param name="value">The input value</param>
        /// <returns>The largest integer less than or equal to the value</returns>
        public static double Floor(double value) => Math.Floor(value);

        /// <summary>
        /// Rounds a number to the nearest integer
        /// </summary>
        /// <param name="value">The input value</param>
        /// <returns>The rounded value</returns>
        public static double Round(double value) => Math.Round(value);

        /// <summary>
        /// Rounds a number to a specified number of decimal places
        /// </summary>
        /// <param name="value">The input value</param>
        /// <param name="digits">Number of decimal places</param>
        /// <returns>The rounded value</returns>
        public static double Round(double value, int digits) => Math.Round(value, digits);

        /// <summary>
        /// Calculates the maximum of two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>The maximum value</returns>
        public static double Max(double a, double b) => Math.Max(a, b);

        /// <summary>
        /// Calculates the minimum of two numbers
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>The minimum value</returns>
        public static double Min(double a, double b) => Math.Min(a, b);

        /// <summary>
        /// Calculates the sign of a number
        /// </summary>
        /// <param name="value">The input value</param>
        /// <returns>-1 for negative, 0 for zero, 1 for positive</returns>
        public static int Sign(double value) => Math.Sign(value);

        /// <summary>
        /// Truncates a number to its integer part
        /// </summary>
        /// <param name="value">The input value</param>
        /// <returns>The truncated value</returns>
        public static double Truncate(double value) => Math.Truncate(value);

        /// <summary>
        /// Clamps a value between a minimum and maximum
        /// </summary>
        /// <param name="value">The value to clamp</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>The clamped value</returns>
        public static double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}
