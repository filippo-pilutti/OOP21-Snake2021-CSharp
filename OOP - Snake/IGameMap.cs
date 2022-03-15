using System;
using System.Collections.Generic;
using System.Text;

namespace OOP___Snake
{
    public interface IGameMap
    {
        ICollection<Pos> Map { get; }
        int XMapSize { get; }
        int YMapSize { get; }
        ICollection<Pos> GetFreeCells(ISnakeEntity snake);
    }
}
