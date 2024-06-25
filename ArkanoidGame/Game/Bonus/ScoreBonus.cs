using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    internal class ScoreBonus : Bonus
    {
        // Свойство, представляющее количество дополнительных очков, которые предоставляет бонус.
        public int ExtraScore { get; }

        // Конструктор класса ScoreBonus, инициализирующий изображение бонуса и количество дополнительных очков.
        public ScoreBonus() : base(@"Images\ScoreBonus.png")
        {
            // Установка количества дополнительных очков.
            ExtraScore = 100;
        }
    }
}
