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

        public Direction Move(Game game)
        {


            
            int[,] cMap;
            Map.FindWave(game, game.myPacman.X, game.myPacman.Y, out cMap);

            int[] direction = { cMap[Y, X - 1], cMap[Y, X + 1], cMap[Y - 1, X], cMap[this.Y + 1, this.X] };

            Direction k = (Direction) MinValue(direction);
            return MoveOneStep(game, k);
            
        }
    }
}
