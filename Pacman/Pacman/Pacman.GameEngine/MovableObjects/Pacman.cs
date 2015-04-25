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
        public int lives { get; set; }

        #region Constructor
        public Pacman(int x, int y) : base(x, y)
        {
            this.lives = 3;
        }

        #endregion

        #region Methods
        //Перевірка того, чи на даній позиції Пакман отримав очки
        public void EatApples(ref Apples app)
        {
            if (app.Dots[this.Y, this.X])
            {
                app.Dots[this.Y, this.X] = false;
                Game.Scores += 1;   
            }           
        }

        

        //Рух Пакмана на клітинку вліво
        public bool MoveAndEatLeft(Game game) 
        {
            Apples currentApples = game.Map.GetApples();
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

        //Рух Пакмана на клітинку вправо
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

        //Рух Пакмана на клітинку вгору
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

        //Рух Пакмана на клітинку вниз
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


        //Рух Пакмана на одну клітинку
        public bool Move(Game game, Direction direction)
        {
            Apples currentApples = game.Map.GetApples();
            
            this.direction = direction;

            switch (direction)
            {

                case Direction.Left:
                    {
                        return CheckedMove(game, MoveAndEatLeft);
                    }

                case Direction.Right:
                    {
                       return CheckedMove(game, MoveAndEatRight);
                    }

                case Direction.Up:
                    {
                        return CheckedMove(game, MoveAndEatUp);
                    }

                case Direction.Down:
                    {
                       return CheckedMove(game, MoveAndEatDown);
                    }

                default: throw new ArgumentException();
            }
        }

        private bool CheckedMove(Game game, Func<Game, bool> func)
        {
            if (game.IfPacmanNotEated())
            {
                return func(game);
            }
            else
            {
                //
                game.MinusLive();
                return false;
            }
        }

        #endregion

    }
}



        
    

            


        
    

