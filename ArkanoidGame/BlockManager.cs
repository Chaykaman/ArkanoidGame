using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArkanoidGame
{
    internal class BlockManager
    {
        private PictureBox[] blocks; // Массив для хранения блоков
        private int dirX; // Координата X для размещения блоков
        private int dirY; // Координата Y для размещения блоков
        private int rows; // Текущая строка в сетке блоков
        private int columns; // Текущий столбец в сетке блоков
        private int count; // Количество добавленных блоков
        private string map; // Строка для хранения конфигурации уровня
        private Control drawArea; 

        // Конструктор класса BlockManager, инициализирующий основные параметры
        public BlockManager(Control drawArea)
        {
            this.drawArea = drawArea;
            blocks = new PictureBox[20];
            dirX = 9;
            dirY = 1;
            rows = 0;
            columns = 0;
            count = 0;
            map = string.Empty;
        }

        
        public void CreateBlock(string blockType, string imagePath)
        {
            if (count >= 20) return; // Проверка на максимальное количество блоков

            // Создание нового блока
            PictureBox blockView = new PictureBox
            {
                Height = 32,
                Width = 100,
                Tag = blockType, // Тип блока (обычный или усиленный)
                BackgroundImage = Image.FromFile(imagePath) // Установка изображения блока
            };

            // Расположение блока в сетке
            if (columns < 4)
            {
                if (rows < 5)
                {
                    blockView.Left = dirX;
                    blockView.Top = dirY;
                    drawArea.Controls.Add(blockView); // Добавление блока в область рисования

                    dirX += blockView.Width; // Обновление координаты X для следующего блока
                    rows++;
                }
                if (rows == 5)
                {
                    // Переход на новую строку после заполнения текущей
                    dirY += blockView.Height;
                    dirX = 9; // Начальное значение по X для новой строки
                    columns++;
                    rows = 0;
                }
            }

            blocks[count] = blockView; // Сохранение блока в массиве
            map += blockType == "Blocks" ? "0 " : "1 "; // Добавление типа блока в строку карты
            count++; // Увеличение счётчика блоков
        }

   
        public string GetMap()
        {
            return map.Trim(); // Возврат строки карты с удалением лишних пробелов
        }

        // Метод для очистки области рисования и сброса параметров
        public void Clear()
        {
            foreach (var block in blocks)
            {
                if (block != null)
                {
                    drawArea.Controls.Remove(block); // Удаление блока из области рисования
                }
            }
            dirX = 9;
            dirY = 1;
            rows = 0;
            columns = 0;
            count = 0;
            map = string.Empty; // Сброс строки карты
        }
    }
}
