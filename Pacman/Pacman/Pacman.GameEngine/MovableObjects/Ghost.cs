using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;


namespace Pacman.GameEngine
{

    public class Ghost : Player
    {

        #region Constructor
        public Ghost(int x, int y) 
            : base(x, y)
        {
           
        }

        #endregion

        #region Methods
       
        public Direction MoveOneStep(Game game, Direction direction) 
        {
            switch (direction)
            {
                case Direction.Left:
                    {
                       MoveLeft(game.Map.MyMap);
                       return CheckApplesRight(game.Map.GetApples());
                    }

                case Direction.Right: 
                    {
                        MoveRight(game.Map.MyMap);
                        return CheckApplesLeft(game.Map.GetApples());
                    }

                case Direction.Up: 
                    {
                        MoveUp(game.Map.MyMap);
                        return CheckApplesDown(game.Map.GetApples());
                    }

                case Direction.Down: 
                    {
                        MoveDown(game.Map.MyMap);
                        return CheckApplesUp(game.Map.GetApples());
                    }

                default: return Direction.None;            
            }           
        }
       
        public Direction Move(Game game)
        {
            int targetX, targetY;
            ChooseTarget(game, out targetX, out targetY);
            int[,] pathToTarget = game.Map.FindPaths(game, targetX, targetY);
            int[] direction = { pathToTarget[this.Y, this.X - 1], pathToTarget[this.Y, this.X + 1], pathToTarget[this.Y - 1, this.X], pathToTarget[this.Y + 1, this.X] };
            Direction k = (Direction)MinValue(direction);

            return game.IfPacmanNotEated() ? MoveOneStep(game, k) : Direction.None;
        }

        #endregion

        #region Helpers

        public virtual void ChooseTarget(Game game, out int targetX, out int targetY)
        {
            targetX = 0;
            targetY = 0;
        }

        private Direction CheckApplesLeft(Apples app)
        {
            return app.IfExistApple(this.X - 1, this.Y) ? Direction.Left : Direction.None;
        }

        private Direction CheckApplesRight(Apples app)
        {
            return app.IfExistApple(this.X + 1, this.Y) ? Direction.Right : Direction.None;
        }

        private Direction CheckApplesUp(Apples app)
        {
            return app.IfExistApple(this.X, this.Y - 1) ? Direction.Up : Direction.None;
        }

        private Direction CheckApplesDown(Apples app)
        {
            return app.IfExistApple(this.X, this.Y + 1) ? Direction.Down : Direction.None;
        }
       
        private int MinValue(int[] x)
        {
            int[] copyx = (int[])x.Clone();
            Array.Sort(x);
            int lastIndexOfUnreachableCell = Array.LastIndexOf(x, -2) + 1;
            int propperDirection = Array.IndexOf(copyx, x[lastIndexOfUnreachableCell]);
            return propperDirection;
        }

        #endregion
    }   
}
