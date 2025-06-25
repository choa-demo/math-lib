# MathLib - Comprehensive .NET Mathematical Library

A comprehensive mathematical library for .NET 8.0 providing standard mathematical functions, statistics, linear algebra, and numerical methods. Small changes

## Features

### 🔢 Basic Math Operations
- Absolute value, min/max, rounding, ceiling, floor
- Clamping, sign detection, truncation
- All standard mathematical operations

### 🚀 Advanced Mathematics  
- Power functions (power, square root, cube root, nth root)
- Exponential and logarithmic functions (exp, log, log10, log2)
- Factorial and gamma functions
- Greatest Common Divisor (GCD) and Least Common Multiple (LCM)

### 📐 Trigonometry
- All standard trigonometric functions (sin, cos, tan, etc.)
- Inverse trigonometric functions (asin, acos, atan, atan2)
- Hyperbolic functions (sinh, cosh, tanh) and their inverses
- Secant, cosecant, cotangent functions
- Degree/radian conversion utilities

### 📊 Statistics
- Descriptive statistics (mean, median, mode, range)
- Variance and standard deviation (population and sample)
- Percentiles and quartiles
- Interquartile range (IQR)
- Correlation and covariance analysis

### 🧮 Linear Algebra
- **Vector2** and **Vector3** classes with full vector operations
  - Magnitude, normalization, dot product, cross product
  - Distance calculations, angle measurements
  - Arithmetic operations (+, -, *, /)
- **Matrix2x2** and **Matrix3x3** classes
  - Matrix arithmetic (addition, subtraction, multiplication)
  - Determinant, transpose, and inverse calculations
  - Matrix-vector multiplication

### 🔬 Numerical Methods
- **Root Finding**: Newton-Raphson method, Bisection method  
- **Numerical Integration**: Trapezoidal rule, Simpson's rule
- **Numerical Differentiation**: Forward, backward, and central difference
- **Linear Systems**: Gaussian elimination solver

## Installation

Add the MathLib project reference to your solution:

```xml
<PackageReference Include="MathLib" Version="1.0.0" />
```

## Quick Start

```csharp
using MathLib;

// Basic math operations
double abs = BasicMath.Abs(-15.5);          // 15.5
double max = BasicMath.Max(10, 25);         // 25
double clamped = BasicMath.Clamp(30, 10, 25); // 25

// Advanced math
double power = AdvancedMath.Power(2, 10);   // 1024
double sqrt = AdvancedMath.Sqrt(144);       // 12
double factorial = AdvancedMath.Factorial(5); // 120

// Trigonometry
double radians = Trigonometry.ToRadians(45); // π/4
double sine = Trigonometry.Sin(radians);     // ≈0.707

// Statistics
var data = new[] { 1.0, 2.0, 3.0, 4.0, 5.0 };
double mean = Statistics.Mean(data);         // 3.0
double stdDev = Statistics.PopulationStandardDeviation(data); // ≈1.58

// Vectors
var v1 = new Vector2(3, 4);
var v2 = new Vector2(1, 2);
double magnitude = v1.Magnitude;            // 5.0
Vector2 sum = v1 + v2;                      // (4, 6)
double dotProduct = v1.Dot(v2);             // 11

// Matrices
var m1 = new Matrix2x2(1, 2, 3, 4);
var m2 = new Matrix2x2(2, 0, 1, 1);
Matrix2x2 product = m1 * m2;
double determinant = m1.Determinant;        // -2

// Numerical methods
Func<double, double> f = x => x * x - 4;
Func<double, double> df = x => 2 * x;
double root = NumericalMethods.NewtonRaphson(f, df, 1.0); // ≈2.0
```

## Documentation

### Basic Math (`BasicMath`)
```csharp
BasicMath.Abs(double value)
BasicMath.Max(double a, double b)
BasicMath.Min(double a, double b)
BasicMath.Clamp(double value, double min, double max)
BasicMath.Round(double value, int digits = 0)
BasicMath.Ceiling(double value)
BasicMath.Floor(double value)
BasicMath.Sign(double value)
BasicMath.Truncate(double value)
```

