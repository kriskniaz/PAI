using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.Kniaz.PAI.Model.Agents.Rover
{
    public enum TypePercept
    {
        WaterSpot, Obstacle, MoveUp, MoveDown, MoveLeft, MoveRight
    }

    public enum TypesBelief
    {
        PotentialWaterSpots, ObstaclesOnTerrain
    }

    public enum TypesDesire
    {
        FindWater, GotoLocation, Dig
    }

    public enum TypesPlan
    {
        PathFinding
    }

    public enum TypesAction
    {
        MoveUp, MoveDown, MoveLeft, MoveRight, Dig, None
    }
}
