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
        public Pinky(int x, int y) : base(x, y) 
        {

        }

        #endregion

        #region Methods
        
        public override void ChooseTarget(Game game, out int targetX, out int targetY) 
        {
            targetX = game.myPacman.X;
            targetY = game.myPacman.Y;
            switch (game.myPacman.Direction) 
            {
                case Direction.Left: 
                    {
                        if (game.myPacman.X > 4)
                        {
                            targetX = game.myPacman.X - 4;
                        }
                        else
                        {
                            targetX = game.myPacman.X;
                        }
                        break;                      
                    }

                case Direction.Right:
                    {
                        if (game.myPacman.X < game.Map.MyMap.GetLength(1) - 5)
                        {
                            targetX = game.myPacman.X + 4;
                        }
                        else
                        {
                            targetX = game.myPacman.X;
                        }
                        break;
                    }

                case Direction.Up:
                    {
                        if (game.myPacman.Y > 4 && game.myPacman.X > 4)
                        {
                            targetY = game.myPacman.Y - 4;
                            targetX = game.myPacman.X - 4;
                        }
                        else
                        {
                            targetY = game.myPacman.Y;
                        }
                        break;
                    }

                case Direction.Down:
                    {
                        if (game.myPacman.Y < game.Map.MyMap.GetLength(0) - 5)
                        {
                            targetY = game.myPacman.Y + 4;
                        }

                        else
                        {
                            targetY = game.myPacman.Y;
                        }
                        break;                     
                    }
            }
        }

        #endregion

    }
}
