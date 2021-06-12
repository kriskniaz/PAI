using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.Kniaz.PAI.Model.Agents;

namespace NET.Kniaz.PAI
{
    public class RunCleaningAgent
    {
        public static void RunLarge()
        {
            var terrain = new int[10, 1];

            for (int i = 0; i < terrain.GetLength(0); i++)
            {
                for (int j = 0; j < terrain.GetLength(1); j++)
                {
                    if (i == terrain.GetLength(0) - 1)
                        terrain[i, j] = 1;
                }
            }
            Console.WriteLine("Starting cleaning agent");
            var cleaningAgent = new CleaningAgent(terrain, 0, 0);
            cleaningAgent.Print();
            cleaningAgent.Start(20000);
            cleaningAgent.Print();
            Console.WriteLine("Ending cleaning Agent");

        }
    }
}
