using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;
using Pacman.GameEngine;
using System.IO;
using System.Configuration;


namespace Pacman.ConsoleUI
{
    class Program
    {

        #region Fields
        
        private static object _sync;
        private static Drawing _draw;
        private static Game _game;

        #endregion


        #region Constructor

        static Program() 
        {
            _sync = new object();
            _draw = new Drawing();

            var mapPath = ConfigurationManager.AppSettings["MapPath"];
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            string path = string.Concat(projectPath, mapPath);

            var width = Int32.Parse(ConfigurationManager.AppSettings["Width"]);
            var heigth = Int32.Parse(ConfigurationManager.AppSettings["Heigth"]);
            int pacmanX = Int32.Parse(ConfigurationManager.AppSettings["PacmanX"]);
            int pacmanY = Int32.Parse(ConfigurationManager.AppSettings["PacmanY"]);
            int inkyX = Int32.Parse(ConfigurationManager.AppSettings["InkyX"]);
            int inkyY = Int32.Parse(ConfigurationManager.AppSettings["InkyY"]);
            int pinkyX = Int32.Parse(ConfigurationManager.AppSettings["PinkyX"]);
            int pinkyY = Int32.Parse(ConfigurationManager.AppSettings["PinkyY"]);

            int[,] array = Game.LoadMap(path, width, heigth);

            _game = new Game(width, heigth, array, pacmanX, pacmanY, inkyX, inkyY, pinkyX, pinkyY);
        }

        #endregion


        #region Main

        static void Main(string[] args)
        {         
            Console.CursorVisible = false;
            WriteMessage(35, 0, "Press Enter to start the game");

            ConsoleKeyInfo key = Console.ReadKey();
            
            while (key.Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                WriteMessage(35, 0, "Press Enter to start the game");
                key = Console.ReadKey();
            }

            Apples currentApples = _game.Map.GetApples();
            Console.Clear();
            _game.Start();
            _draw.DrawMap(_game.Map.MyMap);
            _draw.DrawApples(currentApples);
            _draw.DrawPacman(_game);
            _draw.DrawInky(_game);
            _draw.DrawPinky(_game);
            WriteScores(35, 0, Game.Scores);
            WriteLives(35, 1, _game.MyPacman.Lives);

            Direction direction = Direction.Left;

            var inkyTimer = new Timer(300);
            inkyTimer.Elapsed += InkyMove;
            inkyTimer.Start();

            var pinkyTimer = new Timer(400);
            pinkyTimer.Elapsed += PinkyMove;
            pinkyTimer.Start();

            MainCycle(ref key, currentApples, direction, inkyTimer, pinkyTimer);

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();        
        }

        #endregion


        #region Helpers

        private static void MainCycle(ref ConsoleKeyInfo key, Apples currentApples, Direction direction, Timer inkyTimer, Timer pinkyTimer)
        {
            while (!_game.GameOver())
            {
                if (Game.Scores == 325)
                {
                    inkyTimer.Stop();
                    pinkyTimer.Stop();
                    Console.Clear();
                    Console.WriteLine("Congratulations. You win!");
                    return;
                } 

                WriteScores(35, 0, Game.Scores);
                WriteLives(35, 1, _game.MyPacman.Lives);
                WriteMessage(35, 3, "Press Space to pause");

                if (!_game.IfPacmanNotEated())
                {
                    inkyTimer.Stop();
                    pinkyTimer.Stop();

                    _game.MinusLive();
                    WriteResume(_game);

                    if (!_game.GameOver())
                    {
                        Console.Clear();
                        WriteResume(_game);

                        while (key.Key != ConsoleKey.Enter)
                        {
                            Console.Clear();
                            WriteResume(_game);
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Enter)
                            {
                                DrawLevel(currentApples, inkyTimer, pinkyTimer, 13, 12, 14, 12, 13, 26);
                            }                
                        }
                    }
                }

                PacmanMove(ref currentApples, _draw, _game, ref key, ref direction, inkyTimer, pinkyTimer);                             
            }
        }

        private static void DrawLevel(Apples currentApples, Timer inkyTimer, Timer pinkyTimer,
            int inkyX, int inkyY, int pinkyX, int pinkyY, int pacmanX, int pacmanY)
        {
            _draw.HidePerson(_game.MyInky);
            _game.MyInky.X = inkyX;
            _game.MyInky.Y = inkyY;

            _draw.HidePerson(_game.MyPinky);
            _game.MyPinky.X = pinkyX;
            _game.MyPinky.Y = pinkyY;

            _draw.HidePerson(_game.MyPacman);
            _game.MyPacman.X = pacmanX;
            _game.MyPacman.Y = pacmanY;

            _draw.DrawMap(_game.Map.MyMap);
            _draw.DrawApples(currentApples);
            _draw.DrawPacman(_game);
            _draw.DrawInky(_game);
            _draw.DrawPinky(_game);

            WriteScores(35, 0, Game.Scores);
            WriteLives(35, 1, _game.MyPacman.Lives);

            inkyTimer.Start();
            pinkyTimer.Start();
          
        }

