using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.Kniaz.PAI.GameProgramming.UninformedSearch;

namespace NET.Kniaz.PAI.GameProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Game Programming

            var tree = new Tree<string> { State = "A" };
            tree.Children.Add(new Tree<string> { State = "B", 
                Children = new List<Tree<string>>
                               {
                                  new Tree<string>("E")
                               } });
            tree.Children.Add(new Tree<string> { State = "C",  
             Children = new List<Tree<string>>
                               {
                                   new Tree<string>("F")
                               } 
            });
            tree.Children.Add(new Tree<string> { State = "D" });

            var bfs = new Bfs<string>(tree);
            var dfs = new Dfs<string>(tree);
            var dls = new Dls<string>(tree, 21, "E");
            var ids = new Ids<string>(tree, 10, "F");
            var path = bfs.Execute();
            //var path = dfs.Execute();
            //var path = dls.Execute();
            //var path = ids.Execute();

            var state = new[,]
                            {
                                {6, 4, 7},
                                {8, 5, 0},
                                {3, 2, 1}
                            };

            /*var state = new[,]
                            {
                                {1, 0, 2},
                                {4, 5, 3},
                                {7, 8, 6}
                            };
            */
            var goalState = new[,]
                            {
                                {1, 2, 3},
                                {4, 5, 6},
                                {7, 8, 0}
                            };

            var board = new Board<int>(state, 0, new Tuple<int, int>(1, 2), "");
            var goal = new Board<int>(goalState, 0, new Tuple<int, int>(2, 2), "");
            var slidingTilesPuzzle = new SlidingTilesPuzzle<int>(board, goal);
            var bidirectionalSearch = new Bs<int>(slidingTilesPuzzle);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            //var path = bidirectionalSearch.BidirectionalBfs();
            stopWatch.Stop();

            foreach (var e in path)
                Console.Write(e + ", ");
            Console.WriteLine('\n' + "Total steps: " + path.Count);
            Console.WriteLine("Elapsed Time: " + stopWatch.ElapsedMilliseconds / 1000 + " secs");

            board = new Board<int>(state, 0, new Tuple<int, int>(1, 2), "");

            for (var i = 0; i < path.Count; i++)
            {
                if (path[i] == "R")
                    board = board.Move(Move.Right);
                if (path[i] == "D")
                    board = board.Move(Move.Down);
                if (path[i] == "U")
                    board = board.Move(Move.Up);
                if (path[i] == "L")
                    board = board.Move(Move.Left);
            }  

            #endregion
        }
    }
}
