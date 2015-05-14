using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Grid
    {
        private int Height { get; set; }
        private int Width { get; set; }
        public int NorthEdge { get; private set; }
        public int SouthEdge { get; private set; }
        public int EastEdge { get; private set; }
        public int WestEdge { get; private set; }
        public List<Obstacle> Obstacles { get; private set; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            NorthEdge = height;
            SouthEdge = height * -1;
            EastEdge = width;
            WestEdge = width * -1;
            Obstacles = new List<Obstacle>();
        }

        public void AddObstacle(Obstacle obstacle)
        {
            Obstacles.Add(obstacle);
        }

        public bool AtNorthEdge(int y)
        {
            return y == NorthEdge;
        }

        public bool AtSouthEdge(int y)
        {
            return y == SouthEdge;
        }

        public bool AtEastEdge(int x)
        {
            return x == EastEdge;
        }

        public bool AtWestEdge(int x)
        {
            return x == WestEdge;
        }

        public bool CanMoveNorth(Position currentPosition)
        {
            if (AtNorthEdge(currentPosition.Y))
            {
                return IsThereAnObstacleHere(currentPosition.X, SouthEdge) == false;
            }
            return IsThereAnObstacleHere(currentPosition.X, currentPosition.Y + 1) == false;
        }

        public bool CanMoveEast(Position currentPosition)
        {
            if (AtEastEdge(currentPosition.X))
            {
                return IsThereAnObstacleHere(WestEdge, currentPosition.Y) == false;
            }
            return IsThereAnObstacleHere(currentPosition.X + 1, currentPosition.Y) == false;
        }

        public bool CanMoveSouth(Position currentPosition)
        {
            if (AtSouthEdge(currentPosition.Y))
            {
                return IsThereAnObstacleHere(currentPosition.X, NorthEdge) == false;
            }
            return IsThereAnObstacleHere(currentPosition.X, currentPosition.Y - 1) == false;
        }

        public bool CanMoveWest(Position currentPosition)
        {
            if (AtWestEdge(currentPosition.X))
            {
                return IsThereAnObstacleHere(EastEdge, currentPosition.Y) == false;
            }
            return IsThereAnObstacleHere(currentPosition.X - 1, currentPosition.Y) == false;
        }

        private bool IsThereAnObstacleHere(int x, int y)
        {
            return Obstacles.Any(obstacle => obstacle.X == x && obstacle.Y == y);
        }
    }
}
