using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP___Snake;

namespace Tests
{
    [TestClass]
    public class GameModelTests
    {
        private const int X_MAP_SIZE = 21;
        private const int Y_MAP_SIZE = 21;
        private const int X_START_POS = X_MAP_SIZE / 2;
        private const int Y_START_POS = Y_MAP_SIZE / 3 * 2;
        private const int POINTS = 50;

        private readonly IModel model = new GameModel();

        [TestMethod]
        public void TestGameModelConstructor()
        {
            Assert.AreEqual(Direction.Up, model.Snake.Dir);
            Assert.AreEqual(X_START_POS, model.Snake.Position.X);
            Assert.AreEqual(Y_START_POS, model.Snake.Position.Y);
            Assert.AreEqual(POINTS, model.Apple.PointsValue);
            Assert.AreEqual(0, model.Apple.EatenCounter);
            Assert.AreEqual(0, model.Score);
        }

        [TestMethod]
        public void TestEatApple()
        {
            Pos a = model.Apple.Position;
            model.Snake.Position = a;
            model.EatApple();
            Assert.AreEqual(POINTS, model.Score);
            Assert.AreNotEqual(a.X, model.Apple.Position.X);
            Assert.AreNotEqual(a.Y, model.Apple.Position.Y);
            Assert.AreEqual(1, model.Apple.EatenCounter);
        }

        [TestMethod]
        public void TestReset()
        {
            model.Snake.Move();
            model.Snake.Move();
            model.Snake.Dir = Direction.Right;
            model.Snake.Move();
            model.Snake.Move();
            model.Apple.Position = model.Snake.Position;
            model.EatApple();
            var a = model.Apple.Position;
            model.ResetGame();
            Assert.AreEqual(X_START_POS, model.Snake.Position.X);
            Assert.AreEqual(Y_START_POS, model.Snake.Position.Y);
            Assert.AreNotEqual(a.X, model.Apple.Position.X);
            Assert.AreNotEqual(a.Y, model.Apple.Position.Y);
            Assert.AreEqual(0, model.Apple.EatenCounter);
            Assert.AreEqual(0, model.Score);
        }
    }
}
