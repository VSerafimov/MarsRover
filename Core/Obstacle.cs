using Core.Enums;

namespace Core
{
    public class Obstacle
    {
        public ObstacleType Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Obstacle(ObstacleType type, int x, int y)
        {
            Type = type;
            X = x;
            Y = y;
        }
    }
}
