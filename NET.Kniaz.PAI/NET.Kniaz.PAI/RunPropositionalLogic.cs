using System;
using System.CodeDom;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using NET.Kniaz.PAI.Model.PropositionalLogic;

namespace NET.Kniaz.PAI
{
    public class RunPropositionalLogic
    {
        public static void RunDPLL1()
        {
            Console.WriteLine("Starting DPLL 1");
            var p = new Variable(true) { Name = "p" };
            Console.WriteLine(p);
            var q = new Variable(true) { Name = "q" };
            Console.WriteLine(q);
            var r = new Variable(true) { Name = "r" };
            Console.WriteLine(r);
            var f1 = new And(new Or(p,q),new Or(p, new Not(q)) );
            Console.WriteLine(f1);
            var f2 = new And(new Or(new Not(p),q ), new Or(new Not(p),new Not(r) ));
            Console.WriteLine(f2);
            var formula = new And(f1,f2);
            Console.WriteLine(formula);
            var nnf = formula.ToNnf();
            Console.Write("NNF:");
            Console.WriteLine(nnf);
            nnf = nnf.ToCnf();

            var cnf = new Cnf(nnf as And);
            cnf.SimplifyCnf();
            Console.Write("CNF:");
            Console.WriteLine(cnf);
            Console.Write("SAT:");
            Console.WriteLine(cnf.Dpll());
            
            Console.WriteLine("Ending DPLL1");

        }

        public static void RunDpll2()
        {
            Console.WriteLine("Starting DPLL 2");
            var p = new Variable(true) { Name = "p" };
            Console.WriteLine(p);
            var q = new Variable(true) { Name = "q" };
            Console.WriteLine(q);
            var r = new Variable(true) { Name = "r" };
            Console.WriteLine(r);
            var f1 = new Or(p,new Or(q,new Not(r)));
            Console.WriteLine(f1);
            var f2 = new Or(p, new Or(q, r));
            Console.WriteLine(f2);
            var f3 = new Or(p,new Not(q));
            Console.WriteLine(f3);
            var formula = new And(f1,new And(f2,new And(f3, new Not(p))));
            Console.WriteLine(formula);
            var nnf = formula.ToNnf();
            Console.Write("NNF:");
            Console.WriteLine(nnf);
            nnf = nnf.ToCnf();

            var cnf = new Cnf(nnf as And);
            cnf.SimplifyCnf();
            Console.Write("CNF:");
            Console.WriteLine(cnf);
            Console.Write("SAT:");
            Console.WriteLine(cnf.Dpll());

            Console.WriteLine("Ending DPLL2");


        }

        public static void RunDpll3()
        {
            Console.WriteLine("Starting DPLL 3");
            var p = new Variable(true) { Name = "p" };
            Console.WriteLine(p);
            var q = new Variable(true) { Name = "q" };
            Console.WriteLine(q);
            var r = new Variable(true) { Name = "r" };
            Console.WriteLine(r);
            var f1 = new Or(p,new Or(q,r));
            var f2 = new Or(p, new Or(q, new Not(r)) );
            var f3 = new Or(p,new Or(new Not(q),r ));
            var f4 = new Or(p, new Or(new Not(q), new Not(r)) );
            var f5 = new Or(new Not(p),new Or(q,r) );
            var f6 = new Or(new Not(p),new Or(q, new Not(r)) );
            var f7 = new Or(new Not(p), new Or(new Not(q),r ));
            var formula = new And(f1,new And(f2, new And(f3, new And(f4, new And(f5,new And(f6,f7))))));

            Console.WriteLine(formula);
            var nnf = formula.ToNnf();
            Console.Write("NNF:");
            Console.WriteLine(nnf);
            nnf = nnf.ToCnf();

            var cnf = new Cnf(nnf as And);
            cnf.SimplifyCnf();
            Console.Write("CNF:");
            Console.WriteLine(cnf);
            Console.Write("SAT:");
            Console.WriteLine(cnf.Dpll());

            Console.WriteLine("Ending DPLL3");
        }

        public static void RunPigeonHole()
        {
            Console.WriteLine("Starting Pigeon Hole");
            //if we have 3 pigeons and 2 holes we are proving that we can't occupy 
            //every single hole with 1 pigeon only
            //let pij define a state of pigeon i in the hole j
            var p11 = new Variable(true) { Name = "p11"};
            var p12 = new Variable(true) { Name = "p12" }; ;

            var p21 = new Variable(true) { Name = "p21" }; ;
            var p22 = new Variable(true) { Name = "p22" }; ;

            var p31 = new Variable(true) { Name = "p31" }; ;
            var p32 = new Variable(true) { Name = "p32" }; ;

            //first constraint - each of 2 holes must be occupied by a pigeon
            var f1 = new Or(p11, p12);
            var f2 = new Or(p21, p22);
            var f3 = new Or(p31, p32);

            //second contracts no two pigeons can occupy two holes
            var f4 = new Or(new Not(p11), new Not(p21) );
            var f5 = new Or(new Not(p11), new Not(p31) );
            var f6 = new Or(new Not(p21), new Not(p31) );
            var f7 = new Or(new Not(p12), new Not(p22) );
            var f8 = new Or(new Not(p12), new Not(p32) );
            var f9 = new Or(new Not(p22), new Not(p32) );

            var formula = new And(f1, new And(f2, new And(f3, new And(f4, new And(f5, new And(f6, new And(f7, new And(f8,f9))))))));

            Console.WriteLine(formula);
            var nnf = formula.ToNnf();
            Console.Write("NNF:");
            Console.WriteLine(nnf);
            nnf = nnf.ToCnf();

            var cnf = new Cnf(nnf as And);
            cnf.SimplifyCnf();
            Console.Write("CNF:");
            Console.WriteLine(cnf);
            Console.Write("SAT:");
            Console.WriteLine(cnf.Dpll());

            Console.WriteLine("Ending Pigeon Hole");
        }

        public static void RunDpll4()
        {
            Console.WriteLine("Starting DPLL4");
            var a = new Variable(true) { Name = "a" };
            var b = new Variable(true) { Name = "b" };
            var c = new Variable(true) { Name = "c" };
            var d = new Variable(true) { Name = "d" };
            var f1 = new Or(a, b);
            var f2 = new Or(b, new Or( new Not(c),d ));
            var f3 = new Or(new Not(a), new Not(b));
            var f4 = new Or(new Not(a), new Or(new Not(c), new Not(d)));


            var formula = new And(f1,new And(f2, new And(f3,f4)));

            Console.WriteLine(formula);
            var nnf = formula.ToNnf();
            Console.Write("NNF:");
            Console.WriteLine(nnf);
            nnf = nnf.ToCnf();

            var cnf = new Cnf(nnf as And);
            cnf.SimplifyCnf();
            Console.Write("CNF:");
            Console.WriteLine(cnf);
            Console.Write("SAT:");
            Console.WriteLine(cnf.Dpll());


            Console.WriteLine("ending DPLL4");

        }
    }
}
