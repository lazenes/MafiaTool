using SharpDX;
using System;
using System.Globalization;
using System.IO;
using Utils.Extensions;

namespace Utils.SharpDXExtensions
{
    public static class MatrixExtensions
    {
        public static bool IsNaN(this Matrix matrix)
        {
            return matrix.Column1.IsNaN() || matrix.Column2.IsNaN() || matrix.Column3.IsNaN() || matrix.Column4.IsNaN();
        }

        public static Matrix ReadFromFile(BinaryReader reader)
        {
            Matrix matrix = new Matrix();
            matrix.Column1 = Vector4Extenders.ReadFromFile(reader);
            matrix.Column2 = Vector4Extenders.ReadFromFile(reader);
            matrix.Column3 = Vector4Extenders.ReadFromFile(reader);
            return matrix;
        }

        public static Matrix ReadFromFile(MemoryStream stream, bool isBigEndian)
        {
            Matrix matrix = new Matrix();
            matrix.Column1 = Vector4Extenders.ReadFromFile(stream, isBigEndian);
            matrix.Column2 = Vector4Extenders.ReadFromFile(stream, isBigEndian);
            matrix.Column3 = Vector4Extenders.ReadFromFile(stream, isBigEndian);
            if(matrix.IsNaN())
            {
                System.Diagnostics.Debug.Assert(matrix.IsNaN(), "Matrix.IsNan() during ReadFromFile");
                matrix.Row1 = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
                matrix.Row2 = new Vector4(0.0f, 1.0f, 0.0f, 0.0f);
                matrix.Row3 = new Vector4(0.0f, 0.0f, 1.0f, 0.0f);
            }
            return matrix;
        }

        public static void WriteToFile(this Matrix matrix, BinaryWriter writer)
        {
            Vector4Extenders.WriteToFile(matrix.Column1, writer);
            Vector4Extenders.WriteToFile(matrix.Column2, writer);
            Vector4Extenders.WriteToFile(matrix.Column3, writer);
        }

        public static void WriteToFile(this Matrix matrix, MemoryStream stream, bool isBigEndian)
        {
            Vector4Extenders.WriteToFile(matrix.Column1, stream, isBigEndian);
            Vector4Extenders.WriteToFile(matrix.Column2, stream, isBigEndian);
            Vector4Extenders.WriteToFile(matrix.Column3, stream, isBigEndian);
        }

        public static Matrix SetMatrix(Quaternion rotation, Vector3 scale, Vector3 position)
        {
            //doing the normal T * R * S does not work; I have to manually push in the vector into the final row.
            Matrix r = Matrix.RotationQuaternion(rotation);

            //Matrix fixedRotation = new Matrix();
            //fixedRotation.Column1 = r.Row1;
            //fixedRotation.Column2 = r.Row2;
            //fixedRotation.Column3 = r.Row3;


            Matrix s = Matrix.Scaling(scale);
            Matrix final = r * s;
            final.Row4 = new Vector4(position, 1.0f);
            return final;
        }

        public static Matrix SetTranslationVector(Matrix other, Vector3 position)
        {
            Matrix matrix = other;
            matrix.TranslationVector = position;
            return matrix;
        }

        public static Matrix RowEchelon(Matrix other)
        {
            Matrix matrix = new Matrix();
            matrix.Row1 = other.Column1;
            matrix.Row2 = other.Column2;
            matrix.Row3 = other.Column3;
            matrix.Row4 = other.Row4;
            matrix.Column4 = Vector4.Zero;
            return matrix;
        }

        public static Vector3 RotatePoint(this Matrix matrix, Vector3 position)
        {
            Vector3 vector = new Vector3();
            vector.X = matrix.M11 * position.X + matrix.M12 * position.Y + matrix.M13 * position.Z;
            vector.Y = matrix.M21 * position.X + matrix.M22 * position.Y + matrix.M23 * position.Z;
            vector.Z = matrix.M31 * position.X + matrix.M32 * position.Y + matrix.M33 * position.Z;
            return vector; //Output coords in order (x,y,z)
        }

