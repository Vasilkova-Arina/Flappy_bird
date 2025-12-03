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
    public partial class Complexity : Form
    {
        public Complexity()
        {
            InitializeComponent();
        }

        private void Complexity_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Light_level light = new Light_level();
            this.Hide();
            light.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Medium_level medium = new Medium_level();
            this.Hide();
            medium.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hard_level hard = new Hard_level();
            this.Hide();
            hard.Show();
        }
    }
}
