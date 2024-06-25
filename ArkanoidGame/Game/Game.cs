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
    // Класс, управляющий игровым процессом в игре Arkanoid.
    class Game
    {
        
        // Объекты игры
        private Platform gamePlatform = new Platform();
        private Ball gameBall = new Ball();
        private GameArea gameArea = new GameArea();
        private Blocks gameBlocks = new Blocks();
        private Bonus gameBonus;

        // Таймеры для игры и бонусов
        private Timer gameTimer = new Timer();
        private Timer timeBonus = new Timer();

        // Элементы пользовательского интерфейса
        private readonly Label scoreCounter = new Label();
        private readonly Label msg = new Label();
        private readonly Label gameLevel = new Label();
        private readonly Label livesCounter = new Label();
        private readonly Label continueGame = new Label();

        // Дополнительные переменные
        private Random randomBallSpeed = new Random();
        private Random randBonus = new Random();
        private bool GameIsOver = true;
        private bool NextLevel;
        private int Score;
        private int Lives;
        private bool BonusIsLive = true;
        private int bonusTimeLeft = 0; // оставшееся время действия бонуса в миллисекундах


        // Конструктор класса Game, устанавливающий начальные параметры игры и пользовательского интерфейса
        public Game(PictureBox ballView, PictureBox platformView, PictureBox areaView, Timer gameTime, Label sCount, Label mess, Label gLevel, Label lCount, Label cont)
        {
         
            gameBall.BallView = ballView;
            gamePlatform.PlatformView = platformView;
            gameArea.AreaView = areaView;
            gameTimer = gameTime;

            scoreCounter = sCount;
            msg = mess;
            gameLevel = gLevel;
            livesCounter = lCount;
            continueGame = cont;
        }

        // Запуск игры по нажатию пробела
        public void StartGame(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                RemoveBlocks();
                GenerateLevelOne();
                GameSetup();
            }
        }

        // Обработка нажатия клавиш
        public void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                gamePlatform.MoveLeft = true;
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                gamePlatform.MoveRight = true;
            }
        }

        // Обработка отпускания клавиш
        public void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                gamePlatform.MoveLeft = false;
            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                gamePlatform.MoveRight = false;
            }
        }

        // Переход к следующему уровню (если игра завершена и нажат Enter)
        public void GoNext(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && GameIsOver == true)
            {
                RemoveBlocks();
                GameSetup();
                GenerateLevelOne();
            }
        }

        // Обработчик события таймера игры
        public void GameTime(object sender, EventArgs e)
        {
            
            MovePlatform();
            MoveBall();
            MoveBonus();
            CheckGame();
            scoreCounter.Text = "СЧЕТ: " + Score;
            livesCounter.Text = "ЖИЗНИ: " + Lives;


        }
        // Проверка условий завершения уровня или игры
        private void CheckGame()
        {
            if (gameArea.AreaView.Controls.Count == 0 && NextLevel == false)
            {
                GameContinue();
                Score += 100;
            }

            if (gameBall.BallView.Top > gameArea.AreaView.Height)
            {
                Lives--;
                if (Lives <= 0)
                {
                    GameOver("Вы проиграли");
                }
                else
                {
                    gameBall.BallView.Left = gameArea.AreaWidth / 2;
                    gameBall.BallView.Top = gameArea.AreaHeight / 2;
                    gamePlatform.PlatformView.Left = gameArea.AreaWidth / 2;
                }
                
            }


            if (gameArea.AreaView.Controls.Count == 0 && NextLevel == true)
            {
                GameOver("Вы победили");
            }
        }
        // Движение мяча
        private void MoveBall()
        {
            
            gameBall.BallView.Left += gameBall.BallSpeedX;
            gameBall.BallView.Top += gameBall.BallSpeedY;
        }

        private void MoveBonus()
        {
            if (gameBonus != null)
            {
                gameBonus.BonusView.Top += gameBonus.BonusSpeed;
            }
        }
        // Движение платформы
        private void MovePlatform()
        {
            
            if (gamePlatform.MoveLeft == true && gamePlatform.PlatformView.Left > 0)
            {
                gamePlatform.PlatformView.Left -= gamePlatform.PlatformSpeed;
            }
            if (gamePlatform.MoveRight == true && gamePlatform.PlatformView.Left < gameArea.AreaView.Width - gamePlatform.PlatformView.Width)
            {
                gamePlatform.PlatformView.Left += gamePlatform.PlatformSpeed;
            }
        }
        //Общая коллизия игры
        public void Collision(object sender, EventArgs e)
        {
            if (gameBall.BallView.Bounds.IntersectsWith(gamePlatform.PlatformView.Bounds))
            {
                AdjustBallSpeedAfterPlatformCollision();
            }

            CheckWallCollisions();

            bool ballTrajectoryChanged = false;

            for (int i = gameArea.AreaView.Controls.Count - 1; i >= 0; i--)
            {
                var x = gameArea.AreaView.Controls[i];
                if (x is PictureBox)
                {
                    if (!ballTrajectoryChanged && HandleBlockCollisions(x))
                    {
                        ballTrajectoryChanged = true;
                    }
                    HandleBonusCollisions(x);
                }
            }
        }
        //Скорости мяча
        private void AdjustBallSpeedAfterPlatformCollision()
        {
            gameBall.BallSpeedY = randomBallSpeed.Next(6, 10) * -1;
            gameBall.BallSpeedX = (gameBall.BallSpeedX < 0) ? randomBallSpeed.Next(6, 10) * -1 : randomBallSpeed.Next(6, 10);
        }
        
        // Коллизия стен арены
        private void CheckWallCollisions()
        {
            if (gameBall.BallView.Left < 0)
            {
                gameBall.BallView.Left = 0;
                gameBall.BallSpeedX = -gameBall.BallSpeedX;
            }
            else if (gameBall.BallView.Left > gameArea.AreaWidth - gameBall.BallView.Width)
            {
                gameBall.BallView.Left = gameArea.AreaWidth - gameBall.BallView.Width;
                gameBall.BallSpeedX = -gameBall.BallSpeedX;
            }
            if (gameBall.BallView.Top < 0)
            {
                gameBall.BallView.Top = 0;
                gameBall.BallSpeedY = -gameBall.BallSpeedY;
            }
        }
        //Колизия блоков
        private bool HandleBlockCollisions(Control x)
        {
            bool trajectoryChanged = false;
            if ((string)x.Tag == "Blocks" && gameBall.BallView.Bounds.IntersectsWith(x.Bounds))
            {
                Score += 10;
                gameBall.BallSpeedY = -gameBall.BallSpeedY;
                gameArea.AreaView.Controls.Remove(x);
                GenerateBonus();
                trajectoryChanged = true;
            }

            else if ((string)x.Tag == "HardBlocks" && gameBall.BallView.Bounds.IntersectsWith(x.Bounds))
            {
                gameBall.BallSpeedY = -gameBall.BallSpeedY;
                x.BackgroundImage = Image.FromFile(@"Images\BlockDestroyed.png");
                x.Tag = "damageBlock";
                trajectoryChanged = true;
            }
            else if ((string)x.Tag == "damageBlock" && gameBall.BallView.Bounds.IntersectsWith(x.Bounds))
            {
                Score += 10;
                gameBall.BallSpeedY = -gameBall.BallSpeedY;
                gameArea.AreaView.Controls.Remove(x);
                trajectoryChanged = true;
            }
            return trajectoryChanged;
        }
        //Коллизия бонусов
        private void HandleBonusCollisions(Control x)
        {
            if ((string)x.Tag == "ScoreBonus" || (string)x.Tag == "LifeBonus" || (string)x.Tag == "PlatformBonus")
            {
                if (x.Top > gameArea.AreaView.Height)
                {
                    gameArea.AreaView.Controls.Remove(x);
                    BonusIsLive = true;
                }

                if (gamePlatform.PlatformView.Bounds.IntersectsWith(x.Bounds))
                {
                    ApplyBonus(x);
                }
            }
        }
        
        //Применение бонусов
        private void ApplyBonus(Control x)
        {
           
            switch ((string)x.Tag)
            {
                case "ScoreBonus":
                    Score += ((ScoreBonus)gameBonus).ExtraScore;
                    break;
                case "LifeBonus":
                    if (Lives < 5)
                    {
                        Lives += ((LifeBonus)gameBonus).ExtraLife;
                    }
                    break;
                case "PlatformBonus":
                    gamePlatform.PlatformView.Width = gamePlatform.PlatformWidth + ((PlatformBonus)gameBonus).ExtraWidth;
                    gamePlatform.PlatformView.BackgroundImage = Image.FromFile(@"Images\BigPlatform.png");

                    // Увеличиваем оставшееся время действия бонуса на 10 секунд
                    bonusTimeLeft += 5000;
                    if (!timeBonus.Enabled)
                    {
                        timeBonus.Interval = 1000; // устанавливаем интервал таймера в 1 секунду
                        timeBonus.Tick += TimeBonus_Tick;
                        timeBonus.Start();
                    }
                    break;
            }

            gameArea.AreaView.Controls.Remove(x);
            BonusIsLive = true;
        }

        // Настройка игры
        private void GameSetup()
        {
            // Установка флагов и счетчиков в начальное состояние
            GameIsOver = false;
            NextLevel = false;
            Score = 0;
            Lives = 5;

            // Очистка текстовых полей
            continueGame.Text = "";
            msg.Text = "";
            gameLevel.Text = $"Уровень 1";

            // Позиционирование мяча и платформы по центру игровой области
            gameBall.BallView.Left = gameArea.AreaWidth / 2;
            gameBall.BallView.Top = gameArea.AreaHeight / 2;
            gamePlatform.PlatformView.Left = gameArea.AreaWidth / 2;

            // Запуск таймера
            gameTimer.Start();
        }

        // Генерация блоков для первого уровня
        private void GenerateLevelOne()
        {
            int left = 12;
            int top = 0;
            const int blocksPerRow = 5;
            const int blockSpacing = 101;

            for (int i = 0; i < 10; i++)
            {
                PictureBox block = new PictureBox
                {
                    Height = gameBlocks.BlockHeight,
                    Width = gameBlocks.BlockWidth,
                    Tag = "Blocks",
                    BackgroundImage = Image.FromFile(@"Images\Blocklvl1.png"),
                    BackColor = Color.Transparent
                };

                block.Left = left;
                block.Top = top;
                gameArea.AreaView.Controls.Add(block);

                left += blockSpacing;
                if ((i + 1) % blocksPerRow == 0)
                {
                    top += 35; // Увеличил на 1 пиксель для разделения строк
                    left = 12;
                }
            }
        }

        // Генерация блоков для следующего уровня (если необходимо)
        private void GenerateLevelTwo()
        {
            string blocks;
            try
            {
                // Считывание информации о блоках из файла
                StreamReader reader = new StreamReader("level.txt", Encoding.Default);
                blocks = reader.ReadToEnd();
                reader.Close();

                string[] x = blocks.Split(null);

                int row = 0;
                int top = 0;
                int left = 12;

                // Генерация блоков в соответствии с данными из файла
                for (int i = 0; i < x.Length; i++)
                {
                    gameBlocks.BlocksView = new PictureBox
                    {
                        Height = gameBlocks.BlockHeight,
                        Width = gameBlocks.BlockWidth
                    };

                    if (row < 5)
                    {
                        if (x[i] == "0")
                        {
                            gameBlocks.BlocksView.Tag = "Blocks";
                            gameBlocks.BlocksView.BackgroundImage = Image.FromFile(@"Images\Blocklvl1.png");
                        }
                        if (x[i] == "1")
                        {
                            gameBlocks.BlocksView.Tag = "HardBlocks";
                            gameBlocks.BlocksView.BackgroundImage = Image.FromFile(@"Images\Blocklvl2.png");
                        }

                        gameArea.AreaView.Controls.Add(gameBlocks.BlocksView);
                        gameBlocks.BlocksView.Left = left;
                        gameBlocks.BlocksView.Top = top;
                        row++;
                        left = left + 100;
                    }

                    if (row == 5)
                    {
                        top += 32;
                        left = 12;
                        row = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}! Файл не найден!");
            }

        }

        // Удаление блоков из игровой области
        private void RemoveBlocks()
        {
            for (int i = gameArea.AreaView.Controls.Count - 1; i >= 0; i--)
            {
                var control = gameArea.AreaView.Controls[i];
                if (control is PictureBox && (string)control.Tag == "Blocks" || (string)control.Tag == "HardBlocks" || (string)control.Tag == "damageBlock")
                {
                    gameArea.AreaView.Controls.RemoveAt(i);
                }
            }
        }

        // Обработчик временного бонуса
        private void TimeBonus_Tick(object sender, EventArgs e)
        {
            // Уменьшаем оставшееся время действия бонуса на 1 секунду
            bonusTimeLeft -= 1000;

            if (bonusTimeLeft <= 0)
            {
                // Если время действия бонуса закончилось, сбрасываем параметры платформы
                gamePlatform.PlatformView.Width = gamePlatform.PlatformWidth;
                gamePlatform.PlatformView.BackgroundImage = Image.FromFile(@"Images\gamePlatform.png");
                timeBonus.Stop();
                timeBonus.Tick -= TimeBonus_Tick; // отписываемся от события
            }
        }


        // Генерация бонусов
        private void GenerateBonus()
        {
            if (!BonusIsLive) return;
            int random = randBonus.Next(0, 3); // Ограничиваем диапазон 

            switch (random)
            {
                case 0:
                    gameBonus = new ScoreBonus();
                    gameBonus.BonusView =   CreateBonusView("ScoreBonus", gameBonus.BonusBackGround);
                    break;
                case 1:
                    gameBonus = new LifeBonus();
                    gameBonus.BonusView = CreateBonusView("LifeBonus", gameBonus.BonusBackGround);
                    break;
                case 2:
                    gameBonus = new PlatformBonus();
                    gameBonus.BonusView = CreateBonusView("PlatformBonus", gameBonus.BonusBackGround);
                    break;
            }

            BonusIsLive = false;
            if (gameBonus != null) gameArea.AreaView.Controls.Add(gameBonus.BonusView);
        }

        private PictureBox CreateBonusView(string tag, string backgroundImage)
        {
            return new PictureBox
            {
                BackgroundImage = Image.FromFile(backgroundImage),
                Width = gameBonus.BonusWidth,
                Height = gameBonus.BonusHeight,
                Top = gameArea.AreaHeight / 2,
                Left = gameArea.AreaWidth / 2,
                Tag = tag,
                BackColor = Color.Transparent
            };
        }

        //Поставить на паузу
        public void PauseGame(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && GameIsOver == false)
            {
                gameTimer.Stop();
                continueGame.Text = "Пауза";
            }
        }


        //Снять с паузы
        public void ResumeGame(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M && GameIsOver == false)
            {
                gameTimer.Start();
                continueGame.Text = "";
            }
        }

        // Продолжение игры
        private void GameContinue()
        {
            NextLevel = true;
            gameLevel.Text = "Уровень 2";

            gameBall.BallView.Left = gameArea.AreaWidth / 2;
            gameBall.BallView.Top = gameArea.AreaHeight / 2;
            gamePlatform.PlatformView.Left = gameArea.AreaWidth / 2;

            RemoveBlocks();
            GenerateLevelTwo();
        }

        // Завершение игры
        private void GameOver(string message)
        {
            GameIsOver = true;
            gameTimer.Stop();

            scoreCounter.Text = "СЧЕТ: " + Score;
            msg.Text = message;
            continueGame.Text = "Нажмите Enter";
            // Сохранение финального счета
            ScoreManager.SaveScore(Score);
        }
      
    }
}
