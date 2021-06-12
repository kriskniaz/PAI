using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.Kniaz.PAI.SupervisedLearning.SVM;

namespace NET.Kniaz.PAI.SupervisedLearning
{
    class RunData
    {
        public static List<TrainingSample> GetTrainingData1()
            {
            var trainingSamples = new List<TrainingSample>
                                     {
                                          new TrainingSample(new double[] {1, 1}, 1),
                                          new TrainingSample(new double[] {1, 0}, 1),
                                          new TrainingSample(new double[] {2, 2}, -1),
                                          new TrainingSample(new double[] {2, 3}, -1),
                                     };
            return trainingSamples;
        }

        public static List<double[]> GetData1()
        {
            var data = new List<double[]>
                                      {
                                          new double[] {1, 1},
                                          new double[] {1, 0},
                                          new double[] {2, 2},
                                          new double[] {2, 3},
                                          new double[] {2, 0},
                                          new []   {2.5, 1.5},
                                          new []   {0.5, 1.5},
                                      };
            return data;
        }

        public static List<double[]> GetData2()
        {
            var data = new List<double[]>
                                      {
                                          new double[] {0.5,1.5 },
                                          new double[] {1, 3},
                                          new double[] {2, 3},
                                          new double[] {0.75,0.5 },
                                          new double[] {1.5,1 },
                                          new double[] {2,1.25 },
                                          new double[] {0.5, 3},
                                          new double[] {0.75, 3.75},
                                          new double[] {1, 0.6},
                                          new double[] {1.25, 0.8},
                                      };
            return data;
        }

        public static List<TrainingSample> GetTrainingData2()
        {
            var trainingSamples = new List<TrainingSample>
                                     {
                                          new TrainingSample(new double[] {0.5, 1.5}, 1),
                                          new TrainingSample(new double[] {1, 3}, 1),
                                          new TrainingSample(new double[] {2, 3}, 1),
                                          new TrainingSample(new double[] {0.75, 0.5}, -1),
                                          new TrainingSample(new double[] {1.5,1}, -1),
                                          new TrainingSample(new double[] {2,1.25}, -1),
                                     };
            return trainingSamples;
        }

        public static List<TrainingSample> GetSingleNeuralNetworksData()
        {
            var trainingSamples = new List<TrainingSample>
                                     {
                                          new TrainingSample(new double[] {1, 1}, 0, new double[] { 0 } ),
                                          new TrainingSample(new double[] {1, 0}, 0, new double[] { 0 } ),
                                          new TrainingSample(new double[] {0, 1}, 0, new double[] { 0 } ),
                                          new TrainingSample(new double[] {0, 0}, 0, new double[] { 0 } ),
                                          new TrainingSample(new double[] {1, 2}, 1, new double[] { 0 } ),
                                          new TrainingSample(new double[] {2, 2}, 1, new double[] { 1 } ),
                                          new TrainingSample(new double[] {2, 3}, 1, new double[] { 1 } ),
                                          new TrainingSample(new double[] {0, 3}, 1, new double[] { 1 } ),
                                          new TrainingSample(new double[] {0, 2}, 1, new double[] { 1 } ),
                                     };

            return trainingSamples;
        }

        public static List<TrainingSample> GetXORData()
        {
            var trainingSamplesXor = new List<TrainingSample>
                                      {
                                          new TrainingSample(new double[] {0, 0}, -1, new double[] { 0 } ),
                                          new TrainingSample(new double[] {1, 1}, -1, new double[] { 0 } ),
                                          new TrainingSample(new double[] {0, 1}, -1, new double[] { 1 } ),
                                          new TrainingSample(new double[] {1, 0}, -1, new double[] { 1 } ),
                                      };

            return trainingSamplesXor;
        }

        public static List<double[]> GetToPredict()
        {
            var toPredict = new List<double[]>
                                      {
                                          new double[] {1, 1},
                                          new double[] {1, 0},
                                          new double[] {0, 0},
                                          new double[] {0, 1},
                                          new double[] {2, 0},
                                          new[] {2.5, 2},
                                          new[] {0.5, 1.5},
                                     };

            return toPredict;
        }

    }
}
