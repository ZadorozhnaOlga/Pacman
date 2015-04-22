using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman.GameEngine
{
    public enum Direction
    {
        Left = 0,
        Right = 1,
        Up = 2,
        Down = 3,
        None = 4
    }
    public abstract class Person : IPerson
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Direction direction { get; set; }
     

        public Person(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool CheckPosition(int[,] array, int x, int y)
        {
            if (array[Y + y, X + x] == 1)
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        public bool MoveLeft(int [,] array)
        {
            //direction = Direction.Left;
            if (CheckPosition(array, -1, 0))
            {
                
                X--;
                return true;
            }
            else
            {
               
                return false;
            }
        }

        public bool MoveRight(int[,] array)
        {
            //direction = Direction.Right; 
            if (CheckPosition(array, 1, 0))
            {
               
                X++;
                return true;
            }
            else
            {
                
                return false;
            }
        }

        public bool MoveUp(int[,] array)
        {
            //direction = Direction.Up;
            if (CheckPosition(array, 0, -1))
            {
                
                Y--;
                return true;
            }
            else
            {
                
                return false;
            }
        }

        public bool MoveDown(int[,] array)
        {
            //direction = Direction.Down;
            if (CheckPosition(array, 0, 1))
            {
                
                Y++;
                return true;
            }
            else
            {
                
                return false;
            }
        }










    }
}

