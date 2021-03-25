namespace PerspectiveCamera.ViewApp
{
    public class PerspectiveCameraProperties
    {
        public double Near { get; init; }
        public double Far { get; init; }
        public double Fov { get; set; }
        public double CanvasWidth { get; init; }
        public double CanvasHeight { get; init; }
    }
}