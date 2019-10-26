using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class Form1 : Form
    {
        char[][] Board;

        TextBox[][] InputTextBoxes;
        TextBox[][] OutputTextBoxes;
        bool Solvable = false;
        bool NonNumber = false;
        public Form1()
        {
            InitializeComponent();
            InputTextBoxes = new TextBox[9][] { new TextBox[9],new TextBox[9], new TextBox[9], new TextBox[9], new TextBox[9], new TextBox[9], new TextBox[9], new TextBox[9], new TextBox[9] };

            OutputTextBoxes = new TextBox[9][] { new TextBox[9], new TextBox[9], new TextBox[9], new TextBox[9], new TextBox[9], new TextBox[9], new TextBox[9], new TextBox[9], new TextBox[9] };

            Board = new char[9][] {new char[9], new char[9], new char[9], new char[9], new char[9], new char[9], new char[9], new char[9], new char[9] };
            SetUpInputGrid();
            SetUpOutputGrid();
        }


        private void SetUpInputGrid()
        {
            for(int row = 0; row < 9; row++)
            {
                for(int column = 0; column < 9; column++)
                {
                    TextBox box = new TextBox();
                    InputTextBoxes[row][column] = box;
                    box.Location = new Point(10 + 20 * row , 20 + 20 * column);
                    box.Size = new Size(20, 20);
                    box.KeyDown += CheckIfKeyEnteredIsNumber;
                    box.KeyPress += StopNonNumbers;
                    Controls.Add(box);
                }

            }
        }


        private void SetUpOutputGrid()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int column = 0; column < 9; column++)
                {
                    TextBox box = new TextBox();
                    OutputTextBoxes[row][column] = box;
                    box.Location = new Point(300 + 20 * row, 20 + 20 * column);
                    box.Size = new Size(20, 20);
                    box.ReadOnly = true;
                    Controls.Add(box);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int row = 0; row < 9; row ++)
            {
                for(int column = 0; column < 9; column++)
                {
                    var t = InputTextBoxes[row][column].Text.ToString();
                    if (string.IsNullOrEmpty(t))
                        Board[row][column] = '.';
                    else
                        Board[row][column] = t[0];
                   

                }


            }


           Solvable = Solution.SolveSudoku(Board);
            if (Solvable)
                GetBoard();
            else
            {


            }
            
        }

        private void GetBoard()
        {
            for(int row = 0; row < 9; row++)
            {
                for(int column = 0; column < 9; column++)
                {
                    char t = Board[row][column];
                    string z = "";
                    z += t;
                    OutputTextBoxes[row][column].Text = z;
                }


            }

        }
        private void CheckIfKeyEnteredIsNumber(object sender, KeyEventArgs e)
        {
            var temp = e.KeyCode;
            NonNumber = false;
            if(temp <= Keys.D0 || temp > Keys.D9)
            {
                if(temp <= Keys.NumPad0 || temp > Keys.NumPad9)
                {
                    if (temp != Keys.Back)
                        NonNumber = true;

                }

            }

            if (Control.ModifierKeys == Keys.Shift)
            {
                NonNumber = true;
            }


        }

        private void StopNonNumbers(object sender, KeyPressEventArgs e)
        {
            if (NonNumber)
                e.Handled = true;
            else
            {
                TextBox t = (TextBox)sender;
                t.Text = "";


            }


        }
    }
}
