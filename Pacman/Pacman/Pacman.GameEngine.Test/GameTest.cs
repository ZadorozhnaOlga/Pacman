using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.GameEngine;

namespace Pacman.GameEngine.Test
{
    [TestClass]
    public class GameTest
    {


        #region Game Lifecycle

        [TestMethod]
        public void TestUsualLifecycle()
        {
            Game game = new Game();
            Assert.AreEqual(GameStatus.ReadyToStart, game.Status);
            game.Start();
            Assert.AreEqual(GameStatus.InProgress, game.Status);
            game.Stop();
            Assert.AreEqual(GameStatus.Completed, game.Status);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStart_WrongStatus_1()
        {
            Game game = new Game();
            game.Start();
            game.Start();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStart_WrongStatus_2()
        {
            Game game = new Game();
            game.Start();
            game.Stop();
            game.Start();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStop_WrongStatus_1()
        {
            Game game = new Game();
            game.Stop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStop_WrongStatus_2()
        {
            Game game = new Game();
            game.Start();
            game.Stop();
            game.Stop();
        }

        #endregion
        [TestMethod]
        public void GameOver()
        {
            Game game = new Game();
            game.myPinky.X = 13;
            Assert.IsFalse(game.GameOver());

            game.myPinky.Y = 26;
            Assert.IsTrue(game.GameOver());

            Game game1 = new Game();
            game1.myInky.X = 13;
            Assert.IsFalse(game1.GameOver());

            game1.myInky.Y = 26;
            Assert.IsTrue(game1.GameOver());
        }

      


    }
}
