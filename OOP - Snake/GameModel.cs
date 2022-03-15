using System;
using System.Collections.Generic;
using System.Text;

namespace OOP___Snake
{
    public class GameModel : IModel
    {
        private const Direction START_DIR = Direction.Up;
        private const int INITIAL_BODY_LENGTH = 5;
        private const int X_MAP_SIZE = 21;
        private const int Y_MAP_SIZE = 21;
        private const int X_SNAKE_START_POSITION = X_MAP_SIZE / 2;
        private const int Y_SNAKE_START_POSITION = (Y_MAP_SIZE / 3) * 2;

        public ISnakeEntity Snake { get; }
        public IEatableEntity Apple { get; }
        public IGameMap GameMap { get; }
        public int Score { get; private set; }

        public GameModel()
        {
            Snake = new Snake.SnakeBuilder()
                .Direction(START_DIR)
                .HeadPosition(new Pos(X_SNAKE_START_POSITION, Y_SNAKE_START_POSITION))
                .Body(GetInitialSnake())
                .MapSize(X_MAP_SIZE, Y_MAP_SIZE)
                .Build();
            ISet<Pos> s = new HashSet<Pos>();
            for (int i = 0; i < X_MAP_SIZE; i++)
            {
                for (int j = 0; j < Y_MAP_SIZE; j++)
                {
                    s.Add(new Pos(i, j));
                }
            }
            GameMap = new GameMap(s, X_MAP_SIZE, Y_MAP_SIZE);
            Apple = new Apple(RandomApplePos());
            Score = 0;
        }

        public void EatApple()
        {
            IncScore(Apple.PointsValue);
            Snake.IncreaseLength();
            Apple.IncrementEatenCounter();
            Apple.Position = RandomApplePos();
        }

        public void ResetGame()
        {
            Snake.Body = GetInitialSnake();
            Snake.Length = INITIAL_BODY_LENGTH;
            Snake.ResetDirection();
            Apple.Position = RandomApplePos();
            Apple.ResetPoints();
            Score = 0;
        }

        private IList<Pos> GetInitialSnake()
        {
            IList<Pos> initBody = new List<Pos>();
            for (int i = 0; i < INITIAL_BODY_LENGTH; i++)
            {
                initBody.Add(new Pos(X_SNAKE_START_POSITION, Y_SNAKE_START_POSITION + i));
            }
            return initBody;
        }

        private Pos RandomApplePos()
        {
            Random rand = new Random();
            int x = rand.Next(GameMap.XMapSize);
            int y = rand.Next(GameMap.YMapSize);
            while (Snake.Body.Contains(new Pos(x, y)))
            {
                x = rand.Next(GameMap.XMapSize);
                y = rand.Next(GameMap.YMapSize);
            }
            return new Pos(x, y);
        }

        private void IncScore(int value) => Score += value;
    }
}
