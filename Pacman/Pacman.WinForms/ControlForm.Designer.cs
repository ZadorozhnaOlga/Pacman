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
            this.button1 = new System.Windows.Forms.Button();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblExplainUp = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lblUp = new System.Windows.Forms.Label();
            this.lblExplainDown = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.lblDown = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeft.Location = new System.Drawing.Point(31, 59);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(75, 31);
            this.lblLeft.TabIndex = 0;
            this.lblLeft.Text = "Press";
            // 
            // btnLeft
            // 
            this.btnLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLeft.BackgroundImage")));
            this.btnLeft.Location = new System.Drawing.Point(133, 44);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 68);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.UseVisualStyleBackColor = true;
            // 
            // lblExpainLeft
            // 
            this.lblExpainLeft.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpainLeft.Location = new System.Drawing.Point(231, 59);
            this.lblExpainLeft.Name = "lblExpainLeft";
            this.lblExpainLeft.Size = new System.Drawing.Size(397, 28);
            this.lblExpainLeft.TabIndex = 2;
            this.lblExpainLeft.Text = "to move the Pacman to the Left";
            // 
            // lblExpainRight
            // 
            this.lblExpainRight.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpainRight.Location = new System.Drawing.Point(231, 162);
            this.lblExpainRight.Name = "lblExpainRight";
            this.lblExpainRight.Size = new System.Drawing.Size(397, 28);
            this.lblExpainRight.TabIndex = 5;
            this.lblExpainRight.Text = "to move the Pacman to the Right";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(133, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 68);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRight.Location = new System.Drawing.Point(31, 162);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(75, 31);
            this.lblRight.TabIndex = 3;
            this.lblRight.Text = "Press";
            // 
            // lblExplainUp
            // 
            this.lblExplainUp.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplainUp.Location = new System.Drawing.Point(231, 266);
            this.lblExplainUp.Name = "lblExplainUp";
            this.lblExplainUp.Size = new System.Drawing.Size(397, 28);
            this.lblExplainUp.TabIndex = 8;
            this.lblExplainUp.Text = "to move the Pacman Up";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Location = new System.Drawing.Point(133, 251);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 68);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblUp
            // 
            this.lblUp.AutoSize = true;
            this.lblUp.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUp.Location = new System.Drawing.Point(31, 266);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(75, 31);
            this.lblUp.TabIndex = 6;
            this.lblUp.Text = "Press";
            // 
            // lblExplainDown
            // 
            this.lblExplainDown.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplainDown.Location = new System.Drawing.Point(231, 372);
            this.lblExplainDown.Name = "lblExplainDown";
            this.lblExplainDown.Size = new System.Drawing.Size(397, 28);
            this.lblExplainDown.TabIndex = 11;
            this.lblExplainDown.Text = "to move the Pacman Down";
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.Location = new System.Drawing.Point(133, 357);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 68);
            this.button3.TabIndex = 10;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // lblDown
            // 
            this.lblDown.AutoSize = true;
            this.lblDown.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDown.Location = new System.Drawing.Point(31, 372);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(75, 31);
            this.lblDown.TabIndex = 9;
            this.lblDown.Text = "Press";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Jokerman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 462);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "Press SPACE to Pause the game";
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(923, 604);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblExplainDown);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblDown);
            this.Controls.Add(this.lblExplainUp);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblUp);
            this.Controls.Add(this.lblExpainRight);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblExpainLeft);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.lblLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControlForm";
            this.Text = "Control";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label lblExpainLeft;
        private System.Windows.Forms.Label lblExpainRight;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblExplainUp;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblUp;
        private System.Windows.Forms.Label lblExplainDown;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblDown;
        private System.Windows.Forms.Label label1;
    }
}