using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;


namespace Pacman.WinForms
{
    public partial class GameMenu : Form
    {
        
        SoundPlayer musicStart = new SoundPlayer(Properties.Resources.StartMenuMusic);
            
        public GameMenu()
        {
            InitializeComponent();
            
                
            
        }

       

        private void GameMenu_Load(object sender, EventArgs e)
        {
            musicStart.Play();
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            musicStart.Stop();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            
        }

        private void btnStart_MouseEnter(object sender, EventArgs e)
        {
            btnStart.BackColor = Color.Yellow;
        }

        private void btnStart_MouseLeave(object sender, EventArgs e)
        {
            btnStart.BackColor = Color.DarkOrange;
        }
        

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuit_MouseEnter(object sender, EventArgs e)
        {
            btnQuit.BackColor = Color.Yellow;
        }

        private void btnQuit_MouseLeave(object sender, EventArgs e)
        {
            btnQuit.BackColor = Color.DarkOrange;
        }

        private void btnControls_Click(object sender, EventArgs e)
        {
            ControlForm controlsForm = new ControlForm();
            controlsForm.ShowDialog();
        }

        private void btnControl_MouseEnter(object sender, EventArgs e)
        {
            btnControl.BackColor = Color.Yellow;
        }

        private void btnControl_MouseLeave(object sender, EventArgs e)
        {
            btnControl.BackColor = Color.DarkOrange;
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            RulesForm rulesform = new RulesForm();
            rulesform.ShowDialog();
        }


        private void btnRules_MouseEnter(object sender, EventArgs e)
        {
            btnRules.BackColor = Color.Yellow;
        }

        private void btnRules_MouseLeave(object sender, EventArgs e)
        {
            btnRules.BackColor = Color.DarkOrange;
        }

        private void PacmanStarMenuPlay()
        {
            SoundPlayer musicStart = new SoundPlayer(@"D:\visual_studio\Pacman_branch\Pacman\Pacman\Pacman.WinForms\Sounds\StartMenu.wav");
            
                musicStart.Play();
            
        }

        private void MusicStop()
        {
            
            musicStart.Play();

        }

       
    }
}
