using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Arkanoid.Modelo;

namespace Arkanoid
{
    public partial class Arkanoid : UserControl
    {
        private Blocks[,] BlocksGame;
        private PictureBox player, ball;
        private Panel score;
        private Label lblRemainingLives, lblScore;
        
        // Para trabajar con picicturebox + label
        private PictureBox heart;

        // Para trabajar con n picturebox
        private PictureBox[] heartArray;
        
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
            ScorePanel();
            
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
                    else if(i == 1 || i == 2) BlocksGame[i, j].hits = 2;
                    else BlocksGame[i, j].hits = 1;

                    //tamaño de los bloques
                    BlocksGame[i, j].Height = bkHeight;
                    BlocksGame[i, j].Width = bkWidth;
                    
                    //posicion de los bloques
                    BlocksGame[i, j].Left = j * (bkWidth + 1);
                    BlocksGame[i, j].Top = i * bkHeight + score.Height + 1;
                    
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
            if (!DataGame.startGame)
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
            if(!DataGame.startGame)
                return;
            
            MovementBall?.Invoke();
        }
        
        //Colision de la pelota con los objetos en pantalla
        private void CollisionsBall()
        {
            if (ball.Bottom > Height)
            {
                DataGame.lives--;
                DataGame.startGame = false;
                Timer1Game.Stop();
                
                RepositionElements();
                UpdateElements();

                if (DataGame.lives == 0)
                {    //termina el juego
                    Timer1Game.Stop();
                    
                    MessageBox.Show("Te has quedado sin vidas! Tu puntaje: " + DataGame.score,
                        "Perdiste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    DataGame.RestartGame();
                    ParentForm.Close();
                }
                
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
                        //se hace el calculo de los puntos
                        DataGame.score += (BlocksGame[i, j].hits * (5 - i));
                        
                        BlocksGame[i, j].hits--;

                        if (BlocksGame[i, j].hits == 0)
                        {
                            Controls.Remove(BlocksGame[i, j]);
                            BlocksGame[i, j] = null;
                        }
                        else
                        {
                            //se cambian los sprites cuando hay colision con los bloques
                            if (i == 2)
                            {
                                BlocksGame[i, j].BackgroundImage = Image.FromFile("../../../Sprites/broked3.png");
                            }
                            if (i == 1)
                            {
                                BlocksGame[i, j].BackgroundImage = Image.FromFile("../../../Sprites/broked2.png");
                            }
                            if (i == 0 && BlocksGame[i, j].hits > 1)
                            {
                                BlocksGame[i, j].BackgroundImage = Image.FromFile("../../../Sprites/broked1.png");
                            }
                            if (i == 0 && BlocksGame[i, j].hits == 1)
                            {
                                BlocksGame[i, j].BackgroundImage = Image.FromFile("../../../Sprites/broked11.png");
                            }

                        }

                        DataGame.dirY = -DataGame.dirY;
                        
                        lblScore.Text = "Score: " + DataGame.score;
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
            DataGame.startGame = true;
            Timer1Game.Start();
        }
        
        //panel de puntajes
         private void ScorePanel()
        {
            // Instanciar panel
            score = new Panel();

            // Setear elementos del panel
            score.Width = Width;
            score.Height = (int)(Height * 0.07);

            score.Top = score.Left = 0;

            score.BackColor = Color.Gray;

            #region Label + PictureBox
            // Instanciar pb
            heart = new PictureBox();

            heart.Height = heart.Width = score.Height;

            heart.Top = 0;
            heart.Left = 20;

            heart.BackgroundImage = Image.FromFile("../../../Sprites/HeartFill.png");
            heart.BackgroundImageLayout = ImageLayout.Stretch;
            #endregion

            #region N cantidad de PictureBox
            heartArray = new PictureBox[DataGame.lives];

            for(int i = 0; i < DataGame.lives; i++)
            {
                // Instanciacion de pb
                heartArray[i] = new PictureBox();

                heartArray[i].Height = heartArray[i].Width = score.Height;

                heartArray[i].BackgroundImage = Image.FromFile("../../../Sprites/HeartFill.png");
                heartArray[i].BackgroundImageLayout = ImageLayout.Stretch;

                heartArray[i].Top = 0;

                if (i == 0)
                    // corazones[i].Left = 20;
                    heartArray[i].Left = score.Width / 2;
                else
                {
                    heartArray[i].Left = heartArray[i - 1].Right + 5;
                }
            }
            #endregion

            // Instanciar labels
            lblRemainingLives = new Label();
            lblScore = new Label();

            // Setear elementos de los labels
            lblRemainingLives.ForeColor = lblScore.ForeColor = Color.White;

            //se setean los valores de los lbl
            lblRemainingLives.Text = "x " + DataGame.lives;
            lblScore.Text = "Score: " + DataGame.score;

            lblRemainingLives.Font = lblScore.Font = new Font("Microsoft YaHei", 24F);
            lblRemainingLives.TextAlign = lblScore.TextAlign = ContentAlignment.MiddleCenter;

            lblRemainingLives.Left = heart.Right + 5;
            lblScore.Left = Width - 250;
            lblScore.Width = 250;

            lblRemainingLives.Height = lblScore.Height = score.Height;

            score.Controls.Add(heart);
            score.Controls.Add(lblRemainingLives);
            score.Controls.Add(lblScore);

            foreach(var pb in heartArray)
            {
                score.Controls.Add(pb);
            }

            Controls.Add(score);
        }
         
         //se van actualizando los corazones en pantalla y las vidas
         private void UpdateElements()
         {
             lblRemainingLives.Text = "x " + DataGame.lives;

             if (DataGame.lives == 1)
             {    //cuando le queda una vida se pone un gif de un corazon parpadeando
                 heartArray[DataGame.lives - 1].Image = Image.FromFile("../../../Sprites/HeartAnimated.gif");
                 heartArray[DataGame.lives - 1].SizeMode = PictureBoxSizeMode.StretchImage;
             }

             if (DataGame.lives == 0)
             {    //cuando terminan las vidas se quita el gif y se pone la img normal
                 heartArray[DataGame.lives].Image = Image.FromFile("../../../Sprites/HeartEmpty.png");
                 heartArray[DataGame.lives].SizeMode = PictureBoxSizeMode.StretchImage;
             }
             
             //a los demas picturebox que no son la posicion 1 y 0, se les pone img normales
             heartArray[DataGame.lives].BackgroundImage = Image.FromFile("../../../Sprites/HeartEmpty.png");
             
             heartArray[DataGame.lives] = null;
         }
         
         //se colocan en las posiciones por defecto la bola y el jugador al perder una vida
         private void RepositionElements()
         {
             player.Left = (Width / 2) - (player.Width / 2);
             ball.Top = player.Top - ball.Height - 30;
             ball.Left = player.Left + (player.Width / 2) - (ball.Width / 2);
         }
    }
}