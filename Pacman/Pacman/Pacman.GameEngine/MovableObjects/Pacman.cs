using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Pacman.GameEngine
{


    public class Pacman : Person
    {
       
        public Pacman(int x, int y)
            : base(x, y)
        {

        }
        

        //public abstract bool Move()
        //{
        //    return false;
        //}

        public void EatApples(ref Apples app)
        {
            if (app.Dots[Y, X] == 1)
            {
                app.Dots[Y, X] = 0;
                Game.Scores += 1;
                
            }

            
        }

        public bool MoveAndEatLeft(Game game) 
        {
            Apples currentApples = game.Map.GetApples();
            if (MoveLeft(game.Map.myMap))
            {
                EatApples(ref currentApples);
                return true;
            }
            else return false;
        }

        public bool MoveAndEatRight(Game game)
        {
            Apples currentApples = game.Map.GetApples();
            if (MoveRight(game.Map.myMap))
            {
                EatApples(ref currentApples);
                return true;
            }
            else return false;
        }

        public bool MoveAndEatUp(Game game)
        {
            Apples currentApples = game.Map.GetApples();
            if (MoveUp(game.Map.myMap))
            {
                EatApples(ref currentApples);
                return true;
            }
            else return false;
        }

        public bool MoveAndEatDown(Game game)
        {
            Apples currentApples = game.Map.GetApples();
            if (MoveDown(game.Map.myMap))
            {
                EatApples(ref currentApples);
                return true;
            }
            else return false;
        }
        //public void LeftMove extends Move()
        //{

        //}



        public bool Move(Game game, Direction direction)
        {
            Apples currentApples = game.Map.GetApples();
            
            this.direction = direction;
            
            switch (direction)
            {
                   
                case Direction.Left:
                    {
                        return MoveAndEatLeft(game);
                        
                       
                    }

                case Direction.Right:
                    {
                        return MoveAndEatRight(game);
                        
                       
                    }

                case Direction.Up:
                    {
                        return MoveAndEatUp(game);
                        
                        
                    }

                case Direction.Down:
                    {
                        return MoveAndEatDown(game);
                       
                        
                    }
                default: throw new ArgumentException();
                   
                   // EatApples(ref currentApples);
            }

           

        }
        

   

    }
}



        
    

            


        
    

