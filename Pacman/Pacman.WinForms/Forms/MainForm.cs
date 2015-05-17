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
using System.Media;

namespace Pacman.WinForms
{
    
    
    public partial class MainForm : Form
    {

        #region Fields

        private static Game _game;

        #endregion


        #region Constructor
        public MainForm()
        {
            GameMenu.MusicButtonClicked.Play();
            var width = Int32.Parse(ConfigurationManager.AppSettings["Width"]);
            var heigth = Int32.Parse(ConfigurationManager.AppSettings["Heigth"]);
            int pacmanX = Int32.Parse(ConfigurationManager.AppSettings["PacmanX"]);
            int pacmanY = Int32.Parse(ConfigurationManager.AppSettings["PacmanY"]);
            int inkyX = Int32.Parse(ConfigurationManager.AppSettings["InkyX"]);
            int inkyY = Int32.Parse(ConfigurationManager.AppSettings["InkyY"]);
            int pinkyX = Int32.Parse(ConfigurationManager.AppSettings["PinkyX"]);
            int pinkyY = Int32.Parse(ConfigurationManager.AppSettings["PinkyY"]);

            string path = ConfigurationManager.AppSettings["Path"];
            string filename = Path.Combine(Application.StartupPath, path);
            int[,] array = Game.LoadMap(filename, width, heigth);

            _game = new Game(width, heigth, array, pacmanX, pacmanY, inkyX, inkyY, pinkyX, pinkyY);

            Game.Scores = 0;

            InitializeComponent();           
        }

        #endregion


        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            lblGetScores.Text = Game.Scores.ToString();
            lblGetLives.Text = _game.MyPacman.Lives.ToString();
            Paint += Draw;
            inkyTimer.Tick += InkyMove;
            pinkyTimer.Tick += PinkyMove;

            GameSubscribe();
        }

        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            GameUnsubscribe();
            GameMenu.MusicStart.Play();
        }
      
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Up:
                    {
                        if (_game.MyPacman.CheckPosition(_game.Map.MyMap, 0, -1))
                        {
                            _game.MyPacman.Direction = Direction.Up;
                        }
                    }
                    break;

                case Keys.Down:
                    {
                        if (_game.MyPacman.CheckPosition(_game.Map.MyMap, 0, 1))
                        {
                            _game.MyPacman.Direction = Direction.Down;
                        }
                    }
                    break;

                case Keys.Left:
                    {
                        if (_game.MyPacman.CheckPosition(_game.Map.MyMap, -1, 0))
                        {
                            _game.MyPacman.Direction = Direction.Left;
                        }
                    }
                    break;

                case Keys.Right:
                    {
                        if (_game.MyPacman.CheckPosition(_game.Map.MyMap, 1, 0))
                        {
                            _game.MyPacman.Direction = Direction.Right;
                        }
                    }
                    break;

                case Keys.Space:
                    {
                        GameUnsubscribe();
                        DialogResult result;
                        MessageBoxButtons buttons = MessageBoxButtons.OK;

                        result = MessageBox.Show(this, "Game is paused.\r\nPress space to continue.", "Resume", buttons);

                        if (result == DialogResult.OK)
                        {
                            GameSubscribe();
                        }
                    }
                    break;
            }
            MovePacman();
            Refresh();
            IfPacmanEated();
            IfPacmanWin();
        }

        private void OnPacmanEatApple(object sender, EventArgs e)
        {
            lblGetScores.Text = Game.Scores.ToString();
            Refresh();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            Drawing.DrawGame(_game, sender, e);
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


        #endregion


        #region Methods

        private void GameSubscribe()
        {
            _game.PacmanEatApple += OnPacmanEatApple;
            lblGetScores.Text = Game.Scores.ToString();
            pinkyTimer.Start();
            inkyTimer.Start();
        }

        private void GameUnsubscribe()
        {
            inkyTimer.Stop();
            pinkyTimer.Stop();
        }

        private void IfPacmanWin()
        {
            if (Game.Scores == 325)
            {
                PacmanWinMusic();
                GameUnsubscribe();
                DialogResult result;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                string str = "Congratulations! You Won!\r\nDo you want to restart?";
                string caption = "Resume";
                result = MessageBox.Show(this, str, caption, buttons);
                if (result == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    this.Close();
                    MainForm mainForm = new MainForm();
                    mainForm.ShowDialog();
                }
            }
        }

        private void MovePacman()
        {
            if (_game.MyPacman.Move(_game, _game.MyPacman.Direction))
            {
                lblGetScores.Text = Game.Scores.ToString();
                PacmanEatAppleMusic();
            }
        }

        private void IfPacmanEated()
        {
            if (!_game.IfPacmanNotEated())
            {
                _game.MinusLive();
                PacmanDiedMusic();
                GameUnsubscribe();

                lblGetLives.Text = _game.MyPacman.Lives.ToString();
                string eated = "Oops! You've been eated!\r\nPress Yes to continue.\r\nPress No to exit";
                string died = "You loose! Game Over!\r\nPress Yes to try again.\r\nPress No to exit";
                string caption = "Resume";

                DialogResult result;

                if (_game.MyPacman.Lives > 0)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                    result = MessageBox.Show(this, eated, caption, buttons);

                    if (result == DialogResult.No)
                    {
                        Game.Scores = 0;
                        this.Close();
                    }

                    if (result == DialogResult.Yes)
                    {
                        _game.MyInky.X = 13;
                        _game.MyInky.Y = 12;

                        _game.MyPinky.X = 14;
                        _game.MyPinky.Y = 12;

                        _game.MyPacman.X = 13;
                        _game.MyPacman.Y = 26;
                        _game.MyPacman.Direction = Direction.Left;
                        inkyTimer.Start();
                        pinkyTimer.Start();
                        GameSubscribe();
                        GameMenu.MusicButtonClicked.Play();
                    }
                }

                if (_game.MyPacman.Lives == 0)
                {
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                    result = MessageBox.Show(this, died, caption, buttons);
                    if (result == DialogResult.No)
                    {
                        Game.Scores = 0;
                        this.Close();
                    }

                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                        MainForm mainForm = new MainForm();
                        mainForm.ShowDialog();
                    }
                }
            }
        }
      
        private void PacmanEatAppleMusic()
        {
            SoundPlayer eatApple = new SoundPlayer(Properties.Resources.PacmanEatApple);
             eatApple.Play();          
        }

        private void PacmanDiedMusic()
        {
            SoundPlayer pacmanEated = new SoundPlayer(Properties.Resources.PacmanEated);
            pacmanEated.Play();
        }

        private void PacmanWinMusic()
        {
            SoundPlayer pacmanWin = new SoundPlayer(Properties.Resources.PacnamWin);
            pacmanWin.Play();
        }

        #endregion

    }
}
