#region License
/*
MIT License
Copyright Â© 2006 The Mono.xna Team

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Text;
//using System.Drawing;
using System.Globalization;

namespace XnaGeometry
{
    [Serializable]
    public struct Vector2 : IEquatable<Vector2>
    {
        #region Private Fields

        private static Vector2 zeroVector = new Vector2(0f, 0f);
        private static Vector2 unitVector = new Vector2(1f, 1f);
        private static Vector2 unitXVector = new Vector2(1f, 0f);
        private static Vector2 unitYVector = new Vector2(0f, 1f);

        #endregion Private Fields


        #region Public Fields

        public double x;
        public double y;

        #endregion Public Fields


        #region Properties

        public static Vector2 Zero
        {
            get { return zeroVector; }
        }

        public static Vector2 One
        {
            get { return unitVector; }
        }

        public static Vector2 UnitX
        {
            get { return unitXVector; }
        }

        public static Vector2 UnitY
        {
            get { return unitYVector; }
        }

        #endregion Properties


        #region Constructors

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
         
        public Vector2(double value)
        {
            this.x = value;
            this.y = value;
        }

        #endregion Constructors


        #region Public Methods

        public static Vector2 Add(Vector2 value1, Vector2 value2)
        {
            value1.x += value2.x;
            value1.y += value2.y;
            return value1;
        }

        public static void Add(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.x = value1.x + value2.x;
            result.y = value1.y + value2.y;
        }

        public static Vector2 Barycentric(Vector2 value1, Vector2 value2, Vector2 value3, double amount1, double amount2)
        {
            return new Vector2(
                MathHelper.Barycentric(value1.x, value2.x, value3.x, amount1, amount2),
                MathHelper.Barycentric(value1.y, value2.y, value3.y, amount1, amount2));
        }

        public static void Barycentric(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, double amount1, double amount2, out Vector2 result)
        {
            result = new Vector2(
                MathHelper.Barycentric(value1.x, value2.x, value3.x, amount1, amount2),
                MathHelper.Barycentric(value1.y, value2.y, value3.y, amount1, amount2));
        }

        public static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, double amount)
        {
            return new Vector2(
                MathHelper.CatmullRom(value1.x, value2.x, value3.x, value4.x, amount),
                MathHelper.CatmullRom(value1.y, value2.y, value3.y, value4.y, amount));
        }

        public static void CatmullRom(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, ref Vector2 value4, double amount, out Vector2 result)
        {
            result = new Vector2(
                MathHelper.CatmullRom(value1.x, value2.x, value3.x, value4.x, amount),
                MathHelper.CatmullRom(value1.y, value2.y, value3.y, value4.y, amount));
        }

        public static Vector2 Clamp(Vector2 value1, Vector2 min, Vector2 max)
        {
            return new Vector2(
                MathHelper.Clamp(value1.x, min.x, max.x),
                MathHelper.Clamp(value1.y, min.y, max.y));
        }

        public static void Clamp(ref Vector2 value1, ref Vector2 min, ref Vector2 max, out Vector2 result)
        {
            result = new Vector2(
                MathHelper.Clamp(value1.x, min.x, max.x),
                MathHelper.Clamp(value1.y, min.y, max.y));
        }

        public static double Distance(Vector2 value1, Vector2 value2)
        {
            double v1 = value1.x - value2.x, v2 = value1.y - value2.y;
            return (double)Math.Sqrt((v1 * v1) + (v2 * v2));
        }

        public static void Distance(ref Vector2 value1, ref Vector2 value2, out double result)
        {
            double v1 = value1.x - value2.x, v2 = value1.y - value2.y;
            result = (double)Math.Sqrt((v1 * v1) + (v2 * v2));
        }

        public static double DistanceSquared(Vector2 value1, Vector2 value2)
        {
            double v1 = value1.x - value2.x, v2 = value1.y - value2.y;
            return (v1 * v1) + (v2 * v2);
        }

        public static void DistanceSquared(ref Vector2 value1, ref Vector2 value2, out double result)
        {
            double v1 = value1.x - value2.x, v2 = value1.y - value2.y;
            result = (v1 * v1) + (v2 * v2);
        }

        public static Vector2 Divide(Vector2 value1, Vector2 value2)
        {
            value1.x /= value2.x;
            value1.y /= value2.y;
            return value1;
        }

        public static void Divide(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.x = value1.x / value2.x;
            result.y = value1.y / value2.y;
        }

        public static Vector2 Divide(Vector2 value1, double divider)
        {
            double factor = 1 / divider;
            value1.x *= factor;
            value1.y *= factor;
            return value1;
        }

        public static void Divide(ref Vector2 value1, double divider, out Vector2 result)
        {
            double factor = 1 / divider;
            result.x = value1.x * factor;
            result.y = value1.y * factor;
        }

        public static double Dot(Vector2 value1, Vector2 value2)
        {
            return (value1.x * value2.x) + (value1.y * value2.y);
        }

        public static void Dot(ref Vector2 value1, ref Vector2 value2, out double result)
        {
            result = (value1.x * value2.x) + (value1.y * value2.y);
        }

        public override bool Equals(object obj)
        {
            if(obj is Vector2)
            {
                return Equals((Vector2)this);
            }
            
            return false;
        }

        public bool Equals(Vector2 other)
        {
            return (x == other.x) && (y == other.y);
        }
        
        public static Vector2 Reflect(Vector2 vector, Vector2 normal)
        {
            Vector2 result;
            double val = 2.0f * ((vector.x * normal.x) + (vector.y * normal.y));
            result.x = vector.x - (normal.x * val);
            result.y = vector.y - (normal.y * val);
            return result;
        }
        
        public static void Reflect(ref Vector2 vector, ref Vector2 normal, out Vector2 result)
        {
            double val = 2.0f * ((vector.x * normal.x) + (vector.y * normal.y));
            result.x = vector.x - (normal.x * val);
            result.y = vector.y - (normal.y * val);
        }
        
        public override int GetHashCode()
        {
            return x.GetHashCode() + y.GetHashCode();
        }

        public static Vector2 Hermite(Vector2 value1, Vector2 tangent1, Vector2 value2, Vector2 tangent2, double amount)
        {
            Vector2 result = new Vector2();
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
            return result;
        }

        public static void Hermite(ref Vector2 value1, ref Vector2 tangent1, ref Vector2 value2, ref Vector2 tangent2, double amount, out Vector2 result)
        {
            result.x = MathHelper.Hermite(value1.x, tangent1.x, value2.x, tangent2.x, amount);
            result.y = MathHelper.Hermite(value1.y, tangent1.y, value2.y, tangent2.y, amount);
        }

        public double Length()
        {
            return (double)Math.Sqrt((x * x) + (y * y));
        }

        public double LengthSquared()
        {
            return (x * x) + (y * y);
        }

        public static Vector2 Lerp(Vector2 value1, Vector2 value2, double amount)
        {
            return new Vector2(
                MathHelper.Lerp(value1.x, value2.x, amount),
                MathHelper.Lerp(value1.y, value2.y, amount));
        }

        public static void Lerp(ref Vector2 value1, ref Vector2 value2, double amount, out Vector2 result)
        {
            result = new Vector2(
                MathHelper.Lerp(value1.x, value2.x, amount),
                MathHelper.Lerp(value1.y, value2.y, amount));
        }

        public static Vector2 Max(Vector2 value1, Vector2 value2)
        {
            return new Vector2(value1.x > value2.x ? value1.x : value2.x, 
                               value1.y > value2.y ? value1.y : value2.y);
        }

        public static void Max(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.x = value1.x > value2.x ? value1.x : value2.x;
            result.y = value1.y > value2.y ? value1.y : value2.y;
        }

        public static Vector2 Min(Vector2 value1, Vector2 value2)
        {
            return new Vector2(value1.x < value2.x ? value1.x : value2.x, 
                               value1.y < value2.y ? value1.y : value2.y); 
        }

        public static void Min(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.x = value1.x < value2.x ? value1.x : value2.x;
            result.y = value1.y < value2.y ? value1.y : value2.y;
        }

        public static Vector2 Multiply(Vector2 value1, Vector2 value2)
        {
            value1.x *= value2.x;
            value1.y *= value2.y;
            return value1;
        }

        public static Vector2 Multiply(Vector2 value1, double scaleFactor)
        {
            value1.x *= scaleFactor;
            value1.y *= scaleFactor;
            return value1;
        }

        public static void Multiply(ref Vector2 value1, double scaleFactor, out Vector2 result)
        {
            result.x = value1.x * scaleFactor;
            result.y = value1.y * scaleFactor;
        }

        public static void Multiply(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.x = value1.x * value2.x;
            result.y = value1.y * value2.y;
        }

        public static Vector2 Negate(Vector2 value)
        {
            value.x = -value.x;
            value.y = -value.y;
            return value;
        }

        public static void Negate(ref Vector2 value, out Vector2 result)
        {
            result.x = -value.x;
            result.y = -value.y;
        }

        public void Normalize()
        {
            double val = 1.0f / (double)Math.Sqrt((x * x) + (y * y));
            x *= val;
            y *= val;
        }

        public static Vector2 Normalize(Vector2 value)
        {
            double val = 1.0f / (double)Math.Sqrt((value.x * value.x) + (value.y * value.y));
            value.x *= val;
            value.y *= val;
            return value;
        }

        public static void Normalize(ref Vector2 value, out Vector2 result)
        {
            double val = 1.0f / (double)Math.Sqrt((value.x * value.x) + (value.y * value.y));
            result.x = value.x * val;
            result.y = value.y * val;
        }

        public static Vector2 SmoothStep(Vector2 value1, Vector2 value2, double amount)
        {
            return new Vector2(
                MathHelper.SmoothStep(value1.x, value2.x, amount),
                MathHelper.SmoothStep(value1.y, value2.y, amount));
        }

        public static void SmoothStep(ref Vector2 value1, ref Vector2 value2, double amount, out Vector2 result)
        {
            result = new Vector2(
                MathHelper.SmoothStep(value1.x, value2.x, amount),
                MathHelper.SmoothStep(value1.y, value2.y, amount));
        }

        public static Vector2 Subtract(Vector2 value1, Vector2 value2)
        {
            value1.x -= value2.x;
            value1.y -= value2.y;
            return value1;
        }

        public static void Subtract(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.x = value1.x - value2.x;
            result.y = value1.y - value2.y;
        }

        public static Vector2 Transform(Vector2 position, Matrix matrix)
        {
            Transform(ref position, ref matrix, out position);
            return position;
        }

        public static void Transform(ref Vector2 position, ref Matrix matrix, out Vector2 result)
        {
            result = new Vector2((position.x * matrix.M11) + (position.y * matrix.M21) + matrix.M41,
                                 (position.x * matrix.M12) + (position.y * matrix.M22) + matrix.M42);
        }

        public static Vector2 Transform(Vector2 position, Quaternion quat)
        {
            Transform(ref position, ref quat, out position);
            return position;
        }

        public static void Transform(ref Vector2 position, ref Quaternion quat, out Vector2 result)
        {
            Quaternion v = new Quaternion(position.x, position.y, 0, 0), i, t;
            Quaternion.Inverse(ref quat, out i);
            Quaternion.Multiply(ref quat, ref v, out t);
            Quaternion.Multiply(ref t, ref i, out v);

            result = new Vector2(v.x, v.y);
        }
        
        public static void Transform (
            Vector2[] sourceArray,
            ref Matrix matrix,
            Vector2[] destinationArray)
        {
            Transform(sourceArray, 0, ref matrix, destinationArray, 0, sourceArray.Length);
        }

        
        public static void Transform (
            Vector2[] sourceArray,
            int sourceIndex,
            ref Matrix matrix,
            Vector2[] destinationArray,
            int destinationIndex,
            int length)
        {
            for (int x = 0; x < length; x++) {
                var position = sourceArray[sourceIndex + x];
                var destination = destinationArray[destinationIndex + x];
                destination.x = (position.x * matrix.M11) + (position.y * matrix.M21) + matrix.M41;
                destination.y = (position.x * matrix.M12) + (position.y * matrix.M22) + matrix.M42;
                destinationArray[destinationIndex + x] = destination;
            }
        }

        public static Vector2 TransformNormal(Vector2 normal, Matrix matrix)
        {
            Vector2.TransformNormal(ref normal, ref matrix, out normal);
            return normal;
        }

        public static void TransformNormal(ref Vector2 normal, ref Matrix matrix, out Vector2 result)
        {
            result = new Vector2((normal.x * matrix.M11) + (normal.y * matrix.M21),
                                 (normal.x * matrix.M12) + (normal.y * matrix.M22));
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{X:{0} Y:{1}}}", new object[] { 
                this.x.ToString(currentCulture), this.y.ToString(currentCulture) });
        }

        #endregion Public Methods


        #region Operators

        public static Vector2 operator -(Vector2 value)
        {
            value.x = -value.x;
            value.y = -value.y;
            return value;
        }


        public static bool operator ==(Vector2 value1, Vector2 value2)
        {
            return value1.x == value2.x && value1.y == value2.y;
        }


        public static bool operator !=(Vector2 value1, Vector2 value2)
        {
            return value1.x != value2.x || value1.y != value2.y;
        }


        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            value1.x += value2.x;
            value1.y += value2.y;
            return value1;
        }


        public static Vector2 operator -(Vector2 value1, Vector2 value2)
        {
            value1.x -= value2.x;
            value1.y -= value2.y;
            return value1;
        }


        public static Vector2 operator *(Vector2 value1, Vector2 value2)
        {
            value1.x *= value2.x;
            value1.y *= value2.y;
            return value1;
        }


        public static Vector2 operator *(Vector2 value, double scaleFactor)
        {
            value.x *= scaleFactor;
            value.y *= scaleFactor;
            return value;
        }


        public static Vector2 operator *(double scaleFactor, Vector2 value)
        {
            value.x *= scaleFactor;
            value.y *= scaleFactor;
            return value;
        }


        public static Vector2 operator /(Vector2 value1, Vector2 value2)
        {
            value1.x /= value2.x;
            value1.y /= value2.y;
            return value1;
        }


        public static Vector2 operator /(Vector2 value1, double divider)
        {
            double factor = 1 / divider;
            value1.x *= factor;
            value1.y *= factor;
            return value1;
        }

        #endregion Operators
    }
}