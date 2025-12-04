
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
            this.vverx_trub = new System.Windows.Forms.PictureBox();
            this.nizxh_trub = new System.Windows.Forms.PictureBox();
            this.Count = new System.Windows.Forms.Label();
            this.Pause_instruction = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Bird_game)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Instruction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vverx_trub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nizxh_trub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // vverx_trub
            // 
            this.vverx_trub.BackColor = System.Drawing.Color.Transparent;
            this.vverx_trub.Image = global::Flappy_Bird.Properties.Resources.nizch_trub;
            this.vverx_trub.Location = new System.Drawing.Point(629, -92);
            this.vverx_trub.Name = "vverx_trub";
            this.vverx_trub.Size = new System.Drawing.Size(39, 253);
            this.vverx_trub.TabIndex = 4;
            this.vverx_trub.TabStop = false;
            this.vverx_trub.Click += new System.EventHandler(this.vverx_trub_Click);
            // 
            // nizxh_trub
            // 
            this.nizxh_trub.BackColor = System.Drawing.Color.Transparent;
            this.nizxh_trub.Image = global::Flappy_Bird.Properties.Resources.vverx_trub;
            this.nizxh_trub.Location = new System.Drawing.Point(690, 324);
            this.nizxh_trub.Name = "nizxh_trub";
            this.nizxh_trub.Size = new System.Drawing.Size(45, 206);
            this.nizxh_trub.TabIndex = 5;
            this.nizxh_trub.TabStop = false;
            // 
            // Count
            // 
            this.Count.AutoSize = true;
            this.Count.BackColor = System.Drawing.Color.Transparent;
            this.Count.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Count.ForeColor = System.Drawing.Color.White;
            this.Count.Location = new System.Drawing.Point(12, 3);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(0, 43);
            this.Count.TabIndex = 7;
            // 
            // Pause_instruction
            // 
            this.Pause_instruction.AutoSize = true;
            this.Pause_instruction.BackColor = System.Drawing.Color.Transparent;
            this.Pause_instruction.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pause_instruction.Location = new System.Drawing.Point(18, 18);
            this.Pause_instruction.Name = "Pause_instruction";
            this.Pause_instruction.Size = new System.Drawing.Size(406, 33);
            this.Pause_instruction.TabIndex = 9;
            this.Pause_instruction.Text = "Для паузы, нажмите ESC";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Flappy_Bird.Properties.Resources.Zemlya;
            this.pictureBox1.Location = new System.Drawing.Point(-79, 448);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1124, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Light_level
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Flappy_Bird.Properties.Resources.fon1;
            this.ClientSize = new System.Drawing.Size(882, 503);
            this.Controls.Add(this.nizxh_trub);
            this.Controls.Add(this.Pause_instruction);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.vverx_trub);
            this.Controls.Add(this.Instruction);
            this.Controls.Add(this.Bird_game);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(900, 550);
            this.MinimumSize = new System.Drawing.Size(900, 550);
            this.Name = "Light_level";
            this.Text = "Легкий уровень";
            this.Load += new System.EventHandler(this.Light_level_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Bird_game)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Instruction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vverx_trub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nizxh_trub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Bird_game;
        private System.Windows.Forms.PictureBox Instruction;
        private System.Windows.Forms.PictureBox vverx_trub;
        private System.Windows.Forms.PictureBox nizxh_trub;
        private System.Windows.Forms.Label Count;
        private System.Windows.Forms.Label Pause_instruction;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}