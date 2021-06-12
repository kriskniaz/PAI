using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Model.Agents.Rover
{
    public class Intention : Desire
    {
        public static Intention FromDesire(Desire desire)
        {
            var result = new Intention
            {
                Name = desire.Name,
                SubDesires = new List<Desire>(desire.SubDesires),
                Predicate = desire.Predicate
            };

            return result;
        }
    }
}
