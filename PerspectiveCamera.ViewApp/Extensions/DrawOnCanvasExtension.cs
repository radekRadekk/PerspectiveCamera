using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PerspectiveCamera.ViewApp.Extensions
{
    public static class DrawOnCanvasExtension
    {
        public static void Draw(this Canvas canvas, CameraState cameraState)
        {
            canvas.Children.Clear();

            var pointsForDrawing = cameraState.GetPointsForDrawing();

            var orderedConnections = cameraState.Connections
                .OrderBy(p => p.GetDistanceFromCoordinateSystemOrigin(cameraState.Points))
                .Reverse()
                .ToList();
            foreach (var connection in orderedConnections)
            {
                var line = new Line();
                line.X1 = pointsForDrawing.First(p => p.Id == connection.Point1Id).X;
                line.Y1 = pointsForDrawing.First(p => p.Id == connection.Point1Id).Y;
                line.X2 = pointsForDrawing.First(p => p.Id == connection.Point2Id).X;
                line.Y2 = pointsForDrawing.First(p => p.Id == connection.Point2Id).Y;
                line.StrokeThickness = 2;
                line.Stroke = Brushes.Black;

                canvas.Children.Add(line);
            }

            var orderedPlanes = cameraState.Planes
                .OrderBy(p => p.GetDistanceFromCoordinateSystemOrigin(cameraState.Points))
                .Reverse()
                .ToList();
            foreach (var plane in orderedPlanes)
            {
                var polygon = new Polygon();
                foreach (var pointId in plane.PointIds)
                {
                    polygon.Points.Add(
                        new Point(
                            pointsForDrawing.First(p => p.Id == pointId).X,
                            pointsForDrawing.First(p => p.Id == pointId).Y)
                    );
                }

                polygon.Fill = plane.Color;
                canvas.Children.Add(polygon);
            }
        }
    }
}