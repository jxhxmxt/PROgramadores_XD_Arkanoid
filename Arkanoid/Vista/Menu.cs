using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arkanoid.Controlador;
using Arkanoid.Modelo;

namespace Arkanoid
{
    public partial class Menu : Form
    {
        private User _user;
        private List<Score> Scores;
        private List<UsserxScore> _usersxScore;
        public Menu()
        {
            InitializeComponent();
            
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            Scores = ScoreDAO.getLista();
            _usersxScore = ScoreDAO.getTop(Scores);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Game windowgame = new Game();
            windowgame.ShowDialog();
        }

        private void buttonScore_Click(object sender, EventArgs e)
        {
            ScoreUsers window = new ScoreUsers();
            window.CloseAction = () =>
            {
                Show(); 
                
            };
            
            window.ShowDialog();
            //Hide();
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}