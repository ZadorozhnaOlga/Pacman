using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman.GameEngine.Test.MovableObjects
{
    [TestClass]
    public class PacmanTest
    {
        [TestMethod]
        public void EatApples()
        {
            int [,] arrayeat = new int [3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arrayeat[i, j] = 1;
                }
            }
            Apples app = new Apples(arrayeat);

            Pacman myPacman = new Pacman(1, 1);
            myPacman.EatApples(ref app);
            Assert.AreEqual(app.Dots[myPacman.X, myPacman.Y], 0);

            int[,] arraynoteat = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arraynoteat[i, j] = 0;
                }
            }
            Apples app1 = new Apples(arraynoteat);

            Pacman myPacman1 = new Pacman(1, 1);
            myPacman.EatApples(ref app1);
            Assert.AreEqual(app.Dots[myPacman1.X, myPacman1.Y], 0);
        }

        [TestMethod]
        public void Move()
        {
            //int[,] array = new int[3, 3];
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        array[i, j] = 0;
            //    }
            //}
            Game game = new Game();
           // Apples app = new Apples(array);

            Pacman myPacman = new Pacman(6, 27);
            Assert.IsTrue(myPacman.Move(game, Direction.Left));
            Assert.IsTrue(myPacman.Move(game, Direction.Right));
            Assert.IsTrue(myPacman.Move(game, Direction.Up));
            Assert.IsTrue(myPacman.Move(game, Direction.Down));

            Pacman myPacman1 = new Pacman(6, 26);
            Assert.IsFalse(myPacman1.Move(game, Direction.Left));
            Assert.IsFalse(myPacman1.Move(game, Direction.Right));

            Pacman myPacman2 = new Pacman(13, 26);
            Assert.IsFalse(myPacman2.Move(game, Direction.Up));
            Assert.IsFalse(myPacman2.Move(game, Direction.Down));

            Assert.IsFalse(myPacman2.Move(game, Direction.None));
            //Assert.AreEqual(app.Dots[myPacman.X, myPacman.Y], 0);

            //int[,] arraynoteat = new int[3, 3];
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        arraynoteat[i, j] = 0;
            //    }
            //}
            //Apples app1 = new Apples(arraynoteat);

            //Pacman myPacman1 = new Pacman(1, 1);
            //myPacman.EatApples(ref app1);
            //Assert.AreEqual(app.Dots[myPacman1.X, myPacman1.Y], 0);
        }
    }
}
