using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidGame
{
    public class Platform
    {
       
        public int PlatformSpeed { get; set; }

      
        public int PlatformWidth { get; set; }

       
        public bool MoveLeft { get; set; }

     
        public bool MoveRight { get; set; }

      
        public PictureBox PlatformView = new PictureBox();

    
        public Platform()
        {
           
            PlatformSpeed = 12;

          
            PlatformWidth = 100;
        }
    }
}
