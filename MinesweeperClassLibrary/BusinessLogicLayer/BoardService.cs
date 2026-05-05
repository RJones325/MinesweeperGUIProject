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
using MinesweeperClassLibrary.Models;

namespace MinesweeperClassLibrary.BusinessLogicLayer
{
    public class BoardService : IBoardService
    {
        private readonly Random random = new Random();

        public void SetupBombs(BoardModel board)
        {
            int bombCount = GetBombCount(board.Size, board.Difficulty);
            int placed = 0;

            while (placed < bombCount)
            {
                int row = random.Next(board.Size);
                int col = random.Next(board.Size);

                if (!board.Cells[row, col].IsBomb)
                {
                    board.Cells[row, col].IsBomb = true;
                    placed++;
                }
            }
        }

        public void CountBombsNearby(BoardModel board)
        {
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    if (board.Cells[row, col].IsBomb)
                    {
                        board.Cells[row, col].NumberOfBombNeighbors = 9;
                    }
                    else
                    {
                        board.Cells[row, col].NumberOfBombNeighbors = CountNeighbors(board, row, col);
                    }
                }
            }
        }

        private int CountNeighbors(BoardModel board, int row, int col)
        {
            int count = 0;

            // check all surrounding cells for bombs
            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (r >= 0 && r < board.Size && c >= 0 && c < board.Size)
                    {
                        if (!(r == row && c == col) && board.Cells[r, c].IsBomb)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private int GetBombCount(int size, int difficulty)
        {
            int totalCells = size * size;

            if (difficulty == 1)
            {
                return totalCells / 8;
            }
            else if (difficulty == 2)
            {
                return totalCells / 6;
            }
            else
            {
                return totalCells / 4;
            }
        }
        public bool RevealCell(BoardModel board, int row, int col)
        {
            if (row < 0 || row >= board.Size || col < 0 || col >= board.Size)
                return false;

            CellModel cell = board.Cells[row, col];

            if (cell.IsVisited || cell.IsFlagged)
                return false;

            if (cell.IsBomb)
            {
                cell.IsVisited = true;
                return true;
            }

            FloodFill(board, row, col); 

            return false;
        }
        public void FloodFill(BoardModel board, int row, int col)
        {
           
            if (row < 0 || row >= board.Size || col < 0 || col >= board.Size)
                return;

            CellModel cell = board.Cells[row, col];


            if (cell.IsVisited || cell.IsBomb || cell.IsFlagged)
                return;


            cell.IsVisited = true;

            
            if (cell.NumberOfBombNeighbors == 0)
            {
                
                FloodFill(board, row - 1, col);
                FloodFill(board, row + 1, col);
                FloodFill(board, row, col - 1);
                FloodFill(board, row, col + 1);
                FloodFill(board, row - 1, col - 1);
                FloodFill(board, row - 1, col + 1);
                FloodFill(board, row + 1, col - 1);
                FloodFill(board, row + 1, col + 1);
            }
        }

       

        public void ToggleFlag(BoardModel board, int row, int col)
        {
            if (row < 0 || row >= board.Size || col < 0 || col >= board.Size)
                return;

            if (!board.Cells[row, col].IsVisited)
            {
                board.Cells[row, col].IsFlagged = !board.Cells[row, col].IsFlagged;
            }
        }

        public bool CheckWin(BoardModel board)
        {
            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    CellModel cell = board.Cells[row, col];

                    if (!cell.IsBomb && !cell.IsVisited)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}