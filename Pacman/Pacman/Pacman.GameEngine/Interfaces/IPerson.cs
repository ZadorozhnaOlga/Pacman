using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GameEngine
{
    interface IPerson
    {
        bool MoveLeft(int[,] array);
        bool MoveRight(int[,] array);
        bool MoveUp(int[,] array);
        bool MoveDown(int[,] array);

        

        
    }
}
