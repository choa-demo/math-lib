using System;

namespace MathLib
{
    /// <summary>
    /// Provides numerical methods for solving mathematical problems
    /// </summary>
    public static class NumericalMethods
    {
        /// <summary>
        /// Finds the root of a function using the Newton-Raphson method
        /// </summary>
        /// <param name="function">The function to find the root of</param>
        /// <param name="derivative">The derivative of the function</param>
        /// <param name="initialGuess">Initial guess for the root</param>
        /// <param name="tolerance">Tolerance for convergence</param>
        /// <param name="maxIterations">Maximum number of iterations</param>
        /// <returns>The root of the function</returns>
        /// <exception cref="InvalidOperationException">Thrown when method fails to converge</exception>
        public static double NewtonRaphson(Func<double, double> function, Func<double, double> derivative,
            double initialGuess, double tolerance = 1e-10, int maxIterations = 100)
        {
            double x = initialGuess;
            
            for (int i = 0; i < maxIterations; i++)
            {
                double fx = function(x);
                double fpx = derivative(x);
                
                if (Math.Abs(fpx) < tolerance)
                    throw new InvalidOperationException("Derivative is too close to zero");
                
                double newX = x - fx / fpx;
                
                if (Math.Abs(newX - x) < tolerance)
                    return newX;
                
                x = newX;
            }
            
            throw new InvalidOperationException("Method failed to converge");
        }

        /// <summary>
        /// Finds the root of a function using the bisection method
        /// </summary>
        /// <param name="function">The function to find the root of</param>
        /// <param name="a">Left boundary of the interval</param>
        /// <param name="b">Right boundary of the interval</param>
        /// <param name="tolerance">Tolerance for convergence</param>
        /// <param name="maxIterations">Maximum number of iterations</param>
        /// <returns>The root of the function</returns>
        /// <exception cref="ArgumentException">Thrown when function values at boundaries have the same sign</exception>
        public static double Bisection(Func<double, double> function, double a, double b,
            double tolerance = 1e-10, int maxIterations = 100)
        {
            double fa = function(a);
            double fb = function(b);
            
            if (fa * fb > 0)
                throw new ArgumentException("Function values at boundaries must have opposite signs");
            
            for (int i = 0; i < maxIterations; i++)
            {
                double c = (a + b) / 2;
                double fc = function(c);
                
                if (Math.Abs(fc) < tolerance || Math.Abs(b - a) < tolerance)
                    return c;
                
                if (fa * fc < 0)
                {
                    b = c;
                    fb = fc;
                }
                else
                {
                    a = c;
                    fa = fc;
                }
            }
            
            return (a + b) / 2;
        }

        /// <summary>
        /// Performs numerical integration using the trapezoidal rule
        /// </summary>
        /// <param name="function">The function to integrate</param>
        /// <param name="a">Lower limit of integration</param>
        /// <param name="b">Upper limit of integration</param>
        /// <param name="n">Number of subintervals</param>
        /// <returns>The approximate integral</returns>
        public static double TrapezoidalIntegration(Func<double, double> function, double a, double b, int n = 1000)
        {
            double h = (b - a) / n;
            double sum = 0.5 * (function(a) + function(b));
            
            for (int i = 1; i < n; i++)
            {
                sum += function(a + i * h);
            }
            
            return h * sum;
        }

        /// <summary>
        /// Performs numerical integration using Simpson's rule
        /// </summary>
        /// <param name="function">The function to integrate</param>
        /// <param name="a">Lower limit of integration</param>
        /// <param name="b">Upper limit of integration</param>
        /// <param name="n">Number of subintervals (must be even)</param>
        /// <returns>The approximate integral</returns>
        /// <exception cref="ArgumentException">Thrown when n is not even</exception>
        public static double SimpsonsIntegration(Func<double, double> function, double a, double b, int n = 1000)
        {
            if (n % 2 != 0)
                throw new ArgumentException("Number of subintervals must be even", nameof(n));
            
            double h = (b - a) / n;
            double sum = function(a) + function(b);
            
            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;
                sum += (i % 2 == 0 ? 2 : 4) * function(x);
            }
            
            return h * sum / 3;
        }

        /// <summary>
        /// Performs numerical differentiation using forward difference
        /// </summary>
        /// <param name="function">The function to differentiate</param>
        /// <param name="x">The point at which to evaluate the derivative</param>
        /// <param name="h">The step size</param>
        /// <returns>The approximate derivative</returns>
        public static double ForwardDifference(Func<double, double> function, double x, double h = 1e-8)
        {
            return (function(x + h) - function(x)) / h;
        }

        /// <summary>
        /// Performs numerical differentiation using backward difference
        /// </summary>
        /// <param name="function">The function to differentiate</param>
        /// <param name="x">The point at which to evaluate the derivative</param>
        /// <param name="h">The step size</param>
        /// <returns>The approximate derivative</returns>
        public static double BackwardDifference(Func<double, double> function, double x, double h = 1e-8)
        {
            return (function(x) - function(x - h)) / h;
        }

        /// <summary>
        /// Performs numerical differentiation using central difference
        /// </summary>
        /// <param name="function">The function to differentiate</param>
        /// <param name="x">The point at which to evaluate the derivative</param>
        /// <param name="h">The step size</param>
        /// <returns>The approximate derivative</returns>
        public static double CentralDifference(Func<double, double> function, double x, double h = 1e-8)
        {
            return (function(x + h) - function(x - h)) / (2 * h);
        }

        /// <summary>
        /// Solves a system of linear equations using Gaussian elimination
        /// </summary>
        /// <param name="matrix">Augmented matrix [A|b]</param>
        /// <returns>Solution vector</returns>
        /// <exception cref="ArgumentException">Thrown when matrix is not square or system has no unique solution</exception>
        public static double[] GaussianElimination(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            
            if (m != n + 1)
                throw new ArgumentException("Matrix must be augmented (n x n+1)");
            
            // Forward elimination
            for (int i = 0; i < n; i++)
            {
                // Find pivot
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(matrix[k, i]) > Math.Abs(matrix[maxRow, i]))
                        maxRow = k;
                }
                
                // Swap rows
                if (maxRow != i)
                {
                    for (int k = i; k < m; k++)
                    {
                        (matrix[i, k], matrix[maxRow, k]) = (matrix[maxRow, k], matrix[i, k]);
                    }
                }
                
                // Check for singular matrix
                if (Math.Abs(matrix[i, i]) < 1e-10)
                    throw new ArgumentException("Matrix is singular or nearly singular");
                
                // Eliminate
                for (int k = i + 1; k < n; k++)
                {
                    double factor = matrix[k, i] / matrix[i, i];
                    for (int j = i; j < m; j++)
                    {
                        matrix[k, j] -= factor * matrix[i, j];
                    }
                }
            }
            
            // Back substitution
            double[] solution = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                solution[i] = matrix[i, n];
                for (int j = i + 1; j < n; j++)
                {
                    solution[i] -= matrix[i, j] * solution[j];
                }
                solution[i] /= matrix[i, i];
            }
            
            return solution;
        }
    }
}
