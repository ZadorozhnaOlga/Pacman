using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GameEngine
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down,
        None
    }

    public enum GameStatus
    {
        ReadyToStart,
        InProgress,
        Completed
    }
}
