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
        public int[,] myMap {get; set; }
        public Apples apples { get; set; }

        public Map() 
        {

        }

        public Map(int[,] array)
        {
            this.myMap = array;
            apples = new Apples(array);
        }

        public Apples GetApples() 
        {
            return apples;
        }

       


        public static void FindWave(Game game, int targetX, int targetY, out int[,] cMap)
        {
            //int[,] array = Game.LoadMap(@"../../Map\Map.txt", 28, 32);
            int[,] array = game.Map.myMap;
            bool add = true;
            cMap = new int[array.GetLength(0), array.GetLength(1)];
            int x, y, step = 0;
            for (y = 0; y < array.GetLength(0); y++)
                for (x = 0; x < array.GetLength(1); x++)
                {
                    if (array[y, x] == 1)
                        cMap[y, x] = -2;
                    else
                        cMap[y, x] = -1;
                }
            cMap[targetY, targetX] = 0;
            while (step < array.GetLength(0) * array.GetLength(1))
            {
                add = false;
                for (y = 0; y < array.GetLength(1); y++)
                    for (x = 0; x < array.GetLength(0); x++)
                    {
                        if (cMap[x, y] == step)
                        {

                            if (y - 1 >= 0  && cMap[x - 1, y] != -2 && cMap[x - 1, y] == -1)
                                cMap[x - 1, y] = step + 1;
                            if (x - 1 >= 0 && cMap[x, y - 1] != -2 && cMap[x, y - 1] == -1)
                                cMap[x, y - 1] = step + 1;
                            if (y + 1 < array.GetLength(1) && cMap[x + 1, y] != -2 && cMap[x + 1, y] == -1)
                                cMap[x + 1, y] = step + 1;
                            if (x + 1 < array.GetLength(0) && cMap[x, y + 1] != -2 && cMap[x, y + 1] == -1)
                                cMap[x, y + 1] = step + 1;
                        }
                    }
                step++;
                add = true;

            }

        }
       
    }

        

        

        
        
        
    
}
