using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidGame
{
    internal class Blocks
    {
        public int BlockHeight { get; }
        public int BlockWidth { get; }

        public PictureBox BlocksView = new PictureBox();

        public Blocks()
        {
            BlockHeight = 33;
            BlockWidth = 100;
        }

    
    }
}
