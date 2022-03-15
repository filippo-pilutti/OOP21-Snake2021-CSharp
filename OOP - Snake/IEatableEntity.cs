using System;
using System.Collections.Generic;
using System.Text;

namespace OOP___Snake
{
    public interface IEatableEntity : IGameEntity
    {
        int EatenCounter { get; }
        int PointsValue { get; }
        void ResetPoints();
        void IncrementEatenCounter();
    }
}
