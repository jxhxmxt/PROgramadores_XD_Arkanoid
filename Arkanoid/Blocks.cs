using System.Windows.Forms;

namespace Arkanoid
{
    public class Blocks : PictureBox
    {
        public int hits { get; set; }
        public bool destroyed { get; set; }

        public Blocks() : base(){}
    }
}