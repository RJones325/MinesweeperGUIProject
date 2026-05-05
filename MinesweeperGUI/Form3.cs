// Name: Ray Jones
// Course: CST-250
// Instructor: Gary Ratterree
// Date: 05/03/2026
// Assignment: Milestone 5 - Minesweeper Project

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form3 : Form
    {
        public string PlayerName { get; private set; }

        private int finalScore;

        public Form3(int score)
        {
            InitializeComponent();
            
            btnOK.Click += btnOK_Click;

            finalScore = score;
            lblScore.Text = "Score: " + finalScore;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PlayerName = txtName.Text;

            if (string.IsNullOrWhiteSpace(PlayerName))
            {
                PlayerName = "Player1";
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}