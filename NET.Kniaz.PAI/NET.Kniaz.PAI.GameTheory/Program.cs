using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET.Kniaz.PAI.GameTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Game Theory
            
            var board = new OthelloBoard(8, 8);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OthelloGui(board));

            #endregion

        }
    }
}
