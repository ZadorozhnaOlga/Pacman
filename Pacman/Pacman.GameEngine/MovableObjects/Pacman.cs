using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Pacman.GameEngine
{


    public class Pacman : Player
    {
        #region Properties&Fields
        public int Lives { get; set; }

        #endregion

        #region Constructor
        public Pacman(int x, int y) : base(x, y)
        {
            this.Lives = 3;
        }

        #endregion

        #region Methods

        public bool Move(Game game, Direction direction)
        {
            Apples currentApples = game.Map.GetApples();

            this.Direction = direction;

            switch (direction)
            {

                case Direction.Left:
                    {
                        game.myPacman.Direction = Direction.Left;
                        return CheckedMove(game, MoveAndEatLeft);
                    }

                case Direction.Right:
                    {
                        game.myPacman.Direction = Direction.Right;
                        return CheckedMove(game, MoveAndEatRight);
                    }

                case Direction.Up:
                    {
                        game.myPacman.Direction = Direction.Up;
                        return CheckedMove(game, MoveAndEatUp);
                    }

                case Direction.Down:
                    {
                        game.myPacman.Direction = Direction.Down;
                        return CheckedMove(game, MoveAndEatDown);
                    }

                default: throw new ArgumentException();
            }
        }

#endregion

        #region Helpers
        // для чого тут ref?
        private void EatApples(ref Apples app)
        {
            if (app.Dots[this.Y, this.X])
            {
                app.Dots[this.Y, this.X] = false;
                Game.Scores += 1;   
            }           
        }
        
        private bool MoveAndEatLeft(Game game) 
        {
            Apples currentApples = game.Map.GetApples();
            if (MoveLeft(game.Map.MyMap))
            {
                EatApples(ref currentApples);
                return true;
            }
            else
            {
                return false;
            } 
        }

        private bool MoveAndEatRight(Game game)
        {
            Apples currentApples = game.Map.GetApples();
            if (MoveRight(game.Map.MyMap))
            {
                EatApples(ref currentApples);
                return true;
            }
            else return false;
        }

        private bool MoveAndEatUp(Game game)
        {
            Apples currentApples = game.Map.GetApples();
            if (MoveUp(game.Map.MyMap))
            {
                EatApples(ref currentApples);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool MoveAndEatDown(Game game)
        {
            Apples currentApples = game.Map.GetApples();
            if (MoveDown(game.Map.MyMap))
            {
                EatApples(ref currentApples);
                return true;
            }
            else
            {
                return false;
            }
        }
     
        private bool CheckedMove(Game game, Func<Game, bool> func)
        {
            Apples currentApples = game.Map.GetApples();
            if (game.IfPacmanNotEated())
            {
                return func(game);
            }
            else
            {
                game.myPacman.EatApples(ref currentApples);
                return false;
            }
        }

        #endregion

    }
}



        
    

            


        
    

