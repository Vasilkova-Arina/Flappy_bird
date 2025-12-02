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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Flappy_Bird
{
    public partial class Light_level : Form
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

        public Light_level()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void Light_level_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void InitializeGame()
        {
            // Определяем уровень земли
            groundLevel = this.ClientSize.Height - 100;



            // Инициализируем птицу
            InitializeBird();

            // Инициализируем трубы
            InitializePipes();

            // Настраиваем игровой таймер
            gameTimer = new Timer();
            gameTimer.Interval = 20; // 50 кадров в секунду
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

            // Настраиваем кнопку паузы
            if (pause != null)
            {
                pause.Click += PauseButton_Click;
            }
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
            pipes = new Trub(vverx_trub, nizxh_trub, this);
            pipes.Reset();
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

            // Сбрасываем птицу
            bird.Reset(150, this.ClientSize.Height / 2);
            bird.StartAnimation();

            // Сбрасываем трубы
            pipes.Reset();

            // Запускаем игровой таймер
            gameTimer.Start();
        }

        private void GameOver()
        {
            gameRunning = false;
            gameTimer.Stop();
            bird.StopMovement();

            // Показываем форму GameOver
            ShowGameOverForm();
        }

        private void ShowGameOverForm()
        {
            Game_over gameover = new Game_over(score);
            gameover.ShowDialog();

            // Проверяем результат (переиграть или выйти)
            if (gameover.DialogResult == DialogResult.Retry)
            {
                // Начать заново
                StartGame();
            }
            else if (gameover.DialogResult == DialogResult.Abort)
            {
                // Выход в меню
                this.Close();
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (!gameRunning || Pause_game) return;

            // Обновляем птицу
            bird.Update();

            // Двигаем трубы
            pipes.Move();

            // Проверяем, ушли ли трубы за экран
            if (pipes.IsOutOfScreen())
            {
                pipes.Reset();
                score++;

                // Обновляем счет
                if (Count != null)
                    Count.Text = $"Очки: {score}";
            }

            // Проверяем столкновения
            if (pipes.CheckCollision(bird.GetBounds()) ||
                bird.GetBounds().Bottom >= groundLevel)
            {
                GameOver();
            }

            // Перерисовываем форму
            this.Invalidate();
        }

        // ОБРАБОТКА КЛИКОВ МЫШЬЮ ПО ФОРМЕ
        private void LevelForm_MouseClick(object sender, MouseEventArgs e)
        {
            // Проверяем, не кликнули ли по кнопке паузы
            if (pause != null && pause.Bounds.Contains(e.Location))
            {
                // Клик по кнопке паузы - обработается в PauseButton_Click
                return;
            }

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

        // КНОПКА ПАУЗЫ
        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (!gameStarted) return; // Игра еще не началась

            // Показываем форму паузы
            ShowPauseForm();
        }

        private void ShowPauseForm()
        {
            // Ставим игру на паузу
            Pause_game = true;
            gameTimer.Stop();
            bird.StopAnimation();

            Pause pauseform = new Pause();
            pauseform.ShowDialog();

            // Проверяем результат
            if (pauseform.DialogResult == DialogResult.OK)
            {
                // Продолжаем игру
                Pause_game = false;
                gameTimer.Start();
                bird.StartAnimation();
            }
            else if (pauseform.DialogResult == DialogResult.Abort)
            {
                // Выход из игры
                this.Close();
            }
            else
            {
                // Пользователь просто закрыл окно - остаемся на паузе
                // Кнопка "Продолжить" на форме позволит продолжить
            }
        }

        

        // При изменении размера формы
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Обновляем уровень земли
            groundLevel = this.ClientSize.Height - 100;

            // Обновляем птицу
            if (bird != null)
                bird.SetGroundLevel(groundLevel);

            // Перерисовываем
            this.Invalidate();
        }

        // Закрытие формы при нажатии Escape
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                // Нажали Escape - показываем паузу
                if (gameStarted && gameRunning)
                {
                    ShowPauseForm();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pause pause = new Pause();
            pause.ShowDialog();
        }
    }
}
