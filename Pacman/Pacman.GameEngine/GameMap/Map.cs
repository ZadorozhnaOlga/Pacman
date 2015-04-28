using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Коректний в даному випадку namespace буде Pacman.GameEngine.GameMap
namespace Pacman.GameEngine
{
    public class Map
    {
        #region Properties & Fields
        // Дану властивість варто зробити доступною лише для читання.
        public int[,] MyMap { get; private set; }
        private Apples _apples;

        #endregion

        #region Constructor
        public Map(int[,] array)
        {
            this.MyMap = array;
            this._apples = new Apples(array);
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
            // Локальні змінні - з маленької букви
            int Width = array.GetLength(0);
            int Heigth = array.GetLength(1);
            int[,] cMap = new int[Width, Heigth];
            int x, y, step = 0;

            for (y = 0; y < Width; y++)
            {
                for (x = 0; x < Heigth; x++)
                {
                    if (array[y, x] == 1)
                    {
                        cMap[y, x] = -2;
                    }
                    else
                    {
                        cMap[y, x] = -1;
                    }
                }
            }

            cMap[targetY, targetX] = 0;

            while (step < Width * Heigth)
            {
                for (y = 0; y < Heigth; y++)
                {
                    for (x = 0; x < Width; x++)
                    {
                        if (cMap[x, y] == step)
                        {
                            if ((y - 1 >= 0 && x-1>=0 && cMap[x - 1, y] != -2 && cMap[x - 1, y] == -1))
                            {
                                cMap[x - 1, y] = step + 1;
                            }
                            if ((x - 1 >= 0 && y-1>=0 && cMap[x, y - 1] != -2 && cMap[x, y - 1] == -1))
                            {
                                cMap[x, y - 1] = step + 1;
                            }
                            if ((y + 1 < Heigth && x + 1 < Width && cMap[x + 1, y] != -2 && cMap[x + 1, y] == -1))
                            {
                                cMap[x + 1, y] = step + 1;
                            }

                            if ((x + 1 < Width && y + 1 < Heigth && cMap[x, y + 1] != -2 && cMap[x, y + 1] == -1))
                            {
                                cMap[x, y + 1] = step + 1;
                            }
                        }
                    }
                }

                step++;
            }

            return cMap;
        }

        #endregion

    }
}
