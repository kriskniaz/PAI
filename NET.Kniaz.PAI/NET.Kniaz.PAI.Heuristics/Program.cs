using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;

namespace NET.Kniaz.PAI.Heuristics
{
    class Program
    {
        static void Main(string[] args)
        {
            ///hill climbing
            ///
            Console.WriteLine("Hill Climbing");
            var f = new Function("f", "(x1)^2", "x1");
            var hillClimbing = new HillClimbing(f, 5, 4);
            var result = hillClimbing.Execute();
            Console.WriteLine(result[0]);
            Console.WriteLine("Traveling Salesman");
            ///traveling salesmen problem using genetic algorithms
            var map = new double[,] {
                {1, 2, 3, 1, 5},
                {5, 1, 1, 1, 8},
                {1, 7, 2, 1, 9},
                {1, 1, 6, 1, 8},
                {1, 1, 4, 1, 2},
            };

            var ga = new GeneticAlgorithmTsp(100, new Tsp(map), 100);
            var best = ga.Execute();

            Console.WriteLine("Solution:");
            foreach (var d in best.Ordering)
                Console.Write("{0},", d);
            Console.WriteLine('\n' + "Fitness: {0}", best.Fitness);
            Console.ReadLine();

        }
    }
}
