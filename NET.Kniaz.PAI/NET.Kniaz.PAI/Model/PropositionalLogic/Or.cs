using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Model.PropositionalLogic
{
    public class Or : BinaryGate
    {
        public Or(Formula p, Formula q) : base(p, q) { }

        public override bool Evaluate()
        {
            return P.Evaluate() || Q.Evaluate();
        }

        public override Formula ToNnf()
        {
            return new Or(P.ToNnf(), Q.ToNnf());
        }

        public override Formula ToCnf()
        {
            return DistributeCnf(P.ToCnf(), Q.ToCnf());
        }

        public override string ToString()
        {
            return "(" + P.ToString() + "|" + Q.ToString() + ")";
        }

    }
}
