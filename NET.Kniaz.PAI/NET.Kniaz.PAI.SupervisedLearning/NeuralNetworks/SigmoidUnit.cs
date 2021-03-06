using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.Kniaz.PAI.SupervisedLearning.SVM;

namespace NET.Kniaz.PAI.SupervisedLearning.NeuralNetworks
{
    public class SigmoidUnit : SingleNeuralNetwork
    {
        public double ActivationValue { get; set; }
        public double ErrorTerm { get; set; }

        public SigmoidUnit(IEnumerable<TrainingSample> trainingSamples, int inputs, double learningRate)
            : base(trainingSamples, inputs, learningRate)
        { }

        public override double Predict(double[] features)
        {
            var result = 0.0;

            for (var i = 0; i < features.Length; i++)
                result += features[i] * Weights[i];

            ActivationValue = (1 / (1 + Math.Exp(-result)));

            return ActivationValue;
        }
    }
}
