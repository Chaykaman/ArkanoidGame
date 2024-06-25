using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidGame
{
    public class GameArea
    {
        
        public int AreaWidth { get; }

      
        public int AreaHeight { get; }

        
        public PictureBox AreaView = new PictureBox();

       
        public GameArea()
        {
           
            AreaWidth = 516;

          
            AreaHeight = 682;
        }

    }
}
