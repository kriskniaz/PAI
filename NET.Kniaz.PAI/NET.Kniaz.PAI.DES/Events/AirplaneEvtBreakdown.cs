using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace NET.Kniaz.PAI.DES.Events
{
    public class AirplaneEvtBreakdown : AirportEvent<TimeSpan>
    {
        public AirplaneEvtBreakdown(params double[] lambdas)
        {
            Distributions = new List<IDistribution>();
            DistributionValues = new double[lambdas.Length];
            Parameters = lambdas;
        }
    }
}
