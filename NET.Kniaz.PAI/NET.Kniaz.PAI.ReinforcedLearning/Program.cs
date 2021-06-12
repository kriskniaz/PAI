using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NET.Kniaz.PAI.ReinforcedLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Reinforcement Learning

            
            var map = new [,]
                          {
                              {true, false, true, false, true},
                              {true, true, true, false, true},
                              {true, false, true, false, true},
                              {true, false, true, true, true},
                              {true, true, true, false, true}
                          };

            var reward = new [,]
                          {
                              {-0.01, -0.01, -0.01, -0.01, -0.01},
                              {-0.01, -0.01, -0.01, -0.01, -0.01},
                              {-0.01, -0.01, -0.01, -0.01, -0.01},
                              {-0.01, -0.01, -0.01, -0.01, -0.01},
                              {-0.01, -0.01, -0.01, -0.01, 1},

                          };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MazeGui(5, 5, map, reward));
            
            #endregion
        }
    }
}
