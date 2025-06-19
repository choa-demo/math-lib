using System;
using System.Linq;
using MathLib;

namespace MathLib.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== MathLib Examples ===\n");

            // Basic Math Examples
            Console.WriteLine("1. Basic Math Operations:");
            Console.WriteLine($"   Abs(-15.5) = {BasicMath.Abs(-15.5)}");
            Console.WriteLine($"   Max(10, 25) = {BasicMath.Max(10, 25)}");
            Console.WriteLine($"   Min(10, 25) = {BasicMath.Min(10, 25)}");
            Console.WriteLine($"   Clamp(30, 10, 25) = {BasicMath.Clamp(30, 10, 25)}");
            Console.WriteLine($"   Round(3.14159, 2) = {BasicMath.Round(3.14159, 2)}");
            Console.WriteLine();

            // Advanced Math Examples
            Console.WriteLine("2. Advanced Math Operations:");
            Console.WriteLine($"   Power(2, 10) = {AdvancedMath.Power(2, 10)}");
            Console.WriteLine($"   Sqrt(144) = {AdvancedMath.Sqrt(144)}");
            Console.WriteLine($"   Cbrt(27) = {AdvancedMath.Cbrt(27)}");
            Console.WriteLine($"   Factorial(7) = {AdvancedMath.Factorial(7)}");
            Console.WriteLine($"   GCD(48, 18) = {AdvancedMath.Gcd(48, 18)}");
            Console.WriteLine($"   LCM(12, 8) = {AdvancedMath.Lcm(12, 8)}");
            Console.WriteLine($"   Log(Math.E^3) = {AdvancedMath.Log(Math.Pow(Math.E, 3)):F4}");
            Console.WriteLine($"   Log10(1000) = {AdvancedMath.Log10(1000)}");
            Console.WriteLine();

            // Trigonometry Examples
            Console.WriteLine("3. Trigonometry:");
            double angle45 = Trigonometry.ToRadians(45);
            Console.WriteLine($"   45° in radians = {angle45:F4}");
            Console.WriteLine($"   Sin(45°) = {Trigonometry.Sin(angle45):F4}");
            Console.WriteLine($"   Cos(45°) = {Trigonometry.Cos(angle45):F4}");
            Console.WriteLine($"   Tan(45°) = {Trigonometry.Tan(angle45):F4}");
            Console.WriteLine($"   Asin(0.5) in degrees = {Trigonometry.ToDegrees(Trigonometry.Asin(0.5)):F1}°");
            Console.WriteLine($"   Sec(60°) = {Trigonometry.Sec(Trigonometry.ToRadians(60)):F4}");
            Console.WriteLine();

            // Statistics Examples
            Console.WriteLine("4. Statistics:");
            var dataset = new[] { 2.5, 3.1, 4.7, 5.2, 6.8, 7.1, 8.9, 9.2, 10.5, 11.3 };
            Console.WriteLine($"   Dataset: [{string.Join(", ", dataset)}]");
            Console.WriteLine($"   Mean = {Statistics.Mean(dataset):F2}");
            Console.WriteLine($"   Median = {Statistics.Median(dataset):F2}");
            Console.WriteLine($"   Range = {Statistics.Range(dataset):F2}");
            Console.WriteLine($"   Standard Deviation = {Statistics.PopulationStandardDeviation(dataset):F2}");
            var quartiles = Statistics.Quartiles(dataset);
            Console.WriteLine($"   Quartiles: Q1={quartiles.Q1:F2}, Q2={quartiles.Q2:F2}, Q3={quartiles.Q3:F2}");
            Console.WriteLine($"   75th Percentile = {Statistics.Percentile(dataset, 75):F2}");
            Console.WriteLine();

            // Vector Examples
            Console.WriteLine("5. Vector Operations:");
            var v1 = new Vector2(3, 4);
            var v2 = new Vector2(1, 2);
            Console.WriteLine($"   Vector2 v1 = {v1}");
            Console.WriteLine($"   Vector2 v2 = {v2}");
            Console.WriteLine($"   v1.Magnitude = {v1.Magnitude:F2}");
            Console.WriteLine($"   v1 + v2 = {v1 + v2}");
            Console.WriteLine($"   v1 · v2 = {v1.Dot(v2)}");
            Console.WriteLine($"   v1 × v2 = {v1.Cross(v2)}");
            Console.WriteLine($"   Distance(v1, v2) = {v1.DistanceTo(v2):F2}");
            Console.WriteLine($"   v1.Normalized = {v1.Normalized}");
            Console.WriteLine();

            var v3d1 = new Vector3(1, 2, 3);
            var v3d2 = new Vector3(4, 5, 6);
            Console.WriteLine($"   Vector3 v3d1 = {v3d1}");
            Console.WriteLine($"   Vector3 v3d2 = {v3d2}");
            Console.WriteLine($"   v3d1 × v3d2 = {v3d1.Cross(v3d2)}");
            Console.WriteLine();

            // Matrix Examples
            Console.WriteLine("6. Matrix Operations:");
            var m1 = new Matrix2x2(1, 2, 3, 4);
            var m2 = new Matrix2x2(5, 6, 7, 8);
            Console.WriteLine($"   Matrix2x2 m1:");
            Console.WriteLine($"   {m1.ToString().Replace("\n", "\n   ")}");
            Console.WriteLine($"   Matrix2x2 m2:");
            Console.WriteLine($"   {m2.ToString().Replace("\n", "\n   ")}");
            Console.WriteLine($"   m1 * m2:");
            Console.WriteLine($"   {(m1 * m2).ToString().Replace("\n", "\n   ")}");
            Console.WriteLine($"   m1.Determinant = {m1.Determinant}");
            Console.WriteLine($"   m1.Transpose:");
            Console.WriteLine($"   {m1.Transpose.ToString().Replace("\n", "\n   ")}");
            Console.WriteLine();

            // Numerical Methods Examples
            Console.WriteLine("7. Numerical Methods:");
            
            // Root finding example: find root of x^2 - 4 = 0
            Func<double, double> func = x => x * x - 4;
            Func<double, double> derivative = x => 2 * x;
            try
            {
                double root = NumericalMethods.NewtonRaphson(func, derivative, 1.0);
                Console.WriteLine($"   Root of x² - 4 = 0 using Newton-Raphson: {root:F6}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Newton-Raphson failed: {ex.Message}");
            }

            try
            {
                double root = NumericalMethods.Bisection(func, 0, 5);
                Console.WriteLine($"   Root of x² - 4 = 0 using Bisection: {root:F6}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Bisection failed: {ex.Message}");
            }

            // Integration example: integrate x^2 from 0 to 2
            Func<double, double> integrand = x => x * x;
            double integral = NumericalMethods.TrapezoidalIntegration(integrand, 0, 2, 1000);
            Console.WriteLine($"   ∫₀² x² dx using Trapezoidal rule: {integral:F6} (exact: {8.0/3:F6})");
            
            integral = NumericalMethods.SimpsonsIntegration(integrand, 0, 2, 1000);
            Console.WriteLine($"   ∫₀² x² dx using Simpson's rule: {integral:F6} (exact: {8.0/3:F6})");

            // Differentiation example: derivative of x^3 at x = 2
            Func<double, double> cubic = x => x * x * x;
            double derivative_approx = NumericalMethods.CentralDifference(cubic, 2);
            Console.WriteLine($"   d/dx(x³) at x=2 using Central Difference: {derivative_approx:F6} (exact: 12)");
            Console.WriteLine();

            // Linear system example
            Console.WriteLine("8. Linear System Solution:");
            // Solve: 2x + 3y = 7, 4x + y = 6
            double[,] augmentedMatrix = {
                { 2, 3, 7 },
                { 4, 1, 6 }
            };
            
            try
            {
                double[] solution = NumericalMethods.GaussianElimination(augmentedMatrix);
                Console.WriteLine($"   System: 2x + 3y = 7, 4x + y = 6");
                Console.WriteLine($"   Solution: x = {solution[0]:F2}, y = {solution[1]:F2}");
                Console.WriteLine($"   Verification: 2({solution[0]:F2}) + 3({solution[1]:F2}) = {2*solution[0] + 3*solution[1]:F2}");
                Console.WriteLine($"   Verification: 4({solution[0]:F2}) + ({solution[1]:F2}) = {4*solution[0] + solution[1]:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Linear system solution failed: {ex.Message}");
            }

            Console.WriteLine("\n=== End of Examples ===");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
