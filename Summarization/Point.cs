namespace MLAlgorithms.Summarization
{
    public class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; }

        public double Y { get; }

        public string Id => $"{X}|{Y}";
    }

    public class PointEqualityComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point p1, Point p2)
        {
            if (p1 == null || p2 == null)
                return false;

            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public int GetHashCode(Point p)
        {
            return HashCode.Combine(p.X, p.Y);
        }
    }
}
