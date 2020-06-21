using System;
using System.Drawing;
using System.Windows.Forms;
using Arkanoid.Modelo;

namespace Arkanoid
{
    public partial class Game : Form
    {
        private Arkanoid gameArkanoid;
        
        //Se le solicitara un nombre de usuario al jugador
        private User anUser;
        
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
            
            //se instancia un usuario
            anUser = new User();
            
            //ventana donde se ingresa el nickname
            Nickname nick = new Nickname(anUser);
            nick.ShowDialog();

            //se recibe el nombre que retorna la ventana del nickname desde su metodo UnUser
            anUser = nick.UnUser();

            //se instancia el UC del juego
            gameArkanoid = new Arkanoid(anUser);
            gameArkanoid.Dock = DockStyle.Fill;
            gameArkanoid.Height = Height;
            gameArkanoid.Width = Width;
            Controls.Add(gameArkanoid); 
        }
        
    }
}