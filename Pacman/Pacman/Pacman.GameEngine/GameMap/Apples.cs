using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GameEngine
{
    

    public class Apples 
    {
        public int Count { get; set; }
        public int[,] Dots; 
        
        public Apples(int[,] array)
        {
            int X = array.GetLength(0);
            int Y = array.GetLength(1);
            Dots = new int[X, Y];
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    if (array[i, j] == 0)
                    {
                        Dots[i, j] = 1;
                        Count += 1;
                    }
                }
            }
        }


        public bool IfExistApple(int X, int Y) 
        {
            if (Dots[Y, X] == 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

    }

}

