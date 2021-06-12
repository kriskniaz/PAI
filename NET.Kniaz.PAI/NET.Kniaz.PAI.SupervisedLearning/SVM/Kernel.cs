using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.SupervisedLearning.SVM
{
    public class Kernel
    {
        public static double Polynomial(double degree, double[] v1, double[] v2)
        {
            return Math.Pow(InnerProduct(v1, v2) + 1, degree);
        }

        private static double InnerProduct(double[] v1, double[] v2)
        {
            var result = 0.0;

            for (var i = 0; i < v1.Length; i++)
                result += v1[i] * v2[i];

            return result;
        }
    }
}
