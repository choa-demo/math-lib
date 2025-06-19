using Xunit;
using MathLib;
using System.Linq;

namespace MathLib.Tests
{
    public class StatisticsTests
    {
        [Fact]
        public void Mean_CalculatesAverageCorrectly()
        {
            var values = new[] { 1.0, 2.0, 3.0, 4.0, 5.0 };
            Assert.Equal(3.0, Statistics.Mean(values));
        }

        [Fact]
        public void Median_CalculatesMedianCorrectly_OddCount()
        {
            var values = new[] { 1.0, 3.0, 2.0, 5.0, 4.0 };
            Assert.Equal(3.0, Statistics.Median(values));
        }

        [Fact]
        public void Median_CalculatesMedianCorrectly_EvenCount()
        {
            var values = new[] { 1.0, 2.0, 3.0, 4.0 };
            Assert.Equal(2.5, Statistics.Median(values));
        }

        [Fact]
        public void Mode_FindsMostFrequentValue()
        {
            var values = new[] { 1.0, 2.0, 2.0, 3.0, 3.0, 3.0 };
            var modes = Statistics.Mode(values).ToArray();
            Assert.Single(modes);
            Assert.Equal(3.0, modes[0]);
        }

        [Fact]
        public void Range_CalculatesRangeCorrectly()
        {
            var values = new[] { 1.0, 5.0, 3.0, 8.0, 2.0 };
            Assert.Equal(7.0, Statistics.Range(values));
        }

        [Fact]
        public void PopulationVariance_CalculatesVarianceCorrectly()
        {
            var values = new[] { 2.0, 4.0, 4.0, 4.0, 5.0, 5.0, 7.0, 9.0 };
            var variance = Statistics.PopulationVariance(values);
            Assert.Equal(4.0, variance, 1);
        }

        [Fact]
        public void SampleVariance_CalculatesVarianceCorrectly()
        {
            var values = new[] { 2.0, 4.0, 4.0, 4.0, 5.0, 5.0, 7.0, 9.0 };
            var variance = Statistics.SampleVariance(values);
            Assert.Equal(4.571, variance, 2);
        }

        [Fact]
        public void PopulationStandardDeviation_CalculatesStdDevCorrectly()
        {
            var values = new[] { 2.0, 4.0, 4.0, 4.0, 5.0, 5.0, 7.0, 9.0 };
            var stdDev = Statistics.PopulationStandardDeviation(values);
            Assert.Equal(2.0, stdDev, 1);
        }        [Fact]
        public void Percentile_CalculatesPercentileCorrectly()
        {
            var values = new[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0 };
            
            Assert.Equal(2.75, Statistics.Percentile(values, 25), 2);
            Assert.Equal(5.5, Statistics.Percentile(values, 50), 2);
            Assert.Equal(8.25, Statistics.Percentile(values, 75), 2);
        }        [Fact]
        public void Quartiles_CalculatesQuartilesCorrectly()
        {
            var values = new[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0 };
            var quartiles = Statistics.Quartiles(values);
            
            Assert.Equal(2.75, quartiles.Q1, 2);
            Assert.Equal(5.5, quartiles.Q2, 2);
            Assert.Equal(8.25, quartiles.Q3, 2);
        }        [Fact]
        public void InterquartileRange_CalculatesIQRCorrectly()
        {
            var values = new[] { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0 };
            var iqr = Statistics.InterquartileRange(values);
            Assert.Equal(5.5, iqr, 2);
        }

        [Fact]
        public void Covariance_CalculatesCovarianceCorrectly()
        {
            var x = new[] { 1.0, 2.0, 3.0, 4.0, 5.0 };
            var y = new[] { 2.0, 4.0, 6.0, 8.0, 10.0 };
            var covariance = Statistics.Covariance(x, y);
            Assert.Equal(4.0, covariance, 1);
        }

        [Fact]
        public void Correlation_CalculatesCorrelationCorrectly()
        {
            var x = new[] { 1.0, 2.0, 3.0, 4.0, 5.0 };
            var y = new[] { 2.0, 4.0, 6.0, 8.0, 10.0 };
            var correlation = Statistics.Correlation(x, y);
            Assert.Equal(1.0, correlation, 10);
        }
    }
}
