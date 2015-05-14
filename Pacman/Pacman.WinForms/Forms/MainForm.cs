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
       
        private static Game _game;
       

        //class ButtonWithoutFocus : Button
        //{

        //    public ButtonWithoutFocus()
        //    {

        //        SetStyle(ControlStyles.Selectable, false);

        //    }

        //    public void DeactivateFocus(object sender, EventArgs e)
        //    {
        //        SetStyle(ControlStyles.Selectable, false);
        //    }
        //}

       

      

        public MainForm()
        {
            var mapPath = ConfigurationManager.AppSettings["Path"];
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            string path = string.Concat(projectPath, mapPath);
            _game = new Game(28, 32, Game.LoadMap(path, 28, 32), 13, 26, 13, 12, 14, 12);
            Game.Scores = 0;
            

            InitializeComponent();
           
        }


        public Game GetGame()
        {
            return _game;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            GameUnsubscribe();
        }

        private void GameLoad(object sender, EventArgs e)
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

       

        private void GameSubscribe()
        {
            _game.PacmanEatApple += OnPacmanEatApple;
            lblGetScores.Text = Game.Scores.ToString();
            pinkyTimer.Start();
            inkyTimer.Start();           
            _game.PacmanEated += OnMessagePacmanEated;
            _game.PacmanWin += OnPacmanWin;
        }

        

        private void GameUnsubscribe()
        {  
            inkyTimer.Stop();
            pinkyTimer.Stop();
            _game.PacmanEated -= OnMessagePacmanEated;       
        }

        private void CheckScores()
        {
            if (Game.Scores == 325)
            {
                GameUnsubscribe();
                MessageBox.Show("Congratulations! You Won!");  //== DialogResult.OK)

                //    this.Close();



            }
        }

        private void OnPacmanWin(object sender, EventArgs e)
        {
            if (Game.Scores == 325)
                
            {
                GameUnsubscribe();
                MessageBox.Show("Congratulations! You Won!");  //== DialogResult.OK)
                
                //    this.Close();
                
                
               
            }
        }


        private void OnPacmanEatApple(object sender, EventArgs e) 
        {
            
            lblGetScores.Text = Game.Scores.ToString();
            
            Refresh();
        }

        private void OnMessagePacmanEated(object sender, EventArgs e)
        {
            PacmanDied();
            GameUnsubscribe();

            lblGetLives.Text = _game.MyPacman.Lives.ToString();            
            string eated = "Oops! You've been eated!\r\n Press Yes to continue.\r\n Press No to exit";
            string died = "You loose! Game Over!\r\n Press Yes to try again.\r\n Press No to exit";
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

                    inkyTimer.Start();
                    pinkyTimer.Start();
                    GameSubscribe();
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
                    //inkyTimer.Tick -= new EventHandler(InkyMove);
                    //pinkyTimer.Tick -= new EventHandler(PinkyMove);
                    this.Close();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
            }            
        }



        private void Draw(object sender, PaintEventArgs e)
        {
            Drawing.DrawGame(_game, sender, e);       
        }


        private void GetResume() 
        {
            lblGetScores.Text = Game.Scores.ToString();
            lblGetLives.Text = _game.MyPacman.Lives.ToString();
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            
            this.SetStyle(ControlStyles.Selectable, true);
            switch (e.KeyData)
            {
                case Keys.Up:
                    {  
                        if (_game.MyPacman.CheckPosition(_game.Map.MyMap, 0, -1) & _game.IfPacmanNotEated())
                        {
                            _game.MyPacman.Direction = Direction.Up;

                            if (_game.MyPacman.Move(_game, _game.MyPacman.Direction))
                            {
                                lblGetScores.Text = Game.Scores.ToString();
                                
                                PacmanEatApple();
                               
                            }                         
                            Refresh();
                        }
                    }
                    break;

                case Keys.Down:
                    {
                        if (_game.MyPacman.CheckPosition(_game.Map.MyMap, 0, 1) & _game.IfPacmanNotEated())
                        {
                            _game.MyPacman.Direction = Direction.Down;
                            

                            if (_game.MyPacman.Move(_game, _game.MyPacman.Direction))
                            {
                                lblGetScores.Text = Game.Scores.ToString();
                               
                                PacmanEatApple();
                              
                            }                           
                            Refresh();
                        }
                    }
                    break;

                case Keys.Left:
                    {
                        if (_game.MyPacman.CheckPosition(_game.Map.MyMap, -1, 0) & _game.IfPacmanNotEated())
                        {
                            _game.MyPacman.Direction = Direction.Left;
                            if (_game.MyPacman.Move(_game, _game.MyPacman.Direction))
                            {
                                lblGetScores.Text = Game.Scores.ToString();
                                
                                PacmanEatApple();
                              
                            }                                                  
                            Refresh();
                        }
                    }
                    break;

                case Keys.Right:
                    {
                        if (_game.MyPacman.CheckPosition(_game.Map.MyMap, 1, 0) & _game.IfPacmanNotEated())
                        {
                            _game.MyPacman.Direction = Direction.Right;
                            
                                if (_game.MyPacman.Move(_game, _game.MyPacman.Direction))
                                {
                                    lblGetScores.Text = Game.Scores.ToString();
                                    
                                    PacmanEatApple();
                                    
                                } 
                            Refresh();
                        }
                    }
                    break;

                case Keys.Space: 
                    {
                        GameUnsubscribe();
                        DialogResult result;
                        MessageBoxButtons buttons = MessageBoxButtons.OK;

                        result = MessageBox.Show(this, "Game is paused.\r\n Press space to continue.", "Resume", buttons);

                        if (result == DialogResult.OK)
                        {
                            GameSubscribe();
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

        private void btnPauseGame_Click(object sender, EventArgs e)
        {
            GameUnsubscribe();
            DialogResult result;
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            result = MessageBox.Show(this, "Game is paused.\r\n Press space to continue.", "Resume", buttons);

            if (result == DialogResult.OK)
            {
                GameSubscribe();

            }
          
        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            GameUnsubscribe();
            DialogResult result;
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            result = MessageBox.Show(this, "Game is paused.\r\n Press space to continue.", "Resume", buttons);

            if (result == DialogResult.OK)
            {
                GameSubscribe();
            }
        }

       

        

        //private void btnPause_Click(object sender, EventArgs e)
        //{
        //    GameUnsubscribe();
        //    DialogResult result;
        //    MessageBoxButtons buttons = MessageBoxButtons.OK;

        //    result = MessageBox.Show(this, "Game is paused.\r\n Press space to continue.", "Resume", buttons);

        //    if (result == DialogResult.OK)
        //    {
        //        GameSubscribe();

        //    }
        //}

      


        private void PacmanEatApple()
        {
            SoundPlayer eatApple = new SoundPlayer(Properties.Resources.PacmanEatApple);
            
                eatApple.Play();
            
        }


        private void PacmanDied()
        {
            SoundPlayer pacmanEated = new SoundPlayer(Properties.Resources.PacmanEated);

            pacmanEated.Play();

        }

        

    }
}
