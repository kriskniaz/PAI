using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.Kniaz.PAI.Model.FirstOrderLogic;

namespace NET.Kniaz.PAI
{
    public class RunCleaningRobot
    {
        public static void Run()
        {
            var terrain = new[,]
            {
                {0, 0, 0},
                {1, 1, 1},
                {2, 2, 2}
            };
            Console.WriteLine("Starting robot");
            var cleaningRobot = new CleaningRobot(terrain, 0, 0);
            cleaningRobot.Print();
            cleaningRobot.Start(50000);
            cleaningRobot.Print();
            Console.WriteLine("Ending robot");
        }

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
            Console.WriteLine("Starting robot");
            var cleaningRobot = new CleaningRobot(terrain, 0, 0);
            cleaningRobot.Print();
            cleaningRobot.Start(20000);
            cleaningRobot.Print();
            Console.WriteLine("Ending robot");

        }
    }
}
