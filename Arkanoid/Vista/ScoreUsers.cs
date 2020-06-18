using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Arkanoid.Controlador;
using Arkanoid.Modelo;

namespace Arkanoid
{
    public partial class ScoreUsers : Form
    {
        private List<UsuariosxPuntaje> listaPuntajes;
        private List<Puntuacion> puntuaciones;
        public ScoreUsers()
        {
            InitializeComponent();

        }

        private void ScoreUsers_Load(object sender, EventArgs e)
        {
            cargarPuntajes();
        }

        private void cargarPuntajes()
        {
            puntuaciones = PuntuacionDAO.getLista();
            listaPuntajes = PuntuacionDAO.getTop(puntuaciones);
            int size = listaPuntajes.Count;

            if (size == 1)
            {
                lblPlayer1.Text = listaPuntajes[0].Nombre;
                lblScore1.Text = listaPuntajes[0].Puntaje.ToString();
            }
            if (size == 2)
            {
                lblPlayer2.Text = listaPuntajes[1].Nombre;
                lblScore2.Text = listaPuntajes[1].Puntaje.ToString();
            }
            if (size == 3)
            {
                lblPlayer3.Text = listaPuntajes[3].Nombre;
                lblScore3.Text = listaPuntajes[3].Puntaje.ToString();
            }
            if (size == 4)
            {
                lblPlayer4.Text = listaPuntajes[3].Nombre;
                lblScore4.Text = listaPuntajes[3].Puntaje.ToString();
            }
            if (size == 5)
            {
                lblPlayer5.Text = listaPuntajes[4].Nombre;
                lblScore5.Text = listaPuntajes[4].Puntaje.ToString();
            }
            if (size == 6)
            {
                lblPlayer6.Text = listaPuntajes[5].Nombre;
                lblScore6.Text = listaPuntajes[5].Puntaje.ToString();
            }
            if (size == 7)
            {
                lblPlayer7.Text = listaPuntajes[6].Nombre;
                lblScore7.Text = listaPuntajes[6].Puntaje.ToString();
            }
            if (size == 8)
            {
                lblPlayer8.Text = listaPuntajes[7].Nombre;
                lblScore8.Text = listaPuntajes[7].Puntaje.ToString();
            }
            if (size == 9)
            {
                lblPlayer9.Text = listaPuntajes[8].Nombre;
                lblScore9.Text = listaPuntajes[8].Puntaje.ToString();
            }
            if (size == 10)
            {
                lblPlayer10.Text = listaPuntajes[9].Nombre;
                lblScore10.Text = listaPuntajes[9].Puntaje.ToString();
            }
        }
    }
}