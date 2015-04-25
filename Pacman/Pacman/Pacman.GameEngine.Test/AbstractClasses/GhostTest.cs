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

        public void MivValue()
        {
            int[] array = new int[4];
            array[0] = 2;
            array[1] = -2;
            array[2] = -2;
            array[3] = 4;

            Ghost myInky = new Inky(1, 1);
            Assert.AreEqual(myInky.MinValue(array), 0);
        }

        [TestMethod]
        public void CheckApplesLeft()
        {
            Apples currentapples = game.Map.GetApples();
            Assert.AreEqual(myInky.CheckApplesLeft(ref currentapples), Direction.Left);
            
        }

        [TestMethod]
        public void CheckApplesRight()
        {
            
            Apples currentapples = game.Map.GetApples();
            
            Assert.AreEqual(myInky.CheckApplesRight(ref currentapples), Direction.Right);
           
        }

        [TestMethod]
        public void CheckApplesUp()
        {
            
            Apples currentapples = game.Map.GetApples();
            
            Assert.AreEqual(myInky.CheckApplesUp(ref currentapples), Direction.Up);
           
        }

        [TestMethod]
        public void CheckApplesDown()
        {
            
            Apples currentapples = game.Map.GetApples();
            
            Assert.AreEqual(myInky.CheckApplesDown(ref currentapples), Direction.Down);
        }

        [TestMethod]
        public void MoveOneStep_Left_Ok()
        {

            Apples currentapples = game.Map.GetApples();
            game.myInky.X = 6;
            game.myInky.Y = 27;
            Direction AppleDirection = game.myInky.MoveOneStep(game, Direction.Left);

            Assert.AreEqual(AppleDirection, Direction.Right); 
        }

        [TestMethod]
        public void MoveOneStep_Left_NotOk()
        {

            Apples currentapples = game.Map.GetApples();
            game.myInky.X = 6;
            game.myInky.Y = 26;
            Direction AppleDirection = game.myInky.MoveOneStep(game, Direction.Left);      
           
            Assert.AreEqual(AppleDirection, Direction.None);    
        }
       

         [TestMethod]
        public void MoveOneStep_Right_Ok()
        {

            Apples currentapples = game.Map.GetApples();
            game.myInky.X = 6;
            game.myInky.Y = 26;
            Direction AppleDirection = game.myInky.MoveOneStep(game, Direction.Right);

            Assert.AreEqual(AppleDirection, Direction.None);
        }

         [TestMethod]
         public void MoveOneStep_Right_NotOk()
         {

             Apples currentapples = game.Map.GetApples();
             game.myInky.X = 6;
             game.myInky.Y = 27;
             Direction AppleDirection = game.myInky.MoveOneStep(game, Direction.Right);
             Assert.AreEqual(AppleDirection, Direction.Left);
         }


         [TestMethod]
        public void MoveOneStep_Up_Ok()
        {

            Apples currentapples = game.Map.GetApples();
            game.myInky.X = 6;
            game.myInky.Y = 27;
            Direction AppleDirection = game.myInky.MoveOneStep(game, Direction.Up);
            Assert.AreEqual(AppleDirection, Direction.Down);
        }


        [TestMethod]
         public void MoveOneStep_Up_NotOk()
         {

             Apples currentapples = game.Map.GetApples();
             game.myInky.X = 5;
             game.myInky.Y = 27;
             Direction AppleDirection = game.myInky.MoveOneStep(game, Direction.Up);
             Assert.AreEqual(AppleDirection, Direction.None);
         }

         [TestMethod]
        public void MoveOneStep_Down_Ok()
        {

            Apples currentapples = game.Map.GetApples();
            game.myInky.X = 6;
            game.myInky.Y = 27;
            Direction AppleDirection = game.myInky.MoveOneStep(game, Direction.Down);
            Assert.AreEqual(AppleDirection, Direction.Up);


        }

         [TestMethod]
         public void MoveOneStep_Down_NotOk()
         {

             Apples currentapples = game.Map.GetApples();
             game.myInky.X = 5;
             game.myInky.Y = 27;
             Direction AppleDirection = game.myInky.MoveOneStep(game, Direction.Down);
             Assert.AreEqual(AppleDirection, Direction.None);


         }

         [TestMethod]
         public void MoveOneStep_Down_Ok_NotEat()
         {

             Apples currentapples = game.Map.GetApples();
             game.myInky.X = 14;
             game.myInky.Y = 12;

             Direction AppleDirection = game.myInky.MoveOneStep(game, Direction.Up);
             Assert.AreEqual(AppleDirection, Direction.None);

             Direction AppleDirection1 = game.myInky.MoveOneStep(game, Direction.Right);
             Assert.AreEqual(AppleDirection1, Direction.None);

             Direction AppleDirection2 = game.myInky.MoveOneStep(game, Direction.Down);
             Assert.AreEqual(AppleDirection2, Direction.None);

             Direction AppleDirection3 = game.myInky.MoveOneStep(game, Direction.Left);
             Assert.AreEqual(AppleDirection3, Direction.None);

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
