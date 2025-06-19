using System;

namespace MathLib
{
    /// <summary>
    /// Represents a 2x2 matrix
    /// </summary>
    public struct Matrix2x2 : IEquatable<Matrix2x2>
    {
        public double M11 { get; set; }
        public double M12 { get; set; }
        public double M21 { get; set; }
        public double M22 { get; set; }

        public Matrix2x2(double m11, double m12, double m21, double m22)
        {
            M11 = m11; M12 = m12;
            M21 = m21; M22 = m22;
        }

        /// <summary>
        /// Gets the determinant of the matrix
        /// </summary>
        public readonly double Determinant => M11 * M22 - M12 * M21;

        /// <summary>
        /// Gets the transpose of the matrix
        /// </summary>
        public readonly Matrix2x2 Transpose => new(M11, M21, M12, M22);

        /// <summary>
        /// Gets the inverse of the matrix
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when matrix is not invertible</exception>
        public readonly Matrix2x2 Inverse
        {
            get
            {
                double det = Determinant;
                if (Math.Abs(det) < 1e-10)
                    throw new InvalidOperationException("Matrix is not invertible");
                
                return new Matrix2x2(M22, -M12, -M21, M11) / det;
            }
        }

        // Operators
        public static Matrix2x2 operator +(Matrix2x2 a, Matrix2x2 b) => new(
            a.M11 + b.M11, a.M12 + b.M12,
            a.M21 + b.M21, a.M22 + b.M22);

        public static Matrix2x2 operator -(Matrix2x2 a, Matrix2x2 b) => new(
            a.M11 - b.M11, a.M12 - b.M12,
            a.M21 - b.M21, a.M22 - b.M22);

        public static Matrix2x2 operator *(Matrix2x2 a, Matrix2x2 b) => new(
            a.M11 * b.M11 + a.M12 * b.M21, a.M11 * b.M12 + a.M12 * b.M22,
            a.M21 * b.M11 + a.M22 * b.M21, a.M21 * b.M12 + a.M22 * b.M22);

        public static Matrix2x2 operator *(Matrix2x2 matrix, double scalar) => new(
            matrix.M11 * scalar, matrix.M12 * scalar,
            matrix.M21 * scalar, matrix.M22 * scalar);

        public static Matrix2x2 operator /(Matrix2x2 matrix, double scalar) => new(
            matrix.M11 / scalar, matrix.M12 / scalar,
            matrix.M21 / scalar, matrix.M22 / scalar);

        public static Vector2 operator *(Matrix2x2 matrix, Vector2 vector) => new(
            matrix.M11 * vector.X + matrix.M12 * vector.Y,
            matrix.M21 * vector.X + matrix.M22 * vector.Y);

        // Equality
        public readonly bool Equals(Matrix2x2 other) => 
            M11.Equals(other.M11) && M12.Equals(other.M12) &&
            M21.Equals(other.M21) && M22.Equals(other.M22);

        public override readonly bool Equals(object? obj) => obj is Matrix2x2 other && Equals(other);
        public override readonly int GetHashCode() => HashCode.Combine(M11, M12, M21, M22);
        public static bool operator ==(Matrix2x2 left, Matrix2x2 right) => left.Equals(right);
        public static bool operator !=(Matrix2x2 left, Matrix2x2 right) => !left.Equals(right);

        public override readonly string ToString() => $"[{M11}, {M12}]\n[{M21}, {M22}]";

        // Static matrices
        public static Matrix2x2 Identity => new(1, 0, 0, 1);
        public static Matrix2x2 Zero => new(0, 0, 0, 0);
    }

    /// <summary>
    /// Represents a 3x3 matrix
    /// </summary>
    public struct Matrix3x3 : IEquatable<Matrix3x3>
    {
        public double M11 { get; set; } public double M12 { get; set; } public double M13 { get; set; }
        public double M21 { get; set; } public double M22 { get; set; } public double M23 { get; set; }
        public double M31 { get; set; } public double M32 { get; set; } public double M33 { get; set; }

        public Matrix3x3(double m11, double m12, double m13,
                        double m21, double m22, double m23,
                        double m31, double m32, double m33)
        {
            M11 = m11; M12 = m12; M13 = m13;
            M21 = m21; M22 = m22; M23 = m23;
            M31 = m31; M32 = m32; M33 = m33;
        }

        /// <summary>
        /// Gets the determinant of the matrix
        /// </summary>
        public readonly double Determinant => 
            M11 * (M22 * M33 - M23 * M32) -
            M12 * (M21 * M33 - M23 * M31) +
            M13 * (M21 * M32 - M22 * M31);

        /// <summary>
        /// Gets the transpose of the matrix
        /// </summary>
        public readonly Matrix3x3 Transpose => new(
            M11, M21, M31,
            M12, M22, M32,
            M13, M23, M33);

