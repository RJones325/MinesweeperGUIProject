// Name: Ray Jones
// Course: CST-250
// Instructor: Gary Ratterree
// Date: 04/19/2026
// Assignment: Milestone 3 - Minesweeper Project
using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;
using Xunit;

namespace MinesweeperTests
{
    public class BoardServiceTests
    {
        [Fact]
        public void BoardModel_ShouldInitializeCorrectly()
        {
            BoardModel board = new BoardModel(5, 1);

            Assert.Equal(5, board.Size);
            Assert.NotNull(board.Cells);
            Assert.Equal(5, board.Cells.GetLength(0));
            Assert.Equal(5, board.Cells.GetLength(1));
        }

        [Fact]
        public void SetupBombs_ShouldPlaceBombs()
        {
            BoardModel board = new BoardModel(5, 1);
            IBoardService service = new BoardService();

            service.SetupBombs(board);

            bool foundBomb = false;

            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    if (board.Cells[row, col].IsBomb)
                    {
                        foundBomb = true;
                    }
                }
            }

            Assert.True(foundBomb);
        }

        [Fact]
        public void CountBombsNearby_ShouldSetBombCellToNine()
        {
            BoardModel board = new BoardModel(3, 1);
            IBoardService service = new BoardService();

            board.Cells[1, 1].IsBomb = true;

            service.CountBombsNearby(board);

            Assert.Equal(9, board.Cells[1, 1].NumberOfBombNeighbors);
        }
    }
}