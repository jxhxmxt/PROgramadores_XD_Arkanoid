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
        private Usuario _usuario;
        private List<Puntuacion> Puntuaciones;
        private List<UsuariosxPuntaje> _usuariosxPuntajes;
        public Menu()
        {
            InitializeComponent();
            
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            Puntuaciones = PuntuacionDAO.getLista();
            _usuariosxPuntajes = PuntuacionDAO.getTop(Puntuaciones);
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