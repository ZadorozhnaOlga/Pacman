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
        public Ghost(int x, int y) : base(x, y)
        {
           
        }

        #endregion

        #region Methods
        //Вибір цільової клітинки
        public virtual void ChooseTarget(Game game, out int targetX, out int targetY)
        {
            targetX = 0;
            targetY = 0;
        }

        //Рух на одну клітинку
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

        //Рух привида до цільової клітинки
        public Direction Move(Game game)
        {
            int targetX, targetY;
            this.ChooseTarget(game, out targetX, out targetY);
            int[,] cMap = game.Map.FindPaths(game, targetX, targetY);
            int[] direction = { cMap[this.Y, this.X - 1], cMap[this.Y, this.X + 1], cMap[this.Y - 1, this.X], cMap[this.Y + 1, this.X] };
            Direction k = (Direction)MinValue(direction);
            if (!(game.myInky.X == game.myPacman.X & game.myInky.Y == game.myPacman.Y) &
                !(game.myPinky.X == game.myPacman.X & game.myPinky.Y == game.myPacman.Y))
            {
                return MoveOneStep(game, k);
            }
            else
            {
                return Direction.None;
            }

        }

        #endregion

        #region Helpers
        //Перевірка того, чи зліва від привида є їжа
        public bool CheckApplesLeft(ref Apples app)
        {
            return app.IfExistApple(this.X - 1, this.Y);
        }

        //Перевірка того, чи справа від привида є їжа
        public bool CheckApplesRight(ref Apples app)
        {
            return app.IfExistApple(this.X + 1, this.Y);
        }

        //Перевірка того, чи зверху від привида є їжа
        public bool CheckApplesUp(ref Apples app)
        {
            return app.IfExistApple(this.X, this.Y - 1);
        }

        //Перевірка того, чи знизу від привида є їжа
        public bool CheckApplesDown(ref Apples app)
        {
            return app.IfExistApple(this.X, this.Y + 1);
        }

        //Пошук клітинки з найменшою "вагою" (для алгоритму пошуку оптимального шляху)
        public int MinValue(int[] x)
        {
            int[] copyx = (int[])x.Clone();
            Array.Sort(x);
            int k = Array.LastIndexOf(x, -2) + 1;
            int c = Array.IndexOf(copyx, x[k]);
            return c;
        }

        #endregion
    }   
}
