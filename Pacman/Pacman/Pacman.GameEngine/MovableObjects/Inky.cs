using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GameEngine
{
    public class Inky : Ghost
    {

        #region Constructor
        public Inky(int x, int y) : base(x, y)
        {
        }

        #endregion

        #region Methods
        //вибір цільової клітинки
        public override void ChooseTarget(Game game, out int targetX, out int targetY) 
        {
            targetX = game.myPacman.X;
            targetY = game.myPacman.Y;
        }

        #endregion
    }
}
