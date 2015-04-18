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

        public void DrawApples(int[,] array)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] != 0)
                    {           
                        continue;
                    }
                    else
                    {
                        if (array[i, j] == 0)
                        {
                            Console.SetCursorPosition(j, i);
                            Console.Write((char)8729);
                        }
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawPacman(Game game) 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(game.myPacman.X, game.myPacman.Y);
            Console.Write((char) 9786);
            Console.SetCursorPosition(game.myPacman.X, game.myPacman.Y); 
        }

        public void DrawInky(Game game)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(game.myInky.X, game.myInky.Y);
            Console.Write((char)9786);
            //Console.SetCursorPosition(game.myInky.X, game.myInky.Y);
        }

        public void DrawPinky(Game game)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(game.myPinky.X, game.myPinky.Y);
            Console.Write((char)9786);
           // Console.SetCursorPosition(game.myInky.X, game.myInky.Y);
        }

        public void HidePerson(Person person)
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
           // Console.SetCursorPosition(game.myPacman.X, game.myPacman.Y);
        }

        
    
    }
}
