using System;
using System.Collections.Generic;
using System.Text;

namespace OOP___Snake
{
    public class GameMap : IGameMap
    {

        public ICollection<Pos> Map { get; }
        public int XMapSize { get; }
        public int YMapSize { get; }

        public GameMap(ICollection<Pos> map, int x, int y)
        {
            Map = map;
            XMapSize = x;
            YMapSize = y;
        }

        public ICollection<Pos> GetFreeCells(ISnakeEntity snake)
        {
            ISet<Pos> temp = new HashSet<Pos>(Map);
            if (temp.IsSupersetOf(snake.Body))
            {
                foreach (var pos in snake.Body)
                {
                    temp.Remove(pos);
                }
                return temp;
            } else throw new IndexOutOfRangeException();
        }
    }
}
