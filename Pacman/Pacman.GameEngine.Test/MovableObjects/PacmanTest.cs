using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;

namespace Pacman.GameEngine.Test.MovableObjects
{
    [TestClass]
    public class PacmanTest
    {
        
        [TestMethod]
        public void Move()
        {        
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var mapFile = @"\Map\Map.txt";
            string mapPath = string.Concat(projectPath, mapFile);

            Game game = new Game(28, 32, Game.LoadMap(mapPath, 28, 32), 13, 26, 13, 12, 14, 12);
            game.MyPacman.X = 6;
            game.MyPacman.Y = 27;
            Assert.IsTrue(game.MyPacman.Move(game, Direction.Left));

            game.MyPacman.X = 6;
            game.MyPacman.Y = 27;
            Assert.IsTrue(game.MyPacman.Move(game, Direction.Right));

            game.MyPacman.X = 6;
            game.MyPacman.Y = 27;
            Assert.IsTrue(game.MyPacman.Move(game, Direction.Up));

            game.MyPacman.X = 6;
            game.MyPacman.Y = 27;
            Assert.IsTrue(game.MyPacman.Move(game, Direction.Down));

            game.MyPacman.X = 6;
            game.MyPacman.Y = 26;
            Assert.IsFalse(game.MyPacman.Move(game, Direction.Left));
            Assert.IsFalse(game.MyPacman.Move(game, Direction.Right));

            game.MyPacman.X = 13;
            game.MyPacman.Y = 26;
            Assert.IsFalse(game.MyPacman.Move(game, Direction.Up));
            Assert.IsFalse(game.MyPacman.Move(game, Direction.Down));

            game.MyPacman.X = 6;
            game.MyPacman.Y = 27;
            game.MyPinky.X = 6;
            game.MyPinky.Y = 27;
            Assert.IsFalse(game.MyPacman.Move(game, Direction.Left));

            game.MyPacman.X = 13;
            game.MyPacman.Y = 12;
            Assert.IsFalse(game.MyPacman.Move(game, Direction.Left));
        }
      
    }
}
