using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman.GameEngine.Test.AbstractClasses
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void CheckPosition()
        {
            int[,] array = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[j, i] = 0;
                }
            }

            Person person = new Pacman(1, 1);
            Assert.IsTrue(person.CheckPosition(array, 0, 1));

            array[2, 1] = 1;
            Person person1 = new Pacman(1, 1);
            Assert.IsFalse(person1.CheckPosition(array, 0, 1));

           
        }

        [TestMethod]
        public void MoveLeft()
        {
            int[,] array = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[j, i] = 0;
                }
            }

            Person person = new Pacman(1, 1);
            person.MoveLeft(array);
            Assert.AreEqual(person.X, 0);

            array[1, 0] = 1;
            Person person1 = new Pacman(1, 1);
            person1.MoveLeft(array);
            Assert.AreEqual(person1.X, 1);

            array[1, 0] = 2;
            Person person2 = new Pacman(1, 1);
            person2.MoveLeft(array);
            Assert.AreEqual(person2.X, 0);
        }

        [TestMethod]
        public void MoveRight()
        {
            int[,] array = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[j, i] = 0;
                }
            }

            Person person = new Pacman(1, 1);
            person.MoveRight(array);
            Assert.AreEqual(person.X, 2);

            array[1, 2] = 1;
            Person person1 = new Pacman(1, 1);
            person1.MoveRight(array);
            Assert.AreEqual(person1.X, 1);

            array[1, 2] = 2;
            Person person2 = new Pacman(1, 1);
            person2.MoveRight(array);
            Assert.AreEqual(person2.X, 2);
        }

        [TestMethod]
        public void MoveUp()
        {
            int[,] array = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[j, i] = 0;
                }
            }

            Person person = new Pacman(1, 1);
            person.MoveUp(array);
            Assert.AreEqual(person.Y, 0);

            array[0, 1] = 1;
            Person person1 = new Pacman(1, 1);
            person1.MoveUp(array);
            Assert.AreEqual(person1.Y, 1);

            array[0, 1] = 2;
            Person person2 = new Pacman(1, 1);
            person2.MoveUp(array);
            Assert.AreEqual(person2.Y, 0);
        }

        [TestMethod]
        public void MoveDown()
        {
            int[,] array = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[j, i] = 0;
                }
            }

            Person person = new Pacman(1, 1);
            person.MoveDown(array);
            Assert.AreEqual(person.Y, 2);

            array[2, 1] = 1;
            Person person1 = new Pacman(1, 1);
            person1.MoveDown(array);
            Assert.AreEqual(person1.Y, 1);

            array[2, 1] = 2;
            Person person2 = new Pacman(1, 1);
            person2.MoveDown(array);
            Assert.AreEqual(person2.Y, 2);
        }
    }
}
