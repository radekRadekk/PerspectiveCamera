using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace PerspectiveCamera.ViewApp.Elements
{
    public class Point
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Matrix<double> ToColumnMatrix()
        {
            return DenseMatrix.OfArray(new[,]
            {
                {X},
                {Y},
                {Z},
                {1.0}
            });
        }
    }
}