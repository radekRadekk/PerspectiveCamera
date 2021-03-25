using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;


namespace PerspectiveCamera.ViewApp
{
    public static class State
    {
        public static double Fov { get; set; }
        public static (double X, double Y, double Z, int Id)[] Points { get; set; }
        private static (int Id1, int Id2)[] Connections { get; set; }

        public static void Init()
        {
            Fov = 60;

            Points = new[]
            {
                (-100.0, -100.0, 800.0, 1),
                (-100, 100, 800, 2),
                (100, 100, 800, 3),
                (100, -100, 800, 4),
                (-100, -100, 1000, 5),
                (-100, 100, 1000, 6),
                (100, 100, 1000, 7),
                (100, -100, 1000, 8),
            };

            Connections = new[]
            {
                (1, 2),
                (2, 3),
                (3, 4),
                (4, 1),
                (5, 6),
                (6, 7),
                (7, 8),
                (8, 5),
                (1, 5),
                (2, 6),
                (3, 7),
                (4, 8)
            };
        }

        public static void Draw(Canvas canvas, double fov)
        {
            canvas.Children.Clear();

            var pointsForDrawing = State.GetPointsForDrawing(100, 20000, fov);

            foreach (var connection in State.Connections)
            {
                var line = new Line();
                line.X1 = pointsForDrawing.First(p => p.id == connection.Id1).U;
                line.Y1 = pointsForDrawing.First(p => p.id == connection.Id1).V;
                line.X2 = pointsForDrawing.First(p => p.id == connection.Id2).U;
                line.Y2 = pointsForDrawing.First(p => p.id == connection.Id2).V;
                line.StrokeThickness = 2;
                line.Stroke = Brushes.Black;

                canvas.Children.Add(line);
            }
        }

        private static List<(double U, double V, int id)> GetPointsForDrawing(double n, double f, double fov)
        {
            var pointsForDrawing = new List<(double U, double V, int id)>();
            foreach (var point in Points)
            {
                var pointForDrawing = GetPointForDrawing(point.X, point.Y, point.Z, n, f, fov);
                pointsForDrawing.Add((pointForDrawing.x, pointForDrawing.y, point.Id));
            }

            return pointsForDrawing;
        }

        private static (double x, double y) GetPointForDrawing(double x, double y, double z, double n, double f,
            double fov)
        {
            var fovRad = (fov / 360) * 2 * Math.PI;
            var top = Math.Tan(fovRad / 2) * n;
            var right = top;
            var left = -top;
            var bottom = -top;

            Matrix<double> transformation = DenseMatrix.OfArray(new[,]
            {
                {(2 * n) / (right - left), 0, (right + left) / (right - left), 0},
                {0, 2 * n / (top - bottom), 0, 0},
                {0, 0, -((f + n) / (f - n)), -((2 * f * n) / (f - n))},
                {0, 0, -1, 0}
            });

            Matrix<double> point = DenseMatrix.OfArray(new[,]
            {
                {x}, {y}, {z}, {1.0}
            });

            var result = transformation * point;

            double resx = result[0, 0] / result[3, 0];

            double resy = result[1, 0] / result[3, 0];

            resx = (resx + 1) * 0.5 * (600 - 1);
            resy = (1 - (1 + resy) * 0.5) * (600 - 1);

            return (resx, resy);
        }

        public static void RotateAx(double fi)
        {
            var rotationMatrix = RotationMatrices.GetAxRotationMatrix(fi);

            Points = Points.Select(p =>
            {
                Matrix<double> pointMatrix = DenseMatrix.OfArray(new[,]
                {
                    {p.X},
                    {p.Y},
                    {p.Z},
                    {1.0}
                });

                var result = rotationMatrix * pointMatrix;
                return (
                    (result[0, 0] / result[3, 0]),
                    (result[1, 0] / result[3, 0]),
                    (result[2, 0] / result[3, 0]),
                    p.Id);
            }).ToArray();
        }

        public static void RotateAy(double fi)
        {
            var rotationMatrix = RotationMatrices.GetAyRotationMatrix(fi);

            Points = Points.Select(p =>
            {
                Matrix<double> pointMatrix = DenseMatrix.OfArray(new[,]
                {
                    {p.X},
                    {p.Y},
                    {p.Z},
                    {1.0}
                });

                var result = rotationMatrix * pointMatrix;
                return (
                    (result[0, 0] / result[3, 0]),
                    (result[1, 0] / result[3, 0]),
                    (result[2, 0] / result[3, 0]),
                    p.Id);
            }).ToArray();
        }

        public static void RotateAz(double fi)
        {
            var rotationMatrix = RotationMatrices.GetAzRotationMatrix(fi);

            Points = Points.Select(p =>
            {
                Matrix<double> pointMatrix = DenseMatrix.OfArray(new[,]
                {
                    {p.X},
                    {p.Y},
                    {p.Z},
                    {1.0}
                });

                var result = rotationMatrix * pointMatrix;
                return (
                    (result[0, 0] / result[3, 0]),
                    (result[1, 0] / result[3, 0]),
                    (result[2, 0] / result[3, 0]),
                    p.Id);
            }).ToArray();
        }
    }
}