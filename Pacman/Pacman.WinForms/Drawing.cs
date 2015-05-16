﻿using System;
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
        private const int multiplier = 23;
        private const int turn = 8;
        private const int appleSize = 7;

        #region Draw Methods

        private static void DrawWall(int i, int j, object sender, PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            Rectangle rect = new Rectangle(i * multiplier, j * multiplier, multiplier, multiplier);
            e.Graphics.FillRectangle(blueBrush, rect);
        }

        private static void DrawWay(int i, int j, object sender, PaintEventArgs e)
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            Rectangle rect = new Rectangle(i * multiplier, j * multiplier, multiplier, multiplier);
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
                        Rectangle rect = new Rectangle(j * multiplier + turn, i * multiplier + turn, appleSize, appleSize);
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
            e.Graphics.DrawImage(image, inky.X * multiplier, inky.Y * multiplier, multiplier - 1, multiplier - 1);
        }

        private static void DrawPinky(Pinky pinky, object sender, PaintEventArgs e)
        {
            Image image = Properties.Resources.Pinky;
            e.Graphics.DrawImage(image, pinky.X * multiplier, pinky.Y * multiplier, multiplier - 1, multiplier - 1);
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
            e.Graphics.DrawImage(image, pacman.X * multiplier, pacman.Y * multiplier, multiplier - 1, multiplier - 1);
        }


        #endregion

    }
}
