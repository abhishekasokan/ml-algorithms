using MLAlgorithms.Summarization;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int numberOfClustersToTest = 5;
            var embeddings = new double[][]
            {
                new double[] { -0.0628880858, -0.0427831635},
                new double[] { -0.0610538125, 0.0613973737},
                new double[] { -0.06559628, -0.09377544},
                new double[] { -0.0559743047, 0.06577249},
                new double[] { -0.08143592, 0.000687024556 },
                new double[] { -0.06379545, -0.0174551066 },
                new double[] { -0.05620724, -0.012291 },
                new double[] { -0.101768017, -0.3260213 },
                new double[] { -0.07536936, 0.154612169 },
                new double[] { -0.0763737, 0.1386943 },
                new double[] { -0.0613845, 0.109149076 },
                new double[] { -0.05336821, 0.07296084 },
                new double[] { -0.0598036051, 0.0348322764 },
                new double[] { -0.08613151, -0.153230369 }
            };

            var recommendedClusters = new ClusteringEngine().GetRecommendation(embeddings, numberOfClustersToTest);

            Assert.That(recommendedClusters, Is.EqualTo(2));
        }
    }
}