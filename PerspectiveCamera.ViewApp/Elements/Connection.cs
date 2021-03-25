namespace PerspectiveCamera.ViewApp.Elements
{
    public readonly struct Connection
    {
        public int Point1Id { get; }
        public int Point2Id { get; }

        public Connection(int point1Id, int point2Id)
        {
            Point1Id = point1Id;
            Point2Id = point2Id;
        }
    }
}