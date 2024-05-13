using Microsoft.ML.Data;

namespace MLAlgorithms.Summarization
{
    public class TrainingData
    {
        [VectorType(2)]
        required public float[] Features { get; set; }
    }
}
