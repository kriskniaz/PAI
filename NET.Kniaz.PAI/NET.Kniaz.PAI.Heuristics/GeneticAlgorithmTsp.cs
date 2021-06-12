using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Heuristics
{
    public class GeneticAlgorithmTsp
    {
        public int Iterations { get; set; }
        public Tsp Tsp { get; set; }
        public List<Solution> Population { get; set; }
        public int Size;
        private static readonly Random Random = new Random();

        public GeneticAlgorithmTsp(int iterations, Tsp tsp, int size)
        {
            Iterations = iterations;
            Tsp = tsp;
            Population = new List<Solution>();
            Size = size;
        }

        public Solution Execute()
        {
            InitialPopulation();
            var i = 0;

            while (i < Iterations)
            {
                var selected = Selection();
                var offSprings = OffSprings(selected as List<Solution>);

                NewPopulation(offSprings);
                i++;
            }

            return Population.First();
        }

        private void NewPopulation(IEnumerable<Solution> offSprings)
        {
            Population.AddRange(offSprings);
            Population.Sort((solutionA, solutionB) => solutionA.Fitness >= solutionB.Fitness ? 1 : -1);
            Population = Population.GetRange(0, Size);
        }

        private IEnumerable<Solution> OffSprings(List<Solution> selected)
        {
            var result = new List<Solution>();

            for (var i = 0; i < selected.Count - 1; i++)
            {
                result.Add(Random.NextDouble() <= 0.4
                               ? selected[i].Mutate(Random)
                               : selected[i].CrossOver(Random, selected[Random.Next(0, selected.Count)]));
            }

            return result;
        }

        private IEnumerable<Solution> Selection()
        {
            Population.Sort((solutionA, solutionB) => solutionA.Fitness >= solutionB.Fitness ? 1 : -1);
            return Population.GetRange(0, Size / 2);
        }

        private void InitialPopulation()
        {
            var i = 0;

            while (i < Size)
            {
                Population.Add(RandomSolution(Tsp.Map.GetLength(0)));
                i++;
            }
        }

        private Solution RandomSolution(int n)
        {
            var result = new List<int>();
            var range = Enumerable.Range(0, n).ToList();

            while (range.Count > 0)
            {
                var index = Random.Next(0, range.Count);
                result.Add(range[index]);
                range.RemoveAt(index);
            }

            return new Solution(result);
        }
    }
}
