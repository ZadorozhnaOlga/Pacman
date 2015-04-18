using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;


namespace Pacman.GameEngine
{

    public abstract class Ghost : Person
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
            int k = 0;
            int min = 0;
            if (x[0] != -2)
            {
                min = x[0];
            }
            else if (x[1] != -2)
            {
                min = x[1]; k = 1;
            }
            else if (x[2] != -2)
            {
                min = x[2]; k = 2;
            }
            else
            {
                min = x[3]; k = 3;
            }


            //if (x[0] != -2) { min = x[0]; }
            for (int i = 0; i < x.Length; i++)
            {
                if (min > x[i] && x[i] != -2)
                {
                    min = x[i];
                    k = i;
                }
            }
            return k;
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
       

        
    }
       
    
}
