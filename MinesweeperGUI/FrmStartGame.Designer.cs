namespace MinesweeperGUI
{
    partial class FrmStartGame
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
            label1 = new Label();
            label2 = new Label();
            trkBoardSize = new TrackBar();
            lblBoardSize = new Label();
            label3 = new Label();
            rdoEasy = new RadioButton();
            rdoMedium = new RadioButton();
            rdoHard = new RadioButton();
            btnPlay = new Button();
            ((System.ComponentModel.ISupportInitialize)trkBoardSize).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 9);
            label1.Name = "label1";
            label1.Size = new Size(175, 37);
            label1.TabIndex = 0;
            label1.Text = "Minesweeper";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 66);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Board Size";
            // 
            // trkBoardSize
            // 
            trkBoardSize.Location = new Point(119, 66);
            trkBoardSize.Maximum = 20;
            trkBoardSize.Minimum = 5;
            trkBoardSize.Name = "trkBoardSize";
            trkBoardSize.Size = new Size(159, 45);
            trkBoardSize.TabIndex = 2;
            trkBoardSize.Value = 10;
            trkBoardSize.Scroll += trkBoardSize_Scroll;
            // 
            // lblBoardSize
            // 
            lblBoardSize.AutoSize = true;
            lblBoardSize.Location = new Point(284, 80);
            lblBoardSize.Name = "lblBoardSize";
            lblBoardSize.Size = new Size(19, 15);
            lblBoardSize.TabIndex = 3;
            lblBoardSize.Text = "10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 108);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 4;
            label3.Text = "Difficulty";
            // 
            // rdoEasy
            // 
            rdoEasy.AutoSize = true;
            rdoEasy.Checked = true;
            rdoEasy.Location = new Point(103, 108);
            rdoEasy.Name = "rdoEasy";
            rdoEasy.Size = new Size(48, 19);
            rdoEasy.TabIndex = 5;
            rdoEasy.TabStop = true;
            rdoEasy.Text = "Easy";
            rdoEasy.UseVisualStyleBackColor = true;
            // 
            // rdoMedium
            // 
            rdoMedium.AutoSize = true;
            rdoMedium.Location = new Point(103, 133);
            rdoMedium.Name = "rdoMedium";
            rdoMedium.Size = new Size(70, 19);
            rdoMedium.TabIndex = 6;
            rdoMedium.Text = "Medium";
            rdoMedium.UseVisualStyleBackColor = true;
            // 
            // rdoHard
            // 
            rdoHard.AutoSize = true;
            rdoHard.Location = new Point(103, 158);
            rdoHard.Name = "rdoHard";
            rdoHard.Size = new Size(51, 19);
            rdoHard.TabIndex = 7;
            rdoHard.Text = "Hard";
            rdoHard.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(214, 154);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(75, 23);
            btnPlay.TabIndex = 8;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // FrmStartGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnPlay);
            Controls.Add(rdoHard);
            Controls.Add(rdoMedium);
            Controls.Add(rdoEasy);
            Controls.Add(label3);
            Controls.Add(lblBoardSize);
            Controls.Add(trkBoardSize);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmStartGame";
            Text = "Start a New Game";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trkBoardSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TrackBar trkBoardSize;
        private Label lblBoardSize;
        private Label label3;
        private RadioButton rdoEasy;
        private RadioButton rdoMedium;
        private RadioButton rdoHard;
        private Button btnPlay;
    }
}