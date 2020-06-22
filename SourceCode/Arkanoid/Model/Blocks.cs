using System.Windows.Forms;

namespace Arkanoid
{
    public class Blocks : PictureBox
    {
        public int hits { get; set; }
        
		//instancia bloque
        public Blocks() : base(){}
    }
}