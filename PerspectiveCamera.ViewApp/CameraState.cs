using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using PerspectiveCamera.ViewApp.Elements;
using PerspectiveCamera.ViewApp.Helpers;

namespace PerspectiveCamera.ViewApp
{
    public class CameraState
    {
        private PerspectiveCameraProperties Properties { get; init; }
        public List<Point> Points { get; private init; }
        public List<Connection> Connections { get; private init; }

        private CameraState()
        {
        }

        public List<( int Id, double X, double Y)> GetPointsForDrawing()
        {
            var pointsForDrawing = new List<( int Id, double X, double Y)>();

            foreach (var point in Points)
            {
                var pointForDrawing = point.GetPointForDrawing(Properties.Near, Properties.Far, Properties.Fov);
                pointsForDrawing.Add((point.Id, pointForDrawing.X, pointForDrawing.Y));
            }

            return pointsForDrawing;
        }

        public void HandleControl(KeysState keysState)
        {
            if (keysState.W)
            {
                Move(deltaZ: Constants.CoordinateDelta);
            }

            if (keysState.S)
            {
                Move(deltaZ: -Constants.CoordinateDelta);
            }

            if (keysState.A)
            {
                Move(deltaX: Constants.CoordinateDelta);
            }

            if (keysState.D)
            {
                Move(deltaX: -Constants.CoordinateDelta);
            }

            if (keysState.Q)
            {
                Move(deltaY: Constants.CoordinateDelta);
            }

            if (keysState.E)
            {
                Move(deltaY: -Constants.CoordinateDelta);
            }

            if (keysState.R)
            {
                Properties.Fov += Constants.ZoomDelta;
            }

            if (keysState.F)
            {
                Properties.Fov -= Constants.ZoomDelta;
            }

            if (keysState.I)
            {
                RotateAx(Constants.FiDelta);
            }

            if (keysState.K)
            {
                RotateAx(-Constants.FiDelta);
            }

            if (keysState.J)
            {
                RotateAy(Constants.FiDelta);
            }

            if (keysState.L)
            {
                RotateAy(-Constants.FiDelta);
            }

            if (keysState.U)
            {
                RotateAz(Constants.FiDelta);
            }

            if (keysState.O)
            {
                RotateAz(-Constants.FiDelta);
            }
        }

        private void Move(double deltaX = 0, double deltaY = 0, double deltaZ = 0)
        {
            foreach (var point in Points)
            {
                point.X += deltaX;
                point.Y += deltaY;
                point.Z += deltaZ;
            }
        }

        private void RotateAx(double fi)
        {
            Rotate(Matrices.GetAxRotationMatrix(fi));
        }

        private void RotateAy(double fi)
        {
            Rotate(Matrices.GetAyRotationMatrix(fi));
        }

        private void RotateAz(double fi)
        {
            Rotate(Matrices.GetAzRotationMatrix(fi));
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

    public class PerspectiveCameraProperties
    {
        public double Near { get; init; }
        public double Far { get; init; }
        public double Fov { get; set; }
        public double CanvasWidth { get; init; }
        public double CanvasHeight { get; init; }
    }
}