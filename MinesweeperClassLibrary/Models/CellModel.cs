// Name: Ray Jones
// Course: CST-250
// Instructor: Gary Ratterree
// Date: 04/19/2026
// Assignment: Milestone 3 - Minesweeper Project
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperClassLibrary.Models
{
    public class CellModel : BaseCell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsVisited { get; set; }
        public bool IsBomb { get; set; }
        public bool IsFlagged { get; set; }
        public int NumberOfBombNeighbors { get; set; }
        public bool HasSpecialReward { get; set; }

        public CellModel()
        {
            Row = -1;
            Column = -1;
            IsVisited = false;
            IsBomb = false;
            IsFlagged = false;
            NumberOfBombNeighbors = 0;
            HasSpecialReward = false;
        }

        public override string GetCellType()
        {
            return "Minesweeper Cell";
        }
    }
}