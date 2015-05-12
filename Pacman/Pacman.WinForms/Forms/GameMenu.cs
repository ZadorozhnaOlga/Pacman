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
            mainForm.ShowDialog();
            
        }


        

        private void btnQuite_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnControls_Click(object sender, EventArgs e)
        {
            ControlForm controlsForm = new ControlForm();
            controlsForm.ShowDialog();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            RulesForm rulesform = new RulesForm();
            rulesform.ShowDialog();
        }

        private void btnRules_Click_1(object sender, EventArgs e)
        {
            RulesForm rulesform = new RulesForm();
            rulesform.ShowDialog();
        }

       
    }
}
