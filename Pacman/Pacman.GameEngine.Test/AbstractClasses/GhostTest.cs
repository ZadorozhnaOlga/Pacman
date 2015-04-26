using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman.GameEngine.Test.AbstractClasses
{
    [TestClass]
    public class GhostTest
    {
        Game game = new Game();


        [TestMethod]
        public void MoveOneStep_Left_Eat()
        {
            Apples currentapples = game.Map.GetApples();
            game.myInky.X = 6;
            game.myInky.Y = 27;

            game.myPacman.X = 4;
            game.myPacman.Y = 27;
            Direction AppleDirection = game.myInky.Move(game);

            Assert.AreEqual(AppleDirection, Direction.Right);
        }


        [TestMethod]
        public void MoveOneStep_Right_Eat()
        {
            Apples currentapples = game.Map.GetApples();
            game.myInky.X = 6;
            game.myInky.Y = 27;

            game.myPacman.X = 7;
            game.myPacman.Y = 27;
            Direction AppleDirection = game.myInky.Move(game);

            Assert.AreEqual(AppleDirection, Direction.Left);
        }


        [TestMethod]
        public void MoveOneStep_Up_Eat()
        {
            Apples currentapples = game.Map.GetApples();
            game.myInky.X = 6;
            game.myInky.Y = 27;

            game.myPacman.X = 6;
            game.myPacman.Y = 25;
            Direction AppleDirection = game.myInky.Move(game);

            Assert.AreEqual(AppleDirection, Direction.Down);
        }


        [TestMethod]
        public void MoveOneStep_Down_Eat()
        {
            Apples currentapples = game.Map.GetApples();
            game.myInky.X = 6;
            game.myInky.Y = 27;

            game.myPacman.X = 6;
            game.myPacman.Y = 29;
            Direction AppleDirection = game.myInky.Move(game);

            Assert.AreEqual(AppleDirection, Direction.Up);
        }


        [TestMethod]
        public void MoveOneStep_Left_NotEat()
        {
            Apples currentapples = game.Map.GetApples();
            game.myInky.X = 14;
            game.myInky.Y = 12;

            game.myPacman.X = 12;
            game.myPacman.Y = 12;
            Direction AppleDirection = game.myInky.Move(game);

            Assert.AreEqual(AppleDirection, Direction.None); 
        }


        [TestMethod]
        public void MoveOneStep_Right_NotEat()
        {
            Apples currentapples = game.Map.GetApples();
            game.myInky.X = 14;
            game.myInky.Y = 12;

            game.myPacman.X = 16;
            game.myPacman.Y = 12;

            Direction AppleDirection1 = game.myInky.Move(game);

            Assert.AreEqual(AppleDirection1, Direction.None);
        }


        [TestMethod]
        public void MoveOneStep_Up_NotEat()
        {
            Apples currentapples = game.Map.GetApples();
            game.myInky.X = 14;
            game.myInky.Y = 12;

            game.myPacman.X = 14;
            game.myPacman.Y = 11;

            Direction AppleDirection1 = game.myInky.Move(game);

            Assert.AreEqual(AppleDirection1, Direction.None);

        }


        [TestMethod]
        public void MoveOneStep_Down_NotEat()
        {
            Apples currentapples = game.Map.GetApples();
            game.myInky.X = 14;
            game.myInky.Y = 11;

            game.myPacman.X = 14;
            game.myPacman.Y = 12;

            Direction AppleDirection1 = game.myInky.Move(game);

            Assert.AreEqual(AppleDirection1, Direction.None);

        }


        [TestMethod]
        public void MoveOneStep_Default()
        {
            Apples currentapples = game.Map.GetApples();
            game.myInky.X = 14;
            game.myInky.Y = 12;

            Direction AppleDirection = game.myInky.MoveOneStep(game, Direction.None);

            Assert.AreEqual(AppleDirection, Direction.None);
        }

         [TestMethod]
         public void ChooseTarget()
         {
             Ghost ghost = new Ghost(3,3);
             int targetX, targetY;
             ghost.ChooseTarget(game, out targetX, out targetY);
             Assert.AreEqual(targetX, 0);
             Assert.AreEqual(targetY, 0);
         }


         [TestMethod]
         public void Move()
         {
             Assert.AreEqual(game.myInky.Move(game), Direction.None);
             Assert.AreEqual(game.myInky.Move(game), Direction.None);
             Assert.AreEqual(game.myInky.Move(game), Direction.None);
             Assert.AreEqual(game.myInky.Move(game), Direction.None);
             Assert.AreEqual(game.myInky.Move(game), Direction.None);
             Assert.AreEqual(game.myInky.Move(game), Direction.None);
             Assert.AreEqual(game.myInky.Move(game), Direction.None);

             Assert.AreEqual(game.myInky.Move(game), Direction.Right);
             Assert.AreEqual(game.myInky.Move(game), Direction.Up);

             game.myInky.X = 10;
             game.myInky.Y = 10;
             game.myPacman.X = 10;
             game.myPacman.Y = 10;
             Assert.AreEqual(game.myInky.Move(game), Direction.None);
         }
 
    }
}
