using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman.GameEngine;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Configuration;


namespace Pacman.WinForms
{
    internal class Drawing
    {

        #region Const

        private const int THE_MULTIPLIER = 23;
        private const int THE_TURN = 8;
        private const int THE_APPLESIZE = 7;

        #endregion

        /*
         * ВВ: 
         *      у методи промальовки не варто передавати PaintEventArgs, 
         *      оскільки вони використовують лише графічний контекст Graphics
         */

        #region Draw Methods

        private static void DrawWall(int i, int j, object sender, PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            Rectangle rect = new Rectangle(i * THE_MULTIPLIER, j * THE_MULTIPLIER, THE_MULTIPLIER, THE_MULTIPLIER);
            e.Graphics.FillRectangle(blueBrush, rect);
        }

        private static void DrawWay(int i, int j, object sender, PaintEventArgs e)
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            Rectangle rect = new Rectangle(i * THE_MULTIPLIER, j * THE_MULTIPLIER, THE_MULTIPLIER, THE_MULTIPLIER);
            e.Graphics.FillRectangle(blackBrush, rect);
        }

        private static void DrawApples(Apples app, object sender, PaintEventArgs e)
        {
            SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

            for (int i = 0; i < app.Dots.GetLength(0); i++)
            {
                for (int j = 0; j < app.Dots.GetLength(1); j++)
                {
                    if (app.Dots[i, j] == true)
                    {
                        Rectangle rect = new Rectangle(j * THE_MULTIPLIER + THE_TURN, i * THE_MULTIPLIER + THE_TURN, THE_APPLESIZE, THE_APPLESIZE);
                        e.Graphics.FillEllipse(yellowBrush, rect);
                    }                   
                }
            }           
        }

        private static void DrawMap(int [,] array, object sender, PaintEventArgs e)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 1)
                    {
                        DrawWall(j, i, sender, e);
                    }
                    else if (array[i, j] == 0)
                    {
                        DrawWay(j, i, sender, e);
                    }
                    else 
                    {
                        DrawWay(j, i, sender, e);
                    }
                }
            }
        }

        public static void DrawGame(Game game, object sender, PaintEventArgs e)
        {
            Apples currentApples = game.Map.GetApples();
            DrawMap(game.Map.MyMap, sender, e);
            DrawApples(currentApples, sender, e);

            DrawPacman(game.MyPacman, sender, e);
            DrawInky(game.MyInky, sender, e);
            DrawPinky(game.MyPinky, sender, e);       
        }

        private static void DrawInky(Inky inky, object sender, PaintEventArgs e)
        {
            Image image = Properties.Resources.Inky;
            e.Graphics.DrawImage(image, inky.X * THE_MULTIPLIER, inky.Y * THE_MULTIPLIER, THE_MULTIPLIER - 1, THE_MULTIPLIER - 1);
        }

        private static void DrawPinky(Pinky pinky, object sender, PaintEventArgs e)
        {
            Image image = Properties.Resources.Pinky;
            e.Graphics.DrawImage(image, pinky.X * THE_MULTIPLIER, pinky.Y * THE_MULTIPLIER, THE_MULTIPLIER - 1, THE_MULTIPLIER - 1);
        }

        public static void DrawPacman(Pacman.GameEngine.Pacman pacman, object sender, PaintEventArgs e)
        {          
            Image image = Properties.Resources.Pacman;
            switch (pacman.Direction)
            {
                case Direction.Up: image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case Direction.Down: image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case Direction.Left: image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    break;
            }
            e.Graphics.DrawImage(image, pacman.X * THE_MULTIPLIER, pacman.Y * THE_MULTIPLIER, THE_MULTIPLIER - 1, THE_MULTIPLIER - 1);
        }


        #endregion

    }
}
