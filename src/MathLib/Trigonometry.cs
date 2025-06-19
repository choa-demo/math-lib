using System;

namespace MathLib
{
    /// <summary>
    /// Provides trigonometric functions
    /// </summary>
    public static class Trigonometry
    {
        /// <summary>
        /// Mathematical constant π (pi)
        /// </summary>
        public const double Pi = Math.PI;
        
        /// <summary>
        /// Mathematical constant e
        /// </summary>
        public const double E = Math.E;

        /// <summary>
        /// Converts degrees to radians
        /// </summary>
        /// <param name="degrees">Angle in degrees</param>
        /// <returns>Angle in radians</returns>
        public static double ToRadians(double degrees) => degrees * Math.PI / 180.0;

        /// <summary>
        /// Converts radians to degrees
        /// </summary>
        /// <param name="radians">Angle in radians</param>
        /// <returns>Angle in degrees</returns>
        public static double ToDegrees(double radians) => radians * 180.0 / Math.PI;

        /// <summary>
        /// Calculates the sine of an angle
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns>Sine of the angle</returns>
        public static double Sin(double angle) => Math.Sin(angle);

        /// <summary>
        /// Calculates the cosine of an angle
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns>Cosine of the angle</returns>
        public static double Cos(double angle) => Math.Cos(angle);

        /// <summary>
        /// Calculates the tangent of an angle
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns>Tangent of the angle</returns>
        public static double Tan(double angle) => Math.Tan(angle);

        /// <summary>
        /// Calculates the arcsine of a value
        /// </summary>
        /// <param name="value">Input value between -1 and 1</param>
        /// <returns>Arcsine in radians</returns>
        public static double Asin(double value) => Math.Asin(value);

        /// <summary>
        /// Calculates the arccosine of a value
        /// </summary>
        /// <param name="value">Input value between -1 and 1</param>
        /// <returns>Arccosine in radians</returns>
        public static double Acos(double value) => Math.Acos(value);

        /// <summary>
        /// Calculates the arctangent of a value
        /// </summary>
        /// <param name="value">Input value</param>
        /// <returns>Arctangent in radians</returns>
        public static double Atan(double value) => Math.Atan(value);

        /// <summary>
        /// Calculates the arctangent of y/x using the signs of both arguments
        /// </summary>
        /// <param name="y">Y coordinate</param>
        /// <param name="x">X coordinate</param>
        /// <returns>Arctangent in radians</returns>
        public static double Atan2(double y, double x) => Math.Atan2(y, x);

        /// <summary>
        /// Calculates the hyperbolic sine of a value
        /// </summary>
        /// <param name="value">Input value</param>
        /// <returns>Hyperbolic sine</returns>
        public static double Sinh(double value) => Math.Sinh(value);

        /// <summary>
        /// Calculates the hyperbolic cosine of a value
        /// </summary>
        /// <param name="value">Input value</param>
        /// <returns>Hyperbolic cosine</returns>
        public static double Cosh(double value) => Math.Cosh(value);

        /// <summary>
        /// Calculates the hyperbolic tangent of a value
        /// </summary>
        /// <param name="value">Input value</param>
        /// <returns>Hyperbolic tangent</returns>
        public static double Tanh(double value) => Math.Tanh(value);

        /// <summary>
        /// Calculates the inverse hyperbolic sine of a value
        /// </summary>
        /// <param name="value">Input value</param>
        /// <returns>Inverse hyperbolic sine</returns>
        public static double Asinh(double value) => Math.Log(value + Math.Sqrt(value * value + 1));

        /// <summary>
        /// Calculates the inverse hyperbolic cosine of a value
        /// </summary>
        /// <param name="value">Input value (must be >= 1)</param>
        /// <returns>Inverse hyperbolic cosine</returns>
        public static double Acosh(double value) => Math.Log(value + Math.Sqrt(value * value - 1));

        /// <summary>
        /// Calculates the inverse hyperbolic tangent of a value
        /// </summary>
        /// <param name="value">Input value (must be between -1 and 1)</param>
        /// <returns>Inverse hyperbolic tangent</returns>
        public static double Atanh(double value) => 0.5 * Math.Log((1 + value) / (1 - value));

        /// <summary>
        /// Calculates the secant of an angle
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns>Secant of the angle</returns>
        public static double Sec(double angle) => 1.0 / Math.Cos(angle);

        /// <summary>
        /// Calculates the cosecant of an angle
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns>Cosecant of the angle</returns>
        public static double Csc(double angle) => 1.0 / Math.Sin(angle);

        /// <summary>
        /// Calculates the cotangent of an angle
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns>Cotangent of the angle</returns>
        public static double Cot(double angle) => 1.0 / Math.Tan(angle);
    }
}
