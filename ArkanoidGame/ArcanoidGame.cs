using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArkanoidGame
{
    public partial class ArcanoidGame : Form
    {
        public ArcanoidGame()
        {
            // Инициализация формы
            InitializeComponent();

            // Включение двойной буферизации для более плавного отображения
            DoubleBuffered = true;

            // Инициализация меток для отображения счета, жизней и сообщений
          
            Msg.Text = "Чтобы начать";
            Continue.Text = "Нажмите пробел";
        }

        private void ArcanoidGame_Load(object sender, EventArgs e)
        {
            // Создание экземпляра класса Game
            Game game = new Game(GameBall, GamePlatform, GameArea, GameTimer, ScoreCounter, Msg, GameLevel, LiveCounter, Continue);

            // Присоединение обработчиков событий для управления игрой
            KeyUp += game.StartGame;            // Начало игры при нажатии пробела
            GameTimer.Tick += game.GameTime;    // Обновление времени игры
            GameTimer.Tick += game.Collision;   // Проверка столкновений
            KeyDown += game.KeyIsDown;          // Обработка нажатий клавиш (движение)
            KeyUp += game.KeyIsUp;              // Обработка отпускания клавиш (остановка движения)
            KeyUp += game.GoNext;               // Переход к следующему уровню при нажатии Enter
            KeyUp += game.PauseGame;
            KeyUp += game.ResumeGame;
        }

        private void Extilbl_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }


    

   

}
