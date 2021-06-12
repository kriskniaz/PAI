using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.Kniaz.PAI.SupervisedLearning.SVM;

namespace NET.Kniaz.PAI.SupervisedLearning.NeuralNetworks.HandwrittenDigitRecognition
{
    public class HandwrittenDigitRecognitionNn : MultiLayerNetwork
    {
        public HandwrittenDigitRecognitionNn(IEnumerable<TrainingSample> trainingDataSet, int inputs, int hiddenUnits, int outputs, double learningRate)
            : base(trainingDataSet, inputs, hiddenUnits, outputs, learningRate)
        {
        }
    }
}
