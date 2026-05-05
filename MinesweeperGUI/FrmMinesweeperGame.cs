// Name: Ray Jones
// Course: CST-250
// Instructor: Gary Ratterree
// Date: 00/03/2026
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
using MinesweeperClassLibrary.Models;
using MinesweeperClassLibrary.BusinessLogicLayer;

namespace MinesweeperGUI
{
    public partial class FrmMinesweeperGame : Form
    {
        private Button[,] buttons = null!;
        private int gridSize = 10;
        private BoardModel board;
        private BoardService boardService = new BoardService();


        public FrmMinesweeperGame(int size, int difficulty)
        {
            InitializeComponent();

            gridSize = size;

            board = new BoardModel(gridSize, difficulty);
            boardService.SetupBombs(board);
            boardService.CountBombsNearby(board);

            CreateBoard();
        }

        private void CreateBoard()
        {
            pnlBoard.Controls.Clear();

            buttons = new Button[gridSize, gridSize];

            int buttonSize = pnlBoard.Width / gridSize;

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Button btn = new Button();
                    btn.Width = buttonSize;
                    btn.Height = buttonSize;
                    btn.Left = col * buttonSize;
                    btn.Top = row * buttonSize;
                    btn.Tag = new Point(row, col);
                    btn.Click += Cell_Click;
                    btn.MouseUp += Cell_MouseUp;

                    pnlBoard.Controls.Add(btn);
                    buttons[row, col] = btn;
                }
            }
        }

        private void Cell_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Tag is not Point pos)
            {
                return;
            }

            bool hitBomb = boardService.RevealCell(board, pos.X, pos.Y);

            UpdateBoardUI();

            if (hitBomb)
            {
                MessageBox.Show("You hit a bomb!");
            }
            else if (boardService.CheckWin(board))
            {
                int finalScore = gridSize * board.Difficulty * 100;

                Form3 nameForm = new Form3(finalScore);

                if (nameForm.ShowDialog() == DialogResult.OK)
                {
                    GameStat stat = new GameStat
                    {
                        Id = 1,
                        Name = nameForm.PlayerName,
                        Score = finalScore,
                        GameTime = DateTime.Now
                    };

                    Form4 scoreForm = new Form4(stat);
                    scoreForm.ShowDialog();
                }
            }
        }
        private void UpdateBoardUI()
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    var cell = board.Cells[row, col];
                    var btn = buttons[row, col];

                    // FLAGGED (comes first)
                    if (cell.IsFlagged)
                    {
                        btn.Text = "F";
                        btn.BackColor = Color.LightBlue;
                        btn.Enabled = true;
                    }
                    // NOT VISITED
                    else if (!cell.IsVisited)
                    {
                        btn.Text = "";
                        btn.BackColor = Color.LightGray;
                        btn.Enabled = true;
                    }
                    // VISITED
                    else
                    {
                        btn.Enabled = false;

                        if (cell.IsBomb)
                        {
                            btn.Text = "B";
                            btn.BackColor = Color.Red;
                        }
                        else if (cell.NumberOfBombNeighbors > 0)
                        {
                            btn.Text = cell.NumberOfBombNeighbors.ToString();
                            btn.BackColor = Color.White;
                        }
                        else
                        {
                            btn.Text = "";
                            btn.BackColor = Color.White;
                        }
                    }
                }
            }
        }
        private void Cell_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            if (sender is not Button btn || btn.Tag is not Point pos)
            {
                return;
            }

            boardService.ToggleFlag(board, pos.X, pos.Y);
            UpdateBoardUI();
        }
    }
}
