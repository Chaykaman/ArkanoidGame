using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidGame
{
    abstract class Bonus
    {
        
        public int BonusSpeed { get; }

       
        public int BonusHeight { get; }

       
        public int BonusWidth { get; }

       
        public string BonusBackGround { get; }

        // Поле, представляющее бонус в виде элемента управления PictureBox.
        public PictureBox BonusView = new PictureBox();

     
        public Bonus(string bonusbackground)
        {
        
            BonusSpeed = 5;

           
            BonusHeight = 25;

          
            BonusWidth = 26;

         
            BonusBackGround = bonusbackground;
        }

    }
}