### Advanced Math (`AdvancedMath`)
```csharp
AdvancedMath.Power(double x, double y)
AdvancedMath.Sqrt(double value)
AdvancedMath.Cbrt(double value)
AdvancedMath.NthRoot(double value, double n)
AdvancedMath.Exp(double x)
AdvancedMath.Log(double value, double baseValue = Math.E)
AdvancedMath.Log10(double value)
AdvancedMath.Log2(double value)
AdvancedMath.Factorial(int n)
AdvancedMath.Gamma(double x)
AdvancedMath.Gcd(int a, int b)
AdvancedMath.Lcm(int a, int b)
```

### Trigonometry (`Trigonometry`)
```csharp
// Angle conversion
Trigonometry.ToRadians(double degrees)
Trigonometry.ToDegrees(double radians)

// Basic trigonometric functions
Trigonometry.Sin/Cos/Tan(double angle)
Trigonometry.Asin/Acos/Atan(double value)
Trigonometry.Atan2(double y, double x)

// Hyperbolic functions
Trigonometry.Sinh/Cosh/Tanh(double value)
Trigonometry.Asinh/Acosh/Atanh(double value)

// Additional functions
Trigonometry.Sec/Csc/Cot(double angle)
```

### Statistics (`Statistics`)
```csharp
Statistics.Mean(IEnumerable<double> values)
Statistics.Median(IEnumerable<double> values)
Statistics.Mode(IEnumerable<double> values)
Statistics.Range(IEnumerable<double> values)
Statistics.PopulationVariance(IEnumerable<double> values)
Statistics.SampleVariance(IEnumerable<double> values)
Statistics.PopulationStandardDeviation(IEnumerable<double> values)
Statistics.SampleStandardDeviation(IEnumerable<double> values)
Statistics.Percentile(IEnumerable<double> values, double percentile)
Statistics.Quartiles(IEnumerable<double> values)
Statistics.InterquartileRange(IEnumerable<double> values)
Statistics.Covariance(IEnumerable<double> x, IEnumerable<double> y)
Statistics.Correlation(IEnumerable<double> x, IEnumerable<double> y)
```

## Project Structure

```
MathLib/
├── src/MathLib/                    # Main library
│   ├── BasicMath.cs               # Basic mathematical operations
│   ├── AdvancedMath.cs            # Advanced mathematical functions
│   ├── Trigonometry.cs            # Trigonometric functions
│   ├── Statistics.cs              # Statistical functions
│   ├── Vectors.cs                 # Vector2 and Vector3 classes
│   ├── Matrix.cs                  # Matrix2x2 and Matrix3x3 classes
│   ├── NumericalMethods.cs        # Numerical analysis methods
│   └── MathLib.csproj             # Project file
├── tests/MathLib.Tests/           # Unit tests
├── examples/MathLib.Examples/     # Usage examples
└── MathLib.sln                    # Solution file
```

## Building and Testing

### Build the solution:
```bash
dotnet build
```

### Run tests:
```bash
dotnet test
```

### Run examples:
```bash
dotnet run --project examples/MathLib.Examples
```

### Create NuGet package:
```bash
dotnet pack src/MathLib/MathLib.csproj
```

## Requirements

- .NET 8.0 or later
- System.Numerics.Vectors package (automatically included)

## License

MIT License - see LICENSE file for details.

## Contributing

1. Fork the repository
2. Create a feature branch
3. Add tests for new functionality  
4. Ensure all tests pass
5. Submit a pull request

## Examples

Check out the `examples/MathLib.Examples` project for comprehensive usage examples of all library features.

## Performance Notes

- All calculations use `double` precision for accuracy
- Vector and matrix operations are optimized for performance
- Numerical methods include configurable tolerance and iteration limits
- Statistical functions handle large datasets efficiently

## Future Enhancements

- Complex number support
- Additional matrix operations (eigenvalues, eigenvectors)
- More numerical integration methods
- Optimization algorithms
- Random number generation utilities
