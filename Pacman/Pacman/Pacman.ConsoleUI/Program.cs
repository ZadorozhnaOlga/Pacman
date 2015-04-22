using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;
using Pacman.GameEngine;
using System.IO;

namespace Pacman.ConsoleUI
{

  
    class Program
    {
     public static void DrawOneApple(Person person, Direction direction)
     {
         Drawing Draw = new Drawing();
         switch (direction)
         {
             case Direction.Left:
                 {
                     Draw.DrawOneApple(person.X - 1, person.Y);
                     
                     break;
                 }
             case Direction.Right:
                 {
                     Draw.DrawOneApple(person.X + 1, person.Y);
                     break;
                 }
             case Direction.Up:
                 {
                     Draw.DrawOneApple(person.X, person.Y - 1);
                     break;
                 }
             case Direction.Down:
                 {
                     Draw.DrawOneApple(person.X, person.Y + 1);
                     break;
                 }
         }
       
     }  
        
        static void Main(string[] args)
     {
         //Console.SetCursorPosition(35, 0);


            
         //Console.Write("Press ENTER to start the game");
            Drawing Draw = new Drawing();

            


           // Draw.DrawMap(result);













         Console.CursorVisible = false;
         Game game = new Game();
          
         ConsoleKeyInfo key0 = Console.ReadKey();
         if (key0.Key == ConsoleKey.Enter)
         {
             Console.Clear();
             game.Start();
             //Console.SetCursorPosition(35, 0);
             //Console.WriteLine("The game has been started");
             Draw.DrawMap(game.Map.myMap);
             Draw.DrawApples(game.Map.myMap);
             Draw.DrawPacman(game);
             Draw.DrawInky(game);
             Draw.DrawPinky(game);
         }






         ConsoleKeyInfo key = new ConsoleKeyInfo();
         Direction direction = Direction.Left;

         while (!game.GameOver())
         {



             key = Console.ReadKey(true);
             switch (key.Key)
             {
                 case ConsoleKey.LeftArrow:
                     {

                         if (game.myPacman.CheckPosition(game.Map.myMap, -1, 0))
                         {
                             direction = Direction.Left;
                             Draw.HidePerson(game.myPacman);
                             game.myPacman.Move(game, direction);

                             Draw.DrawPacman(game);
                         }

                     }
                     break;

                 case ConsoleKey.RightArrow:
                     {

                         if (game.myPacman.CheckPosition(game.Map.myMap, 1, 0))
                         {
                             direction = Direction.Right;
                             Draw.HidePerson(game.myPacman);
                             game.myPacman.Move(game, direction);
                             Draw.DrawPacman(game);
                         }


                     }
                     break;
                 case ConsoleKey.UpArrow:
                     {
                         if (game.myPacman.CheckPosition(game.Map.myMap, 0, -1))
                         {
                             direction = Direction.Up;
                             Draw.HidePerson(game.myPacman);
                             game.myPacman.Move(game, direction);
                             Draw.DrawPacman(game);
                         }
                     }
                     break;

                 case ConsoleKey.DownArrow:
                     {
                         if (game.myPacman.CheckPosition(game.Map.myMap, 0, 1))
                         {
                             direction = Direction.Down;
                             Draw.HidePerson(game.myPacman);
                             game.myPacman.Move(game, direction);
                             Draw.DrawPacman(game);
                         }
                     }
                     break;
             }



             Console.SetCursorPosition(35, 0);
             Console.Write(Game.Scores);

             Draw.HidePerson(game.myInky);
             Direction InkyEatApple = game.myInky.Move(game);
             Draw.DrawInky(game);
             DrawOneApple(game.myInky, InkyEatApple);

             Draw.HidePerson(game.myPinky);
             Direction PinkyEatApple = game.myPinky.Move(game);
             Draw.DrawPinky(game);
             DrawOneApple(game.myPinky, PinkyEatApple);


         }


         Console.ReadLine();


     }
    }
}

