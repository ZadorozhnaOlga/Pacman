using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Pacman.GameEngine.Test.MovableObjects
{
    [TestClass]
    public class PinkyTest
    {
        private static Game game;

        static PinkyTest() 
        {
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var mapFile = @"\Map\Map.txt";
            string mapPath = string.Concat(projectPath, mapFile);

            game = new Game(28, 32, Game.LoadMap(mapPath, 28, 32), 13, 26, 13, 12, 14, 12);
        }
        

        [TestMethod]
        public void ChooseTarget_Left()
        {
            game.MyPacman.Direction = Direction.Left;
            int targetX = game.MyPacman.X;
            int targetY = game.MyPacman.Y;
            game.MyPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetX, 9);
            Assert.AreEqual(targetY, 26);

            game.MyPacman.X = 1;
            game.MyPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetX, 1);
            Assert.AreEqual(targetY, 26);
        }


        [TestMethod]
        public void ChooseTarget_Right()
        {
            game.MyPacman.X = 13;
            game.MyPacman.Y = 26;

            game.MyPacman.Direction = Direction.Right;
            int targetX = game.MyPacman.X;
            int targetY = game.MyPacman.Y;
            game.MyPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetX, 17);
            Assert.AreEqual(targetY, 26);

            game.MyPacman.X = 27;
            game.MyPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetX, 27);
            Assert.AreEqual(targetY, 26);
        }


        [TestMethod]
        public void ChooseTarget_Up()
        {
            game.MyPacman.X = 13;
            game.MyPacman.Y = 26;

            game.MyPacman.Direction = Direction.Up;
            int targetX = game.MyPacman.X;
            int targetY = game.MyPacman.Y;
            game.MyPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetY, 22);
            Assert.AreEqual(targetX, 9);

            game.MyPacman.Y = 2;
            game.MyPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetY, 2);
            Assert.AreEqual(targetX, 13);
        }


        [TestMethod]
        public void ChooseTarget_Down()
        {
            game.MyPacman.X = 13;
            game.MyPacman.Y = 26;

            game.MyPacman.Direction = Direction.Down;
            int targetX = game.MyPacman.X;
            int targetY = game.MyPacman.Y;
            game.MyPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetY, 30);
            Assert.AreEqual(targetX, 13);

            game.MyPacman.Y = 30;
            game.MyPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetY, 30);
            Assert.AreEqual(targetX, 13);
        }


    }
}
