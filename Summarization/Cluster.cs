namespace MLAlgorithms.Summarization
{
    public class Cluster
    {
        public Cluster(int id) 
        { 
            this.Id = id;
            this.Points = new HashSet<Point>(new PointEqualityComparer());
        }

        public int Id { get; }
      
        public HashSet<Point> Points { get; }

        public Point Centroid { get; private set; }

        public void AddCentroid(Point point)
        {
            Centroid = point;
            Points.Add(point);
        }

        public void AddPoint(Point point)
        {
            Points.Add(point);
        }
    }
}
