using System;
using System.Collections.Generic;
using System.Linq;

namespace MathLib
{
    /// <summary>
    /// Provides statistical functions and calculations
    /// </summary>
    public static class Statistics
    {
        /// <summary>
        /// Calculates the arithmetic mean of a collection of numbers
        /// </summary>
        /// <param name="values">Collection of numbers</param>
        /// <returns>The mean value</returns>
        /// <exception cref="ArgumentException">Thrown when the collection is empty</exception>
        public static double Mean(IEnumerable<double> values)
        {
            var array = values.ToArray();
            if (array.Length == 0)
                throw new ArgumentException("Cannot calculate mean of empty collection", nameof(values));
            
            return array.Average();
        }

        /// <summary>
        /// Calculates the median of a collection of numbers
        /// </summary>
        /// <param name="values">Collection of numbers</param>
        /// <returns>The median value</returns>
        /// <exception cref="ArgumentException">Thrown when the collection is empty</exception>
        public static double Median(IEnumerable<double> values)
        {
            var sorted = values.OrderBy(x => x).ToArray();
            if (sorted.Length == 0)
                throw new ArgumentException("Cannot calculate median of empty collection", nameof(values));
            
            int middle = sorted.Length / 2;
            if (sorted.Length % 2 == 0)
                return (sorted[middle - 1] + sorted[middle]) / 2.0;
            else
                return sorted[middle];
        }

        /// <summary>
        /// Calculates the mode(s) of a collection of numbers
        /// </summary>
        /// <param name="values">Collection of numbers</param>
        /// <returns>The most frequently occurring value(s)</returns>
        /// <exception cref="ArgumentException">Thrown when the collection is empty</exception>
        public static IEnumerable<double> Mode(IEnumerable<double> values)
        {
            var array = values.ToArray();
            if (array.Length == 0)
                throw new ArgumentException("Cannot calculate mode of empty collection", nameof(values));
            
            var frequency = array.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            int maxCount = frequency.Values.Max();
            return frequency.Where(kv => kv.Value == maxCount).Select(kv => kv.Key);
        }

        /// <summary>
        /// Calculates the range of a collection of numbers
        /// </summary>
        /// <param name="values">Collection of numbers</param>
        /// <returns>The range (max - min)</returns>
        /// <exception cref="ArgumentException">Thrown when the collection is empty</exception>
        public static double Range(IEnumerable<double> values)
        {
            var array = values.ToArray();
            if (array.Length == 0)
                throw new ArgumentException("Cannot calculate range of empty collection", nameof(values));
            
            return array.Max() - array.Min();
        }

        /// <summary>
        /// Calculates the population variance of a collection of numbers
        /// </summary>
        /// <param name="values">Collection of numbers</param>
        /// <returns>The population variance</returns>
        /// <exception cref="ArgumentException">Thrown when the collection is empty</exception>
        public static double PopulationVariance(IEnumerable<double> values)
        {
            var array = values.ToArray();
            if (array.Length == 0)
                throw new ArgumentException("Cannot calculate variance of empty collection", nameof(values));
            
            double mean = Mean(array);
            return array.Select(x => Math.Pow(x - mean, 2)).Average();
        }

        /// <summary>
        /// Calculates the sample variance of a collection of numbers
        /// </summary>
        /// <param name="values">Collection of numbers</param>
        /// <returns>The sample variance</returns>
        /// <exception cref="ArgumentException">Thrown when the collection has less than 2 elements</exception>
        public static double SampleVariance(IEnumerable<double> values)
        {
            var array = values.ToArray();
            if (array.Length < 2)
                throw new ArgumentException("Cannot calculate sample variance with less than 2 values", nameof(values));
            
            double mean = Mean(array);
            return array.Select(x => Math.Pow(x - mean, 2)).Sum() / (array.Length - 1);
        }

        /// <summary>
        /// Calculates the population standard deviation of a collection of numbers
        /// </summary>
        /// <param name="values">Collection of numbers</param>
        /// <returns>The population standard deviation</returns>
        public static double PopulationStandardDeviation(IEnumerable<double> values)
        {
            return Math.Sqrt(PopulationVariance(values));
        }

