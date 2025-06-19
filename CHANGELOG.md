# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2025-06-19

### Added
- Initial release of MathLib
- Basic mathematical operations (BasicMath class)
  - Absolute value, min/max, rounding, ceiling, floor
  - Clamping, sign detection, truncation
- Advanced mathematical functions (AdvancedMath class)
  - Power functions (power, square root, cube root, nth root)
  - Exponential and logarithmic functions
  - Factorial and gamma functions
  - GCD and LCM calculations
- Trigonometric functions (Trigonometry class)
  - Standard trigonometric functions and their inverses
  - Hyperbolic functions and their inverses
  - Secant, cosecant, cotangent functions
  - Degree/radian conversion utilities
- Statistical functions (Statistics class)
  - Descriptive statistics (mean, median, mode, range)
  - Variance and standard deviation calculations
  - Percentiles, quartiles, and IQR
  - Correlation and covariance analysis
- Linear algebra support
  - Vector2 and Vector3 classes with full vector operations
  - Matrix2x2 and Matrix3x3 classes with matrix operations
  - Dot product, cross product, magnitude calculations
  - Matrix determinant, transpose, and inverse
- Numerical methods (NumericalMethods class)
  - Root finding (Newton-Raphson, Bisection)
  - Numerical integration (Trapezoidal, Simpson's rule)
  - Numerical differentiation (Forward, backward, central difference)
  - Linear system solver (Gaussian elimination)
- Comprehensive unit test suite
- Example project demonstrating all features
- Complete XML documentation
- NuGet package configuration

### Technical Details
- Built for .NET 8.0
- Uses double precision for all calculations
- Includes proper error handling and validation
- Follows C# coding conventions and best practices
- Comprehensive test coverage with xUnit
