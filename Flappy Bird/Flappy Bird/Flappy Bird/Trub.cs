using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    /// <summary>
    /// Класс, представляющий игровые трубы (препятствия) в игре Flappy Bird.
    /// Управляет созданием, движением, сбросом и проверкой столкновений труб.
    /// </summary>
    internal class Trub
    {
        // Верхняя труба (препятствие сверху)
        private readonly PictureBox vverx_trub;

        // Нижняя труба (препятствие снизу)
        private readonly PictureBox nizxh_trub;

        // Форма (игровое поле), на котором расположены трубы
        private readonly Form level;

        // Генератор случайных чисел для создания труб различной высоты
        private readonly Random random = new Random();

        // Константы для настройки поведения труб
        private int pipeSpeed;    // Скорость движения труб влево (пикселей за кадр)
        private int pipeGap;      // Расстояние между верхней и нижней трубой (пикселей)

        /// <summary>
        /// Уровни сложности игры, влияющие на скорость труб и ширину прохода
        /// </summary>
        public enum DifficultyLevel
        {
            Easy,    // Легкий уровень: медленные трубы, широкий проход
            Medium,  // Средний уровень: умеренная скорость, средний проход
            Hard     // Сложный уровень: быстрые трубы, узкий проход
        }

        // Текущий уровень сложности
        private readonly DifficultyLevel difficulty;

        /// <summary>
        /// Конструктор класса Trub.
        /// Инициализирует трубы и устанавливает параметры в зависимости от уровня сложности.
        /// </summary>
        /// <param name="top">PictureBox для верхней трубы</param>
        /// <param name="bottom">PictureBox для нижней трубы</param>
        /// <param name="form">Форма игры, на которой расположены трубы</param>
        /// <param name="difficulty">Уровень сложности (по умолчанию Easy)</param>
        public Trub(PictureBox top, PictureBox bottom, Form form, DifficultyLevel difficulty = DifficultyLevel.Easy)
        {
            // Сохраняем ссылки на элементы управления
            vverx_trub = top;
            nizxh_trub = bottom;
            level = form;
            this.difficulty = difficulty;

            // Устанавливаем параметры в зависимости от уровня сложности
            SetDifficultyParameters();
        }

        /// <summary>
        /// Устанавливает параметры скорости и расстояния между трубами
        /// в зависимости от выбранного уровня сложности.
        /// </summary>
        private void SetDifficultyParameters()
        {
            switch (difficulty)
            {
                case DifficultyLevel.Easy:
                    pipeSpeed = 10;      // Медленная скорость движения
                    pipeGap = 250;      // Большой промежуток между трубами
                    break;
                case DifficultyLevel.Medium:
                    pipeSpeed = 20;      // Средняя скорость движения
                    pipeGap = 200;      // Средний промежуток между трубами
                    break;
                case DifficultyLevel.Hard:
                    pipeSpeed = 30;      // Высокая скорость движения
                    pipeGap = 180;      // Маленький промежуток между трубами
                    break;
            }
        }

        /// <summary>
        /// Перемещает обе трубы влево на расстояние, равное текущей скорости.
        /// Вызывается каждый игровой кадр для создания эффекта движения.
        /// </summary>
        public void Move()
        {
            vverx_trub.Left -= pipeSpeed;
            nizxh_trub.Left -= pipeSpeed;
        }

        /// <summary>
        /// Проверяет, полностью ли трубы вышли за левую границу экрана.
        /// </summary>
        /// <returns>
        /// true - если правая граница верхней трубы находится за пределами видимой области
        /// false - если трубы еще видны на экране
        /// </returns>
        public bool IsOutOfScreen()
        {
            return vverx_trub.Right < 0;
        }

        /// <summary>
        /// Сбрасывает положение труб: размещает их за правой границей экрана
        /// и задает случайную высоту верхней трубы.
        /// </summary>
        public void Reset_Trub()
        {
            try
            {
                // ВАЖНО: Проверка на null для предотвращения исключений
                if (vverx_trub == null || nizxh_trub == null || level == null)
                {
                    Console.WriteLine("Ошибка: один из элементов труб равен null");
                    return;
                }

                // Определяем диапазон допустимых высот для верхней трубы
                // Минимальная высота гарантирует, что труба не будет слишком короткой
                int minHeight = 50;

                // Максимальная высота рассчитывается так, чтобы нижняя труба
                // также имела достаточную высоту
                int maxHeight = level.ClientSize.Height - (int)(1.5 * pipeGap);

                // Корректировка максимальной высоты, если расчетное значение слишком мало
                if (maxHeight < minHeight + 10)
                    maxHeight = minHeight + 100;

                // Генерация случайной высоты для верхней трубы
                int topHeight = random.Next(minHeight, maxHeight);

                // Установка положения и размеров верхней трубы
                vverx_trub.SetBounds(
                    level.ClientSize.Width, // Начинаем с правой границы экрана
                    0,                      // Верхняя труба начинается от верха формы
                    vverx_trub.Width,       // Сохраняем оригинальную ширину
                    topHeight               // Устанавливаем случайную высоту
                );

                // Делаем трубы видимыми и устанавливаем зеленый цвет фона
                vverx_trub.Visible = true;
                vverx_trub.BackColor = Color.Green;

                // Расчет положения нижней трубы
                // Нижняя труба начинается сразу после промежутка (gap)
                int bottomY = topHeight + pipeGap;

                // Высота нижней трубы - от ее начала до низа формы
                int bottomHeight = level.ClientSize.Height - bottomY;

                // Гарантируем минимальную высоту нижней трубы
                if (bottomHeight < 50)
                {
                    bottomHeight = 50;
                    bottomY = level.ClientSize.Height - bottomHeight;
                }

                // Установка положения и размеров нижней трубы
                nizxh_trub.SetBounds(
                    level.ClientSize.Width, // Начинаем с правой границы экрана
                    bottomY,                // Положение по вертикали
                    nizxh_trub.Width,       // Сохраняем оригинальную ширину
                    bottomHeight            // Рассчитанная высота
                );

                nizxh_trub.Visible = true;
                nizxh_trub.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                // Обработка исключений с выводом сообщения об ошибке
                MessageBox.Show($"Ошибка в Reset труб: {ex.Message}");
            }
        }

        /// <summary>
        /// Проверяет столкновение птицы с трубами.
        /// </summary>
        /// <param name="bird">Прямоугольник, представляющий границы птицы</param>
        /// <returns>
        /// true - если произошло столкновение с верхней или нижней трубой
        /// false - если столкновения нет
        /// </returns>
        public bool CheckCollision(Rectangle bird)
        {
            // Используем метод IntersectsWith для проверки пересечения прямоугольников
            return bird.IntersectsWith(vverx_trub.Bounds) ||
                   bird.IntersectsWith(nizxh_trub.Bounds);
        }
    }
}