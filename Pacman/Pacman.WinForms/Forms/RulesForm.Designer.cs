namespace Pacman.WinForms
{
    partial class RulesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesForm));
            this.richTxtBoxRules = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTxtBoxRules
            // 
            this.richTxtBoxRules.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.richTxtBoxRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTxtBoxRules.Location = new System.Drawing.Point(12, 37);
            this.richTxtBoxRules.Name = "richTxtBoxRules";
            this.richTxtBoxRules.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTxtBoxRules.Size = new System.Drawing.Size(454, 214);
            this.richTxtBoxRules.TabIndex = 0;
            this.richTxtBoxRules.Text = resources.GetString("richTxtBoxRules.Text");
            // 
            // RulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(501, 281);
            this.Controls.Add(this.richTxtBoxRules);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RulesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rules";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTxtBoxRules;
    }
}