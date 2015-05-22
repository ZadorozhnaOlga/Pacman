﻿namespace Pacman.WinForms
{
    partial class GameMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameMenu));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnControl = new System.Windows.Forms.Button();
            this.btnRules = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStart.Font = new System.Drawing.Font("Jokerman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(231, 446);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(185, 75);
            this.btnStart.TabIndex = 0;
            this.btnStart.TabStop = false;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseEnter += new System.EventHandler(this.btnStart_MouseEnter);
            this.btnStart.MouseLeave += new System.EventHandler(this.btnStart_MouseLeave);
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnQuit.Font = new System.Drawing.Font("Jokerman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(231, 559);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(185, 75);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "QUIT";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            this.btnQuit.MouseEnter += new System.EventHandler(this.btnQuit_MouseEnter);
            this.btnQuit.MouseLeave += new System.EventHandler(this.btnQuit_MouseLeave);
            // 
            // btnControl
            // 
            this.btnControl.BackColor = System.Drawing.Color.DarkOrange;
            this.btnControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnControl.Font = new System.Drawing.Font("Jokerman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnControl.Location = new System.Drawing.Point(231, 336);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(185, 75);
            this.btnControl.TabIndex = 2;
            this.btnControl.TabStop = false;
            this.btnControl.Text = "CONTROL";
            this.btnControl.UseVisualStyleBackColor = false;
            this.btnControl.Click += new System.EventHandler(this.btnControls_Click);
            this.btnControl.MouseEnter += new System.EventHandler(this.btnControl_MouseEnter);
            this.btnControl.MouseLeave += new System.EventHandler(this.btnControl_MouseLeave);
            // 
            // btnRules
            // 
            this.btnRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRules.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRules.Font = new System.Drawing.Font("Jokerman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRules.Location = new System.Drawing.Point(231, 221);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(185, 75);
            this.btnRules.TabIndex = 3;
            this.btnRules.TabStop = false;
            this.btnRules.Text = "RULES";
            this.btnRules.UseVisualStyleBackColor = false;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            this.btnRules.MouseEnter += new System.EventHandler(this.btnRules_MouseEnter);
            this.btnRules.MouseLeave += new System.EventHandler(this.btnRules_MouseLeave);
            // 
            // GameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Pacman.WinForms.Properties.Resources.StartMenu;
            this.ClientSize = new System.Drawing.Size(642, 664);
            this.Controls.Add(this.btnRules);
            this.Controls.Add(this.btnControl);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameMenu";
            this.Load += new System.EventHandler(this.GameMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Button btnRules;


    }
}