using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GameEngine
{
    

    public class Apples
    {
        #region Properties
        public bool[,] Dots { get; set; }

        #endregion

        #region Constructor
        public Apples(int[,] array, int pacmanX, int pacmanY)
        {
            int x = array.GetLength(0);
            int y = array.GetLength(1);
            Dots = new bool[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (array[i, j] == 0)
                    {
                        Dots[i, j] = true;                     
                    }
                }            
            }
            Dots[pacmanY, pacmanX] = false;
        }

        #endregion

        #region Methods
        public bool IfExistApple(int x, int y) 
        {
           return (this.Dots[y, x]);
        }

        #endregion
    }

}

