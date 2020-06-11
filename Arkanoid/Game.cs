using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Game : Form
    {
        private Blocks[,] BlocksGame;
        private PictureBox player;
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
            //picturebox de la plataforma del jugador
            player = new PictureBox();
            player.BackgroundImage = Image.FromFile("../../../Sprites/Player.png");
            player.BackgroundImageLayout = ImageLayout.Stretch;
            player.Width = 150;
            player.Height = 50;
            player.Top = (Height - player.Height) - 80;
            player.Left = (Width / 2) - (player.Width / 2);
            
            Controls.Add(player);
            LoadBloks();
        }
        
        //metodo de crear bloques
        private void LoadBloks()
        {
            int xAxis = 10;
            int yAxis = 4;

            int bkHeight = (int) (Height * 0.3) / yAxis;
            int bkWidth = (Width - 20) / xAxis;
            
            BlocksGame = new Blocks[yAxis,xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    BlocksGame[i,j] = new Blocks();

                    //tamaño de los bloques
                    BlocksGame[i, j].Height = bkHeight;
                    BlocksGame[i, j].Width = bkWidth;
                    //posicion de los bloques
                    BlocksGame[i, j].Left = j * (bkWidth + 1);
                    BlocksGame[i, j].Top = i * bkHeight;
                    //imagen del bloque
                    if(i == j || i + j == 9)
                        BlocksGame[i,j].BackgroundImage = Image.FromFile("../../../Sprites/Block5.png");
                    else
                        BlocksGame[i,j].BackgroundImage = Image.FromFile("../../../Sprites/Block" + (i + 1) + ".png");
                    BlocksGame[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    //se agrega el bloque al form
                    Controls.Add(BlocksGame[i,j]);
                }
            }
        }


        private void Game_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < Width - (player.Width + 10))
                player.Left = e.X;
        }
    }
}