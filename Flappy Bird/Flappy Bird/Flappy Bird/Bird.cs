using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    internal class Bird
    {
        private PictureBox bird;
        private readonly Image birdImage1; // Первое состояние птицы

        private int velocity = 0; // Скорость падения/подъема
        private const int Gravity = 1; // Сила гравитации
        private const int JumpStrength = -15; // Сила прыжка при клике

        // Для ограничения высоты
        private int groundLevel;

        public Bird(PictureBox pictureBox, Image image1, Image image2, int groundLevel)
        {
            // Проверяем входные параметры
            if (pictureBox == null)
                throw new ArgumentNullException(nameof(pictureBox), "PictureBox не может быть null");

            if (image1 == null || image2 == null)
                throw new ArgumentNullException("Изображения не могут быть null");

            //Инициализируем поле bird
            bird = pictureBox;

            try
            {
                birdImage1 = Properties.Resources.redbird_upflap;
                this.groundLevel = groundLevel;

                // Устанавливаем начальное изображение
                bird.Image = birdImage1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }

        // Обработка клика/нажатия (прыжок)
        public void Jump()
        {
            velocity = JumpStrength;
        }

        // Обновление позиции птицы (вызывается в игровом цикле)
        public void Update()
        {
            // Применяем гравитацию
            velocity += Gravity;

            // Обновляем позицию птицы
            bird.Top += velocity;

            // Проверяем границы экрана
            if (bird.Top <= 0)
            {
                bird.Top = 0;
                velocity = 0;
            }

            if (bird.Bottom >= groundLevel)
            {
                bird.Top = groundLevel - bird.Height;
                velocity = 0;
            }
        }

        // Сброс состояния птицы
        public void Reset(int startX, int startY)
        {
            // Проверяем, что bird инициализирован
            if (bird == null)
            {
                throw new InvalidOperationException("Птица не инициализирована. PictureBox равен null.");
            }

            try
            {
                bird.Left = startX;
                bird.Top = startY;
                velocity = 0;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Ошибка сброса птицы: {ex.Message}", ex);
            }
        }

        // Получение границ птицы для проверки столкновений
        public Rectangle GetBounds()
        {
            return bird.Bounds;
        }

        // Изменение уровня земли (если нужно)
        public void SetGroundLevel(int newGroundLevel)
        {
            groundLevel = newGroundLevel;
        }

        // Остановка движения
        public void StopMovement()
        {
            velocity = 0;
        }
    }
}
