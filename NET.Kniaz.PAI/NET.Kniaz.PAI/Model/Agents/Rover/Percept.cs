using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Model.Agents.Rover
{
    public class Percept
    {
        public TypePercept Type { get; set; }
        public Tuple<int, int> Position { get; set; }

        public Percept(Tuple<int, int> position, TypePercept percept)
        {
            Position = position;
            Type = percept;
        }
    }
}
