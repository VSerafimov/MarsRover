using System.Linq;
using Core;
using Core.Enums;
using NUnit.Framework;

namespace UnitTestRover
{
    [TestFixture]
    public class GridShould
    {
        private Grid _grid;

        [SetUp]
        public void SetUp()
        {
            _grid = new Grid(100, 100);
        }

        [Test]
        public void AddObstacles()
        {
            var obstacle = new Obstacle(ObstacleType.Solid, 0, 0);
            _grid.AddObstacle(obstacle);
            Assert.That(_grid.Obstacles.Count, Is.EqualTo(1));
            Assert.That(_grid.Obstacles.First(), Is.EqualTo(obstacle));
        }
    }
}
