using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Net.Kniaz.PAI.MarsRoverGui;
using NET.Kniaz.PAI.Model.Agents.Rover;

namespace Net.Kniaz.PAI.MarsRoverGui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var water = new List<Tuple<int, int>>
            {
                new Tuple<int, int> (1, 2),
                new Tuple<int, int> (3, 5),
            };

            var obstacles = new List<Tuple<int, int>>
            {
                new Tuple<int, int> (2, 2),
                new Tuple<int, int> (4, 5),
            };

            var beliefs = new List<Belief> {
                new Belief(TypesBelief.PotentialWaterSpots, water),
                new Belief(TypesBelief.ObstaclesOnTerrain, obstacles),
            };

            var marsTerrain = new[,]
                              {
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0.8, -1, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0.8, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0.8, 0, 0, 0, 0},
                                  {0, -1, 0, 0, 0, 0, 0, 0, 0, 0}
            };


            var marsUnderneathTerrain = new[,]
                              {
                                  {false, false, false, false, false, false, false, false, false, false},
                                  {false, false, false, false, false, false, false, false, false, false},
                                  {false, false, false, false, false, false, false, false, false, false},
                                  {false, false, false, true, false, false, false, false, false, false},
                                  {false, false, false, false, false, false, false, false, false, false},
                                  {false, false, false, false, false, false, false, false, false, false},
                                  {false, false, false, false, false, false, false, false, false, false},
                                  {false, false, false, false, false, false, false, false, false, false},
                                  {false, false, false, false, false, false, false, false, false, false},
                                  {false, false, false, false, false, false, false, false, false, false},
            };

            var marsRocksCompound = new[,]
                              {
                                  {"", "", "", "", "", "", "", "", "", ""},
                                  {"", "", "", "", "", "", "", "", "", ""},
                                  {"", "", "", "", "", "", "", "", "", ""},
                                  {"", "", "", "", "", "", "", "", "", ""},
                                  {"AXY", "", "", "", "", "", "", "", "", ""},
                                  {"", "", "", "", "", "", "", "", "", ""},
                                  {"AXY", "", "", "", "", "", "", "", "", ""},
                                  {"", "", "", "", "", "", "", "", "", ""},
                                  {"", "", "", "", "", "", "", "", "", ""},
                                  {"AXY", "", "", "", "", "", "", "", "", ""}
            };

            var roverTerrain = new[,]
                              {
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0.8, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0.8, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0.8, 0, 0, 0, 0},
                                  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            var mars = new Mars(marsTerrain);
            var rover = new MarsRover(mars, roverTerrain, 7, 8, beliefs, 0.75, 2);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new MarsWorld(rover, mars, 10, 10));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MarsWorld(rover, mars, 10, 10));
        }
    }
}
