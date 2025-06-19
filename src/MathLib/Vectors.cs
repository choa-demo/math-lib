using System;

namespace MathLib
{
    /// <summary>
    /// Represents a 2D vector with x and y components
    /// </summary>
    public struct Vector2 : IEquatable<Vector2>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets the magnitude (length) of the vector
        /// </summary>
        public readonly double Magnitude => Math.Sqrt(X * X + Y * Y);

        /// <summary>
        /// Gets the squared magnitude of the vector (faster than Magnitude)
        /// </summary>
        public readonly double MagnitudeSquared => X * X + Y * Y;

        /// <summary>
        /// Gets the normalized vector (unit vector)
        /// </summary>
        public readonly Vector2 Normalized
        {
            get
            {
                double mag = Magnitude;
                return mag == 0 ? new Vector2(0, 0) : new Vector2(X / mag, Y / mag);
            }
        }

        /// <summary>
        /// Calculates the dot product with another vector
        /// </summary>
        public readonly double Dot(Vector2 other) => X * other.X + Y * other.Y;

        /// <summary>
        /// Calculates the cross product with another vector (returns scalar for 2D)
        /// </summary>
        public readonly double Cross(Vector2 other) => X * other.Y - Y * other.X;

        /// <summary>
        /// Calculates the distance to another vector
        /// </summary>
        public readonly double DistanceTo(Vector2 other) => (this - other).Magnitude;

        /// <summary>
        /// Calculates the angle between this vector and another vector in radians
        /// </summary>
        public readonly double AngleTo(Vector2 other)
        {
            double dot = Dot(other);
            double magnitudes = Magnitude * other.Magnitude;
            return Math.Acos(dot / magnitudes);
        }

        // Operators
        public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.X - b.X, a.Y - b.Y);
        public static Vector2 operator -(Vector2 a) => new(-a.X, -a.Y);
        public static Vector2 operator *(Vector2 a, double scalar) => new(a.X * scalar, a.Y * scalar);
        public static Vector2 operator *(double scalar, Vector2 a) => new(a.X * scalar, a.Y * scalar);
        public static Vector2 operator /(Vector2 a, double scalar) => new(a.X / scalar, a.Y / scalar);

        // Equality
        public readonly bool Equals(Vector2 other) => X.Equals(other.X) && Y.Equals(other.Y);
        public override readonly bool Equals(object? obj) => obj is Vector2 other && Equals(other);
        public override readonly int GetHashCode() => HashCode.Combine(X, Y);
        public static bool operator ==(Vector2 left, Vector2 right) => left.Equals(right);
        public static bool operator !=(Vector2 left, Vector2 right) => !left.Equals(right);

        public override readonly string ToString() => $"({X}, {Y})";

        // Static properties
        public static Vector2 Zero => new(0, 0);
        public static Vector2 One => new(1, 1);
        public static Vector2 UnitX => new(1, 0);
        public static Vector2 UnitY => new(0, 1);
    }

    /// <summary>
    /// Represents a 3D vector with x, y, and z components
    /// </summary>
    public struct Vector3 : IEquatable<Vector3>
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Gets the magnitude (length) of the vector
        /// </summary>
        public readonly double Magnitude => Math.Sqrt(X * X + Y * Y + Z * Z);

        /// <summary>
        /// Gets the squared magnitude of the vector (faster than Magnitude)
        /// </summary>
        public readonly double MagnitudeSquared => X * X + Y * Y + Z * Z;

        /// <summary>
        /// Gets the normalized vector (unit vector)
        /// </summary>
        public readonly Vector3 Normalized
        {
            get
            {
                double mag = Magnitude;
                return mag == 0 ? new Vector3(0, 0, 0) : new Vector3(X / mag, Y / mag, Z / mag);
            }
        }

        /// <summary>
        /// Calculates the dot product with another vector
        /// </summary>
        public readonly double Dot(Vector3 other) => X * other.X + Y * other.Y + Z * other.Z;

        /// <summary>
        /// Calculates the cross product with another vector
        /// </summary>
        public readonly Vector3 Cross(Vector3 other) => new(
            Y * other.Z - Z * other.Y,
            Z * other.X - X * other.Z,
            X * other.Y - Y * other.X
        );

        /// <summary>
        /// Calculates the distance to another vector
        /// </summary>
        public readonly double DistanceTo(Vector3 other) => (this - other).Magnitude;

        /// <summary>
        /// Calculates the angle between this vector and another vector in radians
        /// </summary>
        public readonly double AngleTo(Vector3 other)
        {
            double dot = Dot(other);
            double magnitudes = Magnitude * other.Magnitude;
            return Math.Acos(dot / magnitudes);
        }

        // Operators
        public static Vector3 operator +(Vector3 a, Vector3 b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector3 operator -(Vector3 a, Vector3 b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector3 operator -(Vector3 a) => new(-a.X, -a.Y, -a.Z);
        public static Vector3 operator *(Vector3 a, double scalar) => new(a.X * scalar, a.Y * scalar, a.Z * scalar);
        public static Vector3 operator *(double scalar, Vector3 a) => new(a.X * scalar, a.Y * scalar, a.Z * scalar);
        public static Vector3 operator /(Vector3 a, double scalar) => new(a.X / scalar, a.Y / scalar, a.Z / scalar);

        // Equality
        public readonly bool Equals(Vector3 other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        public override readonly bool Equals(object? obj) => obj is Vector3 other && Equals(other);
        public override readonly int GetHashCode() => HashCode.Combine(X, Y, Z);
        public static bool operator ==(Vector3 left, Vector3 right) => left.Equals(right);
        public static bool operator !=(Vector3 left, Vector3 right) => !left.Equals(right);

        public override readonly string ToString() => $"({X}, {Y}, {Z})";

        // Static properties
        public static Vector3 Zero => new(0, 0, 0);
        public static Vector3 One => new(1, 1, 1);
        public static Vector3 UnitX => new(1, 0, 0);
        public static Vector3 UnitY => new(0, 1, 0);
        public static Vector3 UnitZ => new(0, 0, 1);
    }
}
