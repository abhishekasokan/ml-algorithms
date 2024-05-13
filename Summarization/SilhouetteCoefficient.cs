namespace MLAlgorithms.Summarization
{
    internal class SilhouetteCoefficient
    {
        private Dictionary<int, Cluster> clustersLookup = new Dictionary<int, Cluster>();
        public SilhouetteCoefficient(IEnumerable<Cluster> clusters) 
        { 
            foreach (var cluster in clusters)
            {
                clustersLookup.Add(cluster.Id, cluster);
            }
        }

        public double Run()
        {
            // We store the silhouette coefficient (SC) for each cluster which is the average of the SC of all the points in the cluster. 
            var clusterCoefficient = new Dictionary<int, double>();

            foreach (var cluster in clustersLookup.Values)
            {
                /*  To calculate the SC for a cluster, for each point in the cluster, calculate
                    1. cohesion  = the average distance of the current point to other points in the cluster
                    2. separation = the min distance of the current point to centroids in other clusters
                    3. coefficient = (separation - cohesion) / max (separation, cohesion)
                */

                var pointCoefficient = new Dictionary<string, double>();
                var otherCentroids = clustersLookup.Values.Where(c => c.Id != cluster.Id).Select(c => c.Centroid);

                var pointCohesion = InitializePointCohesion(cluster);
                for (int i = 0; i < cluster.Points.Count; i++)
                {
                    var currentPoint = cluster.Points[i];
                    double cohesionForCurrentPoint = pointCohesion[i];
                    for (int j = i + 1; j < cluster.Points.Count; j++)
                    {
                        var distance = Utils.GetDistance(currentPoint, cluster.Points[j]);
                        cohesionForCurrentPoint += distance;

                        // Distance from current point to next point is the same as distance from next point to current point.
                        // Store this so we don't have to calculate again.
                        pointCohesion[j] += distance;
                    }
                    cohesionForCurrentPoint = cohesionForCurrentPoint / cluster.Points.Count;

                    var separationForCurrentPoint = double.MaxValue;
                    foreach (var centroid in otherCentroids)
                    {
                        var currentSeparation = Utils.GetDistance(currentPoint, centroid);
                        separationForCurrentPoint = Math.Min(separationForCurrentPoint, currentSeparation);
                    }

                    var coefficient = separationForCurrentPoint - cohesionForCurrentPoint / Math.Max(separationForCurrentPoint, cohesionForCurrentPoint);
                    pointCoefficient.Add(currentPoint.Id, coefficient);
                }

                clusterCoefficient.Add(cluster.Id, pointCoefficient.Values.Sum() / pointCoefficient.Values.Count);
            }

            return clusterCoefficient.Values.Sum() / clusterCoefficient.Values.Count;
        }

        private Dictionary<int, double> InitializePointCohesion(Cluster cluster)
        {
            var cohesionLookup = new Dictionary<int, double>();
            for (int i = 0; i < cluster.Points.Count; i++)
            {
                cohesionLookup.Add(i, 0);
            }

            return cohesionLookup;
        }
    }
}
