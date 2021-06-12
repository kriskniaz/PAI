using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Heuristics
{
    public class Solution
    {
        public List<int> Ordering { get; set; }
        public double Fitness { get; set; }

        public Solution(IEnumerable<int> ordering)
        {
            Ordering = new List<int>(ordering);
            Tsp.Evaluate(this);
        }

        public Solution Mutate(Random random)
        {
            var i = random.Next(0, Ordering.Count);
            var j = random.Next(0, Ordering.Count);

            if (i == j)
                return this;

            var newOrdering = new List<int>(Ordering);
            var temp = newOrdering[i];
            newOrdering[i] = newOrdering[j];
            newOrdering[j] = temp;

            return new Solution(newOrdering);
        }

        public Solution CrossOver(Random random, Solution solution)
        {
            var ordinal = Ordinal();
            var ordinalSol = solution.Ordinal();

            var parentA = new List<int>(ordinal);
            var parentB = new List<int>(ordinalSol);
            var cut = parentA.Count / 2;

            var firstHalf = parentA.GetRange(0, cut);
            var secondHalf = parentB.GetRange(cut, parentB.Count - cut);

            firstHalf.AddRange(secondHalf);
            return DecodeOrdinal(firstHalf);
        }

        public List<int> Ordinal()
        {
            var result = new List<int>();
            var canonic = new List<int>(Canonic);

            foreach (var currentVal in Ordering)
            {
                var indexCanonical = canonic.IndexOf(currentVal);
                result.Add(indexCanonical);
                canonic.RemoveAt(indexCanonical);
            }

            return result;
        }

        public Solution DecodeOrdinal(List<int> ordinal)
        {
            var result = new List<int>();
            var canonic = new List<int>(Canonic);

            for (var i = 0; i < ordinal.Count; i++)
            {
                var indexCanonical = ordinal[i];
                result.Add(canonic[indexCanonical]);
                canonic.RemoveAt(indexCanonical);
            }

            return new Solution(result);
        }

        public List<int> Canonic
        {
            get { return Enumerable.Range(0, Ordering.Count).ToList(); }
        }
    }
}
