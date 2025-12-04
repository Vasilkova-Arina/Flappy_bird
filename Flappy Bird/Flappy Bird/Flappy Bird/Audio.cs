using System;
using System.IO;
using System.Media;

namespace Flappy_Bird
{
    /// <summary>
    /// Класс для импорта звуковых файло
    /// </summary>
    internal class Audio
    {
        /// <summary>
        /// Переменные для хранения звуковых плееров.
        /// Каждая переменная отвечает за определенный звуковой эффект.
        /// </summary>
        //Звуки
        private SoundPlayer dieSound;      // Звук смерти (die)
        private SoundPlayer hitSound;      // Звук удара (hit)
        private SoundPlayer pointSound;    // Звук очков (point)
        private SoundPlayer swooshSound;   // Звук свиста (swoosh) 
        private SoundPlayer wingSound;     // Звук крыльев (wing) 

        /// <summary>
        /// Конструктор класса Audio.
        /// Инициализирует объект и загружает все звуковые файлы.
        /// </summary>
        public Audio()
        {
            LoadSounds(); // Загружаем все звуковые файлы
        }

        /// <summary>
        /// Загружает звуковые файлы из папки с программой.
        /// Ищет файлы в подпапке "Audio" относительно исполняемого файла.
        /// </summary>
        private void LoadSounds()
        {
            // Получаем путь к папке, где находится программа
            string path = AppDomain.CurrentDomain.BaseDirectory;

            // Загружаем ВАШИ звуковые файлы
            TryLoadSound(ref dieSound, Path.Combine(path, "Audio/die.wav"));      // Смерть
            TryLoadSound(ref hitSound, Path.Combine(path, "Audio/hit.wav"));      // Удар
            TryLoadSound(ref pointSound, Path.Combine(path, "Audio/point.wav"));  // Очки
            TryLoadSound(ref swooshSound, Path.Combine(path, "Audio/swoosh.wav"));// Свист
        }

        /// <summary>
        /// Пытается загрузить звуковой файл в указанный SoundPlayer.
        /// </summary>
        /// <param name="player">Ссылка на SoundPlayer, в который будет загружен звук.</param>
        /// <param name="filePath">Полный путь к звуковому файлу.</param>
        private void TryLoadSound(ref SoundPlayer player, string filePath)
        {
            // Проверяем, существует ли файл
            if (File.Exists(filePath))
            {
                // Создаем новый SoundPlayer для этого файла
                player = new SoundPlayer(filePath);
            }
            // Если файла нет - player останется null, и звук не будет проигрываться
        }

        /// <summary>
        /// Воспроизведение звука смерти
        /// </summary>
        public void PlayDie()
        {
            PlaySound(dieSound); // Воспроизводим звук смерти
        }

        /// <summary>
        /// Звук удара об трубу
        /// </summary>
        public void PlayHit()
        {
            PlaySound(hitSound); // Воспроизводим звук удара
        }

        /// <summary>
        /// Звук набора очков
        /// </summary>
        public void PlayPoint()
        {
            PlaySound(pointSound); // Воспроизводим звук счета
        }

        /// <summary>
        /// Звук свиста
        /// </summary>
        public void PlaySwoosh()
        {
            PlaySound(swooshSound); // Воспроизводим звук свиста
        }

        /// <summary>
        /// Общий метод для воспроизведения любого звука через SoundPlayer.
        /// </summary>
        /// <param name="player">SoundPlayer, содержащий загруженный звук.</param>
        private void PlaySound(SoundPlayer player)
        {
            // Проверяем, что плеер создан (звук загружен)
            if (player != null)
            {
                player.Play(); // Воспроизводим звук один раз
            }
        }
    }
}
