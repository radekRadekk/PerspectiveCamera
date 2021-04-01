using System;
using System.Collections.Generic;
using System.Linq;

namespace PerspectiveCamera.ViewApp.Elements
{
    public class Connection : IElement
    {
        public int Point1Id { get; }
        public int Point2Id { get; }

        public Connection(int point1Id, int point2Id)
        {
            Point1Id = point1Id;
            Point2Id = point2Id;
        }

        public double GetDistanceFromCoordinateSystemOrigin(List<Point> points)
        {
            double sumX = 0;
            double sumY = 0;
            double sumZ = 0;

            sumX += points.First(p => p.Id == Point1Id).X;
            sumX += points.First(p => p.Id == Point2Id).X;

            sumY += points.First(p => p.Id == Point1Id).Y;
            sumY += points.First(p => p.Id == Point2Id).Y;

            sumZ += points.First(p => p.Id == Point1Id).Z;
            sumZ += points.First(p => p.Id == Point2Id).Z;

            var x = sumX / 2;
            var y = sumY / 2;
            var z = sumZ / 2;

            return Math.Pow(x * x + y * y + z * z, 1.0 / 3);
        }
    }
}