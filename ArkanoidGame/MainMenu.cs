using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidGame
{
    public partial class MainMenu : Form
    {
       
        public MainMenu()
        {
            InitializeComponent();
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            ArcanoidGame arcanoidGame = new ArcanoidGame();
            arcanoidGame.Show();
            this.Hide();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LvlContstructBtn_Click(object sender, EventArgs e)
        {
            LevelConstructor lvlconst = new LevelConstructor();
            lvlconst.Show();
            this.Hide();
        }

        private void RulesBtn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Цель игры - уничтожить все блоки, как играть - управлять платформой с помощью 'A', 'D', а так же не забывайте собирать бонусы");
            RulePictureBox.Visible = true;
            VisibleScoreBtn.Visible = true;

        }

        private void Recordbtn_Click(object sender, EventArgs e)
        {
            listBoxScores.Visible = true;
            VisibleScoreBtn.Visible = true;
            LoadScores();
        }

        private void LoadScores()
        {
            listBoxScores.Items.Clear();
            var scores = ScoreManager.LoadScores();
           
            for (int i = 0; i < scores.Count && i < 5; i++)
            {                                                       
                
                listBoxScores.Items.Add($"{i + 1}. {scores[i]}");
            }
        }

        private void VisibleScoreBtn_Click(object sender, EventArgs e)
        {
            listBoxScores.Visible=false;
            VisibleScoreBtn.Visible=false;
            RulePictureBox.Visible=false;
        }

     
    }
}
