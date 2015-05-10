using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.WinForms
{
    public partial class GameMenu : Form
    {
        public GameMenu()
        {
            InitializeComponent();
        }

       

        private void GameMenu_Load(object sender, EventArgs e)
        {
           // Paint += DrawMenu;

        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }


        

        private void btnQuite_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnControls_Click(object sender, EventArgs e)
        {
            ControlsForm controlsForm = new ControlsForm();
            controlsForm.Show();
        }
        
    }
}
