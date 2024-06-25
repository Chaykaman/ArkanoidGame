using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidGame
{
    public class Ball
    {
       
        public int BallSpeedX { get; set; }

        
        public int BallSpeedY { get; set; }

      
        public PictureBox BallView = new PictureBox();

    
        public Ball()
        {
          
            BallSpeedX = 5; 

          
            BallSpeedY = 5;
        }
    }
}
