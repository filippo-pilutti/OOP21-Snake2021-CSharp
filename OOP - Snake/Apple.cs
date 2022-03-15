using System;
using System.Collections.Generic;
using System.Text;

namespace OOP___Snake
{
    public class Apple : IEatableEntity
    {
        private const int INITIAL_POINTS = 50;
        private const int POINTS_CHANGE = 50;
        private const int APPLES_MULT = 20;

        public Pos Position { get; set; }
        public int EatenCounter { get; private set; }
        public int PointsValue { get; private set; }

        public Apple(Pos p)
        {
            Position = p;
            EatenCounter = 0;
            PointsValue = INITIAL_POINTS;
        }

        public void ResetPoints()
        {
            EatenCounter = 0;
            PointsValue = INITIAL_POINTS;
        }

        public void IncrementEatenCounter()
        {
            EatenCounter++;
            if (EatenCounter % APPLES_MULT == 0)
            {
                PointsValue += POINTS_CHANGE;
            }
        }
    }
}
