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
        private readonly PictureBox nizxh_trub;
        private readonly Form level;
        private readonly Random random = new Random();

        // Константы для настройки труб
        private int pipeSpeed; //Скорость труб
        private int pipeGap; //Растояние между верхней и нижней трубой

        // Перечисление для уровней сложности
        public enum DifficultyLevel
        {
            Easy,
            Medium,
            Hard
        }

        private readonly DifficultyLevel difficulty;

        public Trub(PictureBox top, PictureBox bottom, Form form, DifficultyLevel difficulty = DifficultyLevel.Easy)
        {
            vverx_trub = top;
            nizxh_trub = bottom;
            level = form;
            this.difficulty = difficulty;

            SetDifficultyParameters();
        }

        private void SetDifficultyParameters()
        {
            switch (difficulty)
            {
                case DifficultyLevel.Easy:
                    pipeSpeed = 10;      // Медленная скорость
                    pipeGap = 250;      // Большой промежуток
                    break;
                case DifficultyLevel.Medium:
                    pipeSpeed = 20;      // Средняя скорость
                    pipeGap = 200;      // Средний промежуток
                    break;
                case DifficultyLevel.Hard:
                    pipeSpeed = 30;      // Высокая скорость
                    pipeGap = 180;      // Маленький промежуток
                    break;
            }
        }

        // Движение труб влево
        public void Move()
        {
            vverx_trub.Left -= pipeSpeed;
            nizxh_trub.Left -= pipeSpeed;
        }

        // Проверка, ушли ли трубы за левый край экрана
        public bool IsOutOfScreen()
        {
            return vverx_trub.Right < 0;
        }

        // Сброс труб на правый край с новой случайной высотой
        public void Reset_Trub()
        {
            try
            {
                // Проверяем контролы
                if (vverx_trub == null || nizxh_trub == null || level == null)
                {
                    Console.WriteLine("Ошибка: один из элементов труб равен null");
                    return;
                }

                // Минимальная и максимальная высота
                int minHeight = 50;
                int maxHeight = level.ClientSize.Height - (int)(1.5 * pipeGap);

                if (maxHeight < minHeight + 10)
                    maxHeight = minHeight + 100;

                // Случайная высота верхней трубы
                int topHeight = random.Next(minHeight, maxHeight);


                // Устанавливаем верхнюю трубу
                vverx_trub.SetBounds(
                    level.ClientSize.Width, // X - правый край
                    0,                      // Y - верх
                    vverx_trub.Width,       // Ширина
                    topHeight               // Высота
                );

                vverx_trub.Visible = true;
                vverx_trub.BackColor = Color.Green;

                // Рассчитываем нижнюю трубу
                int bottomY = topHeight + pipeGap;
                int bottomHeight = level.ClientSize.Height - bottomY;

                // Гарантируем минимальную высоту
                if (bottomHeight < 50)
                {
                    bottomHeight = 50;
                    bottomY = level.ClientSize.Height - bottomHeight;
                }

                // Устанавливаем нижнюю трубу
                nizxh_trub.SetBounds(
                    level.ClientSize.Width, // X - правый край
                    bottomY,                // Y
                    nizxh_trub.Width,       // Ширина
                    bottomHeight            // Высота
                );

                nizxh_trub.Visible = true;
                nizxh_trub.BackColor = Color.Green;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка в Reset труб: {ex.Message}");
            }
        }

        // Проверка столкновения птицы с трубами
        public bool CheckCollision(Rectangle bird)
        {
            return bird.IntersectsWith(vverx_trub.Bounds) ||
                   bird.IntersectsWith(nizxh_trub.Bounds);
        }
    }
}
