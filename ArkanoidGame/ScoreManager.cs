using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ArkanoidGame
{
    internal class ScoreManager
    {
        private const string ScoresFilePath = "scores.txt";
        private const int MaxTopScores = 5;

        // Метод для записи нового счета
        public static void SaveScore(int score)
        {
            List<int> scores = LoadScores();
            bool isNewRecord = false;

            // Проверка, является ли новый счет рекордом
            for (int i = 0; i < scores.Count; i++)
            {
                if (score > scores[i])
                {
                    scores.Insert(i, score); // Вставка нового рекорда на соответствующее место
                    isNewRecord = true;
                    break;
                }
            }

            // Если новый счет не является рекордом, добавляем его в конец списка
            if (!isNewRecord && scores.Count < MaxTopScores)
            {
                scores.Add(score);
                isNewRecord = true;
            }

            // Если в списке больше 5 записей, удаляем лишние
            while (scores.Count > MaxTopScores)
            {
                scores.RemoveAt(scores.Count - 1);
            }

            // Сохранение обновленного списка рекордов
            File.WriteAllLines(ScoresFilePath, scores.Select(s => s.ToString()).ToArray());
        }

        // Метод для загрузки счетов
        public static List<int> LoadScores()
        {
            if (File.Exists(ScoresFilePath))
            {
                List<int> scores = new List<int>();
                foreach (string line in File.ReadAllLines(ScoresFilePath))
                {
                    string trimmedLine = line.Trim();
                    if (!string.IsNullOrEmpty(trimmedLine)) // Проверяем, что строка не пустая
                    {
                        if (int.TryParse(trimmedLine, out int score))
                        {
                            scores.Add(score);
                        }
                        else
                        {
                            MessageBox.Show($"Ошибка: Не удалось преобразовать строку в число: {line}");
                        }
                    }
                }

                return scores.OrderByDescending(s => s).Take(MaxTopScores).ToList();
            }
            else
            {
                File.CreateText(ScoresFilePath);

            }
            return new List<int>();
        }

        
    }

}
