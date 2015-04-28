﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// // Коректний в даному випадку namespace буде Pacman.GameEngine.Interfaces
namespace Pacman.GameEngine
{
    interface IPlayer
    {
        bool MoveLeft(int[,] array);
        bool MoveRight(int[,] array);
        bool MoveUp(int[,] array);
        bool MoveDown(int[,] array);    
    }
}
