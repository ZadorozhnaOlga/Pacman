using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.GameEngine;
using System.IO;

namespace Pacman.GameEngine.Test
{
    [TestClass]
    public class GameTest
    {
        private static Game game;

        static GameTest() 
        {
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var mapFile = @"\Map\Map.txt";
            string mapPath = string.Concat(projectPath, mapFile);

            game = new Game(28, 32, Game.LoadMap(mapPath, 28, 32), 13, 26, 13, 12, 14, 12);
        }


        #region Game Lifecycle

        [TestMethod]
        public void TestUsualLifecycle()
        { 
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
            
            game.Start();
            game.Start();
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStart_WrongStatus_2()
        {
            game.Start();
            game.Stop();
            game.Start();
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStop_WrongStatus_1()
        {
           
            game.Stop();
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStop_WrongStatus_2()
        {
           
            game.Start();
            game.Stop();
            game.Stop();
        }

        #endregion
       
        
        [TestMethod]
        public void GameOver()
        {
            
            game.MyPacman.Lives = 0;
            Assert.IsTrue(game.GameOver());
            Assert.AreEqual(game.Status, GameStatus.Completed);

            game.MyPacman.Lives = 1;
            Assert.IsFalse(game.GameOver());

            game.MyPacman.Lives = 2;
            Assert.IsFalse(game.GameOver());

            game.MyPacman.Lives = 3;
            Assert.IsFalse(game.GameOver());
   
        }


        [TestMethod]
        public void MinusLive()
        {
          
            game.MinusLive();

            Assert.AreEqual(game.MyPacman.Lives, 2);
        }

        [TestMethod]
        public void IfPacmanNotEated()
        {
            
            game.MyPinky.X = 13;
            Assert.IsTrue(game.IfPacmanNotEated());

            game.MyPinky.Y = 26;
            Assert.IsFalse(game.IfPacmanNotEated());

            
            

            //game.MyInky.Y = 26;
            //Assert.IsFalse(game.IfPacmanNotEated());          

            //game.MyInky.Y = 26;
            //Assert.IsFalse(game.IfPacmanNotEated());
        }

     

        

    }
}
