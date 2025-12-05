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
    public partial class Pause : Form
    {
        public Pause()
        {
            InitializeComponent();


            // Инициализируем состояние CheckBox/кнопки
            InitializeAudioSettings();
        }

        

        private void InitializeAudioSettings()
        {
            Setting.Checked = !Audio.IsSoundEnabled();
        }

        private void Pause_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (Audio == null) return;

            if (Setting.Checked)
            {
                // Если отмечено (✓) - ВЫКЛЮЧАЕМ звук
                Audio.DisableSound();
            }
            else
            {
                // Если не отмечено - ВКЛЮЧАЕМ звук
                Audio.EnableSound();
            }
        }
    }
}
