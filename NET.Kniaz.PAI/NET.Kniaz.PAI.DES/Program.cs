using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.Kniaz.PAI.DES.Objects;
using NET.Kniaz.PAI.DES;

namespace NET.Kniaz.PAI.DES
{
    class Program
    {
        static void Main(string[] args)
        {
            var airplanes = new List<Airplane>
            {
                new Airplane(100),
                new Airplane(300),
                new Airplane(50),
                new Airplane(250),
                new Airplane(150),
                new Airplane(200),
                new Airplane(120)
            };

            var sim = new Simulation(new TimeSpan(0, 13, 0, 0), new TimeSpan(0, 15, 0, 0), airplanes);
            sim.Execute();
            Console.ReadKey();
        }
    }
}
