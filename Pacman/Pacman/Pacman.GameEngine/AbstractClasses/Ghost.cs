using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;


namespace Pacman.GameEngine
{

    public class Ghost : Person
    {

        public Ghost(int x, int y) : base(x, y)
        {
           
        }


        public bool CheckApplesLeft(ref Apples app)
        {
            return app.IfExistApple(X - 1, Y);
            
            
        }
        public bool CheckApplesRight(ref Apples app)
        {
            return app.IfExistApple(X + 1, Y);

            
        }
        public bool CheckApplesUp(ref Apples app)
        {
            return app.IfExistApple(X, Y - 1);
            
        }
        public bool CheckApplesDown(ref Apples app)
        {
            return app.IfExistApple(X, Y + 1);
            
        }



        public static int MinValue(int[] x)
        {
            int [] copyx = (int []) x.Clone();
            Array.Sort(x);

            int k = Array.LastIndexOf(x, -2) + 1;
            int c = Array.IndexOf(copyx, x[k]);
            return c;
           
        }

        public virtual void ChooseTarget(Game game, out int targetX, out int targetY)
        {
            targetX = 0;
            targetY = 0;
        }

        public Direction MoveOneStep(Game game, Direction direction) 
        {
            Apples currentApples = game.Map.GetApples();
            switch (direction)
            {
                case Direction.Left:
                    MoveLeft(game.Map.myMap);
                    if (CheckApplesRight(ref currentApples))
                    {
                        return Direction.Right;
                    }
                    else
                    {
                        return Direction.None;
                    }

                case Direction.Right:
                    MoveRight(game.Map.myMap);

                    if (CheckApplesLeft(ref currentApples))
                    {
                        return Direction.Left;
                    }
                    else
                    {
                        return Direction.None;
                    }


                case Direction.Up:
                    MoveUp(game.Map.myMap);
                    if (CheckApplesDown(ref currentApples))
                    {
                        return Direction.Down;
                    }
                    else
                    {
                        return Direction.None;
                    }


                case Direction.Down:
                    MoveDown(game.Map.myMap);
                    if (CheckApplesUp(ref currentApples))
                    {
                        return Direction.Up;
                    }
                    else
                    {
                        return Direction.None;
                    }
                default: return Direction.None;
            }
        }


        public Direction Move(Game game)
        {

            int targetX, targetY;

            this.ChooseTarget(game, out targetX, out targetY);

            int[,] cMap = game.Map.FindPaths(game, targetX, targetY);

            int[] direction = { cMap[Y, X - 1], cMap[Y, X + 1], cMap[Y - 1, X], cMap[this.Y + 1, this.X] };

            Direction k = (Direction)MinValue(direction);
            if (!game.GameOver())
            {
                return MoveOneStep(game, k);
            }
            else
            {
                return Direction.None;
            }

        }
    }
       
    
}
