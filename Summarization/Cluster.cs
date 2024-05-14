namespace MLAlgorithms.Summarization
{
    public class Cluster
    {
        public Cluster(int id) 
        { 
            this.Id = id;
        }

        public int Id { get; }
      
        public HashSet<Point> Points { get; } = new HashSet<Point>();

        public Point Centroid { get; internal set; }

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
