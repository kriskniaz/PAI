using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Model.PropositionalLogic
{
    public class Heuristics
    {
        public static Formula ChooseLiteral(Cnf cnf)
        {
            return cnf.Clauses.First().Literals.First();
        }
    }
}