        private static void PacmanMove(ref Apples currentApples, Drawing Draw, Game game, ref ConsoleKeyInfo key, ref Direction direction, Timer inkyTimer, Timer pinkyTimer)
        {
            key = Console.ReadKey(true);
            switch (key.Key)
            {

                case ConsoleKey.Spacebar: 
                    {
                        
                        inkyTimer.Stop();
                        pinkyTimer.Stop();
                        Console.Clear();
                        WriteMessage(0, 2, "The game is paused");
                        WriteMessage(0, 3, "Press Enter to continue");
                        ConsoleKeyInfo key1 = new ConsoleKeyInfo();
                        while (key1.Key != ConsoleKey.Spacebar)
                        {
                            Console.Clear();
                            WriteMessage(0, 2, "The game is paused");
                            WriteMessage(0, 3, "Press Space to continue");
                            key1 = Console.ReadKey();
                        }

                        if (key.Key == ConsoleKey.Spacebar)
                        {
                            DrawLevel(currentApples, inkyTimer, pinkyTimer, game.MyInky.X, game.MyInky.Y,
                                game.MyPinky.X, game.MyPinky.Y, game.MyPacman.X, game.MyPacman.Y);
                        }
                        
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    {

                        if (game.MyPacman.CheckPosition(game.Map.MyMap, -1, 0) & game.IfPacmanNotEated())
                        {
                            DrawPacman(game.MyPacman.X, game.MyPacman.Y, Direction.Left);
                        }

                    }
                    break;

                case ConsoleKey.RightArrow:
                    {

                        if (game.MyPacman.CheckPosition(game.Map.MyMap, 1, 0) & game.IfPacmanNotEated())
                        {
                            DrawPacman(game.MyPacman.X, game.MyPacman.Y, Direction.Right);
                        }


                    }
                    break;
                case ConsoleKey.UpArrow:
                    {
                        if (game.MyPacman.CheckPosition(game.Map.MyMap, 0, -1) & game.IfPacmanNotEated())
                        {
                            DrawPacman(game.MyPacman.X, game.MyPacman.Y, Direction.Up);
                        }
                    }
                    break;

                case ConsoleKey.DownArrow:
                    {
                        if (game.MyPacman.CheckPosition(game.Map.MyMap, 0, 1) & game.IfPacmanNotEated())
                        {
                            DrawPacman(game.MyPacman.X, game.MyPacman.Y, Direction.Down);
                        }
                    }
                    break;
            }
        }

        private static void InkyMove(Object source, ElapsedEventArgs e)
        {
            lock (_sync)
            {
                _draw.HidePerson(_game.MyInky);
                Direction InkyEatApple = _game.MyInky.Move(_game);
                _draw.DrawInky(_game);
                _draw.DrawOneApple(_game.MyInky, InkyEatApple);
            }
        }

        private static void PinkyMove(Object source, ElapsedEventArgs e)
        {
            lock (_sync)
            {
                _draw.HidePerson(_game.MyPinky);
                Direction PinkyEatApple = _game.MyPinky.Move(_game);
                _draw.DrawPinky(_game);
                _draw.DrawOneApple(_game.MyPinky, PinkyEatApple);
            }
        }

        private static void WriteResume(Game game)
        {
            if (!game.GameOver())
            {
                WriteMessage(0, 0, "Oops, you've been eated");
                WriteScores(0, 1, Game.Scores);
                WriteLives(0, 2, game.MyPacman.Lives);
                WriteMessage(0, 3, "Press Enter to continue");              
            }

            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unfortutatelly, you loose");
                Console.WriteLine("Your Scores: {0}", Game.Scores);
            }
        }

        private static void WriteMessage(int x, int y, string message)
        {
            lock (_sync)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(message);
            }
        }

        private static void WriteScores(int x, int y, int scores)
        {
            lock (_sync)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Scores: {0}", scores);
            }
        }

        private static void WriteLives(int x, int y, int lives)
        {
            lock (_sync)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Lives: {0}", lives);
            }
        }

        private static void DrawPacman(int x, int y, Direction direction)
        {
            lock (_sync)
            {
                _draw.HidePerson(_game.MyPacman);
                _game.MyPacman.Move(_game, direction);
                _draw.DrawPacman(_game);
            }
        }

        #endregion

    }  
}

