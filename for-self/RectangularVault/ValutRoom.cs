using System;
using System.Collections.Generic;
using System.Text;

namespace RectangularVault
{
    public class ValutRoom
    {
        private int[,] _boxes = new int[5, 10];

        public void AssignBox(int row, int col, int userId)
        {
            _boxes[row, col] = userId;
        }

        public int GetOwner(int row, int col) => _boxes[row, col];
    }


}
