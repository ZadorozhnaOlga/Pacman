using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman.GameEngine.Test.GameMap
{
    [TestClass]
    public class ApplesTest
    {
        [TestMethod]
        public void IfExistApple()
        {
            Game game = new Game();
            Assert.IsTrue(game.Map.GetApples().IfExistApple(1, 1));
            Assert.IsFalse(game.Map.GetApples().IfExistApple(13, 12));

        }
    }
}
