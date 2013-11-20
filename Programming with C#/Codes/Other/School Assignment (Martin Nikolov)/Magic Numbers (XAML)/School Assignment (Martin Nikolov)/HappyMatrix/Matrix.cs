using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicSquare
{
    public class Matrix
    {
        public int[,] matrix;
        private const int Sum = 15;

        public Matrix()
        {
            this.matrix = new int[3, 3];
        }

        #region [PROPERTIES TAKE PART IN BINDING - VERY BAD SOLUTION]

        public int? Number1 { get; set; }

        public int? Number2 { get; set; }

        public int? Number3 { get; set; }

        public int? Number4 { get; set; }

        public int? Number5 { get; set; }

        public int? Number6 { get; set; }

        public int? Number7 { get; set; }

        public int? Number8 { get; set; }

        public int? Number9 { get; set; }

        #endregion

        public int this[int row, int col]
        {
            get { return this[row, col]; }
            set { this[row, col] = value; }
        }
         
        // Check all Rows and Columns and check for correct filled Matrix
        public bool IsValidMatrix()
        {
            return this.AreAllNumbersDifferent() && this.RightDownDiagonal() == Sum && this.LeftDownDiagonal() == Sum &&
                   this.GetFirstRowSum() == Sum && this.GetSecondRowSum() == Sum && this.GetThirdRowSum() == Sum &&
                   this.GetFirstColSum() == Sum && this.GetSecondColSum() == Sum && this.GetThirdColSum() == Sum;
        }

        public bool AreAllNumbersDifferent()
        {
            List<int> vector = new List<int>();

            foreach (int number in this.matrix)
                vector.Add(number);

            return vector.Distinct().Count() == 9;
        }

        #region [CHECK SUM OF MATRIX LINES]

        // RIGHT-DOWN DIAGONAL
        public int RightDownDiagonal()
        {
            return this.matrix[0, 2] + this.matrix[1, 1] + this.matrix[2, 0];
        }

        // LEFT-DOWN DIAGONAL
        public int LeftDownDiagonal()
        {
            return this.matrix[0, 0] + this.matrix[1, 1] + this.matrix[2, 2];
        }

        // COLUMN 0
        public int GetFirstRowSum()
        {
            return this.matrix[0, 0] + this.matrix[0, 1] + this.matrix[0, 2];
        }

        // ROW 1
        public int GetSecondRowSum()
        {
            return this.matrix[1, 0] + this.matrix[1, 1] + this.matrix[1, 2];
        }
         
        // ROW 2
        public int GetThirdRowSum()
        {
            return this.matrix[2, 0] + this.matrix[2, 1] + this.matrix[2, 2];
        }
         
        // COLUMN 0
        public int GetFirstColSum()
        {
            return this.matrix[0, 0] + this.matrix[1, 0] + this.matrix[2, 0];
        }
         
        // COLUMN 1
        public int GetSecondColSum()
        {
            return this.matrix[0, 1] + this.matrix[1, 1] + this.matrix[2, 1];
        }
         
        // COLUMN 2
        public int GetThirdColSum()
        {
            return this.matrix[0, 2] + this.matrix[1, 2] + this.matrix[2, 2];
        }
        
        #endregion
    }
}