using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using Pacman.GameEngine;

namespace Pacman.WinForms
{
    public partial class MainForm : Form
    {
       
        private static Game _game;
        private static object _sync = new object();

       

        static MainForm() 
        {
            var mapPath = ConfigurationManager.AppSettings["Path"];
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            string path = string.Concat(projectPath, mapPath);
            _game = new Game(28, 32, Game.LoadMap(path, 28, 32), 13, 26, 13, 12, 14, 12);
            
        }

      

        public MainForm()
        {
            InitializeComponent();
        }

        public Game GetGame()
        {
            return _game;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void GameLoad(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            
            Paint += Draw;
       
            
        }



        private void Draw(object sender, PaintEventArgs e)
        {
            Drawing.DrawGame(_game, sender, e);
           
        }


        public void InkyStep(object sender, EventArgs e)
        {
            inkyTimer.Tick += InkyMove; 
            //inkyTimer.Start();
            //Refresh();
        }

        public void PinkyStep(object sender, EventArgs e)
        {
            pinkyTimer.Tick += PinkyMove;
            
           // Refresh();
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyData)
            {
                case Keys.Up:
                    {
                        if (_game.MyPacman.CheckPosition(_game.Map.MyMap, 0, -1) & _game.IfPacmanNotEated())
                        {
                            _game.MyPacman.Direction = Direction.Up;
                            _game.MyPacman.Move(_game, _game.MyPacman.Direction);
                            lblGetScores.Text = Game.Scores.ToString();
                            Refresh();
                        }
                    }
                    break;
                case Keys.Down:
                    {
                        if (_game.MyPacman.CheckPosition(_game.Map.MyMap, 0, 1) & _game.IfPacmanNotEated())
                        {
                            _game.MyPacman.Direction = Direction.Down;
                            _game.MyPacman.Move(_game, _game.MyPacman.Direction);
                            lblGetScores.Text = Game.Scores.ToString();
                            Refresh();
                        }
                    }
                    break;
                case Keys.Left:
                    {
                        if (_game.MyPacman.CheckPosition(_game.Map.MyMap, -1, 0) & _game.IfPacmanNotEated())
                        {
                            _game.MyPacman.Direction = Direction.Left;
                            _game.MyPacman.Move(_game, _game.MyPacman.Direction);
                            lblGetScores.Text = Game.Scores.ToString();
                            Refresh();
                        }
                    }

                    break;
                case Keys.Right:
                    {
                        if (_game.MyPacman.CheckPosition(_game.Map.MyMap, 1, 0) & _game.IfPacmanNotEated())
                        {
                            _game.MyPacman.Direction = Direction.Right;
                            _game.MyPacman.Move(_game, _game.MyPacman.Direction);
                            lblGetScores.Text = Game.Scores.ToString();

                           
                            Refresh();
                        }
                    }
                    break;

       
            }

        }

        
       
       

        private void InkyMove(Object source, EventArgs e)
        {
           
   
                Direction InkyEatApple = _game.MyInky.Move(_game);
    
        }

        private void PinkyMove(Object source, EventArgs e)
        {
    
                Direction PinkyEatApple = _game.MyPinky.Move(_game);

        }

        private void inkyTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void pinkyTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }
        

    }
}
