using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Pacman.GameEngine.Test.MovableObjects
{
    [TestClass]
    public class InkyTest
    {
        [TestMethod]
        public void ChooseTarget()
        {
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var mapFile = @"\Map\Map.txt";
            string mapPath = string.Concat(projectPath, mapFile);
            Game game = new Game(28, 32, Game.LoadMap(mapPath, 28, 32), 13, 26, 13, 12, 14, 12);
        
            int targetX;
            int targetY;
            game.MyInky.ChooseTarget(game, out targetX, out targetY);
            Assert.AreEqual(targetX, game.MyPacman.X);
            Assert.AreEqual(targetY, game.MyPacman.Y);
        }
    }
}
