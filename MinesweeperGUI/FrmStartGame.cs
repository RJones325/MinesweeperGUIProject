// Name: Ray Jones
// Course: CST-250
// Instructor: Gary Ratterree
// Date: 05/03/2026
// Assignment: Milestone 5 - Minesweeper Project
using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class FrmStartGame : Form
    {
        private BoardModel? board;
        private BoardService? boardService;
        private Button[,]? buttons;

        private const int boardSize = 10;
        private const int difficulty = 1;
        private const int cellSize = 35;

        public FrmStartGame()
        {
            InitializeComponent();
            
        }

        private void StartGame()
        {
            this.Controls.Clear();

            boardService = new BoardService();
            board = new BoardModel(boardSize, difficulty);
            buttons = new Button[boardSize, boardSize];

            boardService.SetupBombs(board);
            boardService.CountBombsNearby(board);

            Label lblStatus = new Label();
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "Game in progress";
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(10, 10);
            this.Controls.Add(lblStatus);

            Button btnNewGame = new Button();
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Text = "New Game";
            btnNewGame.Size = new Size(100, 30);
            btnNewGame.Location = new Point(150, 5);
            btnNewGame.Click += BtnNewGame_Click;
            this.Controls.Add(btnNewGame);

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(cellSize, cellSize);
                    btn.Location = new Point(10 + col * cellSize, 45 + row * cellSize);
                    btn.Tag = new Point(row, col);
                    btn.MouseUp += Cell_MouseUp;

                    buttons[row, col] = btn;
                    this.Controls.Add(btn);
                }
            }

            this.ClientSize = new Size(20 + boardSize * cellSize, 60 + boardSize * cellSize);
        }

        private void BtnNewGame_Click(object? sender, EventArgs e)
        {
            StartGame();
        }

        private void Cell_MouseUp(object? sender, MouseEventArgs e)
        {
            if (board == null || boardService == null || buttons == null)
                return;

            if (board.GameState != GameState.InProgress)
                return;

            if (sender is not Button clickedButton)
                return;

            if (clickedButton.Tag is not Point point)
                return;

            int row = point.X;
            int col = point.Y;

            if (e.Button == MouseButtons.Left)
            {
                bool hitBomb = boardService.RevealCell(board, row, col);

                if (hitBomb)
                {
                    board.GameState = GameState.Lost;
                }
                else if (boardService.CheckWin(board))
                {
                    board.GameState = GameState.Won;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                boardService.ToggleFlag(board, row, col);
            }

            UpdateBoard();

            Label? lblStatus = this.Controls["lblStatus"] as Label;

            if (lblStatus == null)
                return;

            if (board.GameState == GameState.Won)
            {
                lblStatus.Text = "You won!";
                MessageBox.Show("You won!");
            }
            else if (board.GameState == GameState.Lost)
            {
                lblStatus.Text = "You lost!";
                RevealAllBombs();
                MessageBox.Show("You hit a bomb!");
            }
        }

        private void UpdateBoard()
        {
            if (board == null || buttons == null)
                return;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    CellModel cell = board.Cells[row, col];
                    Button btn = buttons[row, col];

                    if (cell.IsFlagged && !cell.IsVisited)
                    {
                        btn.Text = "F";
                    }
                    else if (cell.IsVisited)
                    {
                        btn.Enabled = false;

                        if (cell.IsBomb)
                        {
                            btn.Text = "B";
                        }
                        else if (cell.NumberOfBombNeighbors > 0)
                        {
                            btn.Text = cell.NumberOfBombNeighbors.ToString();
                        }
                        else
                        {
                            btn.Text = "";
                        }
                    }
                    else
                    {
                        btn.Text = "";
                        btn.Enabled = true;
                    }
                }
            }
        }

        private void RevealAllBombs()
        {
            if (board == null || buttons == null)
                return;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (board.Cells[row, col].IsBomb)
                    {
                        buttons[row, col].Text = "B";
                    }
                }
            }
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
        }

        private void trkBoardSize_Scroll(object sender, EventArgs e)
        {
            lblBoardSize.Text = trkBoardSize.Value.ToString();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            int size = trkBoardSize.Value;
            int difficulty = 1;

            if (rdoMedium.Checked)
            {
                difficulty = 2;
            }
            else if (rdoHard.Checked)
            {
                difficulty = 3;
            }

            FrmMinesweeperGame gameForm = new FrmMinesweeperGame(size, difficulty);
            gameForm.ShowDialog();
        }
    }
}