        /// <summary>
        /// Calculates the sample standard deviation of a collection of numbers
        /// </summary>
        /// <param name="values">Collection of numbers</param>
        /// <returns>The sample standard deviation</returns>
        public static double SampleStandardDeviation(IEnumerable<double> values)
        {
            return Math.Sqrt(SampleVariance(values));
        }

        /// <summary>
        /// Calculates the covariance between two collections of numbers
        /// </summary>
        /// <param name="x">First collection</param>
        /// <param name="y">Second collection</param>
        /// <returns>The covariance</returns>
        /// <exception cref="ArgumentException">Thrown when collections have different lengths or are empty</exception>
        public static double Covariance(IEnumerable<double> x, IEnumerable<double> y)
        {
            var xArray = x.ToArray();
            var yArray = y.ToArray();
            
            if (xArray.Length != yArray.Length)
                throw new ArgumentException("Collections must have the same length");
            
            if (xArray.Length == 0)
                throw new ArgumentException("Cannot calculate covariance of empty collections");
            
            double xMean = Mean(xArray);
            double yMean = Mean(yArray);
            
            return xArray.Zip(yArray, (xi, yi) => (xi - xMean) * (yi - yMean)).Average();
        }

        /// <summary>
        /// Calculates the Pearson correlation coefficient between two collections of numbers
        /// </summary>
        /// <param name="x">First collection</param>
        /// <param name="y">Second collection</param>
        /// <returns>The correlation coefficient</returns>
        public static double Correlation(IEnumerable<double> x, IEnumerable<double> y)
        {
            var xArray = x.ToArray();
            var yArray = y.ToArray();
            
            double covariance = Covariance(xArray, yArray);
            double xStdDev = PopulationStandardDeviation(xArray);
            double yStdDev = PopulationStandardDeviation(yArray);
            
            return covariance / (xStdDev * yStdDev);
        }

        /// <summary>
        /// Calculates the percentile of a value in a collection
        /// </summary>
        /// <param name="values">Collection of numbers</param>
        /// <param name="percentile">Percentile value (0-100)</param>
        /// <returns>The value at the specified percentile</returns>
        /// <exception cref="ArgumentException">Thrown when percentile is not between 0 and 100</exception>
        public static double Percentile(IEnumerable<double> values, double percentile)
        {
            if (percentile < 0 || percentile > 100)
                throw new ArgumentException("Percentile must be between 0 and 100", nameof(percentile));
            
            var sorted = values.OrderBy(x => x).ToArray();
            if (sorted.Length == 0)
                throw new ArgumentException("Cannot calculate percentile of empty collection", nameof(values));
            
            if (percentile == 100)
                return sorted[sorted.Length - 1];
            
            double index = percentile / 100.0 * (sorted.Length + 1) - 1;
            int lowerIndex = (int)Math.Floor(index);
            int upperIndex = (int)Math.Ceiling(index);
            
            if (lowerIndex < 0)
                return sorted[0];
            if (upperIndex >= sorted.Length)
                return sorted[sorted.Length - 1];
            
            double weight = index - lowerIndex;
            return sorted[lowerIndex] * (1 - weight) + sorted[upperIndex] * weight;
        }

        /// <summary>
        /// Calculates the quartiles of a collection of numbers
        /// </summary>
        /// <param name="values">Collection of numbers</param>
        /// <returns>Tuple containing Q1, Q2 (median), and Q3</returns>
        public static (double Q1, double Q2, double Q3) Quartiles(IEnumerable<double> values)
        {
            return (
                Percentile(values, 25),
                Percentile(values, 50),
                Percentile(values, 75)
            );
        }

        /// <summary>
        /// Calculates the interquartile range of a collection of numbers
        /// </summary>
        /// <param name="values">Collection of numbers</param>
        /// <returns>The interquartile range (Q3 - Q1)</returns>
        public static double InterquartileRange(IEnumerable<double> values)
        {
            var quartiles = Quartiles(values);
            return quartiles.Q3 - quartiles.Q1;
        }
    }
}
