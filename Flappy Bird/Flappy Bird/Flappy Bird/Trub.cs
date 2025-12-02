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
            // Безопасная минимальная высота
            int minHeight = 50;

            // Вычисляем максимальную высоту с запасом
            int maxHeight = level.ClientSize.Height - PipeGap - 50;

            // Гарантируем, что maxHeight > minHeight
            if (maxHeight < minHeight + 20)
                maxHeight = minHeight + 20;

            // Случайная высота верхней трубы
            int topHeight = random.Next(minHeight, maxHeight);

            // Устанавливаем верхнюю трубу
            vverx_trub.Left = level.ClientSize.Width;
            vverx_trub.Top = 0;
            vverx_trub.Height = topHeight;

            // Рассчитываем нижнюю трубу
            int bottomY = topHeight + PipeGap;
            int bottomHeight = level.ClientSize.Height - bottomY;

            // Гарантируем минимальную высоту нижней трубы
            if (bottomHeight < 50)
            {
                bottomHeight = 50;
                bottomY = level.ClientSize.Height - bottomHeight;
            }

            // Устанавливаем нижнюю трубу
            nizch_trub.Left = level.ClientSize.Width;
            nizch_trub.Top = bottomY;
            nizch_trub.Height = bottomHeight;
        }

        // Проверка столкновения птицы с трубами
        public bool CheckCollision(Rectangle bird)
        {
            return bird.IntersectsWith(vverx_trub.Bounds) ||
                   bird.IntersectsWith(nizch_trub.Bounds);
        }
    }
}
