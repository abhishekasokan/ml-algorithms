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
}
