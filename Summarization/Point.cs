namespace MLAlgorithms.Summarization
{
    public class Point
    {
        public Point(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public float X { get; }

        public float Y { get; }

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
