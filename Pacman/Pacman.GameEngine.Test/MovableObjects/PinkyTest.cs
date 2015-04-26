using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman.GameEngine.Test.MovableObjects
{
    [TestClass]
    public class PinkyTest
    {
        
        [TestMethod]
        public void ChooseTarget_Left()
        {
            Game game = new Game();
            game.myPacman.Direction = Direction.Left;
            int targetX = game.myPacman.X;
            int targetY = game.myPacman.Y;
            game.myPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetX, 9);
            Assert.AreEqual(targetY, 26);

            game.myPacman.X = 1;
            game.myPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetX, 1);
            Assert.AreEqual(targetY, 26);
        }


        [TestMethod]
        public void ChooseTarget_Right()
        {
            Game game = new Game();
            game.myPacman.Direction = Direction.Right;
            int targetX = game.myPacman.X;
            int targetY = game.myPacman.Y;
            game.myPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetX, 17);
            Assert.AreEqual(targetY, 26);

            game.myPacman.X = 27;
            game.myPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetX, 27);
            Assert.AreEqual(targetY, 26);
        }


        [TestMethod]
        public void ChooseTarget_Up()
        {
            Game game = new Game();
            game.myPacman.Direction = Direction.Up;
            int targetX = game.myPacman.X;
            int targetY = game.myPacman.Y;
            game.myPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetY, 22);
            Assert.AreEqual(targetX, 9);

            game.myPacman.Y = 2;
            game.myPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetY, 2);
            Assert.AreEqual(targetX, 13);
        }


        [TestMethod]
        public void ChooseTarget_Down()
        {
            Game game = new Game();
            game.myPacman.Direction = Direction.Down;
            int targetX = game.myPacman.X;
            int targetY = game.myPacman.Y;
            game.myPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetY, 30);
            Assert.AreEqual(targetX, 13);

            game.myPacman.Y = 30;
            game.myPinky.ChooseTarget(game, out targetX, out targetY);

            Assert.AreEqual(targetY, 30);
            Assert.AreEqual(targetX, 13);
        }


    }
}
