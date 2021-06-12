using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Model.PropositionalLogic
{
    public class Variable : Formula
    {
        public bool Value { get; set; }
        public string Name { get; set; }

        public Variable(bool value)
        {
            Value = value;
        }

        public Variable(bool value, string name)
        {
            Value = value;
            Name = name;
        }

        public override bool Evaluate()
        {
            return Value;
        }

        public override IEnumerable<Variable> Variables()
        {
            return new List<Variable>() { this };
        }

        public override Formula ToNnf()
        {
            return this;
        }

        public override Formula ToCnf()
        {
            return this;
        }

        public override IEnumerable<Formula> Literals()
        {
            return new List<Formula>() {this};
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
