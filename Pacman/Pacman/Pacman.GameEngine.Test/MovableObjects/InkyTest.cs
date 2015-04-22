using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman.GameEngine.Test.MovableObjects
{
    [TestClass]
    public class InkyTest
    {
        [TestMethod]
        public void ChooseTarget()
        {
            Game game = new Game();
            int targetX;
            int targetY;
            game.myInky.ChooseTarget(game, out targetX, out targetY);
            Assert.AreEqual(targetX, game.myPacman.X);
            Assert.AreEqual(targetY, game.myPacman.Y);
        }
    }
}
