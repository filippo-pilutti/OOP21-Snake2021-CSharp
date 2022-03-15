using System;
using System.Collections.Generic;
using System.Text;

namespace OOP___Snake
{
    public interface IModel
    {
        ISnakeEntity Snake { get; }
        IEatableEntity Apple { get; }
        IGameMap GameMap { get; }
        int Score { get; }
        void EatApple();
        void ResetGame();
    }
}
