using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ArkanoidGame
{
    public partial class LevelConstructor : Form
    {
        private BlockManager blockManager; // Экземпляр класса BlockManager для управления блоками

        // Конструктор формы LevelConstructor
        public LevelConstructor()
        {
            InitializeComponent();
            blockManager = new BlockManager(DrawArea); // Инициализация BlockManager с областью рисования
        }

        // Обработчик события нажатия кнопки для добавления блока первого уровня
        private void AddBtn1lvl_Click(object sender, EventArgs e)
        {
            blockManager.CreateBlock("Blocks", @"Images\Blocklvl1.png"); // Создание блока первого уровня
        }

        // Обработчик события нажатия кнопки для добавления блока второго уровня
        private void AddBtn2lvl_Click(object sender, EventArgs e)
        {
            blockManager.CreateBlock("HardBlocks", @"Images\Blocklvl2.png"); // Создание блока второго уровня
        }

        // Обработчик события нажатия кнопки сохранения уровня
        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (DrawArea.Controls.Count == 0)
            {
                MessageBox.Show("Уровень не может быть пустым!"); // Проверка на наличие блоков
            }
            else
            {
                using(FileStream fs = new FileStream("level.txt", FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.Default))
                    {
                        writer.Write(blockManager.GetMap()); // Запись конфигурации уровня в файл
                    }
                }
                MessageBox.Show("Уровень сохранён");
            }
            blockManager.Clear();
        }

        // Обработчик события нажатия кнопки выхода из редактора уровней
        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
