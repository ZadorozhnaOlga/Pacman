﻿using System.Windows.Forms;
using Pacman.GameEngine;
using System.Configuration;
using System.IO;
using System.Timers;

namespace Pacman.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //System.EventHandler Inky;// = new System.EventHandler();

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.lblScores = new System.Windows.Forms.Label();
            this.lblGetScores = new System.Windows.Forms.Label();
            this.inkyTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // lblScores
            // 
            this.lblScores.Font = new System.Drawing.Font("Jokerman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScores.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblScores.Location = new System.Drawing.Point(678, 46);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(115, 28);
            this.lblScores.TabIndex = 0;
            this.lblScores.Text = "SCORES :";
            // 
            // lblGetScores
            // 
            this.lblGetScores.Font = new System.Drawing.Font("Jokerman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGetScores.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblGetScores.Location = new System.Drawing.Point(799, 46);
            this.lblGetScores.Name = "lblGetScores";
            this.lblGetScores.Size = new System.Drawing.Size(60, 23);
            lblGetScores.Text = Game.Scores.ToString();
            this.lblGetScores.TabIndex = 1;
            // 

            //

            this.inkyTimer.Interval = 500;
            this.inkyTimer.Tick += new System.EventHandler(this.inkyTimer_Tick);
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(884, 732);
            this.Controls.Add(this.lblGetScores);
            this.Controls.Add(this.lblScores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Pacman";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.GameLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);

            this.Move += new System.EventHandler(this.MainForm_MoveInky);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);



           
        }


        
         

        #endregion

        
        private FontDialog fontDialog1;
        private System.Diagnostics.EventLog eventLog1;
        private Label lblGetScores;
        private Label lblScores;
        private System.Windows.Forms.Timer inkyTimer;
        
        
    }
}
