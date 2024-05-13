namespace MLAlgorithms.Summarization
{
    public class Cluster
    {
        private int centroidIndex = -1;

        public Cluster(int id) 
        { 
            this.Id = id;
        }

        public int Id { get; }
      
        public List<Point> Points { get; set; } = new List<Point>();

        public Point Centroid => centroidIndex == -1 ? new Point(0,0) : Points[centroidIndex]; 

        public void AddCentroid(Point point)
        {
            var index = Points.FindIndex(p => p.Id == point.Id);
            if (index == -1)
            {
                Points.Add(point);
                centroidIndex = Points.Count - 1;
            }
            else
            {
                centroidIndex = index;
            }
        }
    }
}
