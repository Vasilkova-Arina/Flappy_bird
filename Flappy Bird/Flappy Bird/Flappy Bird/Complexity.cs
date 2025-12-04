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
            this.Close();

            Light_level light = new Light_level();
            light.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            Medium_level medium = new Medium_level();
            medium.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

            Hard_level hard = new Hard_level();
            hard.Show();
        }
    }
}