        /// <summary>
        /// Gets the inverse of the matrix
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when matrix is not invertible</exception>
        public readonly Matrix3x3 Inverse
        {
            get
            {
                double det = Determinant;
                if (Math.Abs(det) < 1e-10)
                    throw new InvalidOperationException("Matrix is not invertible");

                return new Matrix3x3(
                    (M22 * M33 - M23 * M32), -(M12 * M33 - M13 * M32), (M12 * M23 - M13 * M22),
                    -(M21 * M33 - M23 * M31), (M11 * M33 - M13 * M31), -(M11 * M23 - M13 * M21),
                    (M21 * M32 - M22 * M31), -(M11 * M32 - M12 * M31), (M11 * M22 - M12 * M21)
                ) / det;
            }
        }

        // Operators
        public static Matrix3x3 operator +(Matrix3x3 a, Matrix3x3 b) => new(
            a.M11 + b.M11, a.M12 + b.M12, a.M13 + b.M13,
            a.M21 + b.M21, a.M22 + b.M22, a.M23 + b.M23,
            a.M31 + b.M31, a.M32 + b.M32, a.M33 + b.M33);

        public static Matrix3x3 operator -(Matrix3x3 a, Matrix3x3 b) => new(
            a.M11 - b.M11, a.M12 - b.M12, a.M13 - b.M13,
            a.M21 - b.M21, a.M22 - b.M22, a.M23 - b.M23,
            a.M31 - b.M31, a.M32 - b.M32, a.M33 - b.M33);

        public static Matrix3x3 operator *(Matrix3x3 a, Matrix3x3 b) => new(
            a.M11 * b.M11 + a.M12 * b.M21 + a.M13 * b.M31,
            a.M11 * b.M12 + a.M12 * b.M22 + a.M13 * b.M32,
            a.M11 * b.M13 + a.M12 * b.M23 + a.M13 * b.M33,
            a.M21 * b.M11 + a.M22 * b.M21 + a.M23 * b.M31,
            a.M21 * b.M12 + a.M22 * b.M22 + a.M23 * b.M32,
            a.M21 * b.M13 + a.M22 * b.M23 + a.M23 * b.M33,
            a.M31 * b.M11 + a.M32 * b.M21 + a.M33 * b.M31,
            a.M31 * b.M12 + a.M32 * b.M22 + a.M33 * b.M32,
            a.M31 * b.M13 + a.M32 * b.M23 + a.M33 * b.M33);

        public static Matrix3x3 operator *(Matrix3x3 matrix, double scalar) => new(
            matrix.M11 * scalar, matrix.M12 * scalar, matrix.M13 * scalar,
            matrix.M21 * scalar, matrix.M22 * scalar, matrix.M23 * scalar,
            matrix.M31 * scalar, matrix.M32 * scalar, matrix.M33 * scalar);

        public static Matrix3x3 operator /(Matrix3x3 matrix, double scalar) => new(
            matrix.M11 / scalar, matrix.M12 / scalar, matrix.M13 / scalar,
            matrix.M21 / scalar, matrix.M22 / scalar, matrix.M23 / scalar,
            matrix.M31 / scalar, matrix.M32 / scalar, matrix.M33 / scalar);

        public static Vector3 operator *(Matrix3x3 matrix, Vector3 vector) => new(
            matrix.M11 * vector.X + matrix.M12 * vector.Y + matrix.M13 * vector.Z,
            matrix.M21 * vector.X + matrix.M22 * vector.Y + matrix.M23 * vector.Z,
            matrix.M31 * vector.X + matrix.M32 * vector.Y + matrix.M33 * vector.Z);

        // Equality
        public readonly bool Equals(Matrix3x3 other) => 
            M11.Equals(other.M11) && M12.Equals(other.M12) && M13.Equals(other.M13) &&
            M21.Equals(other.M21) && M22.Equals(other.M22) && M23.Equals(other.M23) &&
            M31.Equals(other.M31) && M32.Equals(other.M32) && M33.Equals(other.M33);

        public override readonly bool Equals(object? obj) => obj is Matrix3x3 other && Equals(other);
        public override readonly int GetHashCode() => HashCode.Combine(
            HashCode.Combine(M11, M12, M13),
            HashCode.Combine(M21, M22, M23),
            HashCode.Combine(M31, M32, M33));
        public static bool operator ==(Matrix3x3 left, Matrix3x3 right) => left.Equals(right);
        public static bool operator !=(Matrix3x3 left, Matrix3x3 right) => !left.Equals(right);

        public override readonly string ToString() => 
            $"[{M11}, {M12}, {M13}]\n[{M21}, {M22}, {M23}]\n[{M31}, {M32}, {M33}]";

        // Static matrices
        public static Matrix3x3 Identity => new(1, 0, 0, 0, 1, 0, 0, 0, 1);
        public static Matrix3x3 Zero => new(0, 0, 0, 0, 0, 0, 0, 0, 0);
    }
}
