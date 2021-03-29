using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace PerspectiveCamera.ViewApp.Elements
{
    public readonly struct Plane : IGetDistanceFromCoordinateSystemOrigin
    {
        public List<int> PointIds { get; }
        public Brush Color { get; }

        public Plane(Brush color, params int[] pointIds)
        {
            if (pointIds.Length != 4)
            {
                throw new ArgumentException("Number of plane's points cannot be different than 4.");
            }

            Color = color;
            PointIds = new List<int>(pointIds);
        }

        public double GetDistanceFromCoordinateSystemOrigin(List<Point> points)
        {
            var (x, y, z) = GetCenterOfMass(points);
            return Math.Pow(x * x + y * y + z * z, 1.0 / 3);
        }

        public (double X, double Y, double Z) GetCenterOfMass(List<Point> points)
        {
            var numberOfPoints = PointIds.Count;

            double sumX = 0;
            double sumY = 0;
            double sumZ = 0;

            foreach (var pointId in PointIds)
            {
                sumX += points.First(p => p.Id == pointId).X;
                sumY += points.First(p => p.Id == pointId).Y;
                sumZ += points.First(p => p.Id == pointId).Z;
            }

            return (sumX / numberOfPoints, sumY / numberOfPoints, sumZ / numberOfPoints);
        }
    }
}