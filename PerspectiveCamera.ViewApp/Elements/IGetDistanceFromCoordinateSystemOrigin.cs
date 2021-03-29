using System.Collections.Generic;

namespace PerspectiveCamera.ViewApp.Elements
{
    public interface IGetDistanceFromCoordinateSystemOrigin
    {
        public double GetDistanceFromCoordinateSystemOrigin(List<Point> points);
    }
}