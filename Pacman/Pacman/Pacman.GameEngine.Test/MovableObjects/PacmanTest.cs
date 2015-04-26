using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman.GameEngine.Test.MovableObjects
{
    [TestClass]
    public class PacmanTest
    {
        
        [TestMethod]
        public void Move()
        {        
            Game game = new Game();           

            game.myPacman.X = 6;
            game.myPacman.Y = 27;
            Assert.IsTrue(game.myPacman.Move(game, Direction.Left));
            Assert.IsTrue(game.myPacman.Move(game, Direction.Right));
            Assert.IsTrue(game.myPacman.Move(game, Direction.Up));
            Assert.IsTrue(game.myPacman.Move(game, Direction.Down));

            game.myPacman.X = 6;
            game.myPacman.Y = 26;
            Assert.IsFalse(game.myPacman.Move(game, Direction.Left));
            Assert.IsFalse(game.myPacman.Move(game, Direction.Right));

            game.myPacman.X = 13;
            game.myPacman.Y = 26;
            Assert.IsFalse(game.myPacman.Move(game, Direction.Up));
            Assert.IsFalse(game.myPacman.Move(game, Direction.Down));

            game.myPacman.X = 6;
            game.myPacman.Y = 27;
            game.myPinky.X = 6;
            game.myPinky.Y = 27;
            Assert.IsFalse(game.myPacman.Move(game, Direction.Left));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionMove()
        {
            Game game = new Game();
            game.myPacman.Move(game, Direction.None);
        }
      
    }
}
