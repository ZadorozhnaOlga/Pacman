using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman.GameEngine
{
    // за замовчуванням першому енумератору присвоюється значення 0.
    // Значення кожного наступного збільшкється на 1. В даному випадку явно вказувати значення не потрібно.
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
        public Direction Direction { get; set; }

        #endregion

        #region Constructor
        // В даному випадку, варто відкрити конструктор лише для нащадків.
        protected Player(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        #endregion

        #region Methods
        
        // З якою метою цей метод повертає значення bool? 
        public bool MoveLeft(int [,] array)
        {
            return Move(array, -1, 0, () =>
            {
                X--;
            });
        }

        public bool MoveRight(int[,] array)
        {
            return Move(array, 1, 0, () =>
            {
                X++;
            });
        }

        public bool MoveUp(int[,] array)
        {
            return Move(array, 0, -1, () =>
            {
                Y--;
            });
        }

        public bool MoveDown(int[,] array)
        {
            return Move(array, 0, 1, () =>
            {
                Y++;
            });
        }

        #endregion

        #region Helpers

        private bool Move(int[,] array, int x, int y, Action action)
        {
            if (CheckPosition(array, x, y))
            {
                action();
                return true;
            }

            return false;
        }

        public bool CheckPosition(int[,] array, int x, int y)
        {
            // Для підвищення читабельності коду варто використовувати this
            if (array[this.Y + y, this.X + x] == 1)
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

