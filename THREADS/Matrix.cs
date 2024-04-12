using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THREADS
{
    internal class Matrix
    {
        private int[,] data;

        public int Rows => data.GetLength(0);
        public int Columns => data.GetLength(1);

        public Matrix(int rows, int columns)
        {
            data = new int[rows, columns];
        }

        public int GetValue(int row, int column)
        {
            return data[row, column];
        }

        public void SetValue(int row, int column, int value)
        {
            data[row, column] = value;
        }

        public void Display()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(data[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static Matrix GenerateRandomMatrix(int rows, int columns)
        {
            Random random = new Random();
            Matrix matrix = new Matrix(rows, columns);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix.SetValue(i, j, random.Next(1, 10));
                }
            }
            return matrix;
        }
    }
}
