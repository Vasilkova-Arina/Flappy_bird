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
        private readonly Image birdImage2; // Второе состояние птицы
        private Timer animationTimer;

        private bool isFlapping = false;
        private int velocity = 0; // Скорость падения/подъема
        private const int Gravity = 1; // Сила гравитации
        private const int JumpStrength = -15; // Сила прыжка при клике

        // Для ограничения высоты
        private int groundLevel = 10;

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
                //что то не нравится с картинками
                //string path1 = "redbird-downflap.png";
                //string path2 = "redbird-upflap.png";
                //birdImage1 = Image.FromFile(path1);
                //birdImage2 = Image.FromFile("Flappy bird/bin/Debug/img/redbirdflap.png");
                bird.Image = birdImage1;
                //bird.Image = birdImage2;

                birdImage1 = Properties.Resources.redbird_upflap;
                //birdImage1 = 
                this.groundLevel = groundLevel;

                // Устанавливаем начальное изображение
                bird.Image = birdImage1;

                //// Настраиваем таймер для анимации
                //animationTimer = new Timer
                //{
                //    Interval = 100 // Интервал смены кадров в миллисекундах
                //};
                //animationTimer.Tick += AnimationTimer_Tick;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
            }
        }


        // Метод для начала анимации
        //public void StartAnimation()
        //{
        //    if (animationTimer != null)
        //    {
        //        animationTimer.Start();
        //    }

        //    // Проверяем bird и изображение
        //    if (bird != null && birdImage1 != null)
        //    {
        //        bird.Image = birdImage1;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Предупреждение: bird или birdImage1 равен null в StartAnimation");
        //    }

        //}

        // Метод для остановки анимации
        //public void StopAnimation()
        //{
        //    try
        //    {
        //        // Проверяем таймер
        //        if (animationTimer != null)
        //        {
        //            animationTimer.Stop();
        //        }

        //        // Проверяем bird и изображение
        //        if (bird != null && birdImage1 != null)
        //        {
        //            bird.Image = birdImage1;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Предупреждение: bird или birdImage1 равен null в StopAnimation");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка в StopAnimation: {ex.Message}");
        //    }
        //}

        // Обработчик тика таймера для анимации
        //private void AnimationTimer_Tick(object sender, EventArgs e)
        //{
        //    // Переключаем изображение
        //    bird.Image = isFlapping ? birdImage1 : birdImage2;
        //    isFlapping = !isFlapping;
        //}

        // Обработка клика/нажатия (прыжок)
        public void Jump()
        {
            velocity = JumpStrength;

            // Можно добавить временную анимацию прыжка
            //Task.Run(async () =>
            //{
            //    // Временно ускоряем анимацию при прыжке
            //    int originalInterval = animationTimer.Interval;
            //    animationTimer.Interval = 80;

            //    await Task.Delay(200);

            //    // Возвращаем обычную скорость анимации
            //    if (animationTimer.Enabled)
            //    {
            //        animationTimer.Interval = originalInterval;
            //    }
            //});
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
                //StopAnimation();
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
            //StopAnimation();
        }
    }
}
