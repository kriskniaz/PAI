using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Kniaz.PAI.UnsupervisedLearning.Clustering
{
    public class Element
    {
        public List<double> Features { get; set; }
        public int Cluster { get; set; }

        public Element(int cluster = -1)
        {
            Features = new List<double>();
            Cluster = cluster;
        }

        public Element(IEnumerable<double> features)
        {
            Features = new List<double>(features);
            Cluster = -1;
        }
    }
}
