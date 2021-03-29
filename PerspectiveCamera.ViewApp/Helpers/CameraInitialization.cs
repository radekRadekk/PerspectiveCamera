using System.Collections.Generic;
using System.Windows.Media;
using PerspectiveCamera.ViewApp.Elements;

namespace PerspectiveCamera.ViewApp.Helpers
{
    public static class CameraInitialization
    {
        public static CameraState DefaultWithThreeCubes()
        {
            const double defaultNear = 100;
            const double defaultFar = 20000;
            const double defaultFov = 60;

            var points = new List<Point>
            {
                new Point
                {
                    Id = 1, X = -100, Y = -100, Z = 800
                },
                new Point
                {
                    Id = 2, X = -100, Y = 100, Z = 800
                },
                new Point
                {
                    Id = 3, X = 100, Y = 100, Z = 800
                },
                new Point
                {
                    Id = 4, X = 100, Y = -100, Z = 800
                },
                new Point
                {
                    Id = 5, X = -100, Y = -100, Z = 1000
                },
                new Point
                {
                    Id = 6, X = -100, Y = 100, Z = 1000
                },
                new Point
                {
                    Id = 7, X = 100, Y = 100, Z = 1000
                },
                new Point
                {
                    Id = 8, X = 100, Y = -100, Z = 1000
                },
                new Point
                {
                    Id = 9, X = -400, Y = -100, Z = 800
                },
                new Point
                {
                    Id = 10, X = -400, Y = 100, Z = 800
                },
                new Point
                {
                    Id = 11, X = -200, Y = 100, Z = 800
                },
                new Point
                {
                    Id = 12, X = -200, Y = -100, Z = 800
                },
                new Point
                {
                    Id = 13, X = -400, Y = -100, Z = 1000
                },
                new Point
                {
                    Id = 14, X = -400, Y = 100, Z = 1000
                },
                new Point
                {
                    Id = 15, X = -200, Y = 100, Z = 1000
                },
                new Point
                {
                    Id = 16, X = -200, Y = -100, Z = 1000
                },
                new Point
                {
                    Id = 17, X = 200, Y = -100, Z = 800
                },
                new Point
                {
                    Id = 18, X = 200, Y = 100, Z = 800
                },
                new Point
                {
                    Id = 19, X = 400, Y = 100, Z = 800
                },
                new Point
                {
                    Id = 20, X = 400, Y = -100, Z = 800
                },
                new Point
                {
                    Id = 21, X = 200, Y = -100, Z = 1000
                },
                new Point
                {
                    Id = 22, X = 200, Y = 100, Z = 1000
                },
                new Point
                {
                    Id = 23, X = 400, Y = 100, Z = 1000
                },
                new Point
                {
                    Id = 24, X = 400, Y = -100, Z = 1000
                },
            };

            var connections = new List<Connection>
            {
                new Connection(1, 2),
                new Connection(2, 3),
                new Connection(3, 4),
                new Connection(4, 1),
                new Connection(5, 6),
                new Connection(6, 7),
                new Connection(7, 8),
                new Connection(8, 5),
                new Connection(1, 5),
                new Connection(2, 6),
                new Connection(3, 7),
                new Connection(4, 8),
                new Connection(9, 10),
                new Connection(10, 11),
                new Connection(11, 12),
                new Connection(12, 9),
                new Connection(13, 14),
                new Connection(14, 15),
                new Connection(15, 16),
                new Connection(16, 13),
                new Connection(9, 13),
                new Connection(10, 14),
                new Connection(11, 15),
                new Connection(12, 16),
                new Connection(17, 18),
                new Connection(18, 19),
                new Connection(19, 20),
                new Connection(20, 17),
                new Connection(21, 22),
                new Connection(22, 23),
                new Connection(23, 24),
                new Connection(24, 21),
                new Connection(17, 21),
                new Connection(18, 22),
                new Connection(19, 23),
                new Connection(20, 24)
            };

            var planes = new List<Plane>
            {
                new Plane(Brushes.Aqua, 1, 2, 3, 4),
                new Plane(Brushes.Chartreuse, 5, 6, 7, 8),
                new Plane(Brushes.Gold, 1, 2, 6, 5),
                new Plane(Brushes.Fuchsia, 3, 4, 8, 7),
                new Plane(Brushes.BlueViolet, 1, 4, 8, 5),
                new Plane(Brushes.SaddleBrown, 2, 3, 7, 6),

                new Plane(Brushes.Aqua, 9, 10, 11, 12),
                new Plane(Brushes.Chartreuse, 13, 14, 15, 16),
                new Plane(Brushes.Gold, 9, 10, 14, 13),
                new Plane(Brushes.Fuchsia, 11, 12, 16, 15),
                new Plane(Brushes.BlueViolet, 9, 12, 16, 13),
                new Plane(Brushes.SaddleBrown, 10, 11, 15, 14),

                new Plane(Brushes.Aqua, 17, 18, 19, 20),
                new Plane(Brushes.Chartreuse, 21, 22, 23, 24),
                new Plane(Brushes.Gold, 17, 18, 22, 21),
                new Plane(Brushes.Fuchsia, 19, 20, 24, 23),
                new Plane(Brushes.BlueViolet, 17, 20, 24, 21),
                new Plane(Brushes.SaddleBrown, 18, 19, 23, 22),
            };

            return CameraState.CreateCameraState(
                defaultNear,
                defaultFar,
                defaultFov,
                Constants.CanvasWidth,
                Constants.CanvasHeight,
                points,
                connections,
                planes);
        }
    }
}