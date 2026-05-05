namespace MinesweeperGUI
{
    partial class Form4
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
            dgvScores = new DataGridView();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            sortToolStripMenuItem = new ToolStripMenuItem();
            byNameToolStripMenuItem = new ToolStripMenuItem();
            byScoreToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            byNameToolStripMenuItem1 = new ToolStripMenuItem();
            byScoreToolStripMenuItem1 = new ToolStripMenuItem();
            byDateToolStripMenuItem1 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvScores).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvScores
            // 
            dgvScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScores.Location = new Point(179, 177);
            dgvScores.Name = "dgvScores";
            dgvScores.Size = new Size(393, 257);
            dgvScores.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, saveToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sortToolStripMenuItem, byNameToolStripMenuItem, byScoreToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(40, 20);
            fileToolStripMenuItem.Text = "File:";
            // 
            // sortToolStripMenuItem
            // 
            sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            sortToolStripMenuItem.Size = new Size(180, 22);
            sortToolStripMenuItem.Text = "Save";
            sortToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // byNameToolStripMenuItem
            // 
            byNameToolStripMenuItem.Name = "byNameToolStripMenuItem";
            byNameToolStripMenuItem.Size = new Size(180, 22);
            byNameToolStripMenuItem.Text = "Load";
            byNameToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // byScoreToolStripMenuItem
            // 
            byScoreToolStripMenuItem.Name = "byScoreToolStripMenuItem";
            byScoreToolStripMenuItem.Size = new Size(180, 22);
            byScoreToolStripMenuItem.Text = "Exit";
            byScoreToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { byNameToolStripMenuItem1, byScoreToolStripMenuItem1, byDateToolStripMenuItem1 });
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(43, 20);
            saveToolStripMenuItem.Text = "Sort:";
            // 
            // byNameToolStripMenuItem1
            // 
            byNameToolStripMenuItem1.Name = "byNameToolStripMenuItem1";
            byNameToolStripMenuItem1.Size = new Size(180, 22);
            byNameToolStripMenuItem1.Text = "By Name";
            byNameToolStripMenuItem1.Click += byNameToolStripMenuItem_Click;
            // 
            // byScoreToolStripMenuItem1
            // 
            byScoreToolStripMenuItem1.Name = "byScoreToolStripMenuItem1";
            byScoreToolStripMenuItem1.Size = new Size(180, 22);
            byScoreToolStripMenuItem1.Text = "By Score";
            byScoreToolStripMenuItem1.Click += byScoreToolStripMenuItem_Click;
            // 
            // byDateToolStripMenuItem1
            // 
            byDateToolStripMenuItem1.Name = "byDateToolStripMenuItem1";
            byDateToolStripMenuItem1.Size = new Size(180, 22);
            byDateToolStripMenuItem1.Text = "By Date";
            byDateToolStripMenuItem1.Click += byDateToolStripMenuItem_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvScores);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dgvScores).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvScores;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem sortToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem byNameToolStripMenuItem;
        private ToolStripMenuItem byScoreToolStripMenuItem;
        private ToolStripMenuItem byNameToolStripMenuItem1;
        private ToolStripMenuItem byScoreToolStripMenuItem1;
        private ToolStripMenuItem byDateToolStripMenuItem1;
    }
}