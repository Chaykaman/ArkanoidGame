using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidGame
{
    internal class PlatformBonus : Bonus
    {
        // Свойство, представляющее дополнительную ширину, которую предоставляет бонус платформы.
        public int ExtraWidth { get; }

        // Конструктор класса PlatformBonus, инициализирующий изображение бонуса и дополнительную ширину.
        public PlatformBonus() : base(@"Images\PlatBonus.png")
        {
            // Установка дополнительной ширины платформы.
            ExtraWidth = 50;
        }

    }
}
