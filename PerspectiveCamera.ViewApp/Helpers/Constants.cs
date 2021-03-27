namespace PerspectiveCamera.ViewApp.Helpers
{
    public static class Constants
    {
        public const double CoordinateDelta = 10.0;
        public const double ZoomDelta = 1.0;
        public const double FiDelta = 1.0;

        public const double CanvasWidth = 600;
        public const double CanvasHeight = 600;

        public const string MenuText =
            "W\t- move back \nS\t- move front \nA\t- move left \nD\t- move right \nQ\t- move up\nE\t- move down\n"
            + "R\t- zoom- \nF\t- zoom+\n"
            + "I\\K\t- rotate AX\nJ\\L\t- rotate AY\nU\\O\t- rotate AZ\n";
    }
}