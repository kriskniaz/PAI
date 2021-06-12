using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Model.Agents
{
    public class CleaningAgent
    {
        private readonly int[,] _terrain;
        private static Stopwatch _stopwatch;
        public int X { get; set; }
        public int Y { get; set; }
        private static Random _random;
        public bool TaskFinished { get; set; }
        private readonly List<Tuple<int, int>> _cellsVisited;

        public CleaningAgent(int[,] terrain, int x, int y)
        {
            X = x;
            Y = y;
            _terrain = new int[terrain.GetLength(0), terrain.GetLength(1)];
            Array.Copy(terrain, _terrain, terrain.GetLength(0) * terrain.GetLength(1));
            _cellsVisited = new List<Tuple<int, int>>();
            _stopwatch = new Stopwatch();
            _random = new Random();
        }

        public void Start(int milliseconds)
        {
            _stopwatch.Start();

            do
            {
                AgentAction(Perceived());

             } while (!TaskFinished && !(_stopwatch.ElapsedMilliseconds > milliseconds));

        }
 
        public enum Percepts
        {
            Dirty, Clean, Finished, MoveUp, MoveDown, MoveLeft, MoveRight
        }

        private List<Percepts> Perceived()
        {
            var result = new List<Percepts>();

            if (IsDirty())
                result.Add(Percepts.Dirty);
            else
            {
                result.Add(Percepts.Clean);
            }
            if (_cellsVisited.Count == _terrain.GetLength(0)* _terrain.GetLength(1))
                result.Add(Percepts.Finished);

            if (MoveAvailable(X-1,Y))
                result.Add(Percepts.MoveUp);

            if (MoveAvailable(X+1,Y))
                result.Add(Percepts.MoveDown);

            if (MoveAvailable(X,Y-1))
                result.Add(Percepts.MoveLeft);

            if (MoveAvailable(X,Y+1))
                result.Add(Percepts.MoveRight);

            return result;
        }

        private void UpdateState()
        {
            if (!_cellsVisited.Contains(new Tuple<int,int>(X,Y)))
                _cellsVisited.Add(new Tuple<int, int>(X,Y));
        }


        public void Clean()
        {
            _terrain[X, Y] -= 1;
        }

        public bool IsDirty()
        {
            return _terrain[X, Y] > 0;
        }

        private void Move(Percepts p)
        {
            switch (p)
            {
                case Percepts.MoveUp:
                    X -= 1;
                    Console.WriteLine("X={0}, Y={1}", X, Y);
                    break;
                case Percepts.MoveDown:
                    X += 1;
                    Console.WriteLine("X={0}, Y={1}", X, Y);
                    break;
                case Percepts.MoveLeft:
                    Y -= 1;
                    Console.WriteLine("X={0}, Y={1}", X, Y);
                    break;
                case Percepts.MoveRight:
                    Y += 1;
                    Console.WriteLine("X={0}, Y={1}", X, Y);
                    break;
            }
        }

        private void RandomAction(List<Percepts> percepts)
        {
            var p = percepts[_random.Next(1, percepts.Count)];
            Move(p);
        }

        public void AgentAction(List<Percepts> percepts)
        {
            if (percepts.Contains(Percepts.Clean))
                UpdateState();
            if (percepts.Contains(Percepts.Dirty))
                Clean();
            else if (percepts.Contains(Percepts.Finished))
                TaskFinished = true;
            else if ( (percepts.Contains(Percepts.MoveUp)) && 
                      (!_cellsVisited.Contains(new Tuple<int,int>(X-1,Y))) )
                Move(Percepts.MoveUp);
            else if ( (percepts.Contains(Percepts.MoveDown)) &&
                     (!_cellsVisited.Contains(new Tuple<int, int>(X + 1, Y))) )
                Move(Percepts.MoveDown);
            else if ((percepts.Contains(Percepts.MoveLeft)) &&
                     (!_cellsVisited.Contains(new Tuple<int, int>(X, Y-1))))
                Move(Percepts.MoveLeft);
            else if ((percepts.Contains(Percepts.MoveRight)) &&
                     (!_cellsVisited.Contains(new Tuple<int, int>(X, Y+1))))
                Move(Percepts.MoveRight);
            else
            {
                RandomAction(percepts);
            }




        }
        public bool MoveAvailable(int x, int y)
        {
            return x >= 0 && y >= 0 && 
                   x < _terrain.GetLength(0) && y < _terrain.GetLength(1);

        }

        public bool IsTerrainClean()
        {
            foreach (var c in _terrain)
                if (c > 0)
                    return false;

            return true;
        }

        public void Print()
        {
            var col = _terrain.GetLength(1);
            var i = 0;
            var line = String.Empty;
            Console.WriteLine("-------------------------------------");
            foreach (var c in _terrain)
            {
                line += string.Format("{0}", c);
                i++;
                if (col == i)
                {
                    Console.WriteLine(line);
                    line = String.Empty;
                    ;
                    i = 0;
                }
            }

        }
    }
}
