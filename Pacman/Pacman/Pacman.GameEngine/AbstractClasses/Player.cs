﻿using System;
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
    public abstract class Player : IPlayer
    {
        #region Properties
        public int X { get; set; }
        public int Y { get; set; }
        public Direction direction { get; set; }

        #endregion

        #region Constructor
        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion

        #region Methods
        
        //Рух на одну клітинку вліво
        public bool MoveLeft(int [,] array)
        {
            return Move(array, -1, 0, () =>
            {
                X--;
            });
        }

        //Рух на одну клітинку вправо
        public bool MoveRight(int[,] array)
        {
            return Move(array, 1, 0, () =>
            {
                X++;
            });
        }

        //Рух на одну клітинку вгору
        public bool MoveUp(int[,] array)
        {
            return Move(array, 0, -1, () =>
            {
                Y--;
            });
        }

        //Рух на одну клітинку вниз
        public bool MoveDown(int[,] array)
        {
            return Move(array, 0, 1, () =>
            {
                Y++;
            });
        }

        private bool Move(int[,] array, int x, int y, Action action)
        {
            if (CheckPosition(array, x, y))
            {
                action();
                return true;
            }

            return false;
        }

        #endregion

        #region Helpers

        //Перевірка того, чи можна зміститись на x та на y клітинок у відповідних напрямках
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

        #endregion
    }
}
