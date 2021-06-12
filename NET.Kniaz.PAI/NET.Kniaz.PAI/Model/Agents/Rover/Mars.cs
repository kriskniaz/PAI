using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Model.Agents.Rover
{
    public class Mars
    {
        private readonly double[,] _terrain;

        public Mars(double[,] terrain)
        {
            _terrain = new double[terrain.GetLength(0), terrain.GetLength(1)];
            Array.Copy(terrain, _terrain, terrain.GetLength(0)*terrain.GetLength(1));
        }

        public double TerrainAt(int x, int y)
        {
            return _terrain[x, y];
        }

        public bool WaterAt(int x, int y)
        {
            return _terrain[x, y] < 0;
        }
    }
}
