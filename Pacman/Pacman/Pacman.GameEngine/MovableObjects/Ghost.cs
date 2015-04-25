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
                    return CheckApplesRight(ref currentApples);

                case Direction.Right:
                    MoveRight(game.Map.myMap);
                    return CheckApplesLeft(ref currentApples);
                    

                case Direction.Up:
                    MoveUp(game.Map.myMap);
                    return CheckApplesDown(ref currentApples);


                case Direction.Down:
                    MoveDown(game.Map.myMap);
                   return CheckApplesUp(ref currentApples);
                   

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
            if (game.IfPacmanNotEated())
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
        public Direction CheckApplesLeft(ref Apples app)
        {
            if (app.IfExistApple(this.X - 1, this.Y))
            {
                return Direction.Left;
            }
            else 
            {
                return Direction.None;
            }
        }

        //Перевірка того, чи справа від привида є їжа
        public Direction CheckApplesRight(ref Apples app)
        {
            if (app.IfExistApple(this.X + 1, this.Y))
            {
                return Direction.Right;
            }
            else
            {
                return Direction.None;
            }
        }

        //Перевірка того, чи зверху від привида є їжа
        public Direction CheckApplesUp(ref Apples app)
        {
            if (app.IfExistApple(this.X, this.Y - 1))
            {
                return Direction.Up;
            }
            else
            {
                return Direction.None;
            }
        }

        //Перевірка того, чи знизу від привида є їжа
        public Direction CheckApplesDown(ref Apples app)
        {
            if (app.IfExistApple(this.X, this.Y + 1))
            {
                return Direction.Down;
            }
            else
            {
                return Direction.None;
            }

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
