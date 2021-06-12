using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Model.Agents.Rover
{
    public class Plan
    {
        public TypesPlan Name { get; set; }
        public List<Tuple<int,int>> Path { get; set; }
        private MarsRover _rover;

        public Plan(TypesPlan name, MarsRover rover)
        {
            Name = name;
            _rover = rover;
            Path = new List<Tuple<int, int>>();
        }

        public TypesAction NextAction()
        {
            if (Path.Count == 0)
                return TypesAction.None;
            var next = Path.First();
            Path.RemoveAt(0);

            if (_rover.X > next.Item1)
                return TypesAction.MoveUp;
            if (_rover.X < next.Item1)
                return TypesAction.MoveDown;
            if (_rover.Y < next.Item2)
                return TypesAction.MoveRight;
            if (_rover.Y > next.Item2)
                return TypesAction.MoveLeft;

            return TypesAction.None;
        }

        public void BuildPlan(Tuple<int,int> source, Tuple<int,int> dest)
        {

            switch (Name)
            {
                case TypesPlan.PathFinding:
                    Path = PathFinding(source.Item1, source.Item2, dest.Item1, dest.Item2).Item2;
                    break;
            }
        }

        private Tuple<Tuple<int, int>, List<Tuple<int, int>>> PathFinding(int x1, int y1, int x2, int y2)
        {
            var queue = new Queue<Tuple<Tuple<int,int>, List<Tuple<int,int>>>>();
            queue.Enqueue(new Tuple< Tuple<int,int>, 
                    List<Tuple<int,int>> > 
                (new Tuple<int,int>(x1,y1), new List<Tuple<int,int>>()));
            var hashSetVisitedCells = new HashSet<Tuple<int, int>>();

            while (queue.Count>0)
            {
                var currentCell = queue.Dequeue();
                var currentPath = currentCell.Item2;
                hashSetVisitedCells.Add(currentCell.Item1);
                var x = currentCell.Item1.Item1;
                var y = currentCell.Item1.Item2;

                if (x == x2 && y == y2)
                    return currentCell;
                
                //up
                if (_rover.MoveAvailable(x - 1, y) &&
                    !hashSetVisitedCells.Contains(new Tuple<int, int>(x - 1, y)))
                {
                    var pathUp = new List<Tuple<int, int>>(currentPath);
                    pathUp.Add(new Tuple<int,int>(x-1,y));
                    queue.Enqueue(new Tuple<Tuple<int, int>,
                        List<Tuple<int, int>>>(new Tuple<int, int>(x - 1, y), pathUp));
                }
                    
                //Down
                if (_rover.MoveAvailable(x + 1, y) &&
                    !hashSetVisitedCells.Contains(new Tuple<int, int>(x + 1, y)))
                {
                    var pathDown = new List<Tuple<int, int>>(currentPath);
                    pathDown.Add(new Tuple<int, int>(x + 1, y));
                    queue.Enqueue(new Tuple<Tuple<int, int>, 
                        List<Tuple<int, int>>>(new Tuple<int, int>(x + 1, y), pathDown));
                 }

                // Left
                if (_rover.MoveAvailable(x, y - 1) &&
                    !hashSetVisitedCells.Contains(new Tuple<int, int>(x, y - 1)))
                {
                    var pathLeft = new List<Tuple<int, int>>(currentPath);
                    pathLeft.Add(new Tuple<int, int>(x, y - 1));
                    queue.Enqueue(new Tuple<Tuple<int, int>, 
                        List<Tuple<int, int>>>(new Tuple<int, int>(x, y - 1), pathLeft));
                }

                // Right
                if (_rover.MoveAvailable(x, y + 1) &&
                    !hashSetVisitedCells.Contains(new Tuple<int, int>(x, y + 1)))
                {
                    var pathRight = new List<Tuple<int, int>>(currentPath);
                    pathRight.Add(new Tuple<int, int>(x, y + 1));
                    queue.Enqueue(new Tuple<Tuple<int, int>, 
                        List<Tuple<int, int>>>(new Tuple<int, int>(x, y + 1), pathRight));
                }

 
            }

            return null;
        }

        public bool FullFill()
        {
            return Path.Count == 0;
        }
    }
}
