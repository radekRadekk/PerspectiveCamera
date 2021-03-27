using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using PerspectiveCamera.ViewApp.Helpers;

namespace PerspectiveCamera.ViewApp.Elements
{
    public class Point
    {
        public int Id { get; init; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Matrix<double> ToColumnMatrix()
        {
            return DenseMatrix.OfArray(new[,]
            {
                {X},
                {Y},
                {Z},
                {1.0}
            });
        }

        public (double X, double Y) GetPointForDrawing(double near, double far, double fov)
        {
            var fovRad = Matrices.DegreesToRadians(fov);
            var top = Math.Tan(fovRad / 2) * near;
            var right = top;
            var left = -top;
            var bottom = -top;

            var presentationMatrix = Matrices.GetPresentationMatrix(near, far, right, left, bottom, top);

            var pointMatrix = ToRowMatrix();

            var resultMatrix = presentationMatrix * pointMatrix;

            var resultX = resultMatrix[0, 0] / resultMatrix[3, 0];

            var resultY = resultMatrix[1, 0] / resultMatrix[3, 0];

            resultX = (resultX + 1) * 0.5 * (Constants.CanvasHeight - 1);
            resultY = (1 - (1 + resultY) * 0.5) * (Constants.CanvasWidth - 1);

            return (resultX, resultY);
        }

        private Matrix<double> ToRowMatrix()
        {
            return DenseMatrix.OfArray(new[,]
            {
                {X}, {Y}, {Z}, {1.0}
            });
        }
    }
}