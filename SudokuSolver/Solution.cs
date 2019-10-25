using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class Solution
    {
        public void SolveSudoku(char[][] board)
        {


            if (SolvePuzzle(board, 0, 0))
            {
                Console.WriteLine("Solved");

            }
            else
            {

                Console.WriteLine("Not solvable");
            }


        }


        public bool SolvePuzzle(char[][] sudokuBoard, int startRow, int startColumn)
        {

            for (int row = startRow; row < 9; row++)
            {
                for (int column = startColumn; column < 9; column++)
                {
                    if (sudokuBoard[row][column] == '.')
                    {
                        for (int PossibleValue = 1; PossibleValue <= 9; PossibleValue++)
                        {
                            if (Validate(sudokuBoard, row, column, PossibleValue))
                            {

                                sudokuBoard[row][column] = (char)(PossibleValue + 48);

                                int nextRow, nextCol;
                                nextRow = row;
                                nextCol = column + 1;
                                if (nextCol > 8)
                                {
                                    nextRow++;
                                    nextCol = 0;

                                }
                                if (nextRow == 9)
                                    return true;

                                if (SolvePuzzle(sudokuBoard, nextRow, nextCol))
                                {
                                    return true;
                                }
                                else
                                    sudokuBoard[row][column] = '.';

                            }
                        }

                        return false;
                    }
                }
                startColumn = 0;

            }

            return true;
        }


        public bool Validate(char[][] sudokuBoard, int row, int column, int possibleValue)
        {

            return isValidRow(sudokuBoard, row, column, possibleValue)
                && isValidColumn(sudokuBoard, row, column, possibleValue)
                && isValidSquare(sudokuBoard, row, column, possibleValue);

        }
        public bool isValidRow(char[][] sudokuBoard, int row, int column, int possibleValue)
        {

            char temp = (char)(48 + possibleValue);
            for (int x = 0; x < 9; x++)
            {
                if (temp == sudokuBoard[x][column])
                    return false;

            }

            return true;
        }

        public bool isValidColumn(char[][] sudokuBoard, int row, int column, int possibleValue)
        {

            char temp = (char)(48 + possibleValue);
            for (int x = 0; x < 9; x++)
            {
                if (temp == sudokuBoard[row][x])
                    return false;

            }

            return true;
        }

        public bool isValidSquare(char[][] sudokuBoard, int row, int column, int possibleValue)
        {
            char temp = (char)(48 + possibleValue);
            int[] hold = new int[] { 0, 3, 6 };
            int startrow = hold[row / 3];
            int startcol = hold[column / 3];
            for (int x = startrow; x <= startrow + 2; x++)
                for (int y = startcol; y <= startcol + 2; y++)
                {
                    if (temp == sudokuBoard[x][y])
                        return false;


                }

            return true;
        }

    }
}
