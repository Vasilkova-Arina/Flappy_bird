using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Medium_level : Form
    {
        // Игровые объекты
        private Bird bird;
        private Trub pipes;
        private Timer gameTimer;

        // Игровые переменные
        private bool gameRunning = false;
        private bool gameStarted = false;
        private int score = 0;
        private int groundLevel;
        private bool Pause_game = false;

        private Audio audio; // для воспроизведения аудио

        // Для звука свиста
        private int frameCount = 0;
        private const int SwooshInterval = 100; // Каждые 100 кадров

        public Medium_level()
        {
            InitializeComponent();

            DoubleBuffered = true;

            this.Focus();
            this.KeyPreview = true;

            this.MouseClick += LevelForm_MouseClick;

            // Устанавливаем, чтобы форма могла получать фокус
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;

            audio = new Audio();

            InitializeGame();
        }

        

        private void Medium_level_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void InitializeGame()
        {
            // Определяем уровень земли
            groundLevel = this.ClientSize.Height - 5;

            // Инициализируем птицу
            InitializeBird();

            // Инициализируем трубы
            InitializePipes();

            // Настраиваем игровой таймер
            gameTimer = new Timer();
            gameTimer.Interval = 30; // 30 кадров в секунду
            gameTimer.Tick += GameTimer_Tick;

            // Настраиваем управление - клики мыши
            this.MouseClick += LevelForm_MouseClick;
            this.KeyPreview = true;

            // Показываем инструкцию при старте
            if (Instruction != null)
            {
                Instruction.Visible = true;
                Instruction.Click += (s, ev) => StartGame();
            }

            if (Pause_instruction != null)
            {
                Pause_instruction.Visible = true; // ИЗМЕНИТЕ false на true
                Pause_instruction.Text = "Нажмите пробел или кликните чтобы прыгнуть\nESC - пауза";
                Pause_instruction.Click += (s, ev) => StartGame();
            }
        }

        //метод - обработка клавиш
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Пробел - прыжок
            if (keyData == Keys.Space)
            {
                if (!gameStarted)
                {
                    StartGame();
                }
                else if (gameRunning && !Pause_game)
                {
                    bird.Jump();
                }
                return true; // Клавиша обработана
            }

            // ESC - пауза
            if (keyData == Keys.Escape)
            {
                if (gameStarted && gameRunning)
                {
                    ShowPauseForm();
                }
                return true; // Клавиша обработана
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void InitializeBird()
        {
            // Создаем или загружаем изображения для птицы
            Image birdImage1, birdImage2;

            try
            {
                // Пробуем загрузить изображения из файлов
                string exePath = Application.StartupPath;
                string path1 = Path.Combine(exePath, "redbird-downflap.png");
                string path2 = Path.Combine(exePath, "redbird-upflap.png");

                if (File.Exists(path1) && File.Exists(path2))
                {
                    birdImage1 = Image.FromFile(path1);
                    birdImage2 = Image.FromFile(path2);
                }
                else
                {
                    // Если файлы не найдены, создаем простые изображения
                    birdImage1 = CreateSimpleBirdImage(Color.Red, false);
                    birdImage2 = CreateSimpleBirdImage(Color.DarkRed, true);
                }
            }
            catch
            {
                // При любой ошибке создаем простые изображения
                birdImage1 = CreateSimpleBirdImage(Color.Red, false);
                birdImage2 = CreateSimpleBirdImage(Color.DarkRed, true);
            }

            // СОЗДАЕМ ПТИЦУ
            bird = new Bird(Bird_game, birdImage1, birdImage2, groundLevel);
        }

        // Вспомогательный метод для создания простых изображений птицы
        private Image CreateSimpleBirdImage(Color color, bool wingsUp)
        {
            Bitmap bmp = new Bitmap(40, 30);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillEllipse(brush, 0, wingsUp ? 5 : 0, 30, 25);
                }

                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    g.FillEllipse(brush, 20, 8, 10, 10);
                }

                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    g.FillEllipse(brush, 23, 11, 4, 4);
                }

                using (SolidBrush brush = new SolidBrush(Color.Orange))
                {
                    Point[] beakPoints = { new Point(30, 12), new Point(38, 15), new Point(30, 18) };
                    g.FillPolygon(brush, beakPoints);
                }
            }
            return bmp;
        }




        private void InitializePipes()
        {
            // СОЗДАЕМ ТРУБЫ
            pipes = new Trub(vverx_trub, nizxh_trub, this, Trub.DifficultyLevel.Medium);
            pipes.Reset_Trub();
        }

        private void StartGame()
        {
            gameStarted = true;
            gameRunning = true;
            score = 0;

            // Обновляем счет
            if (Count != null)
                Count.Text = "Очки: 0";

            // Скрываем инструкцию
            if (Instruction != null)
                Instruction.Visible = false;

            if (Pause_instruction != null)
                Pause_instruction.Visible = false;

            // Сбрасываем птицу
            bird.Reset(150, this.ClientSize.Height / 2);

            // Сбрасываем трубы
            pipes.Reset_Trub();

            // Запускаем игровой таймер
            gameTimer.Start();
        }

        private void GameOver()
        {
            gameRunning = false;
            gameTimer.Stop();
            bird.StopMovement();
            audio.PlayDie();

            // Показываем форму GameOver
            ShowGameOverForm();
        }

        private void ShowGameOverForm()
        {
            Game_over gameover = new Game_over(score);
            var result = gameover.ShowDialog();

            // Проверяем результат (переиграть или выйти)
            if (result == DialogResult.Retry)
            {
                // Начать заново
                StartGame();
            }
            else if (result == DialogResult.Abort || result == DialogResult.Cancel)
            {
                // Выход в меню
                this.Close();

                Main main = new Main();
                main.Show();

                //Application.Exit();
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (!gameRunning || Pause_game) return;

            // Обновляем птицу
            bird.Update();

            // Двигаем трубы
            pipes.Move();

            if (frameCount % 100 == 0) // Каждые 30 кадров, проигрываем звук свиста
            {
                audio.PlaySwoosh();
            }
            frameCount++;

            // Проверяем, ушли ли трубы за экран
            if (pipes.IsOutOfScreen())
            {
                pipes.Reset_Trub();
                score++;
                audio.PlayPoint();

                // Обновляем счет
                if (Count != null)
                    Count.Text = $"Очки: {score}";
            }

            // Проверяем столкновения
            if (pipes.CheckCollision(bird.GetBounds()) ||
                bird.GetBounds().Bottom >= groundLevel)
            {
                audio.PlayHit();
                GameOver();
            }

            // Перерисовываем форму
            this.Invalidate();
        }

        // ОБРАБОТКА КЛИКОВ МЫШЬЮ ПО ФОРМЕ
        private void LevelForm_MouseClick(object sender, MouseEventArgs e)
        {

            // Клик по форме
            if (!gameStarted)
            {
                // Первый клик - начинаем игру
                StartGame();
            }
            else if (gameRunning && !Pause_game)
            {
                // Игра идет - птица прыгает
                bird.Jump();
            }
        }

        private void ShowPauseForm()
        {
            if (!gameStarted) return;

            // Ставим на паузу
            Pause_game = true;
            gameTimer.Stop();

            // Показываем форму паузы
            Pause pauseForm = new Pause();
            DialogResult result = pauseForm.ShowDialog(); // Получаем результат

            // Обрабатываем результат
            if (result == DialogResult.OK)
            {
                // Пользователь выбрал "Продолжить"
                Pause_game = false;
                gameTimer.Start();
            }
            else if (result == DialogResult.Abort)
            {
                // Выход в меню
                this.Close();

                Main main = new Main();
                main.Show();
            }
        }
    }
}
