using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Kniaz.PAI.UnsupervisedLearning.Clustering;
using Net.Kniaz.PAI.UnsupervisedLearning.Clustering.Methods;

namespace Net.Kniaz.PAI.UnsupervisedLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = new List<UnsupervisedLearning.Clustering.Element>
                               {
                                   new UnsupervisedLearning.Clustering.Element(new double[] {1, 2}),
                                   new UnsupervisedLearning.Clustering.Element(new double[] {1, 3}),
                                   new UnsupervisedLearning.Clustering.Element(new double[] {3, 3}),
                                   new UnsupervisedLearning.Clustering.Element(new double[] {3, 4}),
                                   new UnsupervisedLearning.Clustering.Element(new double[] {6, 6}),
                                   new UnsupervisedLearning.Clustering.Element(new double[] {6, 7})
                               };
            var dataSet = new DataSet();
            dataSet.Load(elements);

            var kMeans = new KMeans(3, dataSet);
            kMeans.Start();

            foreach (var cluster in kMeans.Clusters)
            {
                Console.WriteLine("Cluster No {0}", cluster.ClusterNo);
                foreach (var obj in cluster.Objects)
                    Console.WriteLine("({0}, {1}) in {2}", obj.Features[0], obj.Features[1], obj.Cluster);
                
                Console.WriteLine("--------------");
                Console.ReadLine();

            }
        }
    }
}
