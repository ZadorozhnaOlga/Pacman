using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GameEngine
{
    public class Inky : Ghost
    {
        public Inky(int x, int y) : base(x, y)
        {
        }

        public override void ChooseTarget(Game game, out int targetX, out int targetY) 
        {
            targetX = game.myPacman.X;
            targetY = game.myPacman.Y;
        }

      
    }
}
