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


        #region Fields

        private SoundPlayer _musicStart = new SoundPlayer(Properties.Resources.StartMenuMusic);

        public static SoundPlayer musicButtonClicked = new SoundPlayer(Properties.Resources.ButtonClicked);

        #endregion


        #region Constructor

        public GameMenu()
        {
            InitializeComponent();
        }

        #endregion


        #region Load

        private void GameMenu_Load(object sender, EventArgs e)
        {
            _musicStart.Play();
        }

        #endregion


        #region ButtonRules
        private void btnRules_Click(object sender, EventArgs e)
        {
            musicButtonClicked.Play();
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

        #endregion


        #region ButtonControls
        private void btnControls_Click(object sender, EventArgs e)
        {
            musicButtonClicked.Play();
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

        #endregion

         
        #region ButtonStart

        private void btnStart_Click(object sender, EventArgs e)
        {
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

        #endregion


        #region ButtonQuite
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

        #endregion

       
    }
}
