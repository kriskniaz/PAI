using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Heuristics
{
    public class Tsp
    {
        public static double[,] Map { get; set; }

        public Tsp(double[,] map)
        {
            Map = map;
        }

        public static void Evaluate(Solution solution)
        {
            var result = 0.0;

            for (var i = 0; i < solution.Ordering.Count - 1; i++)
                result += Map[solution.Ordering[i], solution.Ordering[i + 1]];

            solution.Fitness = result;
        }
    }
}
