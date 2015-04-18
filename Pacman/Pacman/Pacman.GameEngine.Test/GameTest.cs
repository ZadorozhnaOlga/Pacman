using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.GameEngine;

namespace Pacman.GameEngine.Test
{
    [TestClass]
    public class GameTest
    {
        
        

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

        //[TestMethod]
        //public void MovePacmanDown()
        //{
        //    Pacman myPacman = new Pacman(1, 1);
        //    int[,] array = new int[3, 3];
        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            array[j, i] = 0;
        //        }
        //    }

        //    GameEngine.Game game = new GameEngine.Game();

        //    game.MovePacmanDown(myPacman, array);
        //    Assert.AreEqual(myPacman.Y, 2);

        //    Pacman myPacman1 = new Pacman(1, 1);
        //    array[2, 1] = 1;
        //    game.MovePacmanDown(myPacman1, array);
        //    Assert.AreEqual(myPacman1.Y, 1);

        //    Pacman myPacman2 = new Pacman(1, 1);
        //    array[2, 1] = 2;
        //    game.MovePacmanDown(myPacman2, array);
        //    Assert.AreEqual(myPacman2.Y, 2);
        //}

        //[TestMethod]
        //public void MovePacman()
        //{
        //    Random rnd = new Random();
        //    int[,] arraymove = new int[3, 3];
        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            arraymove[j, i] = 0;
        //        }
        //    }

        //    Pacman myPacman = new Pacman(1, 1);

        //    GameEngine.Game game = new GameEngine.Game();

        //    game.MovePacman(myPacman, arraymove, 0);
        //    Assert.AreEqual(myPacman.X, 0);

        //    Pacman myPacman1 = new Pacman(1, 1);
        //    game.MovePacman(myPacman1, arraymove, 1);
        //    Assert.AreEqual(myPacman1.X, 2);

        //    Pacman myPacman2 = new Pacman(1, 1);
        //    game.MovePacman(myPacman2, arraymove, 2);
        //    Assert.AreEqual(myPacman2.Y, 0);

        //    Pacman myPacman3 = new Pacman(1, 1);
        //    game.MovePacman(myPacman3, arraymove, 3);
        //    Assert.AreEqual(myPacman3.Y, 2);

        //    Pacman myPacman4 = new Pacman(1, 1);
        //    game.MovePacman(myPacman4, arraymove, 4);
        //    Assert.AreEqual(myPacman4.Y, 1);




           
        //}

    }
}
