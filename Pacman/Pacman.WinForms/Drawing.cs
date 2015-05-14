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
        public Label[,] element = new Label[28, 32];
       



        private static void DrawWall(int i, int j, object sender, PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            Rectangle rect = new Rectangle(i*23, j*23, 23, 23);
            e.Graphics.FillRectangle(blueBrush, rect);
        }

        private static void DrawWay(int i, int j, object sender, PaintEventArgs e)
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            Rectangle rect = new Rectangle(i*23, j*23, 23, 23);
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
                        Rectangle rect = new Rectangle(j * 23 + 8, i * 23 + 8, 7, 7);
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
                        //DrawApple(j, i, sender, e);
                    }
                    else 
                    {
                        DrawWay(j, i, sender, e);
                    }
                    //if (i == 26 && j == 13) 
                    //{
                    //    DrawWay(j, i, sender, e);
                    //}
                }
            }
        }

        

        public static void DrawGame(Game game, object sender, PaintEventArgs e)
        {
            Apples currentApples = game.Map.GetApples();
            DrawMap(game.Map.MyMap, sender, e);
            DrawApples(currentApples, sender, e);
            
            
            DrawInky(game.MyInky, sender, e);
            DrawPinky(game.MyPinky, sender, e);
            DrawPacman(game.MyPacman, sender, e);
            
        }

        


        private static void DrawInky(Inky inky, object sender, PaintEventArgs e)
        {
            Image image = Properties.Resources.Inky;
            
            e.Graphics.DrawImage(image, inky.X*23, inky.Y*23, 22, 22);
        }

        private static void DrawPinky(Pinky pinky, object sender, PaintEventArgs e)
        {
            Image image = Properties.Resources.Pinky;

            e.Graphics.DrawImage(image, pinky.X * 23, pinky.Y * 23, 22, 22);
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

            e.Graphics.DrawImage(image, pacman.X * 23, pacman.Y * 23, 22, 22);
        }


        //public static void DrawPicture(string str, int positionX, int positionY, int width, int height, object sender, PaintEventArgs e)
        //{

        //    string path = GetPath(str);
        //    Image image = Image.FromFile(path);
        //    e.Graphics.DrawImage(image, positionX, positionY, width, height);
        //}


       //public static string GetPath(string str)
       //{
       //     var imagesPath = ConfigurationManager.AppSettings[str];
       //     var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
       //     string path = string.Concat(projectPath, imagesPath);
       //     return path;
       //}
    
  

    }
}
