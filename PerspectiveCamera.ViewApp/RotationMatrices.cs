using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace PerspectiveCamera.ViewApp
{
    public static class RotationMatrices
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

        private static double DegreesToRadians(double degreesValue)
        {
            return (degreesValue / 360) * 2 * Math.PI;
        }
    }
}