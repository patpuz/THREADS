/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THREADS
{
    internal class MatrixCalculator
    {
        public Matrix CalculateMatrix(Matrix matrixA, Matrix matrixB, int maxThreads)
        {
            Matrix resultMatrix = new Matrix(matrixA.Rows, matrixB.Columns);

            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = maxThreads;

            Parallel.For(0, resultMatrix.Columns, options, column =>
            {
                for (int row = 0; row < resultMatrix.Rows; row++)
                {
                    int sum = 0;
                    for (int k = 0; k < matrixA.Columns; k++)
                    {
                        sum += matrixA.GetValue(row, k) * matrixB.GetValue(k, column);
                    }
                    resultMatrix.SetValue(row, column, sum);
                }
            });

            return resultMatrix;
        }
    }
}
*/