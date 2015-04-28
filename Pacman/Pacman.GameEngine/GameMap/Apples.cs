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
        // Для чого цей лічильник? Він не використовується.
        //private int _count;

        // Дану властивість варто зробити доступною лише для читання.
        public bool[,] Dots { get; private set; }
        #endregion

        #region Constructor
        public Apples(int[,] array)
        {
            // Локальні змінні мають починатися з маленької букви
            int x = array.GetLength(0);
            int y = array.GetLength(1);
            Dots = new bool [x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (array[i, j] == 0)
                    {
                        Dots[i, j] = true;
                        //_count += 1;
                    }
                }
            }
            Dots[26, 13] = false;
        }

        #endregion

        #region Methods

        // Параметри мають починатися з маленької букви
        public bool IfExistApple(int X, int Y) 
        {
            return (Dots[Y, X]);
        }

        #endregion
    }
}

