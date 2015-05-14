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
        #region Properties & Fields
        public int Lives { get; set; }

        #endregion

        #region Constructor
        public Pacman(int x, int y) 
            : base(x, y)
        {
            this.Lives = 3;
        }

        #endregion

        public event EventHandler PacmanEatApple;

        #region Methods

        public bool Move(Game game, Direction direction)
        {
            this.Direction = direction;

            switch (direction)
            {

                case Direction.Left:
                    {
                        game.MyPacman.Direction = Direction.Left;
                        return CheckedMove(game, MoveAndEatLeft);
                    }

                case Direction.Right:
                    {
                        game.MyPacman.Direction = Direction.Right;
                        return CheckedMove(game, MoveAndEatRight);
                    }

                case Direction.Up:
                    {
                        game.MyPacman.Direction = Direction.Up;
                        return CheckedMove(game, MoveAndEatUp);
                    }

                case Direction.Down:
                    {
                        game.MyPacman.Direction = Direction.Down;
                        return CheckedMove(game, MoveAndEatDown);
                    }

                default: throw new ArgumentException();
            }
        }

#endregion

        #region Helpers
        public bool EatApples(Apples app)
        {
            if (app.Dots[this.Y, this.X])
            {
                Game.Scores += 1;
                app.Dots[this.Y, this.X] = false;
                return true;
            }
            
            return false;
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
            if (game.IfPacmanNotEated())
            {
                return func(game);
            }
            else
            {
                game.MyPacman.EatApples(game.Map.GetApples());
                return false;
            }
        }

        #endregion

    }
}



        
    

            


        
    

