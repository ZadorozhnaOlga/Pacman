using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Pacman.GameEngine.Test.AbstractClasses
{
    [TestClass]
    public class GhostTest
    {
        private static Game game;
        static GhostTest() 
        {
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var mapFile = @"\Map\Map.txt";
            string mapPath = string.Concat(projectPath, mapFile);

            game = new Game(28, 32, Game.LoadMap(mapPath, 28, 32), 13, 26, 13, 12, 14, 12);
        }
        

        [TestMethod]
        public void MoveOneStep_Left_Eat()
        {
            Apples currentapples = game.Map.GetApples();
            game.MyInky.X = 6;
            game.MyInky.Y = 27;

            game.MyPacman.X = 4;
            game.MyPacman.Y = 27;
            Direction AppleDirection = game.MyInky.Move(game);

            Assert.AreEqual(AppleDirection, Direction.Right);
        }


        [TestMethod]
        public void MoveOneStep_Right_Eat()
        {
            Apples currentapples = game.Map.GetApples();
            game.MyInky.X = 6;
            game.MyInky.Y = 27;

            game.MyPacman.X = 7;
            game.MyPacman.Y = 27;
            Direction AppleDirection = game.MyInky.Move(game);

            Assert.AreEqual(AppleDirection, Direction.Left);
        }


        [TestMethod]
        public void MoveOneStep_Up_Eat()
        {
            Apples currentapples = game.Map.GetApples();
            game.MyInky.X = 6;
            game.MyInky.Y = 27;

            game.MyPacman.X = 6;
            game.MyPacman.Y = 25;
            Direction AppleDirection = game.MyInky.Move(game);

            Assert.AreEqual(AppleDirection, Direction.Down);
        }


        [TestMethod]
        public void MoveOneStep_Down_Eat()
        {
            Apples currentapples = game.Map.GetApples();
            game.MyInky.X = 6;
            game.MyInky.Y = 27;

            game.MyPacman.X = 6;
            game.MyPacman.Y = 29;
            Direction AppleDirection = game.MyInky.Move(game);

            Assert.AreEqual(AppleDirection, Direction.Up);
        }


        [TestMethod]
        public void MoveOneStep_Left_NotEat()
        {
            Apples currentapples = game.Map.GetApples();
            game.MyInky.X = 14;
            game.MyInky.Y = 12;

            game.MyPacman.X = 12;
            game.MyPacman.Y = 12;
            Direction AppleDirection = game.MyInky.Move(game);

            Assert.AreEqual(AppleDirection, Direction.None); 
        }


        [TestMethod]
        public void MoveOneStep_Right_NotEat()
        {
            Apples currentapples = game.Map.GetApples();
            game.MyInky.X = 14;
            game.MyInky.Y = 12;

            game.MyPacman.X = 16;
            game.MyPacman.Y = 12;

            Direction AppleDirection1 = game.MyInky.Move(game);

            Assert.AreEqual(AppleDirection1, Direction.None);
        }


        [TestMethod]
        public void MoveOneStep_Up_NotEat()
        {
            Apples currentapples = game.Map.GetApples();
            game.MyInky.X = 14;
            game.MyInky.Y = 12;

            game.MyPacman.X = 14;
            game.MyPacman.Y = 11;

            Direction AppleDirection1 = game.MyInky.Move(game);

            Assert.AreEqual(AppleDirection1, Direction.None);

        }


        [TestMethod]
        public void MoveOneStep_Down_NotEat()
        {
            Apples currentapples = game.Map.GetApples();
            game.MyInky.X = 14;
            game.MyInky.Y = 11;

            game.MyPacman.X = 14;
            game.MyPacman.Y = 12;

            Direction AppleDirection1 = game.MyInky.Move(game);

            Assert.AreEqual(AppleDirection1, Direction.None);

        }


        [TestMethod]
        public void MoveOneStep_Default()
        {
            Apples currentapples = game.Map.GetApples();
            game.MyInky.X = 14;
            game.MyInky.Y = 12;

            Direction AppleDirection = game.MyInky.MoveOneStep(game, Direction.None);

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
             game.MyPacman.X = 13;
             game.MyPacman.Y = 26;
             game.MyInky.X = 13;
             game.MyInky.Y = 12;
  
             Assert.AreEqual(game.MyInky.Move(game), Direction.None);
             Assert.AreEqual(game.MyInky.Move(game), Direction.None);
             Assert.AreEqual(game.MyInky.Move(game), Direction.None);
             Assert.AreEqual(game.MyInky.Move(game), Direction.None);
             Assert.AreEqual(game.MyInky.Move(game), Direction.None);
             Assert.AreEqual(game.MyInky.Move(game), Direction.None);
             Assert.AreEqual(game.MyInky.Move(game), Direction.None);

             Assert.AreEqual(game.MyInky.Move(game), Direction.Right);
             Assert.AreEqual(game.MyInky.Move(game), Direction.Up);

             game.MyInky.X = 10;
             game.MyInky.Y = 10;
             game.MyPacman.X = 10;
             game.MyPacman.Y = 10;
             Assert.AreEqual(game.MyInky.Move(game), Direction.None);
         }
 
    }
}
