using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using PerspectiveCamera.ViewApp.Elements;

namespace PerspectiveCamera.ViewApp
{
    public class CameraState
    {
        public PerspectiveCameraProperties Properties { get; private init; }
        public List<Point> Points { get; private init; }
        public List<Connection> Connections { get; private init; }

        private CameraState()
        {
        }

        public void Move(double deltaX = 0, double deltaY = 0, double deltaZ = 0)
        {
            foreach (var point in Points)
            {
                point.X += deltaX;
                point.Y += deltaY;
                point.Z += deltaZ;
            }
        }

        public void RotateAx(double fi)
        {
            Rotate(RotationMatrices.GetAxRotationMatrix(fi));
        }

        public void RotateAy(double fi)
        {
            Rotate(RotationMatrices.GetAyRotationMatrix(fi));
        }

        public void RotateAz(double fi)
        {
            Rotate(RotationMatrices.GetAzRotationMatrix(fi));
        }

        private void Rotate(Matrix<double> rotationMatrix)
        {
            foreach (var point in Points)
            {
                var pointMatrix = point.ToColumnMatrix();
                var result = rotationMatrix * pointMatrix;

                point.X = result[0, 0] / result[3, 0];
                point.Y = result[1, 0] / result[3, 0];
                point.Z = result[2, 0] / result[3, 0];
            }
        }

        public static CameraState CreateCameraState(double near, double far, double fov,
            double canvasWidth, double canvasHeight,
            List<Point> points, List<Connection> connections)
        {
            return new CameraState
            {
                Properties = new PerspectiveCameraProperties
                {
                    Near = near,
                    Far = far,
                    Fov = fov,
                    CanvasWidth = canvasWidth,
                    CanvasHeight = canvasHeight
                },
                Points = points,
                Connections = connections
            };
        }
    }
}