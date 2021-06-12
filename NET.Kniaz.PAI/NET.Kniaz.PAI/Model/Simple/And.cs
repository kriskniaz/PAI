using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Model.Simple
{
    public class And : BinaryGate
    {
        public And(Formula p, Formula q) :base(p,q)
        {
        }

        public override bool Evaluate()
        {
            return P.Evaluate() && Q.Evaluate();
        }
    }
}
