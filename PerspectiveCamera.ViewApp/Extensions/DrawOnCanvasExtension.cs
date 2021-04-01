using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using PerspectiveCamera.ViewApp.Elements;

namespace PerspectiveCamera.ViewApp.Extensions
{
    public static class DrawOnCanvasExtension
    {
        public static void DrawWithPainterAlgorithm(this Canvas canvas, CameraState cameraState)
        {
            canvas.Children.Clear();

            var pointsForDrawing = cameraState.GetPointsForDrawing();

            var elements = new List<IElement>()
                .Concat(cameraState.Connections)
                .Concat(cameraState.Planes)
                .OrderBy(e => e.GetDistanceFromCoordinateSystemOrigin(cameraState.Points))
                .Reverse()
                .ToList();

            foreach (var element in elements)
            {
                switch (element)
                {
                    case Connection connection:
                        var line = CreateLine(connection, pointsForDrawing);
                        canvas.Children.Add(line);
                        break;
                    case Plane plane:
                        var polygon = CreatePolygon(plane, pointsForDrawing);
                        canvas.Children.Add(polygon);
                        break;
                }
            }
        }

        private static Line CreateLine(Connection connection, List<(int Id, double X, double Y)> pointsForDrawing)
        {
            var line = new Line();
            line.X1 = pointsForDrawing.First(p => p.Id == connection.Point1Id).X;
            line.Y1 = pointsForDrawing.First(p => p.Id == connection.Point1Id).Y;
            line.X2 = pointsForDrawing.First(p => p.Id == connection.Point2Id).X;
            line.Y2 = pointsForDrawing.First(p => p.Id == connection.Point2Id).Y;
            line.StrokeThickness = 2;
            line.Stroke = Brushes.Black;

            return line;
        }

        private static Polygon CreatePolygon(Plane plane, List<(int Id, double X, double Y)> pointsForDrawing)
        {
            var polygon = new Polygon();
            foreach (var pointId in plane.PointIds)
            {
                polygon.Points.Add(
                    new System.Windows.Point(
                        pointsForDrawing.First(p => p.Id == pointId).X,
                        pointsForDrawing.First(p => p.Id == pointId).Y)
                );
            }

            polygon.Fill = plane.Color;

            return polygon;
        }
    }
}