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
        private Usuario unUsuario;
       

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
            BackgroundImage = Image.FromFile("../../../Sprites/BackgroundGame.png");
            BackgroundImageLayout = ImageLayout.Stretch;
            
            unUsuario = new Usuario();
        }

        private void txbUsu_KeyDown(object sender, KeyEventArgs e)
        {
            //Se almacena el usuario en Base y se pasa al userControl Arkanoid
            if (e.KeyCode == Keys.Enter)
            {
                try
                {   //se toma el nombre del usuario del textbox
                    unUsuario.Nombre = txbUsu.Text;
                    
                    if (unUsuario.Nombre.Length > 10)
                        throw new NicknameLongException("Nickname no puede contener mas de 10 caracteres");
                    if (unUsuario.Nombre.Length == 0)
                        throw  new NicknameEmptyException("Nombre no puede estar vacio");
                    
                    //se verifica si el usuario existe o no
                    if(UsuarioDAO.ExistPlayer(unUsuario))
                        throw new ExistPlayersExeption("Bienvenido nuevamente " + unUsuario.Nombre);
                    
                    UsuarioDAO.AddPlayer(unUsuario);

                    MessageBox.Show("Gracias por registrarte a Arkanoid");

                }
                catch (NicknameLongException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (NicknameEmptyException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (ExistPlayersExeption ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                label1.Hide();
                txbUsu.Hide();
                
                //se instancia el UC del juego
                gameArkanoid = new Arkanoid(unUsuario);
                gameArkanoid.Dock = DockStyle.Fill;
                gameArkanoid.Height = Height;
                gameArkanoid.Width = Width;
                Controls.Add(gameArkanoid);  
            }
        }
    }
}