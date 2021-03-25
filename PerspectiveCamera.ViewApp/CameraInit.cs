using System.Collections.Generic;
using PerspectiveCamera.ViewApp.Elements;

namespace PerspectiveCamera.ViewApp
{
    public static class CameraInit
    {
        public static CameraState DefaultWithCube()
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
                }
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
                new Connection(4, 8)
            };

            return CameraState.CreateCameraState(
                defaultNear,
                defaultFar,
                defaultFov,
                Constants.CanvasWidth,
                Constants.CanvasHeight,
                points,
                connections);
        }
    }
}