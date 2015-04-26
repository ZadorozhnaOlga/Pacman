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

            game.myPacman.Lives = 0;
            Assert.IsTrue(game.GameOver());
            Assert.AreEqual(game.Status, GameStatus.Completed);

            game.myPacman.Lives = 1;
            Assert.IsFalse(game.GameOver());

            game.myPacman.Lives = 2;
            Assert.IsFalse(game.GameOver());

            game.myPacman.Lives = 3;
            Assert.IsFalse(game.GameOver());

            
        }


        [TestMethod]
        public void MinusLive()
        {
            Game game = new Game();
            game.MinusLive();

            Assert.AreEqual(game.myPacman.Lives, 2);
        }

        [TestMethod]
        public void IfPacmanNotEated()
        {
            Game game = new Game();
            game.myPinky.X = 13;
            Assert.IsTrue(game.IfPacmanNotEated());

            game.myPinky.Y = 26;
            Assert.IsFalse(game.IfPacmanNotEated());

            game.myInky.Y = 26;
            Assert.IsFalse(game.IfPacmanNotEated());          

            game.myInky.Y = 26;
            Assert.IsFalse(game.IfPacmanNotEated());
        }

    }
}
