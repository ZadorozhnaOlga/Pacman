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
        //public Form gameForm;
        private Game _game;
        private static object _sync = new object();

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
            var mapPath = ConfigurationManager.AppSettings["Path"];
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            string path = string.Concat(projectPath, mapPath);
            _game = new Game(28, 32, Game.LoadMap(path, 28, 32), 13, 26, 13, 12, 14, 12);
            Paint += Draw;
            
            
        }

        private void GameProcess(object sender, EventArgs e) 
        {
            Paint += Draw;
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            Drawing.DrawGame(_game, sender, e);
            //Drawing.DrawInkyMove(_game, sender, e);
        }


        public void MainForm_MoveInky(object sender, EventArgs e)
        {
            //System.Windows.Forms.Timer inkyTimer = new System.Windows.Forms.Timer();
            inkyTimer.Interval = 500;
            inkyTimer.Tick += InkyMove; 
            inkyTimer.Start();
            Refresh();
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

                //case Keys.Space: _game.OnPauseGame();
                //    break;
                //case Keys.R: OnRestart(this, EventArgs.Empty);
                //    break;
            }

        }

        
       
            

            //System.Windows.Forms.Timer pinkyTimer = new System.Windows.Forms.Timer();
            //inkyTimer.Interval = 400;
            //pinkyTimer.Elapsed += PinkyMove;
            //pinkyTimer.Start();
        


        private void InkyMove(Object source, EventArgs e)
        {
            //lock (_sync)
            {

                Direction InkyEatApple = _game.MyInky.Move(_game);
                
                //Draw.DrawOneApple(game.myInky, InkyEatApple);
            }
        }

        private void PinkyMove(Game game, Object source, EventArgs e)
        {
            //lock (_sync)
            {

                Direction PinkyEatApple = game.MyPinky.Move(game);

                //Draw.DrawOneApple(game.myPinky, PinkyEatApple);
            }
        }

        private void inkyTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
        

    }
}
