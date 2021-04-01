using System.Collections.Generic;

namespace PerspectiveCamera.ViewApp.Elements
{
    public interface IElement
    {
        public double GetDistanceFromCoordinateSystemOrigin(List<Point> points);
    }
}