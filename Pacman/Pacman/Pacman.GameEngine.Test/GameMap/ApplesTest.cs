using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Pacman.GameEngine.Test.GameMap
{
    [TestClass]
    public class ApplesTest
    {
        [TestMethod]
        public void IfExistApple()
        {
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var mapFile = @"\Map\Map.txt";
            string mapPath = string.Concat(projectPath, mapFile);

            Game game = new Game(28, 32, Game.LoadMap(mapPath, 28, 32), 13, 26, 13, 12, 14, 12);
        
            Assert.IsTrue(game.Map.GetApples().IfExistApple(1, 1));
            Assert.IsFalse(game.Map.GetApples().IfExistApple(13, 12));
        }
    }
}
