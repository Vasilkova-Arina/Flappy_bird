
namespace Flappy_Bird
{
    partial class Medium_level
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
            this.button1 = new System.Windows.Forms.Button();
            this.pause = new System.Windows.Forms.Button();
            this.Instruction = new System.Windows.Forms.PictureBox();
            this.Bird_game = new System.Windows.Forms.PictureBox();
            this.Count = new System.Windows.Forms.Label();
            this.vverx_trub = new System.Windows.Forms.PictureBox();
            this.nizxh_trub = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Instruction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bird_game)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vverx_trub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nizxh_trub)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(197)))), ((int)(((byte)(207)))));
            this.button1.BackgroundImage = global::Flappy_Bird.Properties.Resources.pause1;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(1124, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 48);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pause
            // 
            this.pause.BackColor = System.Drawing.Color.Transparent;
            this.pause.BackgroundImage = global::Flappy_Bird.Properties.Resources.pause1;
            this.pause.Location = new System.Drawing.Point(824, 9);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(40, 40);
            this.pause.TabIndex = 6;
            this.pause.UseVisualStyleBackColor = false;
            // 
            // Instruction
            // 
            this.Instruction.BackColor = System.Drawing.Color.Transparent;
            this.Instruction.Image = global::Flappy_Bird.Properties.Resources.Instruction;
            this.Instruction.Location = new System.Drawing.Point(358, 220);
            this.Instruction.Margin = new System.Windows.Forms.Padding(4);
            this.Instruction.Name = "Instruction";
            this.Instruction.Size = new System.Drawing.Size(129, 134);
            this.Instruction.TabIndex = 5;
            this.Instruction.TabStop = false;
            // 
            // Bird_game
            // 
            this.Bird_game.BackColor = System.Drawing.Color.Transparent;
            this.Bird_game.Image = global::Flappy_Bird.Properties.Resources.redbird_upflap;
            this.Bird_game.Location = new System.Drawing.Point(388, 145);
            this.Bird_game.Margin = new System.Windows.Forms.Padding(4);
            this.Bird_game.Name = "Bird_game";
            this.Bird_game.Size = new System.Drawing.Size(57, 52);
            this.Bird_game.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Bird_game.TabIndex = 4;
            this.Bird_game.TabStop = false;
            // 
            // Count
            // 
            this.Count.AutoSize = true;
            this.Count.BackColor = System.Drawing.Color.Transparent;
            this.Count.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Count.ForeColor = System.Drawing.Color.White;
            this.Count.Location = new System.Drawing.Point(12, 9);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(0, 44);
            this.Count.TabIndex = 10;
            // 
            // vverx_trub
            // 
            this.vverx_trub.BackColor = System.Drawing.Color.Transparent;
            this.vverx_trub.Image = global::Flappy_Bird.Properties.Resources.nizch_trub;
            this.vverx_trub.Location = new System.Drawing.Point(777, -107);
            this.vverx_trub.Name = "vverx_trub";
            this.vverx_trub.Size = new System.Drawing.Size(45, 237);
            this.vverx_trub.TabIndex = 8;
            this.vverx_trub.TabStop = false;
            // 
            // nizxh_trub
            // 
            this.nizxh_trub.BackColor = System.Drawing.Color.Transparent;
            this.nizxh_trub.Image = global::Flappy_Bird.Properties.Resources.vverx_trub;
            this.nizxh_trub.Location = new System.Drawing.Point(766, 298);
            this.nizxh_trub.Name = "nizxh_trub";
            this.nizxh_trub.Size = new System.Drawing.Size(56, 206);
            this.nizxh_trub.TabIndex = 11;
            this.nizxh_trub.TabStop = false;
            // 
            // Medium_level
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Flappy_Bird.Properties.Resources.fon2;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.nizxh_trub);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.vverx_trub);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.Instruction);
            this.Controls.Add(this.Bird_game);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(900, 500);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "Medium_level";
            this.Text = "Medium_level";
            this.Load += new System.EventHandler(this.Medium_level_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Instruction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bird_game)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vverx_trub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nizxh_trub)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.PictureBox Instruction;
        private System.Windows.Forms.PictureBox Bird_game;
        private System.Windows.Forms.Label Count;
        private System.Windows.Forms.PictureBox vverx_trub;
        private System.Windows.Forms.PictureBox nizxh_trub;
    }
}