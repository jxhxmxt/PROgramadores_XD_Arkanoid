using System;
using System.Drawing;
using System.Windows.Forms;
using Arkanoid.Controlador;
using Arkanoid.Modelo;

namespace Arkanoid
{
    public partial class Nickname : Form
    {
        private User anUser;
        public Nickname(User user)
        {
            InitializeComponent();
            anUser = user;
        }

        private void Nickname_Load(object sender, EventArgs e)
        {
            BackgroundImage = Image.FromFile("../../../Sprites/BackgroundNickname.png");
            BackgroundImageLayout = ImageLayout.Stretch;
            
            anUser = new User();
        }

        private void txbNickname_KeyDown(object sender, KeyEventArgs e)
        {
            //Se almacena el usuario en Base y se pasa al userControl Arkanoid
            if (e.KeyCode == Keys.Enter)
            {
                try
                {   //se toma el nombre del usuario del textbox
                    anUser.Name = txbNickname.Text;
                    
                    if (anUser.Name.Length > 10)
                        throw new NicknameLongException("Nickname no puede contener mas de 10 caracteres");
                    if (anUser.Name.Length == 0)
                        throw  new NicknameEmptyException("Nombre no puede estar vacio");
                    
                    //se verifica si el usuario existe o no
                    if (UserDAO.ExistPlayer(anUser))
                    {
                        Close();
                        
                        throw new ExistPlayersExeption("Bienvenido nuevamente " + anUser.Name);
                    }
                        
                    
                    UserDAO.AddPlayer(anUser);

                    MessageBox.Show("Gracias por registrarte a Arkanoid");

                    Close();
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
                
            }
        }

        //se retorna el usuario que retorna la base con el nombre que se ha ingresado en el textbox
        public User UnUser()
        {
            //se instancia un usuario
            User u = new User();
            
            return u = UserDAO.GetPlayer(anUser);
        }
    }
}