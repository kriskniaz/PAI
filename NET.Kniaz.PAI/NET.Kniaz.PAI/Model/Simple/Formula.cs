using System;
using System.Collections;
using System.Collections.Generic;

namespace NET.Kniaz.PAI.Model.Simple
{
    public abstract class Formula
    {
        public abstract bool Evaluate();
        public abstract IEnumerable<Variable> Variables();

    }
}
