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
        #region Properties
        public int Lives { get; set; }

        #endregion

        #region Constructor
        public Pacman(int x, int y) 
            : base(x, y)
        {
            // Магічне число)
            this.Lives = 3;
        }

        #endregion
       
        #region Methods

        public bool Move(Game game, Direction direction)
        {
            this.Direction = direction;
            bool ifMoved = false;
            switch (direction)
            {
                case Direction.Left:
                    {
                        game.MyPacman.Direction = Direction.Left;
                        ifMoved = CheckedMove(game, MoveAndEatLeft);
                    }
                    break;

                case Direction.Right:
                    {
                        game.MyPacman.Direction = Direction.Right;
                        ifMoved = CheckedMove(game, MoveAndEatRight);
                    }
                    break;

                case Direction.Up:
                    {
                        game.MyPacman.Direction = Direction.Up;
                        ifMoved = CheckedMove(game, MoveAndEatUp);
                    }
                    break;

                case Direction.Down:
                    {
                        game.MyPacman.Direction = Direction.Down;
                        ifMoved = CheckedMove(game, MoveAndEatDown);
                    }
                    break;
            }

            return ifMoved;
        }

#endregion

        #region Helpers
        public bool EatApples(Apples app)
        {
            bool ifEat = false;
            if (app.Dots[this.Y, this.X])
            {
                Game.Scores += 1;
                app.Dots[this.Y, this.X] = false;
                ifEat = true;
            }
            
            return ifEat;
        }

        private bool MoveAndEatLeft(Game game)
        {
            return (MoveLeft(game.Map.MyMap)) ? EatApples(game.Map.GetApples()) : false;
        }

        private bool MoveAndEatRight(Game game)
        {
            return (MoveRight(game.Map.MyMap)) ? EatApples(game.Map.GetApples()) : false;
        }

        private bool MoveAndEatUp(Game game)
        {
            return (MoveUp(game.Map.MyMap)) ? EatApples(game.Map.GetApples()) : false;
        }

        private bool MoveAndEatDown(Game game)
        {
            return (MoveDown(game.Map.MyMap)) ? EatApples(game.Map.GetApples()) : false;
        }
     
        private bool CheckedMove(Game game, Func<Game, bool> func)
        {
            bool result = false;
            if (game.IfPacmanNotEated())
            {
                result = func(game);
            }
            else
            {
                game.MyPacman.EatApples(game.Map.GetApples());
            }

            return result;
        }

#endregion

    }
}



        
    

            


        
    

