using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Arkanoid : UserControl
    {
        private Blocks[,] BlocksGame;
        private PictureBox player, ball;
        
        private delegate void ActionsBall();
        private readonly ActionsBall MovementBall;
        public Action GameOver;

        public Arkanoid()
        {
            InitializeComponent();

            MovementBall = CollisionsBall;
            MovementBall += MoveBall;
        }

        private void Arkanoid_Load(object sender, EventArgs e)
        {
            //picturebox de la plataforma del jugador
            player = new PictureBox();
            player.Width = 150;
            player.Height = 50;
            player.BackgroundImage = Image.FromFile("../../../Sprites/Player.png");
            player.BackgroundImageLayout = ImageLayout.Stretch;
            
            player.Top = (Height - player.Height) - 80;
            player.Left = (Width / 2) - (player.Width / 2);
            
            //picturebox de la pelota
            ball = new PictureBox();
            ball.Width = ball.Height = 20;
            ball.BackgroundImage = Image.FromFile("../../../Sprites/Ball.png");
            ball.BackgroundImageLayout = ImageLayout.Stretch;
            
            ball.Top = player.Top - ball.Height;
            ball.Left = player.Left + (player.Width / 2) - (ball.Width / 2);
            
            Controls.Add(ball);
            Controls.Add(player);

            LoadBloks();
            Timer1Game.Start();
        }
        
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

                    //se setean los golpes a los cuales se destruiran los bloques
                    if(i == 0) BlocksGame[i, j].hits = 3;
                    else if(i == 1 || i == 2) BlocksGame[i, j].hits = 1;
                    else BlocksGame[i, j].hits = 1;

                    //tamaño de los bloques
                    BlocksGame[i, j].Height = bkHeight;
                    BlocksGame[i, j].Width = bkWidth;
                    
                    //posicion de los bloques
                    BlocksGame[i, j].Left = j * (bkWidth + 1);
                    BlocksGame[i, j].Top = i * bkHeight;
                    
                    //imagen del bloque
                    BlocksGame[i,j].BackgroundImage = Image.FromFile("../../../Sprites/Block" + (i + 1) + ".png");
                    BlocksGame[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    
                    //se agrega el bloque al form
                    Controls.Add(BlocksGame[i,j]);
                }
            }
        }

        //movimiento del cursor
        private void Arkanoid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!DataGame.StartGame)
            {
                if (e.X < (Width - player.Width))
                {
                    player.Left = e.X;
                    ball.Left = player.Left + (player.Width / 2) - (ball.Width / 2);
                }
            }
            else
            {
                if (e.X < (Width - player.Width))
                    player.Left = e.X;
            }
            
        }

        //timer de movimiento de la bola
        private void Timer1Game_Tick(object sender, EventArgs e)
        {
            if(!DataGame.StartGame)
                return;
            
            MovementBall?.Invoke();
        }
        
        //Colision de la pelota con los objetos en pantalla
        private void CollisionsBall()
        {
            if (ball.Bottom > Height)
            {
                Timer1Game.Stop();
                Application.Exit();
            }

            //colision con laterales de la pantalla
            if (ball.Left < 0 || ball.Right > Width)
            {
                DataGame.dirX = -DataGame.dirX;
                
            }

            //colision con la parte Top de la pantalla
            if (ball.Top < 0)
            {
                DataGame.dirY = -DataGame.dirY;
                return;
            }
                
            //colision con la plataforma
            if (ball.Bounds.IntersectsWith(player.Bounds))
            {
                DataGame.dirY = -DataGame.dirY;
            }

            for (int i = 3; i >= 0; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    //colision con los bloques
                    if (BlocksGame[i, j] != null && ball.Bounds.IntersectsWith(BlocksGame[i, j].Bounds))
                    {
                        BlocksGame[i, j].hits--;

                        if (BlocksGame[i, j].hits == 0)
                        {
                            Controls.Remove(BlocksGame[i, j]);
                            BlocksGame[i, j] = null;
                        }
                        else
                        {
                            //se cambian los sprites cuando hay colision con los bloques
                            if(i == 2)
                                BlocksGame[i, j].BackgroundImage = Image.FromFile("../../../Sprites/broked3.png");
                            if(i == 1)
                                BlocksGame[i, j].BackgroundImage = Image.FromFile("../../../Sprites/broked2.png");
                            if(i == 0 && BlocksGame[i,j].hits > 1) 
                                BlocksGame[i, j].BackgroundImage = Image.FromFile("../../../Sprites/broked1.png");
                            if(i == 0 && BlocksGame[i,j].hits == 1) 
                                BlocksGame[i, j].BackgroundImage = Image.FromFile("../../../Sprites/broked11.png");
                        }

                        DataGame.dirY = -DataGame.dirY;

                        return;
                    }
                }
            }
        }
        
        //movimiento de la bola
        public void MoveBall()
        {
            ball.Left += DataGame.dirX;
            ball.Top += DataGame.dirY;
        }

        //dar click en la pantalla para comenzar el juego
        private void Arkanoid_MouseClick(object sender, MouseEventArgs e)
        {
            DataGame.StartGame = true;
        }
    }
}