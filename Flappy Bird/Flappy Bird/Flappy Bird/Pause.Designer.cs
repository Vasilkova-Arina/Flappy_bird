
namespace Flappy_Bird
{
    partial class Pause
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.Contin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Contin)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(197)))), ((int)(((byte)(207)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(191, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пауза";
            // 
            // exit
            // 
            this.exit.BackgroundImage = global::Flappy_Bird.Properties.Resources.fon_button;
            this.exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.Color.White;
            this.exit.Image = global::Flappy_Bird.Properties.Resources.fon_button;
            this.exit.Location = new System.Drawing.Point(139, 268);
            this.exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(221, 80);
            this.exit.TabIndex = 1;
            this.exit.Text = "Выйти";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.button2_Click);
            // 
            // Contin
            // 
            this.Contin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(197)))), ((int)(((byte)(207)))));
            this.Contin.Image = global::Flappy_Bird.Properties.Resources.Repeet;
            this.Contin.Location = new System.Drawing.Point(95, 105);
            this.Contin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Contin.Name = "Contin";
            this.Contin.Size = new System.Drawing.Size(331, 156);
            this.Contin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Contin.TabIndex = 2;
            this.Contin.TabStop = false;
            this.Contin.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Pause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Flappy_Bird.Properties.Resources.fon2;
            this.ClientSize = new System.Drawing.Size(509, 558);
            this.Controls.Add(this.Contin);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(527, 605);
            this.MinimumSize = new System.Drawing.Size(527, 605);
            this.Name = "Pause";
            this.Text = "Пауза";
            this.Load += new System.EventHandler(this.Pause_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Contin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.PictureBox Contin;
    }
}