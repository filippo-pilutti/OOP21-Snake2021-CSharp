using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OOP___Snake;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class SnakeTests
    {
        private const int BODY_LENGTH = 5;
        private const int X_MAP_SIZE = 21;
        private const int Y_MAP_SIZE = 21;
        private const int X_START_POS = 10;
        private const int Y_START_POS = 10;

        private readonly IList<Pos> body = new List<Pos>();

        [TestMethod]
        public void Test1()
        {
            Assert.IsTrue(true);
        }

        
        [TestMethod]
        public void TestSnakeBuilderMissingParameters()
        {
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                ISnakeEntity snake = new Snake.SnakeBuilder().Build();
            });
        }

        [TestMethod]
        public void TestSnakeBuilderFields()
        {
            for (int i = 0; i < BODY_LENGTH; i++)
            {
                body.Add(new Pos(X_START_POS, Y_START_POS + i));
            }

            Assert.ThrowsException<ArgumentException>(() =>
            {
                ISnakeEntity snake = new Snake.SnakeBuilder()
                                              .Direction(Direction.Up)
                                              .HeadPosition(new Pos(X_START_POS, Y_START_POS))
                                              .Body(body)
                                              .MapSize(4, 3)
                                              .Build();
            });

            ISnakeEntity snake = new Snake.SnakeBuilder()
                                              .Direction(Direction.Up)
                                              .HeadPosition(new Pos(X_START_POS, Y_START_POS))
                                              .Body(body)
                                              .MapSize(X_MAP_SIZE, Y_MAP_SIZE)
                                              .Build();
            Assert.IsNotNull(snake);
            Assert.AreEqual(Direction.Up, snake.Dir);
            Assert.AreEqual(10, snake.Position.X);
            Assert.AreEqual(10, snake.Position.Y);
            for (int j = 0; j < BODY_LENGTH; j++)
            {
                Assert.IsTrue(snake.Body.Contains(body[j]));
            }
        }

        
        [TestMethod]
        public void TestDirection()
        {
            for (int i = 0; i < BODY_LENGTH; i++)
            {
                body.Add(new Pos(X_START_POS, Y_START_POS + i));
            }
            ISnakeEntity snake = new Snake.SnakeBuilder()
                                              .Direction(Direction.Up)
                                              .HeadPosition(new Pos(X_START_POS, Y_START_POS))
                                              .Body(body)
                                              .MapSize(X_MAP_SIZE, Y_MAP_SIZE)
                                              .Build();

            Assert.AreEqual(Direction.Up, snake.Dir);
            snake.Dir = Direction.Right;
            Assert.AreEqual(Direction.Right, snake.Dir);
            snake.Dir = Direction.Down;
            Assert.AreEqual(Direction.Down, snake.Dir);
            snake.Dir = Direction.Left;
            Assert.AreEqual(Direction.Left, snake.Dir);
            snake.Dir = Direction.Right;
            Assert.AreNotEqual(Direction.Right, snake.Dir);
            Assert.AreEqual(Direction.Left, snake.Dir);
            snake.Dir = Direction.Up;
            snake.Dir = Direction.Down;
            Assert.AreNotEqual(Direction.Down, snake.Dir);
            Assert.AreEqual(Direction.Up, snake.Dir);
        }

        [TestMethod]
        public void TestNextPosition()
        {
            for (int i = 0; i < BODY_LENGTH; i++)
            {
                body.Add(new Pos(X_START_POS, Y_START_POS + i));
            }
            ISnakeEntity snake = new Snake.SnakeBuilder()
                                              .Direction(Direction.Up)
                                              .HeadPosition(new Pos(X_START_POS, Y_START_POS))
                                              .Body(body)
                                              .MapSize(X_MAP_SIZE, Y_MAP_SIZE)
                                              .Build();
            var np = snake.NextPosition();
            Assert.AreEqual(X_START_POS, np.X);
            Assert.AreEqual(Y_START_POS - 1, np.Y);
            snake.Dir = Direction.Right;
            np = snake.NextPosition();
            Assert.AreEqual(X_START_POS + 1, np.X);
            Assert.AreEqual(Y_START_POS, np.Y);
            snake.Dir = Direction.Down;
            np = snake.NextPosition();
            Assert.AreEqual(X_START_POS, np.X);
            Assert.AreEqual(Y_START_POS + 1, np.Y);
            snake.Dir = Direction.Left;
            np = snake.NextPosition();
            Assert.AreEqual(X_START_POS - 1, np.X);
            Assert.AreEqual(Y_START_POS, np.Y);
        }

        [TestMethod]
        public void TestMove()
        {
            for (int i = 0; i < BODY_LENGTH; i++)
            {
                body.Add(new Pos(X_START_POS, Y_START_POS + i));
            }
            ISnakeEntity snake = new Snake.SnakeBuilder()
                                              .Direction(Direction.Up)
                                              .HeadPosition(new Pos(X_START_POS, Y_START_POS))
                                              .Body(body)
                                              .MapSize(X_MAP_SIZE, Y_MAP_SIZE)
                                              .Build();
            snake.Move();
            Assert.AreEqual(X_START_POS, snake.Position.X);
            Assert.AreEqual(Y_START_POS - 1, snake.Position.Y);
            snake.Move();
            Assert.AreEqual(X_START_POS, snake.Position.X);
            Assert.AreEqual(Y_START_POS - 2, snake.Position.Y);
        }
        
    }
}
