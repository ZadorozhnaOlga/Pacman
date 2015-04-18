using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pacman.GameEngine
{
    public class Pinky : Ghost
    {
        public Pinky(int x, int y) : base(x, y) 
        {

        }

        public void ChooseTarget(Game game, out int targetX, out int targetY) 
        {
            targetX = game.myPacman.X;
            targetY = game.myPacman.Y;
            switch (game.myPacman.direction) 
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
                        if (game.myPacman.X < game.Map.myMap.GetLength(1) - 5)
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
                        if (game.myPacman.Y < game.Map.myMap.GetLength(0) - 5)
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
        
        

        public Direction Move(Game game)
        {

            int targetX, targetY;
            
            int[,] cMap;
            ChooseTarget(game, out targetX, out targetY);
                       
            Map.FindWave(game, targetX, targetY, out cMap);

            int[] direction = { cMap[Y, X - 1], cMap[Y, X + 1], cMap[Y - 1, X], cMap[this.Y + 1, this.X] };

           Direction k = (Direction) MinValue(direction);
            return MoveOneStep(game, k);
        }


    }
}
