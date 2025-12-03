using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Game_over : Form
    {
        private int finalScore;

        public Game_over(int score)
        {
            InitializeComponent();
            finalScore = score;
            InitializeForm();
        }

        private void Game_over_Load(object sender, EventArgs e)
        {

        }
        private void InitializeForm()
        {
            // Счет
            scoreLabel.Text = $"Ваш счет: {finalScore}";

            this.FormClosing += Game_over_FormClosing;
               
        }

        private void Game_over_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Если пользователь закрыл форму крестиком
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Устанавливаем DialogResult для обработки в основной форме
                if (this.DialogResult == DialogResult.None)
                {
                    this.DialogResult = DialogResult.Abort; 
                    //this.Close();
                }
            }
        }

        private void Repeet_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }

        private void scoreLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
