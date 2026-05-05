// Name: Ray Jones
// Course: CST-250
// Instructor: Gary Ratterree
// Date: 05/03/2026
// Assignment: Milestone 5 - Minesweeper Project

using MinesweeperClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MinesweeperGUI
{
    public partial class Form4 : Form
    {
        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private List<GameStat> scores = new List<GameStat>();
        private string filePath = "scores.txt";

        public Form4(GameStat newScore)
        {
            InitializeComponent();

            if (File.Exists(filePath))
            {
                LoadScores();
            }

            scores.Add(newScore);
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvScores.DataSource = null;
            dgvScores.DataSource = scores;
        }

        private void LoadScores()
        {
            scores.Clear();

            if (!File.Exists(filePath))
            {
                return;
            }

            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split(',');

                scores.Add(new GameStat
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    Score = int.Parse(parts[2]),
                    GameTime = DateTime.Parse(parts[3])
                });
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> lines = new List<string>();

            foreach (GameStat score in scores)
            {
                lines.Add($"{score.Id},{score.Name},{score.Score},{score.GameTime}");
            }

            File.WriteAllLines(filePath, lines);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadScores();
            RefreshGrid();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scores = scores.OrderBy(s => s.Name).ToList();
            RefreshGrid();
        }

        private void byScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scores = scores.OrderByDescending(s => s.Score).ToList();
            RefreshGrid();
        }

        private void byDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scores = scores.OrderByDescending(s => s.GameTime).ToList();
            RefreshGrid();
        }
        public Form4()
        {
            InitializeComponent();
        }

        

        

       
    }
}
