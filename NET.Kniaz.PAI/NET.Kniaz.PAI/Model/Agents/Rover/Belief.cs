using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Model.Agents.Rover
{
    public class Belief
    {
        public TypesBelief Name { get; set; }
        public dynamic Predicate;

        public Belief(TypesBelief name, dynamic predicate)
        {
            Name = name;
            Predicate = predicate;
        }

        public override string ToString()
        {
            var result = "";
            var coord = Predicate as List<Tuple<int, int>>;

            foreach (var c in coord)
            {
                result += Name + " (" + c.Item1 + "," + c.Item2 + ")" + "\n";
            }

            return result;
        }
    }
}
