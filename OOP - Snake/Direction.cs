using System;
using System.Collections.Generic;
using System.Text;

namespace OOP___Snake
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    public class Directions
    {
        public static bool IsOppositeDirection(Direction currDir, Direction newDir) => currDir.Equals(Direction.Up) && newDir.Equals(Direction.Down)
                                                                                        || currDir.Equals(Direction.Left) && newDir.Equals(Direction.Right)
                                                                                        || currDir.Equals(Direction.Down) && newDir.Equals(Direction.Up)
                                                                                        || currDir.Equals(Direction.Right) && newDir.Equals(Direction.Left);
        public static IList<Direction> GetDirectionList() => new List<Direction>() { Direction.Up, Direction.Left, Direction.Right, Direction.Down };
    }
}
