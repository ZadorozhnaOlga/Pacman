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
        

        public void EatApples(ref Apples app)
        {
            if (app.Dots[Y, X] == 1)
            {
                app.Dots[Y, X] = 0;
                Game.Scores += 1;
                
            }

            
        }

        public bool Move(Game game, Direction direction)
        {
            Apples currentApples = game.Map.GetApples();
            this.direction = direction;
            switch (direction)
            {
                   
                case Direction.Left:
                    {

                        {
                            if (MoveLeft(game.Map.myMap)) 
                            {
                                
                                EatApples(ref currentApples);
                                return true;
                            }
                            
                            else 
                            {
                                return false;
                            }
                        }

                       
                    }

                case Direction.Right:
                    {

                        if (MoveRight(game.Map.myMap)) 
                        {
                           // direction = Direction.Right;
                            EatApples(ref currentApples);
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                       
                    }

                case Direction.Up:
                    {
                        if (MoveUp(game.Map.myMap)) 
                        {
                            //direction = Direction.Up;
                            EatApples(ref currentApples);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        
                    }

                case Direction.Down:
                    {
                       if( MoveDown(game.Map.myMap))
                       {
                          // direction = Direction.L;
                           EatApples(ref currentApples);
                           return true;
                       }
                       else
                       {
                           return false;
                       }
                        
                    }
                default:
                    {
                        // EatApples(ref game.Map.apples);
                        return false;
                    }
                    
                    
            }

        }
        

   

    }
}



        
    

            


        
    

