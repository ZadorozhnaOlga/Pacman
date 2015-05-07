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

        #region Fields


        private static object _sync = new object();

        // Review remark from IP:
        // а чому тут - з великої, а рядком нижче - з малої .....
        private static Drawing Draw = new Drawing();

        private static Game game = new Game();


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

            Apples currentApples = game.Map.GetApples();
            Console.Clear();
            game.Start();
            Draw.DrawMap(game.Map.MyMap);
            Draw.DrawApples(ref currentApples);
            Draw.DrawPacman(game);
            Draw.DrawInky(game);
            Draw.DrawPinky(game);
            WriteScores(35, 0, Game.Scores);
            WriteLives(35, 1, game.myPacman.Lives);

            Direction direction = Direction.Left;

            var inkyTimer = new Timer(300);
            inkyTimer.Elapsed += InkyMove;
            inkyTimer.Start();

            var pinkyTimer = new Timer(400);
            pinkyTimer.Elapsed += PinkyMove;
            pinkyTimer.Start();


            MainCycle(ref key, ref currentApples, ref direction, inkyTimer, pinkyTimer);

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();

        }

        #endregion


        #region Helpers

        private static void MainCycle(ref ConsoleKeyInfo key, ref Apples currentApples, ref Direction direction, Timer inkyTimer, Timer pinkyTimer)
        {

            while (!game.GameOver())
            {
                if (Game.Scores == 325)
                {
                    Console.Clear();
                    Console.WriteLine("Congratulations. You win!");
                    return;
                }

                WriteScores(35, 0, Game.Scores);
                WriteLives(35, 1, game.myPacman.Lives);
                WriteMessage(35, 3, "Press Space to pause");

                if (!game.IfPacmanNotEated())
                {
                    inkyTimer.Stop();
                    pinkyTimer.Stop();

                    game.MinusLive();
                    WriteResume(game);

                    if (!game.GameOver())
                    {
                        Console.Clear();
                        WriteResume(game);

                        while (key.Key != ConsoleKey.Enter)
                        {
                            Console.Clear();
                            WriteResume(game);
                            key = Console.ReadKey();


                            if (key.Key == ConsoleKey.Enter)
                            {
                                DrawLevel(ref currentApples, inkyTimer, pinkyTimer, 13, 12, 14, 12, 13, 26);
                            }
                        }
                    }
                }

                PacmanMove(ref currentApples, Draw, game, ref key, ref direction, inkyTimer, pinkyTimer);
            }
        }

        private static void DrawLevel(ref Apples currentApples, Timer inkyTimer, Timer pinkyTimer,
            int inkyX, int inkyY, int pinkyX, int pinkyY, int pacmanX, int pacmanY)
        {
            Draw.HidePerson(game.myInky);
            game.myInky.X = inkyX;
            game.myInky.Y = inkyY;

            Draw.HidePerson(game.myPinky);
            game.myPinky.X = pinkyX;
            game.myPinky.Y = pinkyY;

            Draw.HidePerson(game.myPacman);
            game.myPacman.X = pacmanX;
            game.myPacman.Y = pacmanY;

            Draw.DrawMap(game.Map.MyMap);
            Draw.DrawApples(ref currentApples);
            Draw.DrawPacman(game);
            Draw.DrawInky(game);
            Draw.DrawPinky(game);

            WriteScores(35, 0, Game.Scores);
            WriteLives(35, 1, game.myPacman.Lives);

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
                        while (key.Key != ConsoleKey.Enter)
                        {
                            Console.Clear();
                            WriteMessage(0, 2, "The game is paused");
                            WriteMessage(0, 3, "Press Enter to continue");
                            key = Console.ReadKey();
                        }

                        if (key.Key == ConsoleKey.Enter)
                        {
                            DrawLevel(ref currentApples, inkyTimer, pinkyTimer, game.myInky.X, game.myInky.Y,
                                game.myPinky.X, game.myPinky.Y, game.myPacman.X, game.myPacman.Y);
                        }

                    }
                    break;

                case ConsoleKey.LeftArrow:
                    {

                        if (game.myPacman.CheckPosition(game.Map.MyMap, -1, 0) & game.IfPacmanNotEated())
                        {
                            DrawPacman(game.myPacman.X, game.myPacman.Y, Direction.Left);
                        }

                    }
                    break;

                case ConsoleKey.RightArrow:
                    {

                        if (game.myPacman.CheckPosition(game.Map.MyMap, 1, 0) & game.IfPacmanNotEated())
                        {
                            DrawPacman(game.myPacman.X, game.myPacman.Y, Direction.Right);
                        }


                    }
                    break;
                case ConsoleKey.UpArrow:
                    {
                        if (game.myPacman.CheckPosition(game.Map.MyMap, 0, -1) & game.IfPacmanNotEated())
                        {
                            DrawPacman(game.myPacman.X, game.myPacman.Y, Direction.Up);
                        }
                    }
                    break;

                case ConsoleKey.DownArrow:
                    {
                        if (game.myPacman.CheckPosition(game.Map.MyMap, 0, 1) & game.IfPacmanNotEated())
                        {
                            DrawPacman(game.myPacman.X, game.myPacman.Y, Direction.Down);
                        }
                    }
                    break;
            }
        }

        private static void InkyMove(Object source, ElapsedEventArgs e)
        {
            lock (_sync)
            {
                Draw.HidePerson(game.myInky);
                Direction InkyEatApple = game.myInky.Move(game);
                Draw.DrawInky(game);
                Draw.DrawOneApple(game.myInky, InkyEatApple);
            }
        }

        private static void PinkyMove(Object source, ElapsedEventArgs e)
        {
            lock (_sync)
            {
                Draw.HidePerson(game.myPinky);
                Direction PinkyEatApple = game.myPinky.Move(game);
                Draw.DrawPinky(game);
                Draw.DrawOneApple(game.myPinky, PinkyEatApple);
            }
        }

        private static void WriteResume(Game game)
        {
            if (!game.GameOver())
            {
                WriteMessage(0, 0, "Oops, you've been eated");
                WriteScores(0, 1, Game.Scores);
                WriteLives(0, 2, game.myPacman.Lives);
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
                Draw.HidePerson(game.myPacman);
                game.myPacman.Move(game, direction);
                Draw.DrawPacman(game);
            }
        }

        #endregion

    }
}

