using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;
using Accord.Math.Optimization;
using NET.Kniaz.PAI.SupervisedLearning.Extensors;

namespace NET.Kniaz.PAI.SupervisedLearning.SVM
{
    public class TrainingSample
    {
        public int Classification { get; set; }
        public List<double> Classifications { get; set; }
        public double[] Features { get; set; }

        public TrainingSample(double[] features, int classification, double[] clasifications = null)
        {
            Features = new double[features.Length];
            Array.Copy(features, Features, features.Length);
            Classification = classification;
            if (clasifications != null)
                Classifications = new List<double>(clasifications);
        }
    }
}
