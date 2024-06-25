namespace ArkanoidGame
{
    partial class ArcanoidGame
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArcanoidGame));
            this.GameArea = new System.Windows.Forms.PictureBox();
            this.GameMenu = new System.Windows.Forms.PictureBox();
            this.GameLevel = new System.Windows.Forms.Label();
            this.ScoreCounter = new System.Windows.Forms.Label();
            this.LiveCounter = new System.Windows.Forms.Label();
            this.GameBall = new System.Windows.Forms.PictureBox();
            this.GamePlatform = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.Msg = new System.Windows.Forms.Label();
            this.Continue = new System.Windows.Forms.Label();
            this.Extilbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameBall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GamePlatform)).BeginInit();
            this.SuspendLayout();
            // 
            // GameArea
            // 
            this.GameArea.BackColor = System.Drawing.Color.Transparent;
            this.GameArea.Location = new System.Drawing.Point(10, 3);
            this.GameArea.Name = "GameArea";
            this.GameArea.Size = new System.Drawing.Size(697, 691);
            this.GameArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GameArea.TabIndex = 0;
            this.GameArea.TabStop = false;
            // 
            // GameMenu
            // 
            this.GameMenu.BackColor = System.Drawing.Color.Transparent;
            this.GameMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GameMenu.Location = new System.Drawing.Point(713, 3);
            this.GameMenu.Name = "GameMenu";
            this.GameMenu.Size = new System.Drawing.Size(277, 680);
            this.GameMenu.TabIndex = 1;
            this.GameMenu.TabStop = false;
            // 
            // GameLevel
            // 
            this.GameLevel.AutoSize = true;
            this.GameLevel.BackColor = System.Drawing.Color.Transparent;
            this.GameLevel.Font = new System.Drawing.Font("Californian FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameLevel.ForeColor = System.Drawing.Color.White;
            this.GameLevel.Location = new System.Drawing.Point(737, 76);
            this.GameLevel.Name = "GameLevel";
            this.GameLevel.Size = new System.Drawing.Size(181, 43);
            this.GameLevel.TabIndex = 2;
            this.GameLevel.Text = "Уровень ";
            // 
            // ScoreCounter
            // 
            this.ScoreCounter.AutoSize = true;
            this.ScoreCounter.BackColor = System.Drawing.Color.Transparent;
            this.ScoreCounter.Font = new System.Drawing.Font("Californian FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreCounter.ForeColor = System.Drawing.Color.White;
            this.ScoreCounter.Location = new System.Drawing.Point(737, 143);
            this.ScoreCounter.Name = "ScoreCounter";
            this.ScoreCounter.Size = new System.Drawing.Size(108, 43);
            this.ScoreCounter.TabIndex = 3;
            this.ScoreCounter.Text = "Счёт";
            // 
            // LiveCounter
            // 
            this.LiveCounter.AutoSize = true;
            this.LiveCounter.BackColor = System.Drawing.Color.Transparent;
            this.LiveCounter.Font = new System.Drawing.Font("Californian FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LiveCounter.ForeColor = System.Drawing.Color.White;
            this.LiveCounter.Location = new System.Drawing.Point(737, 230);
            this.LiveCounter.Name = "LiveCounter";
            this.LiveCounter.Size = new System.Drawing.Size(139, 43);
            this.LiveCounter.TabIndex = 4;
            this.LiveCounter.Text = "Жизни";
            // 
            // GameBall
            // 
            this.GameBall.BackColor = System.Drawing.Color.Transparent;
            this.GameBall.Image = ((System.Drawing.Image)(resources.GetObject("GameBall.Image")));
            this.GameBall.Location = new System.Drawing.Point(240, 503);
            this.GameBall.Name = "GameBall";
            this.GameBall.Size = new System.Drawing.Size(36, 30);
            this.GameBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.GameBall.TabIndex = 5;
            this.GameBall.TabStop = false;
            // 
            // GamePlatform
            // 
            this.GamePlatform.BackColor = System.Drawing.Color.Transparent;
            this.GamePlatform.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GamePlatform.BackgroundImage")));
            this.GamePlatform.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.GamePlatform.Location = new System.Drawing.Point(185, 632);
            this.GamePlatform.Name = "GamePlatform";
            this.GamePlatform.Size = new System.Drawing.Size(132, 48);
            this.GamePlatform.TabIndex = 6;
            this.GamePlatform.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 20;
            // 
            // Msg
            // 
            this.Msg.AutoSize = true;
            this.Msg.BackColor = System.Drawing.Color.Transparent;
            this.Msg.Font = new System.Drawing.Font("Californian FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Msg.ForeColor = System.Drawing.Color.White;
            this.Msg.Location = new System.Drawing.Point(134, 271);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(268, 43);
            this.Msg.TabIndex = 7;
            this.Msg.Text = "Чтобы начать";
            // 
            // Continue
            // 
            this.Continue.AutoSize = true;
            this.Continue.BackColor = System.Drawing.Color.Transparent;
            this.Continue.Font = new System.Drawing.Font("Californian FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Continue.ForeColor = System.Drawing.Color.White;
            this.Continue.Location = new System.Drawing.Point(134, 355);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(325, 43);
            this.Continue.TabIndex = 8;
            this.Continue.Text = "Нажмите пробел";
            // 
            // Extilbl
            // 
            this.Extilbl.AutoSize = true;
            this.Extilbl.BackColor = System.Drawing.Color.Transparent;
            this.Extilbl.Font = new System.Drawing.Font("Californian FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Extilbl.ForeColor = System.Drawing.Color.White;
            this.Extilbl.Location = new System.Drawing.Point(738, 512);
            this.Extilbl.Name = "Extilbl";
            this.Extilbl.Size = new System.Drawing.Size(138, 43);
            this.Extilbl.TabIndex = 9;
            this.Extilbl.Text = "Выход";
            this.Extilbl.Click += new System.EventHandler(this.Extilbl_Click);
            // 
            // ArcanoidGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1034, 692);
            this.Controls.Add(this.Extilbl);
            this.Controls.Add(this.Continue);
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.GamePlatform);
            this.Controls.Add(this.GameBall);
            this.Controls.Add(this.LiveCounter);
            this.Controls.Add(this.ScoreCounter);
            this.Controls.Add(this.GameLevel);
            this.Controls.Add(this.GameMenu);
            this.Controls.Add(this.GameArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ArcanoidGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ArcanoidGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GameArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameBall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GamePlatform)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GameArea;
        private System.Windows.Forms.PictureBox GameMenu;
        private System.Windows.Forms.Label GameLevel;
        private System.Windows.Forms.Label ScoreCounter;
        private System.Windows.Forms.Label LiveCounter;
        private System.Windows.Forms.PictureBox GameBall;
        private System.Windows.Forms.PictureBox GamePlatform;
        public System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label Msg;
        private System.Windows.Forms.Label Continue;
        private System.Windows.Forms.Label Extilbl;
    }
}

