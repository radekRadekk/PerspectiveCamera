using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace PerspectiveCamera.ViewApp.Helpers
{
    public static class Matrices
    {
        public static Matrix<double> GetAxRotationMatrix(double fi)
        {
            var fiRad = DegreesToRadians(fi);

            return DenseMatrix.OfArray(new[,]
            {
                {1, 0, 0, 0},
                {0, Math.Cos(fiRad), -Math.Sin(fiRad), 0},
                {0, Math.Sin(fiRad), Math.Cos(fiRad), 0},
                {0, 0, 0, 1}
            });
        }

        public static Matrix<double> GetAyRotationMatrix(double fi)
        {
            var fiRad = DegreesToRadians(fi);

            return DenseMatrix.OfArray(new[,]
            {
                {Math.Cos(fiRad), 0, Math.Sin(fiRad), 0},
                {0, 1, 0, 0},
                {-Math.Sin(fiRad), 0, Math.Cos(fiRad), 0},
                {0, 0, 0, 1}
            });
        }

        public static Matrix<double> GetAzRotationMatrix(double fi)
        {
            var fiRad = DegreesToRadians(fi);

            return DenseMatrix.OfArray(new[,]
            {
                {Math.Cos(fiRad), -Math.Sin(fiRad), 0, 0},
                {Math.Sin(fiRad), Math.Cos(fiRad), 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            });
        }

        public static Matrix<double> GetPresentationMatrix(double near, double far, double right, double left,
            double bottom, double top)
        {
            return DenseMatrix.OfArray(new[,]
            {
                {(2 * near) / (right - left), 0, (right + left) / (right - left), 0},
                {0, 2 * near / (top - bottom), 0, 0},
                {0, 0, -((far + near) / (far - near)), -((2 * far * near) / (far - near))},
                {0, 0, -1, 0}
            });
        }

        public static double DegreesToRadians(double degreesValue)
        {
            return (degreesValue / 360) * 2 * Math.PI;
        }
    }
}