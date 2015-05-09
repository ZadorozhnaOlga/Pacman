using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pacman.GameEngine
{
    public class Map
    {
        #region Properties & Fields
        public int[,] MyMap { get; set; }
        private Apples _apples;

        #endregion

        #region Constructor
        public Map(int[,] array, int pacmanX, int pacmanY)
        {
            this.MyMap = array;
            this._apples = new Apples(array, pacmanX, pacmanY);
        }

        #endregion

        #region Methods
        public Apples GetApples()
        {
            return this._apples;
        }
    
        public int[,] FindPaths(Game game, int targetX, int targetY)
        {
            int[,] array = game.Map.MyMap;
            int width = array.GetLength(0);
            int heigth = array.GetLength(1);
            int[,] pathToTarget = new int[width, heigth];
            int x, y, step = 0;

            for (y = 0; y < width; y++)
            {
                for (x = 0; x < heigth; x++)
                {
                    pathToTarget[y, x] = (array[y, x] == 1) ? -2 : -1;
                }
            }

            pathToTarget[targetY, targetX] = 0;

            while (step < width * heigth)
            {
                for (y = 0; y < heigth; y++)
                {
                    for (x = 0; x < width; x++)
                    {
                        if (pathToTarget[x, y] == step)
                        {
                            if ((y - 1 >= 0 && x-1>=0 && pathToTarget[x - 1, y] != -2 && pathToTarget[x - 1, y] == -1))
                            {
                                pathToTarget[x - 1, y] = step + 1;
                            }
                            if ((x - 1 >= 0 && y-1>=0 && pathToTarget[x, y - 1] != -2 && pathToTarget[x, y - 1] == -1))
                            {
                                pathToTarget[x, y - 1] = step + 1;
                            }
                            if ((y + 1 < heigth && x + 1 < width && pathToTarget[x + 1, y] != -2 && pathToTarget[x + 1, y] == -1))
                            {
                                pathToTarget[x + 1, y] = step + 1;
                            }

                            if ((x + 1 < width && y + 1 < heigth && pathToTarget[x, y + 1] != -2 && pathToTarget[x, y + 1] == -1))
                            {
                                pathToTarget[x, y + 1] = step + 1;
                            }
                        }
                    }
                }

                step++;
            }

            return pathToTarget;
        }

        #endregion

    }
}
