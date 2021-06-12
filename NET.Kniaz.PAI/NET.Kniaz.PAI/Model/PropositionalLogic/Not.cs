﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Model.PropositionalLogic
{
    public class Not : Formula
    {
        public override Formula ToCnf()
        {
            return this;
        }

        public Formula P { get; set; }

        public Not(Formula p)
        {
            P = p;
        }

        public override bool Evaluate()
        {
            return !P.Evaluate();
        }

        public override IEnumerable<Variable> Variables()
        {
            return new List<Variable>(P.Variables());
        }

        public override Formula ToNnf()
        {
            if (P is And)
                return new Or(new Not((P as And).P), new Not((P as And).Q));
            if (P is Or)
                return new And(new Not((P as Or).P),new Not((P as Or).Q) );
            if (P is Not)
                return new Not((P as Not).P);
            return this;
        }

        public override IEnumerable<Formula> Literals()
        {
            return P is Variable ? new List<Formula>() {this} : P.Literals();
        }

        public override string ToString()
        {
            return "!" + P.ToString();
        }
    }
}

