﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Arkanoid.Controlador;
using Arkanoid.Modelo;

namespace Arkanoid
{
    public partial class Game : Form
    {
        private Arkanoid gameArkanoid;
        
        //Se le solicitara un nombre de usuario al jugador
        private string nombreUsuario;

        public Game()
        {
            InitializeComponent();
            //ventana maximizada
            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }
        
        private void Game_Load(object sender, EventArgs e)
        {
            
            gameArkanoid = new Arkanoid();
            gameArkanoid.Dock = DockStyle.Fill;
            gameArkanoid.Height = Height;
            gameArkanoid.Width = Width;
            
            Controls.Add(gameArkanoid);
        }
    }
}