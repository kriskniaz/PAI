using System;
using NET.Kniaz.PAI.Model.Simple;

namespace NET.Kniaz.PAI
{
    public class RunSimple
    {
        public static void Run()
        {
            Console.WriteLine("Starting Simple");
            var p = new Variable(false);
            var q = new Variable(false);
            var formula = new Or(new Not(p), q);
            Console.WriteLine(formula.Evaluate());
            Console.WriteLine("Ending Simple");
        }
    }
}
