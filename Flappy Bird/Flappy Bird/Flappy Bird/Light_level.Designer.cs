
namespace Flappy_Bird
{
    partial class Light_level
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
            this.Bird_game = new System.Windows.Forms.PictureBox();
            this.Instruction = new System.Windows.Forms.PictureBox();
            this.pause = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Bird_game)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Instruction)).BeginInit();
            this.SuspendLayout();
            // 
            // Bird_game
            // 
            this.Bird_game.BackColor = System.Drawing.Color.Transparent;
            this.Bird_game.Image = global::Flappy_Bird.Properties.Resources.redbird_upflap;
            this.Bird_game.Location = new System.Drawing.Point(394, 148);
            this.Bird_game.Margin = new System.Windows.Forms.Padding(4);
            this.Bird_game.Name = "Bird_game";
            this.Bird_game.Size = new System.Drawing.Size(57, 52);
            this.Bird_game.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Bird_game.TabIndex = 1;
            this.Bird_game.TabStop = false;
            // 
            // Instruction
            // 
            this.Instruction.BackColor = System.Drawing.Color.Transparent;
            this.Instruction.Image = global::Flappy_Bird.Properties.Resources.Instruction;
            this.Instruction.Location = new System.Drawing.Point(364, 223);
            this.Instruction.Margin = new System.Windows.Forms.Padding(4);
            this.Instruction.Name = "Instruction";
            this.Instruction.Size = new System.Drawing.Size(129, 134);
            this.Instruction.TabIndex = 2;
            this.Instruction.TabStop = false;
            // 
            // pause
            // 
            this.pause.BackColor = System.Drawing.Color.Transparent;
            this.pause.BackgroundImage = global::Flappy_Bird.Properties.Resources.pause1;
            this.pause.Location = new System.Drawing.Point(830, 12);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(40, 40);
            this.pause.TabIndex = 3;
            this.pause.UseVisualStyleBackColor = false;
            // 
            // Light_level
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Flappy_Bird.Properties.Resources.fon1;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.Instruction);
            this.Controls.Add(this.Bird_game);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(900, 500);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "Light_level";
            this.Text = "Легкий уровень";
            this.Load += new System.EventHandler(this.Light_level_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Bird_game)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Instruction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox Bird_game;
        private System.Windows.Forms.PictureBox Instruction;
        private System.Windows.Forms.Button pause;
    }
}