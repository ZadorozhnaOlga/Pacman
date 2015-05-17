using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman.GameEngine
{
    public abstract class Player : IPlayer
    {
        #region Properties
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        #endregion

        #region Constructor
        public Player(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        #endregion

        #region Methods
        
        public bool MoveLeft(int[,] array)
        {
            return Move(array, -1, 0, () =>
            {
                this.X--;
            });
        }

        public bool MoveRight(int[,] array)
        {
            return Move(array, 1, 0, () =>
            {
                this.X++;
            });
        }

        public bool MoveUp(int[,] array)
        {
            return Move(array, 0, -1, () =>
            {
                this.Y--;
            });
        }

        public bool MoveDown(int[,] array)
        {
            return Move(array, 0, 1, () =>
            {
                this.Y++;
            });
        }

        #endregion

        #region Helpers

        private bool Move(int[,] array, int x, int y, Action action)
        {
            bool ifMoved = false;
            if (CheckPosition(array, x, y))
            {
                action();
                ifMoved = true;
            }
            return ifMoved;
        }

        public bool CheckPosition(int[,] array, int x, int y)
        {
            return (!(array[this.Y + y, this.X + x] == 1));     
        }

        #endregion
    }
}

