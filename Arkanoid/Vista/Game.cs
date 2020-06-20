using System;
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
            unUsuario = new Usuario();
        }

        private void txbUsu_KeyDown(object sender, KeyEventArgs e)
        {
            //Se almacena el usuario en Base y se pasa al userControl Arkanoid
            if (e.KeyCode == Keys.Enter)
            {
                unUsuario.Nombre = txbUsu.Text;
                if (unUsuario.Nombre.Length > 100)
                {
                    NicknameLongException longException = new NicknameLongException("Nickname no puede contener" +
                                                                                    "mas de 100 caracteres");
                    MessageBox.Show(longException.Message);
                }
                else if(unUsuario.Nombre.Length == 0)
                {
                    NicknameEmptyException emptyException = new NicknameEmptyException("Nombre no puede estar" +
                                                                                       "vacio");
                    MessageBox.Show(emptyException.Message);
                }
                else
                {
                    try
                    {
                        UsuarioDAO.addUsuario(unUsuario);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nickname ya existe, bienvenido");
                    }
                    
                    label1.Hide();
                    txbUsu.Hide();
                    
                    gameArkanoid = new Arkanoid(unUsuario);
                    gameArkanoid.Dock = DockStyle.Fill;
                    gameArkanoid.Height = Height;
                    gameArkanoid.Width = Width;
                    Controls.Add(gameArkanoid);
                }
            }
        }
    }
}