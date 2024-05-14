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
            var embeddings = new float[][]
            {
                new float[] { -0.0628880858f, -0.0427831635f},
                new float[] { -0.0610538125f, 0.0613973737f},
                new float[] { -0.06559628f, -0.09377544f},
                new float[] { -0.0559743047f, 0.06577249f},
                new float[] { -0.08143592f, 0.000687024556f },
                new float[] { -0.06379545f, -0.0174551066f },
                new float[] { -0.05620724f, -0.012291f },
                new float[] { -0.101768017f, -0.3260213f },
                new float[] { -0.07536936f, 0.154612169f },
                new float[] { -0.0763737f, 0.1386943f },
                new float[] { -0.0613845f, 0.109149076f },
                new float[] { -0.05336821f, 0.07296084f },
                new float[] { -0.0598036051f, 0.0348322764f },
                new float[] { -0.08613151f, -0.153230369f }
            };

            var recommendedClusters = new ClusteringEngine().GetRecommendation(embeddings, numberOfClustersToTest);

            Assert.That(recommendedClusters, Is.EqualTo(2));
        }
    }
}