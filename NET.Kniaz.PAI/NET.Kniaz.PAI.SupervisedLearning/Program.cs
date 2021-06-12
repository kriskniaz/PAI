using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.Kniaz.PAI.SupervisedLearning.SVM;
using NET.Kniaz.PAI.SupervisedLearning.SVM.GUI;
using NET.Kniaz.PAI.SupervisedLearning.DecisionTrees;
using System.Windows.Forms;
using NET.Kniaz.PAI.SupervisedLearning.NeuralNetworks;
using NET.Kniaz.PAI.SupervisedLearning.NeuralNetworks.HandwrittenDigitRecognition;
using OxyPlot;
using OxyPlot.Series;

namespace NET.Kniaz.PAI.SupervisedLearning
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter 1 for SVM, 2 for Decision Threes, 3 for Simple Neural Networks 4 for MLL / Handwriting");
            string line = Console.ReadLine();
            int decision = int.Parse(line);

            switch(decision)
            {
                case 1:
                   #region SVM
                    //var trainingSamples = RunData.GetTrainingData1();
                    var trainingSamples = RunData.GetTrainingData2();

                    var svmClassifier = new LinearSvmClassifier(trainingSamples);
                    svmClassifier.Training();
                    //svmClassifier.Predict(RunData.GetData1());
                    svmClassifier.Predict(RunData.GetData2());

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new SvmGui(svmClassifier.Weights, svmClassifier.Bias, svmClassifier.ModelToUse, svmClassifier.SetA, svmClassifier.SetB, svmClassifier.Hyperplane));
                    break;
                #endregion

                case 2:
                    #region Decision Trees

                var values = new [,]
                             {
                                 { "sunny", "12", "high", "weak", "no" },
                                 { "sunny", "12", "high", "strong", "no" },
                                 { "cloudy", "14", "high", "weak", "yes" },
                                 { "rainy", "12", "high", "weak", "yes" },
                                 { "rainy", "20", "normal", "weak", "yes" },
                                 { "rainy", "20", "normal", "strong", "no" },
                                 { "cloudy", "20", "normal", "strong", "yes" },
                                 { "sunny", "12", "high", "weak", "no" },
                                 { "sunny", "14", "normal", "weak", "yes" },
                                 { "rainy", "20", "normal", "weak", "yes" },
                                 { "sunny", "14", "normal", "strong", "yes" },
                                 { "cloudy", "20", "high", "strong", "yes" },
                                 { "cloudy", "20", "normal", "weak", "yes" },
                                 { "rainy", "14", "high", "strong", "no" },
                             };

                var attribs = new List<NET.Kniaz.PAI.SupervisedLearning.DecisionTrees.Attribute>
                             {
                                  new NET.Kniaz.PAI.SupervisedLearning.DecisionTrees.Attribute("Outlook", new[] { "sunny", "cloudy", "rainy" }, TypeAttrib.NonGoal, TypeVal.Discrete),
                                  new NET.Kniaz.PAI.SupervisedLearning.DecisionTrees.Attribute("Temperature", new[] { "12", "14", "20" }, TypeAttrib.NonGoal, TypeVal.Continuous),
                                  new NET.Kniaz.PAI.SupervisedLearning.DecisionTrees.Attribute("Humidity", new[] { "high", "normal" }, TypeAttrib.NonGoal, TypeVal.Discrete),
                                  new NET.Kniaz.PAI.SupervisedLearning.DecisionTrees.Attribute("Wind", new[] { "weak", "strong" }, TypeAttrib.NonGoal, TypeVal.Discrete),
                              };

                var goalAttrib = new NET.Kniaz.PAI.SupervisedLearning.DecisionTrees.Attribute("Play Baseball", new[] { "yes", "no" }, TypeAttrib.Goal, TypeVal.Discrete);
                var trainingDataSet = new TrainingDataSet(values, attribs, goalAttrib);
                var dtree = DecisionTree.Learn(trainingDataSet, DtTrainingAlgorithm.Id3);
                    string[] val = { "sunny", "28", "strong" };
                TestTree(dtree, val);
                dtree.Visualize(); 
             break;
                #endregion

                case 3:                   
                    #region Perceptron
                    var trainingSamplesNeural = RunData.GetSingleNeuralNetworksData();
                    var perceptron = new Perceptron(trainingSamplesNeural, 2, 0.01);
                    perceptron.Training();

                    var toPredict = RunData.GetToPredict();

                    var predictions = perceptron.PredictSet(toPredict);
                    Console.WriteLine("---------------Perceptron----------");
                    for (var i = 0; i < predictions.Count; i++)
                        Console.WriteLine("Data: ( {0} , {1} ) Classified as: {2}", toPredict[i][0], toPredict[i][1], predictions[i]);

                    #endregion
                    #region Adaline
                    var trainingSamplesAdaline = RunData.GetSingleNeuralNetworksData();
                    var adaline = new Adaline(trainingSamplesAdaline, 2, 0.01);
                    adaline.Training();
                    var toPredictAdaline = RunData.GetToPredict();
                    var predictionsAdaline = adaline.PredictSet(toPredictAdaline);
                    Console.WriteLine("---------------Adaline----------");
                    for (var i = 0; i < predictionsAdaline.Count; i++)
                        Console.WriteLine("Data: ( {0} , {1} ) Classified as: {2}", toPredictAdaline[i][0], toPredictAdaline[i][1], predictionsAdaline[i]);
                    #endregion                   
                    #region MNN
                    var trainingSamplesXor = RunData.GetXORData();
                    var multilayer = new MultiLayerNetwork(trainingSamplesXor, 2, 3, 1, 0.01);
                    var toPredictMNN = RunData.GetToPredict();
                    var predictionsMNN = multilayer.PredictSet(toPredictMNN);
                    Console.WriteLine("---------------MNN----------");
                    for (var i = 0; i < predictionsMNN.Count; i++)
                        Console.WriteLine("Data: ( {0} , {1} ) Classified as: {2}", toPredictMNN[i][0], toPredictMNN[i][1], predictionsMNN[i]);

                    break;
                    #endregion
                    break;
                case 4:
                    #region Handwritten Digit Recognition

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new HandwrittenRecognitionGui());

                    #endregion
                break;

            }

            int stop = 0;


        }

        //this needs to be changed into unittests
        static bool TestTree(DecisionTree tree, string[] val)
        {
            string weatherOutlook = "Outlook : " + val[0];
            string windOutlook = "Wind : " + val[2];
            string temperature = val[1];
            bool outcome = false;

            foreach(DecisionTree child in tree.Children)
            {
                if (child.Edge == weatherOutlook)
                {
                    foreach(DecisionTree nextChild in child.Children)
                    {
                        foreach(DecisionTree lastChild in nextChild.Children)
                        {
                            if (lastChild.Value == "yes")
                                outcome = true;
                        }
                        if (nextChild.Edge == windOutlook && nextChild.Value == "yes")
                        {
                            outcome = true;
                            break;
                        }
                        if (TestTemperature(nextChild.Edge,temperature))
                        {
                            outcome = true;
                            break;
                        }
                        
                    }

                    if (child.Value == "yes")
                        outcome = true;
                }
            }

            return outcome;
        }

        static bool TestTemperature(string val1, string val2)
        {
            string[] vals = val1.Split(':');
            string[] finalVals = vals[1].Split(' ');
            string opertr = finalVals[1];
            string limitVal = finalVals[2];

            if (opertr == "less")
                return int.Parse(val2) < int.Parse(limitVal);

            if (opertr == "greater")
                return int.Parse(val2) > int.Parse(limitVal);

            return false;
        }

    }


}
