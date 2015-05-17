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

namespace Pacman.WinForms
{
    public partial class ControlForm : Form
    {
        #region Fields

        private SoundPlayer _musicButtonClicked = new SoundPlayer(Properties.Resources.ButtonClicked);

        #endregion


        #region Constructor
        public ControlForm()
        {  
            InitializeComponent();
        }

        #endregion


        #region Events

        private void ControlForm_Closed(object sender, FormClosedEventArgs e)
        {
            GameMenu.MusicStart.Play();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            _musicButtonClicked.Play();
            pctBoxLeft.Visible = false;
            pctBoxLeftLeft.Visible = true;
            btnLeft.Enabled = false;
            pctBoxPressLeft.Visible = true;
        }
  

        private void btnRight_Click(object sender, EventArgs e)
        {
            _musicButtonClicked.Play();
            this.pctBoxRight.Visible = false;
            this.pctBoxRightRight.Visible = true;
            btnRight.Enabled = false;
            pctBoxPressRight.Visible = true;
        }


        private void btnUp_Click(object sender, EventArgs e)
        {
            _musicButtonClicked.Play();
            this.pctBoxUp.Visible = false;
            this.pctBoxUpUp.Visible = true;
            btnUp.Enabled = false;
            pctBoxPressUp.Visible = true;
        }
     

        private void btnDown_Click(object sender, EventArgs e)
        {
            _musicButtonClicked.Play();
            pctBoxDown.Visible = false;
            pctBoxDownDown.Visible = true;
            btnDown.Enabled = false;
            pctBoxPressDown.Visible = true;
        }

        #endregion

    }
}
