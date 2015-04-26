using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GameEngine
{
    public class Apples
    {

        #region Properties & Fields
        private int _count;
        public bool[,] Dots { get; set; }
        #endregion

        #region Constructor
        public Apples(int[,] array)
        {
            int X = array.GetLength(0);
            int Y = array.GetLength(1);
            Dots = new bool [X, Y];
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    if (array[i, j] == 0)
                    {
                        Dots[i, j] = true;
                        _count += 1;
                    }
                }
            }
            Dots[26, 13] = false;
        }

        #endregion

        #region Methods
        
        public bool IfExistApple(int X, int Y) 
        {
            return (Dots[Y, X]);
        }

        #endregion
    }
}

