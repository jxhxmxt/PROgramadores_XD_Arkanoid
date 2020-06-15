using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Game ventana = new Game();
            ventana.ShowDialog();
        }

        private void buttonScore_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}