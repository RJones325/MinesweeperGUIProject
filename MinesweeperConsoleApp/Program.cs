// Name: Ray Jones
// Course: CST-250
// Instructor: Gary Ratterree
// Date: 04/19/2026
// Assignment: Milestone 3 - Minesweeper Project

using System;
using MinesweeperClassLibrary.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;

namespace MinesweeperConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunBoardDemo(10, 1);

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue to the second board...");
            Console.ReadLine();

            RunBoardDemo(15, 2);

            Console.WriteLine();
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

        static void RunBoardDemo(int size, int difficulty)
        {
            BoardModel board = new BoardModel(size, difficulty);
            IBoardService service = new BoardService();

            service.SetupBombs(board);
            service.CountBombsNearby(board);

            Console.WriteLine($"Minesweeper Board - Size: {size}x{size}  Difficulty: {difficulty}");
            PrintAnswers(board);
        }

        static void PrintAnswers(BoardModel board)
        {
            Console.Write("    ");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write($"{col,3}");
            }
            Console.WriteLine();

            Console.Write("   +");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("---");
            }
            Console.WriteLine("+");

            for (int row = 0; row < board.Size; row++)
            {
                Console.Write($"{row,2} |");

                for (int col = 0; col < board.Size; col++)
                {
                    CellModel cell = board.Cells[row, col];

                    if (cell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" B ");
                    }
                    else if (cell.NumberOfBombNeighbors > 0)
                    {
                        SetNumberColor(cell.NumberOfBombNeighbors);
                        Console.Write($" {cell.NumberOfBombNeighbors} ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" . ");
                    }

                    Console.ResetColor();
                }

                Console.WriteLine("|");
            }

            Console.Write("   +");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("---");
            }
            Console.WriteLine("+");
        }

        static void SetNumberColor(int number)
        {
            switch (number)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
            }
        }
    }
}