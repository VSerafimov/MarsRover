using System.Collections.Generic;
using Core.Enums;

namespace Core
{
    public class Rover
    {
        public Position CurrentPosition { get; private set; }
        public Direction DirectionFacing { get; set; }
        public List<Command> Commands { get; private set; }
        private Grid Grid { get; set; }

        public Rover(Position position, Direction directionFacing, Grid grid)
        {
            CurrentPosition = position;
            DirectionFacing = directionFacing;
            Grid = grid;
            Commands = new List<Command>();
        }

        private void TurnRight()
        {
            switch (DirectionFacing)
            {
                case Direction.North:
                    DirectionFacing = Direction.East;
                    break;
                case Direction.East:
                    DirectionFacing = Direction.South;
                    break;
                case Direction.South:
                    DirectionFacing = Direction.West;
                    break;
                case Direction.West:
                    DirectionFacing = Direction.North;
                    break;
            }
        }

        private void TurnLeft()
        {
            switch (DirectionFacing)
            {
                case Direction.North:
                    DirectionFacing = Direction.West;
                    break;
                case Direction.East:
                    DirectionFacing = Direction.North;
                    break;
                case Direction.South:
                    DirectionFacing = Direction.East;
                    break;
                case Direction.West:
                    DirectionFacing = Direction.South;
                    break;
            }
        }

        public bool Execute()
        {
            foreach (var command in Commands)
            {
                if (command == Command.Forward)
                {
                    if (MoveForward() == false)
                    {
                        return false;
                    }
                }
                else if (command == Command.Reverse)
                {
                    if (MoveReverse() == false)
                    {
                        return false;
                    }
                }
                else if (command == Command.Right)
                {
                    TurnRight();
                }
                else if (command == Command.Left)
                {
                    TurnLeft();
                }
            }
            return true;
        }

        private bool MoveForward()
        {
            if (DirectionFacing == Direction.North && Grid.CanMoveNorth(CurrentPosition))
            {
                MoveNorth();
                return true;
            }
            if (DirectionFacing == Direction.South && Grid.CanMoveSouth(CurrentPosition))
            {
                MoveSouth();
                return true;
            }
            if (DirectionFacing == Direction.East && Grid.CanMoveEast(CurrentPosition))
            {
                MoveEast();
                return true;
            }
            if (DirectionFacing == Direction.West && Grid.CanMoveWest(CurrentPosition))
            {
                MoveWest();
                return true;
            }
            return false;
        }

        private void MoveNorth()
        {
            if (Grid.AtNorthEdge(CurrentPosition.Y))
            {
                CurrentPosition.Y = Grid.SouthEdge;
            }
            else
            {
                CurrentPosition.Y += 1;
            }
        }

        private void MoveSouth()
        {
            if (Grid.AtSouthEdge(CurrentPosition.Y))
            {
                CurrentPosition.Y = Grid.NorthEdge;
            }
            else
            {
                CurrentPosition.Y -= 1;
            }
        }

        private void MoveEast()
        {
            if (Grid.AtEastEdge(CurrentPosition.X))
            {
                CurrentPosition.X = Grid.WestEdge;
            }
            else
            {
                CurrentPosition.X += 1;
            }
        }

        private void MoveWest()
        {
            if (Grid.AtWestEdge(CurrentPosition.X))
            {
                CurrentPosition.X = Grid.EastEdge;
            }
            else
            {
                CurrentPosition.X -= 1;
            }
        }

        private bool MoveReverse()
        {
            if (DirectionFacing == Direction.North && Grid.CanMoveSouth(CurrentPosition))
            {
                MoveSouth();
                return true;
            }
            if (DirectionFacing == Direction.South && Grid.CanMoveNorth(CurrentPosition))
            {
                MoveNorth();
                return true;
            }
            if (DirectionFacing == Direction.East && Grid.CanMoveWest(CurrentPosition))
            {
                MoveWest();
                return true;
            }
            if (DirectionFacing == Direction.West && Grid.CanMoveEast(CurrentPosition))
            {
                MoveEast();
                return true;
            }
            return false;
        }
    }
}
