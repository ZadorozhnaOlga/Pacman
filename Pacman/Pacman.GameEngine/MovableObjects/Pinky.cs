using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pacman.GameEngine
{
    public class Pinky : Ghost
    {
        #region Constructor
        public Pinky(int x, int y) 
            : base(x, y) 
        {

        }

        #endregion

        #region Methods
        
        public override void ChooseTarget(Game game, out int targetX, out int targetY) 
        {
            targetX = game.MyPacman.X;
            targetY = game.MyPacman.Y;
            switch (game.MyPacman.Direction) 
            {

                case Direction.Left: 
                    {
                        if (game.MyPacman.X > 4)
                        {
                            targetX = game.MyPacman.X - 4;
                        }
                        else
                        {
                            targetX = game.MyPacman.X;
                        }
                        break;                      
                    }

                case Direction.Right:
                    {
                        if (game.MyPacman.X < game.Map.MyMap.GetLength(1) - 5)
                        {
                            targetX = game.MyPacman.X + 4;
                        }
                        else
                        {
                            targetX = game.MyPacman.X;
                        }
                        break;
                    }

                case Direction.Up:
                    {
                        if (game.MyPacman.Y > 4 && game.MyPacman.X > 4)
                        {
                            targetY = game.MyPacman.Y - 4;
                            targetX = game.MyPacman.X - 4;
                        }
                        else
                        {
                            targetY = game.MyPacman.Y;
                        }
                        break;
                    }

                case Direction.Down:
                    {
                        if (game.MyPacman.Y < game.Map.MyMap.GetLength(0) - 5)
                        {
                            targetY = game.MyPacman.Y + 4;
                        }

                        else
                        {
                            targetY = game.MyPacman.Y;
                        }
                        break;                     
                    }
            }
        }

        #endregion

    }
}
