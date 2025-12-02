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
               
        }

        private void Repeet_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
