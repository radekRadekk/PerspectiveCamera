using System.Linq;
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

            foreach (var connection in cameraState.Connections)
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
        }
    }
}