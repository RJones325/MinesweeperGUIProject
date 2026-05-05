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
using MinesweeperClassLibrary.Models;

namespace MinesweeperClassLibrary.BusinessLogicLayer
{
    public interface IBoardService
    {
        void SetupBombs(BoardModel board);
        void CountBombsNearby(BoardModel board);
    }
}
