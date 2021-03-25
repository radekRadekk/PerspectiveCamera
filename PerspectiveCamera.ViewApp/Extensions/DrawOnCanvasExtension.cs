using System.Windows.Controls;

namespace PerspectiveCamera.ViewApp.Extensions
{
    public static class DrawOnCanvasExtension
    {
        public static void Draw(this Canvas canvas, CameraState cameraState)
        {
            canvas.Children.Clear();
        }
    }
}