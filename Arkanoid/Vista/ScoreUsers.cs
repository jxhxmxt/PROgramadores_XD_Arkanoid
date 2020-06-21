using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Arkanoid.Controlador;
using Arkanoid.Modelo;

namespace Arkanoid
{
    public partial class ScoreUsers : Form
    {
        public delegate void OnCloseWindows();

        public OnCloseWindows CloseAction;
        
        // Delegates para manejar Hide y Show
        private List<UsserxScore> listScores;
        private List<Score> Scoresp;

        private Label[,] players;
        public ScoreUsers()
        {
            InitializeComponent();

        }

        private void ScoreUsers_Load(object sender, EventArgs e)
        {
            BackgroundImage = Image.FromFile("../../../Sprites/BackgroundTop.png");
            BackgroundImageLayout = ImageLayout.Stretch;
            
            LoadScores();
        }

        private void LoadScores()
        {
            try
            {
                Scoresp = ScoreDAO.getLista();
                listScores = ScoreDAO.getTop(Scoresp);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
            players = new Label[10,2];

            int sampleTop = label1.Bottom + 25, sampleLeft = 10;

            for (int i = 0; i < listScores.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    players[i, j] = new Label();

                    if (j == 0)
                    {
                        players[i, j].Text = listScores[i].Name;
                        players[i, j].Left = sampleLeft;
                    }
                    else
                    {
                        players[i, j].Text = listScores[i].Score.ToString();
                        players[i, j].Left = Width / 2 + sampleLeft;
                    }

                    players[i, j].Top = sampleTop + (sampleTop / 2) * i;

                    players[i, j].Height += 4;
                    players[i, j].Width += 20;

                    players[i, j].Font = new Font("Microsoft YaHei", 14F);
                    players[i, j].TextAlign = ContentAlignment.MiddleCenter;

                    Controls.Add(players[i, j]);
                }
            }
        }

        private void ScoreUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseAction?.Invoke();
        }
    }
}