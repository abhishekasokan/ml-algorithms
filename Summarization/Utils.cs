namespace MLAlgorithms.Summarization
{
    internal static class Utils
    {
        public static double GetDistance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        public static float GetDistanceAsFloat(Point point1, Point point2)
            => (float)GetDistance(point1, point2);
    }
}
