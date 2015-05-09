using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Pacman.GameEngine;

namespace Pacman.WinForms
{
    static class Program
    {

        private static Game _game = new Game(28, 32, Game.LoadMap(@"../../Map\Map.txt", 28, 32), 13, 26, 13, 12, 14, 12);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameMenu());

            //System.Windows.Forms.Timer inkyTimer = new System.Windows.Forms.Timer();
            //inkyTimer.Interval = 300;
            //inkyTimer.Tick += InkyMove; ;
            //inkyTimer.Start();
            

            //System.Windows.Forms.Timer pinkyTimer = new System.Windows.Forms.Timer();
            //inkyTimer.Interval = 400;
            //pinkyTimer.Elapsed += PinkyMove;
            //pinkyTimer.Start();
        }


        //private static void InkyMove(Object source, EventArgs e)
        //{
        //    //lock (_sync)
        //    {

        //        Direction InkyEatApple = _game.myInky.Move(_game);
                
        //        //Draw.DrawOneApple(game.myInky, InkyEatApple);
        //    }
        //}

        //private static void PinkyMove(Game game, Object source, EventArgs e)
        //{
        //    //lock (_sync)
        //    {

        //        Direction PinkyEatApple = game.myPinky.Move(game);

        //        //Draw.DrawOneApple(game.myPinky, PinkyEatApple);
        //    }
        //}
    }
}
