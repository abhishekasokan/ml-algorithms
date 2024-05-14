using System.Data;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;

namespace MLAlgorithms.Summarization
{
    internal class KMeans
    {
        private const int SeedValue = 1;

        public static (VBuffer<float>[], List<int>) GetCentroidsAndClusters(float[][] twoDVectors, int numberOfClusters)
        {
            var mlContext = new MLContext(SeedValue);
            var pipeline = mlContext.Clustering.Trainers.KMeans(
                new KMeansTrainer.Options
                {
                    NumberOfClusters = numberOfClusters,
                    OptimizationTolerance = 1E-07f,
                    NumberOfThreads = 1,
                });

            var trainingData = mlContext.Data.LoadFromEnumerable(twoDVectors.Select(values => new TrainingData { Features = values }));
            var model = pipeline.Fit(trainingData);

            // Using training data for test data.
            var predictions = model.Transform(trainingData);

            VBuffer<float>[] centroids = default;
            model.Model.GetClusterCentroids(ref centroids, out var k);

            return (centroids, GetPredictedClusterIds(predictions));
        }

        private static List<int> GetPredictedClusterIds(IDataView predictions)
        {
            var predictedClusters = predictions.GetColumn<uint>("PredictedLabel").ToArray();

            // The predictedClusters have 1 based index. Update to 0 based index.
            var result = new List<int>();
            for (int i = 0; i < predictedClusters.Length; i++)
            {
                result.Add((int)predictedClusters[i] - 1);
            }

            return result.ToList();
        }
    }
}
