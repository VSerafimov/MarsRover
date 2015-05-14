using Core;
using Core.Enums;
using NUnit.Framework;

namespace UnitTestRover
{
    [TestFixture]
    public class RoverShould
    {
        private Grid _grid;
        private Position _position;
        private Rover _rover;

        [SetUp]
        public void SetUp()
        {
            _grid = new Grid(10, 10);
            _position = new Position(0, 0);
            _rover = new Rover(_position, Direction.North, _grid);
        }

        [Test]
        public void BeCreated()
        {
            Assert.That(_rover, Is.Not.Null);
        }

        [Test]
        public void MoveNorthOneStep_WhenFacingNorthAndMovingForward()
        {
            _rover.DirectionFacing = Direction.North;
            _rover.Commands.Add(Command.Forward);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(1));
        }

        [Test]
        public void MoveSouthOneStep_WhenFacingSouthAndMovingForward()
        {
            _rover.DirectionFacing = Direction.South;
            _rover.Commands.Add(Command.Forward);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(-1));
        }

        [Test]
        public void MoveEastOneStep_WhenFacingEastAndMovingForward()
        {
            _rover.DirectionFacing = Direction.East;
            _rover.Commands.Add(Command.Forward);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(1));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void MoveWestOneStep_WhenFacingWestAndMovingForward()
        {
            _rover.DirectionFacing = Direction.West;
            _rover.Commands.Add(Command.Forward);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(-1));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void MoveNorthOneStep_WhenFacingSouthAndMovingReverse()
        {
            _rover.DirectionFacing = Direction.South;
            _rover.Commands.Add(Command.Reverse);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(1));
        }

        [Test]
        public void MoveSouthOneStep_WhenFacingNorthAndMovingReverse()
        {
            _rover.DirectionFacing = Direction.North;
            _rover.Commands.Add(Command.Reverse);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(-1));
        }

        [Test]
        public void MoveEastOneStep_WhenFacingWestAndMovingReverse()
        {
            _rover.DirectionFacing = Direction.West;
            _rover.Commands.Add(Command.Reverse);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(1));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void MoveWestOneStep_WhenFacingEastAndMovingReverse()
        {
            _rover.DirectionFacing = Direction.East;
            _rover.Commands.Add(Command.Reverse);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(-1));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void FaceEast_WhenFacingNorthAndTurningRight()
        {
            _rover.DirectionFacing = Direction.North;
            _rover.Commands.Add(Command.Right);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
            Assert.That(_rover.DirectionFacing, Is.EqualTo(Direction.East));
        }

        [Test]
        public void FaceSouth_WhenFacingEastAndTurningRight()
        {
            _rover.DirectionFacing = Direction.East;
            _rover.Commands.Add(Command.Right);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
            Assert.That(_rover.DirectionFacing, Is.EqualTo(Direction.South));
        }

        [Test]
        public void FaceWest_WhenFacingSouthAndTurningRight()
        {
            _rover.DirectionFacing = Direction.South;
            _rover.Commands.Add(Command.Right);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
            Assert.That(_rover.DirectionFacing, Is.EqualTo(Direction.West));
        }

        [Test]
        public void FaceNorth_WhenFacingWestAndTurningRight()
        {
            _rover.DirectionFacing = Direction.West;
            _rover.Commands.Add(Command.Right);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
            Assert.That(_rover.DirectionFacing, Is.EqualTo(Direction.North));
        }

        [Test]
        public void MoveNorthEast()
        {
            _rover.DirectionFacing = Direction.East;
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Left);
            _rover.Commands.Add(Command.Forward);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(1));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(1));
        }

        [Test]
        public void MoveSouthEast()
        {
            _rover.DirectionFacing = Direction.East;
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Right);
            _rover.Commands.Add(Command.Forward);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(1));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(-1));
        }

        [Test]
        public void MoveSouthWest()
        {
            _rover.DirectionFacing = Direction.South;
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Right);
            _rover.Commands.Add(Command.Forward);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(-1));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(-1));
        }

        [Test]
        public void MoveNorthWest()
        {
            _rover.DirectionFacing = Direction.North;
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Left);
            _rover.Commands.Add(Command.Forward);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(-1));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(1));
        }

        [Test]
        public void EncounterAnObstacleNorth_WhenMovingForward()
        {
            var obstacle = AddObstacle(0, 1);
            _grid.AddObstacle(obstacle);

            _rover.DirectionFacing = Direction.North;
            _rover.Commands.Add(Command.Forward);
            var encounteredObstacle = _rover.Execute() == false;

            Assert.That(encounteredObstacle, Is.True);
            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void EncounterAnObstacleEast_WhenMovingForward()
        {
            var obstacle = AddObstacle(1, 0);
            _grid.AddObstacle(obstacle);

            _rover.DirectionFacing = Direction.East;
            _rover.Commands.Add(Command.Forward);
            var encounteredObstacle = _rover.Execute() == false;

            Assert.That(encounteredObstacle, Is.True);
            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void EncounterAnObstacleSouth_WhenMovingForward()
        {
            var obstacle = AddObstacle(0, -1);
            _grid.AddObstacle(obstacle);

            _rover.DirectionFacing = Direction.South;
            _rover.Commands.Add(Command.Forward);
            var encounteredObstacle = _rover.Execute() == false;

            Assert.That(encounteredObstacle, Is.True);
            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void EncounterAnObstacleWest_WhenMovingForward()
        {
            var obstacle = AddObstacle(-1, 0);
            _grid.AddObstacle(obstacle);

            _rover.DirectionFacing = Direction.West;
            _rover.Commands.Add(Command.Forward);
            var encounteredObstacle = _rover.Execute() == false;

            Assert.That(encounteredObstacle, Is.True);
            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void EncounterAnObstacleNorth_WhenMovingReverse()
        {
            var obstacle = AddObstacle(0, 1);
            _grid.AddObstacle(obstacle);

            _rover.DirectionFacing = Direction.South;
            _rover.Commands.Add(Command.Reverse);
            var encounteredObstacle = _rover.Execute() == false;

            Assert.That(encounteredObstacle, Is.True);
            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void EncounterAnObstacleEast_WhenMovingReverse()
        {
            var obstacle = AddObstacle(1, 0);
            _grid.AddObstacle(obstacle);

            _rover.DirectionFacing = Direction.West;
            _rover.Commands.Add(Command.Reverse);
            var encounteredObstacle = _rover.Execute() == false;

            Assert.That(encounteredObstacle, Is.True);
            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void EncounterAnObstacleSouth_WhenMovingReverse()
        {
            var obstacle = AddObstacle(0, -1);
            _grid.AddObstacle(obstacle);

            _rover.DirectionFacing = Direction.North;
            _rover.Commands.Add(Command.Reverse);
            var encounteredObstacle = _rover.Execute() == false;

            Assert.That(encounteredObstacle, Is.True);
            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void EncounterAnObstacleWest_WhenMovingReverse()
        {
            var obstacle = AddObstacle(-1, 0);
            _grid.AddObstacle(obstacle);

            _rover.DirectionFacing = Direction.East;
            _rover.Commands.Add(Command.Reverse);
            var encounteredObstacle = _rover.Execute() == false;

            Assert.That(encounteredObstacle, Is.True);
            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void EncounterAnObstacleSouth_AfterGoingAroundItOnTheRight()
        {
            var obstacle = AddObstacle(0, 1);
            _grid.AddObstacle(obstacle);

            _rover.DirectionFacing = Direction.East;
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Left);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Left);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Left);
            _rover.Commands.Add(Command.Forward);
            var encounteredObstacle = _rover.Execute() == false;

            Assert.That(encounteredObstacle, Is.True);
            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(2));
        }

        [Test]
        public void WrapAround_FromLeftToRight()
        {
            _rover.DirectionFacing = Direction.West;
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(10));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void WrapAround_FromRightToLeft()
        {
            _rover.DirectionFacing = Direction.East;
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(-10));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void WrapAround_FromTopToBottom()
        {
            _rover.DirectionFacing = Direction.North;
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(-10));
        }

        [Test]
        public void WrapAround_FromBottomToTop()
        {
            _rover.DirectionFacing = Direction.South;
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Execute();

            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(10));
        }

        [Test]
        public void NotWrapAround_FromLeftToRigh_WhenThereIsAnObstacle()
        {
            var obstacle = AddObstacle(10, 0);
            _grid.AddObstacle(obstacle);

            _rover.DirectionFacing = Direction.West;
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            var encounteredObstacle = _rover.Execute() == false;

            Assert.That(encounteredObstacle, Is.True);
            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(-10));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void NotWrapAround_FromRightToLeft_WhenThereIsAnObstacle()
        {
            var obstacle = AddObstacle(-10, 0);
            _grid.AddObstacle(obstacle);

            _rover.DirectionFacing = Direction.East;
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            var encounteredObstacle = _rover.Execute() == false;

            Assert.That(encounteredObstacle, Is.True);
            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(10));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(0));
        }

        [Test]
        public void NotWrapAround_FromTopToBottom_WhenThereIsAnObstacle()
        {
            var obstacle = AddObstacle(0, -10);
            _grid.AddObstacle(obstacle);

            _rover.DirectionFacing = Direction.North;
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            var encounteredObstacle = _rover.Execute() == false;

            Assert.That(encounteredObstacle, Is.True);
            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(10));
        }

        [Test]
        public void NotWrapAround_FromBottomToTop_WhenThereIsAnObstacle()
        {
            var obstacle = AddObstacle(0, 10);
            _grid.AddObstacle(obstacle);

            _rover.DirectionFacing = Direction.South;
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            _rover.Commands.Add(Command.Forward);
            var encounteredObstacle = _rover.Execute() == false;

            Assert.That(encounteredObstacle, Is.True);
            Assert.That(_rover.CurrentPosition.X, Is.EqualTo(0));
            Assert.That(_rover.CurrentPosition.Y, Is.EqualTo(-10));
        }

        private Obstacle AddObstacle(int x, int y)
        {
            return new Obstacle(ObstacleType.Solid, x, y);
        }
    }
}
