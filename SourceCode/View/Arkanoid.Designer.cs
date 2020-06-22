using System.ComponentModel;

namespace Arkanoid
{
    partial class Arkanoid
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Timer1Game = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Timer1Game
            // 
            this.Timer1Game.Tick += new System.EventHandler(this.Timer1Game_Tick);
            // 
            // Arkanoid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "Arkanoid";
            this.Size = new System.Drawing.Size(807, 444);
            this.Load += new System.EventHandler(this.Arkanoid_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Arkanoid_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Arkanoid_MouseMove);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer Timer1Game;
    }
}