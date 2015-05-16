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
    public partial class ControlForm : Form
    {

        #region Constructor
        public ControlForm()
        {
            InitializeComponent();
        }

        #endregion

        private void btnLeft_Click(object sender, EventArgs e)
        {
            this.pctBoxLeft.Visible = false;
            this.pctBoxLeftLeft.Visible = true;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            this.pctBoxRight.Visible = false;
            this.pctBoxRightRight.Visible = true;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            this.pctBoxUp.Visible = false;
            this.pctBoxUpUp.Visible = true;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            this.pctBoxDown.Visible = false;
            this.pctBoxDownDown.Visible = true;
        }

    
    }
}
