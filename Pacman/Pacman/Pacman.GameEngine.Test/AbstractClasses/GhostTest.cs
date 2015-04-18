using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman.GameEngine.Test.AbstractClasses
{
    [TestClass]
    public class GhostTest
    {
        Game game = new Game();
        Ghost myInky = new Inky(6, 27);

        [TestMethod]
        public void CheckApplesLeft()
        {
            Apples currentapples = game.Map.GetApples();
            Assert.IsTrue(myInky.CheckApplesLeft(ref currentapples));
            
        }

        [TestMethod]
        public void CheckApplesRight()
        {
            
            Apples currentapples = game.Map.GetApples();
            
            Assert.IsTrue(myInky.CheckApplesRight(ref currentapples));
           
        }

        [TestMethod]
        public void CheckApplesUp()
        {
            
            Apples currentapples = game.Map.GetApples();
            
            Assert.IsTrue(myInky.CheckApplesUp(ref currentapples));
           
        }

        [TestMethod]
        public void CheckApplesDown()
        {
            
            Apples currentapples = game.Map.GetApples();
            
            Assert.IsTrue(myInky.CheckApplesDown(ref currentapples));
        }
    }
}
