﻿using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Model.PropositionalLogic
{
    public class Clause
    {
        public List<Formula> Literals { get; set; }

        public Clause()
        {
            Literals = new List<Formula>();
        }

        public bool Contains(Formula literal)
        {
            if (!IsLiteral(literal))
                throw new ArgumentException("specified formula is not a literal");

            foreach (var formula in Literals)
            {
                if (LiteralEquals(formula,literal))
                    return true;
            }

            return false;
        }
        public bool LiteralEquals(Formula p, Formula q)
        {
            bool result = false;

            if (p is Variable && q is Variable)
                return (p as Variable).Name == (q as Variable).Name;
            if (p is Not && q is Not)
                return LiteralEquals((p as Not).P, (q as Not).P);

            return result;
        }
        public bool IsLiteral(Formula p)
        {
            return p is Variable || (p is Not && (p as Not).P is Variable);
        }

        public Clause RemoveLiteral(Formula literal)
        {
            if (!IsLiteral(literal))
            {
                throw new ArgumentException("Specified formula is not a literal");
            }

            var result = new Clause();
            for (var i = 0; i < Literals.Count; i++)
            {
                if (!LiteralEquals(literal, Literals[i]))
                    result.Literals.Add(Literals[i]);
            }

            return result;
        }


    }
}
