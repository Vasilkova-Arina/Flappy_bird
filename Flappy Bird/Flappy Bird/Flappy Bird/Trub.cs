using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    internal class Trub
    {
        private readonly PictureBox vverx_trub;
        private readonly PictureBox nizch_trub;
        private readonly Form level;
        private readonly Random random = new Random();

        // Константы для настройки труб
        private const int PipeSpeed = 5; //Скорость труб
        private const int PipeGap = 250; //Растояние между верхней и нижней трубой

        public Trub(PictureBox top, PictureBox bottom, Form form)
        {
            vverx_trub = top;
            nizch_trub = bottom;

            level = form;
        }

        // Движение труб влево
        public void Move()
        {
            vverx_trub.Left -= PipeSpeed;
            nizch_trub.Left -= PipeSpeed;
        }

        // Проверка, ушли ли трубы за левый край экрана
        public bool IsOutOfScreen()
        {
            return vverx_trub.Right < 0;
        }

        // Сброс труб на правый край с новой случайной высотой
        public void Reset()
        {
            int minHeight = 50;
            int maxHeight = level.ClientSize.Height - (int)(1.5 * PipeGap);
            int topHeight = random.Next(minHeight, maxHeight);

            // Устанавливаем верхнюю трубу
            vverx_trub.SetBounds(
                level.ClientSize.Width, // X - правый край формы
                0,                        // Y - верх формы
                vverx_trub.Width,            // Ширина
                topHeight                 // Высота
            );

            // Рассчитываем нижнюю трубу
            int bottomY = topHeight + PipeGap;
            int bottomHeight = level.ClientSize.Height - bottomY;

            nizch_trub.SetBounds(
                level.ClientSize.Width, // X - правый край формы
                bottomY,                  // Y - под зазором от верхней трубы
                nizch_trub.Width,         // Ширина
                bottomHeight              // Высота
            );
        }

        // Проверка столкновения птицы с трубами
        public bool CheckCollision(Rectangle bird)
        {
            return bird.IntersectsWith(vverx_trub.Bounds) ||
                   bird.IntersectsWith(nizch_trub.Bounds);
        }
    }
}
