using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman.GameEngine;

namespace Pacman.ConsoleUI
{
    class Drawing
    {
        public void DrawMap(int[,] array) 
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 1)
                    {
                        Console.Write("+");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }
        }

        public void DrawApples(ref Apples app)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < app.Dots.GetLength(0); i++)
            {
                for (int j = 0; j < app.Dots.GetLength(1); j++)
                {
                    //if (app.Dots[i, j] != true)
                    //{           
                    //    continue;
                    //}
                    //else
                    //{
                        if (app.Dots[i, j] == true)
                        {
                            Console.SetCursorPosition(j, i);
                            Console.Write((char)8729);
                        }
                    //}
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawPacman(Game game) 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(game.myPacman.X, game.myPacman.Y);
            Console.Write((char) 9786);
        }

        public void DrawInky(Game game)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(game.myInky.X, game.myInky.Y);
            Console.Write((char)9786);
        }

        public void DrawPinky(Game game)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(game.myPinky.X, game.myPinky.Y);
            Console.Write((char)9786);       
        }

        public void HidePerson(Player person)
        {   
            Console.SetCursorPosition(person.X, person.Y);
            Console.Write(" ");
            Console.SetCursorPosition(person.X, person.Y);
        }
        
        public void DrawOneApple(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x, y);
            Console.Write((char)8729);
        }

        public void DrawOneApple(Player person, Direction direction)
        {

            switch (direction)
            {
                case Direction.Left:
                    {
                        DrawOneApple(person.X - 1, person.Y);

                        break;
                    }
                case Direction.Right:
                    {
                        DrawOneApple(person.X + 1, person.Y);
                        break;
                    }
                case Direction.Up:
                    {
                        DrawOneApple(person.X, person.Y - 1);
                        break;
                    }
                case Direction.Down:
                    {
                        DrawOneApple(person.X, person.Y + 1);
                        break;
                    }
            }

        }  
    }
}
