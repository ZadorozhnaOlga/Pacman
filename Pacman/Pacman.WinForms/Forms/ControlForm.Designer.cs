namespace Pacman.WinForms
{
    partial class ControlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
            this.lblLeft = new System.Windows.Forms.Label();
            this.btnLeft = new System.Windows.Forms.Button();
            this.lblExpainLeft = new System.Windows.Forms.Label();
            this.lblExpainRight = new System.Windows.Forms.Label();
            this.btnRight = new System.Windows.Forms.Button();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblExplainUp = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.lblUp = new System.Windows.Forms.Label();
            this.lblExplainDown = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.lblDown = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pctBoxLeft = new System.Windows.Forms.PictureBox();
            this.pctBoxRight = new System.Windows.Forms.PictureBox();
            this.pctBoxUp = new System.Windows.Forms.PictureBox();
            this.pctBoxDown = new System.Windows.Forms.PictureBox();
            this.pctBoxLeftLeft = new System.Windows.Forms.PictureBox();
            this.pctBoxRightRight = new System.Windows.Forms.PictureBox();
            this.pctBoxUpUp = new System.Windows.Forms.PictureBox();
            this.pctBoxDownDown = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxLeftLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxRightRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxUpUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxDownDown)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeft.Location = new System.Drawing.Point(20, 348);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(75, 31);
            this.lblLeft.TabIndex = 0;
            this.lblLeft.Text = "Press";
            // 
            // btnLeft
            // 
            this.btnLeft.Image = global::Pacman.WinForms.Properties.Resources.Left;
            this.btnLeft.Location = new System.Drawing.Point(138, 333);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 68);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // lblExpainLeft
            // 
            this.lblExpainLeft.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpainLeft.Location = new System.Drawing.Point(238, 351);
            this.lblExpainLeft.Name = "lblExpainLeft";
            this.lblExpainLeft.Size = new System.Drawing.Size(397, 28);
            this.lblExpainLeft.TabIndex = 2;
            this.lblExpainLeft.Text = "to move the Pacman to the Left";
            // 
            // lblExpainRight
            // 
            this.lblExpainRight.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpainRight.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblExpainRight.Location = new System.Drawing.Point(238, 499);
            this.lblExpainRight.Name = "lblExpainRight";
            this.lblExpainRight.Size = new System.Drawing.Size(397, 28);
            this.lblExpainRight.TabIndex = 5;
            this.lblExpainRight.Text = "to move the Pacman to the Right";
            // 
            // btnRight
            // 
            this.btnRight.Image = global::Pacman.WinForms.Properties.Resources.Right;
            this.btnRight.Location = new System.Drawing.Point(138, 484);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 68);
            this.btnRight.TabIndex = 4;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRight.Location = new System.Drawing.Point(20, 499);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(75, 31);
            this.lblRight.TabIndex = 3;
            this.lblRight.Text = "Press";
            // 
            // lblExplainUp
            // 
            this.lblExplainUp.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplainUp.Location = new System.Drawing.Point(238, 208);
            this.lblExplainUp.Name = "lblExplainUp";
            this.lblExplainUp.Size = new System.Drawing.Size(397, 28);
            this.lblExplainUp.TabIndex = 8;
            this.lblExplainUp.Text = "to move the Pacman Up";
            // 
            // btnUp
            // 
            this.btnUp.Image = global::Pacman.WinForms.Properties.Resources.Up;
            this.btnUp.Location = new System.Drawing.Point(138, 181);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 68);
            this.btnUp.TabIndex = 7;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lblUp
            // 
            this.lblUp.AutoSize = true;
            this.lblUp.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUp.Location = new System.Drawing.Point(20, 196);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(75, 31);
            this.lblUp.TabIndex = 6;
            this.lblUp.Text = "Press";
            // 
            // lblExplainDown
            // 
            this.lblExplainDown.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplainDown.Location = new System.Drawing.Point(238, 46);
            this.lblExplainDown.Name = "lblExplainDown";
            this.lblExplainDown.Size = new System.Drawing.Size(397, 28);
            this.lblExplainDown.TabIndex = 11;
            this.lblExplainDown.Text = "to move the Pacman Down";
            // 
            // btnDown
            // 
            this.btnDown.Image = global::Pacman.WinForms.Properties.Resources.Down;
            this.btnDown.Location = new System.Drawing.Point(138, 31);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 68);
            this.btnDown.TabIndex = 10;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // lblDown
            // 
            this.lblDown.AutoSize = true;
            this.lblDown.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDown.Location = new System.Drawing.Point(20, 46);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(75, 31);
            this.lblDown.TabIndex = 9;
            this.lblDown.Text = "Press";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label1.Location = new System.Drawing.Point(287, 601);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "Press SPACE to Pause the game";
            // 
            // pctBoxLeft
            // 
            this.pctBoxLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctBoxLeft.Image = global::Pacman.WinForms.Properties.Resources.PacmanLeft;
            this.pctBoxLeft.Location = new System.Drawing.Point(791, 299);
            this.pctBoxLeft.Name = "pctBoxLeft";
            this.pctBoxLeft.Size = new System.Drawing.Size(159, 134);
            this.pctBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxLeft.TabIndex = 13;
            this.pctBoxLeft.TabStop = false;
            // 
            // pctBoxRight
            // 
            this.pctBoxRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctBoxRight.Image = global::Pacman.WinForms.Properties.Resources.PacmanRight;
            this.pctBoxRight.Location = new System.Drawing.Point(652, 439);
            this.pctBoxRight.Name = "pctBoxRight";
            this.pctBoxRight.Size = new System.Drawing.Size(159, 141);
            this.pctBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxRight.TabIndex = 14;
            this.pctBoxRight.TabStop = false;
            // 
            // pctBoxUp
            // 
            this.pctBoxUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctBoxUp.Image = global::Pacman.WinForms.Properties.Resources.PacmanUp;
            this.pctBoxUp.Location = new System.Drawing.Point(800, 151);
            this.pctBoxUp.Name = "pctBoxUp";
            this.pctBoxUp.Size = new System.Drawing.Size(159, 142);
            this.pctBoxUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxUp.TabIndex = 15;
            this.pctBoxUp.TabStop = false;
            // 
            // pctBoxDown
            // 
            this.pctBoxDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctBoxDown.Image = global::Pacman.WinForms.Properties.Resources.PacmanDown;
            this.pctBoxDown.Location = new System.Drawing.Point(595, 12);
            this.pctBoxDown.Name = "pctBoxDown";
            this.pctBoxDown.Size = new System.Drawing.Size(158, 137);
            this.pctBoxDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxDown.TabIndex = 16;
            this.pctBoxDown.TabStop = false;
            // 
            // pctBoxLeftLeft
            // 
            this.pctBoxLeftLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctBoxLeftLeft.Image = global::Pacman.WinForms.Properties.Resources.PacmanLeft;
            this.pctBoxLeftLeft.Location = new System.Drawing.Point(654, 299);
            this.pctBoxLeftLeft.Name = "pctBoxLeftLeft";
            this.pctBoxLeftLeft.Size = new System.Drawing.Size(159, 134);
            this.pctBoxLeftLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxLeftLeft.TabIndex = 17;
            this.pctBoxLeftLeft.TabStop = false;
            this.pctBoxLeftLeft.Visible = false;
            // 
            // pctBoxRightRight
            // 
            this.pctBoxRightRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctBoxRightRight.Image = global::Pacman.WinForms.Properties.Resources.PacmanRight;
            this.pctBoxRightRight.Location = new System.Drawing.Point(800, 439);
            this.pctBoxRightRight.Name = "pctBoxRightRight";
            this.pctBoxRightRight.Size = new System.Drawing.Size(159, 141);
            this.pctBoxRightRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxRightRight.TabIndex = 18;
            this.pctBoxRightRight.TabStop = false;
            this.pctBoxRightRight.Visible = false;
            // 
            // pctBoxUpUp
            // 
            this.pctBoxUpUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctBoxUpUp.Image = global::Pacman.WinForms.Properties.Resources.PacmanUp;
            this.pctBoxUpUp.Location = new System.Drawing.Point(800, 31);
            this.pctBoxUpUp.Name = "pctBoxUpUp";
            this.pctBoxUpUp.Size = new System.Drawing.Size(159, 142);
            this.pctBoxUpUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxUpUp.TabIndex = 19;
            this.pctBoxUpUp.TabStop = false;
            this.pctBoxUpUp.Visible = false;
            // 
            // pctBoxDownDown
            // 
            this.pctBoxDownDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pctBoxDownDown.Image = global::Pacman.WinForms.Properties.Resources.PacmanDown;
            this.pctBoxDownDown.Location = new System.Drawing.Point(595, 112);
            this.pctBoxDownDown.Name = "pctBoxDownDown";
            this.pctBoxDownDown.Size = new System.Drawing.Size(158, 137);
            this.pctBoxDownDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctBoxDownDown.TabIndex = 20;
            this.pctBoxDownDown.TabStop = false;
            this.pctBoxDownDown.Visible = false;
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(981, 638);
            this.Controls.Add(this.pctBoxDownDown);
            this.Controls.Add(this.pctBoxUpUp);
            this.Controls.Add(this.pctBoxRightRight);
            this.Controls.Add(this.pctBoxLeftLeft);
            this.Controls.Add(this.pctBoxDown);
            this.Controls.Add(this.pctBoxUp);
            this.Controls.Add(this.pctBoxRight);
            this.Controls.Add(this.pctBoxLeft);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblExplainDown);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.lblDown);
            this.Controls.Add(this.lblExplainUp);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lblUp);
            this.Controls.Add(this.lblExpainRight);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblExpainLeft);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.lblLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ControlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control";
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxLeftLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxRightRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxUpUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxDownDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label lblExpainLeft;
        private System.Windows.Forms.Label lblExpainRight;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblExplainUp;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label lblUp;
        private System.Windows.Forms.Label lblExplainDown;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label lblDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pctBoxLeft;
        private System.Windows.Forms.PictureBox pctBoxRight;
        private System.Windows.Forms.PictureBox pctBoxUp;
        private System.Windows.Forms.PictureBox pctBoxDown;
        private System.Windows.Forms.PictureBox pctBoxLeftLeft;
        private System.Windows.Forms.PictureBox pctBoxRightRight;
        private System.Windows.Forms.PictureBox pctBoxUpUp;
        private System.Windows.Forms.PictureBox pctBoxDownDown;
    }
}