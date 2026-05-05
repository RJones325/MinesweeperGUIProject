// Name: Ray Jones
// Course: CST-250
// Instructor: Gary Ratterree
// Date: 05/03/2026
// Assignment: Milestone 5 - Minesweeper Project
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperClassLibrary.Models
{
    public class BoardModel
    {
        public int Size { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public CellModel[,] Cells { get; set; }
        public int Difficulty { get; set; }
        public int RewardsRemaining { get; set; }
        public GameState GameState { get; set; }

        public BoardModel(int size, int difficulty)
        {
            Size = size;
            Difficulty = difficulty;
            StartTime = DateTime.Now;
            EndTime = DateTime.MinValue;
            RewardsRemaining = 0;
            GameState = GameState.InProgress;

            Cells = new CellModel[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Cells[row, col] = new CellModel
                    {
                        Row = row,
                        Column = col
                    };
                }
            }
        }
    }
}
