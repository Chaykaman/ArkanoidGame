using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    internal class LifeBonus : Bonus
    {
        // Свойство, представляющее количество дополнительных жизней, которые предоставляет бонус.
        public int ExtraLife { get; }

        // Конструктор класса LifeBonus, инициализирующий изображение бонуса и количество дополнительных жизней.
        public LifeBonus() : base(@"Images\LifeBonus.png")
        {
            // Установка количества дополнительных жизней.
            ExtraLife = 1;
        }

    }
}