        public static Matrix SetMatrix(Vector3 rotation, Vector3 scale, Vector3 position)
        {
            float radX, radY, radZ;
            radX = -MathUtil.DegreesToRadians(rotation.X);
            radY = -MathUtil.DegreesToRadians(rotation.Y);
            radZ = -MathUtil.DegreesToRadians(rotation.Z);

            Matrix x = Matrix.RotationX(radX);
            Matrix y = Matrix.RotationY(radY);
            Matrix z = Matrix.RotationZ(radZ);

            Matrix result = x * y * z;

            Matrix fixedRotation = new Matrix();
            fixedRotation.Column1 = result.Row1;
            fixedRotation.Column2 = result.Row2;
            fixedRotation.Column3 = result.Row3;
            Quaternion rotation1 = Quaternion.RotationMatrix(fixedRotation);
            return SetMatrix(rotation1, scale, position);
        }
    }

    public static class QuaternionExtensions
    {
        public static Vector3 ToEuler(this Quaternion quat)
        {
            float X = quat.X;
            float Y = quat.Y;
            float Z = quat.Z;
            float W = quat.W;
            float X2 = X * 2.0f;
            float Y2 = Y * 2.0f;
            float Z2 = Z * 2.0f;
            float XX2 = X * X2;
            float XY2 = X * Y2;
            float XZ2 = X * Z2;
            float YX2 = Y * X2;
            float YY2 = Y * Y2;
            float YZ2 = Y * Z2;
            float ZX2 = Z * X2;
            float ZY2 = Z * Y2;
            float ZZ2 = Z * Z2;
            float WX2 = W * X2;
            float WY2 = W * Y2;
            float WZ2 = W * Z2;

            Vector3 AxisX, AxisY, AxisZ;
            AxisX.X = (1.0f - (YY2 + ZZ2));
            AxisY.X = (XY2 + WZ2);
            AxisZ.X = (XZ2 - WY2);
            AxisX.Y = (XY2 - WZ2);
            AxisY.Y = (1.0f - (XX2 + ZZ2));
            AxisZ.Y = (YZ2 + WX2);
            AxisX.Z = (XZ2 + WY2);
            AxisY.Z = (YZ2 - WX2);
            AxisZ.Z = (1.0f - (XX2 + YY2));

            double SmallNumber = double.Parse("1E-08", NumberStyles.Float);
            Vector3 ResultVector = new Vector3();

            ResultVector.Y = (float)Math.Asin(-MathUtil.Clamp(AxisZ.X, -1.0f, 1.0f));

            if(Math.Abs(AxisZ.X) < 1.0f - SmallNumber)
            {
                ResultVector.X = (float)Math.Atan2(AxisZ.Y, AxisZ.Z);
                ResultVector.Z = (float)Math.Atan2(AxisY.X, AxisX.X);
            }
            else
            {
                ResultVector.X = 0.0f;
                ResultVector.Z = (float)Math.Atan2(-AxisX.Y, AxisY.Y);
            }

            ResultVector.Z = MathUtil.RadiansToDegrees(ResultVector.Z);
            ResultVector.Y = MathUtil.RadiansToDegrees(ResultVector.Y);
            ResultVector.X = MathUtil.RadiansToDegrees(ResultVector.X);
            return ResultVector;
        }

        public static Quaternion ReadFromFile(BinaryReader reader)
        {
            Quaternion quaternion = new Quaternion();
            quaternion.X = reader.ReadSingle();
            quaternion.Y = reader.ReadSingle();
            quaternion.Z = reader.ReadSingle();
            quaternion.W = reader.ReadSingle();
            return quaternion;
        }

        public static Quaternion ReadFromFile(MemoryStream stream, bool isBigEndian)
        {
            Quaternion quaternion = new Quaternion();
            quaternion.X = stream.ReadSingle(isBigEndian);
            quaternion.Y = stream.ReadSingle(isBigEndian);
            quaternion.Z = stream.ReadSingle(isBigEndian);
            quaternion.W = stream.ReadSingle(isBigEndian);
            return quaternion;
        }

        public static void WriteToFile(this Quaternion quaternion, BinaryWriter writer)
        {
            writer.Write(quaternion.X);
            writer.Write(quaternion.Y);
            writer.Write(quaternion.Z);
            writer.Write(quaternion.W);
        }

        public static void WriteToFile(this Quaternion quaternion, MemoryStream stream, bool isBigEndian)
        {
            stream.Write(quaternion.X, isBigEndian);
            stream.Write(quaternion.Y, isBigEndian);
            stream.Write(quaternion.Z, isBigEndian);
            stream.Write(quaternion.W, isBigEndian);
        }
    }
}
