using System;
using System.Collections.Generic;
using System.Text;

namespace OOP___Snake
{
    public class Snake : ISnakeEntity
    {
        private Direction _dir;
        private Pos _position;
        private IList<Pos> _body;

        public Direction Dir 
        {
            get => _dir;
            set
            {
                if (!Directions.IsOppositeDirection(_dir, value))
                {
                    _dir = value;
                }
            }
        }
        public Pos Position 
        {
            get => _position;
            set
            {
                if (value.X < 0 || value.X > MapSizeX || value.Y < 0 || value.Y > MapSizeY)
                {
                    throw new ArgumentException();
                }
                _position = value;
            }
        }
        public IList<Pos> Body 
        {
            get => _body;
            set
            {
                _body = value;
                _position = value[0];
            }
        }
        public int Length { get; set; }
        public int MapSizeX { get; }
        public int MapSizeY { get; }
        public bool Dead { get; set; } = false;

        private Snake(Direction dir, Pos headPos, IList<Pos> bodyPos, int x, int y)
        {
            MapSizeX = x;
            MapSizeY = y;
            Dir = dir;
            Position = headPos;
            Body = bodyPos;
            Length = bodyPos.Count;
        }

        public class SnakeBuilder
        {
            private const int MINIMUM_SIZE = 5;

            private Direction? _direction = null;
            private Pos _headPosition = null;
            private IList<Pos> _body = null;
            private int? _x = null;
            private int? _y = null;
            private bool _built;

            public SnakeBuilder Direction(Direction dir)
            {
                _direction = dir;
                return this;
            }
            public SnakeBuilder HeadPosition(Pos pos)
            {
                _headPosition = pos;
                return this;
            }
            public SnakeBuilder Body(IList<Pos> bodyPos)
            {
                _body = bodyPos;
                return this;
            }
            public SnakeBuilder MapSize(int x, int y)
            {
                if (x < MINIMUM_SIZE || y < MINIMUM_SIZE)
                {
                    throw new ArgumentException();
                }
                _x = x;
                _y = y;
                return this;
            }
            public Snake Build()
            {
                if (_built)
                {
                    throw new InvalidOperationException();
                }
                if (!_direction.HasValue || _headPosition == null || _body == null
                    || _x == null || _y == null)
                {
                    throw new InvalidOperationException();
                }
                _built = true;
                return new Snake(_direction.Value, _headPosition, _body, _x.Value, _y.Value);
            }
        }

        public void Die() => Dead = true;

        public void IncreaseLength() => Length++;

        public void Move()
        {
            if (!Dead)
            {
                Position = NextPosition();
                if (Length == Body.Count)
                {
                    Body.RemoveAt(Body.Count - 1);
                }
                Body.Insert(0, Position);
            }
        }

        public Pos NextPosition()
        {
            var x = Position.X;
            var y = Position.Y;
            switch (Dir)
            {
                case Direction.Left:
                    x--;
                    break;
                case Direction.Right:
                    x++;
                    break;
                case Direction.Up:
                    y--;
                    break;
                case Direction.Down:
                    y++;
                    break;
                default:
                    break;
            }
            return new Pos(x, y);
        }

        public void ResetDirection()
        {
            Dir = Direction.Up;
            Dead = false;
        }
    }
}
