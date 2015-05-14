using Core;
using Core.Enums;
using NUnit.Framework;

namespace UnitTestRover
{
    [TestFixture]
    public class ObstacleShould
    {
        [Test]
        public void BeCreated_AsALiquidObstacle()
        {
            var obstacle = new Obstacle (ObstacleType.Liquid, 0, 0 );
            Assert.That(obstacle, Is.Not.Null);
        }

        [Test]
        public void BeCreated_AsASolidObstacle()
        {
            var obstacle = new Obstacle(ObstacleType.Solid, 0, 0);
            Assert.That(obstacle, Is.Not.Null);
        }
    }
}
