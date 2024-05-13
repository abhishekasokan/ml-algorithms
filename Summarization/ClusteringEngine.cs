namespace MLAlgorithms.Summarization
{
    public class ClusteringEngine
    {
        private const int minNumberOfClusters = 2;

        public int GetRecommendation(double[][] embeddings, int numberOfClusters)
        {
            if (embeddings == null || embeddings.Length < minNumberOfClusters)
            {
                throw new ArgumentException($"{nameof(embeddings)} value is invalid");
            } 

            if (numberOfClusters > embeddings.Length)
            {
                throw new ArgumentException($"{nameof(numberOfClusters)} value is invalid");
            }

            var result = new List<double>();

            for (int i = minNumberOfClusters; i <= numberOfClusters; i++)
            {
                var (centroids, clusterIds) = KMeans.GetCentroidsAndClusters(embeddings, i);

                var clusters = new List<Cluster>();
                for (int j = 0; j < centroids.Length; j++)
                {
                    var centroid = centroids[j].DenseValues().ToArray();
                    var cluster = new Cluster(j);
                    cluster.AddCentroid(new Point(centroid[0], centroid[1]));
                    clusters.Add(cluster);
                }

                // Add points to each cluster.
                for (int j = 0; j < clusterIds.Count(); j++)
                {
                    var clusterIdx = clusterIds[j];
                    var currentCluster = clusters[clusterIdx];
                    var pointValue = embeddings[j];
                    currentCluster.Points.Add(new Point(pointValue[0], pointValue[1]));
                }

                var sc = new SilhouetteCoefficient(clusters);
                result.Add(sc.Run());
            }

            return result.IndexOf(result.Max()) + minNumberOfClusters;
        }
    }
}
