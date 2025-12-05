using System;
using System.IO;
using System.Media;

namespace Flappy_Bird
{
    /// <summary>
    /// Статический класс для импорта звуковых файлов
    /// </summary>
    internal static class Audio
    {
        /// <summary>
        /// Переменные для хранения звуковых плееров.
        /// Каждая переменная отвечает за определенный звуковой эффект.
        /// </summary>
        private static SoundPlayer dieSound;      // Звук смерти (die)
        private static SoundPlayer hitSound;      // Звук удара (hit)
        private static SoundPlayer pointSound;    // Звук очков (point)
        private static SoundPlayer swooshSound;   // Звук свиста (swoosh) 
        private static SoundPlayer wingSound;     // Звук крыльев (wing) 

        /// <summary>
        /// Флаг для отслеживания состояния звука.
        /// true - звук включен, false - звук выключен.
        /// </summary>
        private static bool isSoundEnabled = true; // Изменил на true для включенного звука по умолчанию

        /// <summary>
        /// Статический конструктор класса Audio.
        /// Инициализирует объект и загружает все звуковые файлы.
        /// </summary>
        static Audio()
        {
            LoadSounds(); // Загружаем все звуковые файлы
        }

        /// <summary>
        /// Загружает звуковые файлы из папки с программой.
        /// Ищет файлы в подпапке "Audio" относительно исполняемого файла.
        /// </summary>
        private static void LoadSounds()
        {
            // Получаем путь к папке, где находится программа
            string path = AppDomain.CurrentDomain.BaseDirectory;

            // Загружаем ВАШИ звуковые файлы
            TryLoadSound(ref dieSound, Path.Combine(path, "Audio/die.wav"));      // Смерть
            TryLoadSound(ref hitSound, Path.Combine(path, "Audio/hit.wav"));      // Удар
            TryLoadSound(ref pointSound, Path.Combine(path, "Audio/point.wav"));  // Очки
            TryLoadSound(ref swooshSound, Path.Combine(path, "Audio/swoosh.wav"));// Свист
            TryLoadSound(ref wingSound, Path.Combine(path, "Audio/wing.wav"));    // Крылья
        }

        /// <summary>
        /// Пытается загрузить звуковой файл в указанный SoundPlayer.
        /// </summary>
        /// <param name="player">Ссылка на SoundPlayer, в который будет загружен звук.</param>
        /// <param name="filePath">Полный путь к звуковому файлу.</param>
        private static void TryLoadSound(ref SoundPlayer player, string filePath)
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
        public static void PlayDie()
        {
            if (isSoundEnabled) // Добавил проверку
            {
                PlaySound(dieSound);
            }
        }

        /// <summary>
        /// Звук удара об трубу
        /// </summary>
        public static void PlayHit()
        {
            if (isSoundEnabled) // Добавил проверку
            {
                PlaySound(hitSound);
            }
        }

        /// <summary>
        /// Звук набора очков
        /// </summary>
        public static void PlayPoint()
        {
            if (isSoundEnabled) // Добавил проверку
            {
                PlaySound(pointSound);
            }
        }

        /// <summary>
        /// Звук свиста
        /// </summary>
        public static void PlaySwoosh()
        {
            if (isSoundEnabled) // Добавил проверку
            {
                PlaySound(swooshSound);
            }
        }

        /// <summary>
        /// Звук крыльев
        /// </summary>
        public static void PlayWing()
        {
            if (isSoundEnabled && wingSound != null) // Добавил проверку
            {
                PlaySound(wingSound);
            }
        }

        /// <summary>
        /// Общий метод для воспроизведения любого звука через SoundPlayer.
        /// </summary>
        /// <param name="player">SoundPlayer, содержащий загруженный звук.</param>
        private static void PlaySound(SoundPlayer player)
        {
            // Проверяем, что плеер создан (звук загружен)
            if (player != null)
            {
                player.Play(); // Воспроизводим звук один раз
            }
        }

        /// <summary>
        /// Включает воспроизведение звуковых эффектов.
        /// </summary>
        public static void EnableSound()
        {
            isSoundEnabled = true;
        }

        /// <summary>
        /// Выключает воспроизведение звуковых эффектов.
        /// </summary>
        public static void DisableSound()
        {
            isSoundEnabled = false;
        }

        /// <summary>
        /// Получает текущее состояние звука.
        /// </summary>
        /// <returns>true - звук включен, false - звук выключен</returns>
        public static bool IsSoundEnabled()
        {
            return isSoundEnabled;
        }

        /// <summary>
        /// Переключает состояние звука.
        /// </summary>
        /// <returns>Новое состояние звука</returns>
        public static bool ToggleSound()
        {
            isSoundEnabled = !isSoundEnabled;
            return isSoundEnabled;
        }
    }
}