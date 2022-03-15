using System;
using System.Collections.Generic;
using System.Text;

namespace OOP___Snake
{
    public interface ISnakeEntity : IGameEntity
    {
        Direction Dir { get; set; }
        IList<Pos> Body{ get; set; }
        int Length { get; set; }
        int MapSizeX { get; }
        int MapSizeY { get; }
        bool Dead { get; set; }
        void ResetDirection();
        Pos NextPosition();
        void IncreaseLength();
        void Move();
        void Die();
    }
}
