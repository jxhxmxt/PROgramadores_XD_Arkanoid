namespace Arkanoid
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonScore = new System.Windows.Forms.Button();
            this.buttonOut = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage =
                ((System.Drawing.Image) (resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 3);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(924, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackgroundImage =
                ((System.Drawing.Image) (resources.GetObject("buttonPlay.BackgroundImage")));
            this.buttonPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.buttonPlay.ForeColor = System.Drawing.Color.GhostWhite;
            this.buttonPlay.Location = new System.Drawing.Point(311, 161);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(305, 158);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonScore
            // 
            this.buttonScore.BackgroundImage =
                ((System.Drawing.Image) (resources.GetObject("buttonScore.BackgroundImage")));
            this.buttonScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.buttonScore.ForeColor = System.Drawing.Color.GhostWhite;
            this.buttonScore.Location = new System.Drawing.Point(311, 321);
            this.buttonScore.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonScore.Name = "buttonScore";
            this.buttonScore.Size = new System.Drawing.Size(305, 158);
            this.buttonScore.TabIndex = 2;
            this.buttonScore.Text = "Score";
            this.buttonScore.UseVisualStyleBackColor = true;
            this.buttonScore.Click += new System.EventHandler(this.buttonScore_Click);
            // 
            // buttonOut
            // 
            this.buttonOut.BackgroundImage =
                ((System.Drawing.Image) (resources.GetObject("buttonOut.BackgroundImage")));
            this.buttonOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.buttonOut.ForeColor = System.Drawing.Color.GhostWhite;
            this.buttonOut.Location = new System.Drawing.Point(311, 481);
            this.buttonOut.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonOut.Name = "buttonOut";
            this.buttonOut.Size = new System.Drawing.Size(305, 159);
            this.buttonOut.TabIndex = 3;
            this.buttonOut.Text = "Out";
            this.buttonOut.UseVisualStyleBackColor = true;
            this.buttonOut.Click += new System.EventHandler(this.buttonOut_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonOut, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonPlay, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonScore, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(928, 641);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(928, 641);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button buttonOut;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonScore;
        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}