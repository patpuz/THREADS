using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace THREADS
{  
    internal class MatrixCalculator
    {
        private readonly object locker = new object();
        private volatile int currentColumn = 0;

        public Matrix CalculateMatrix(Matrix matrixA, Matrix matrixB, int numberOfThreads)
        {
            Matrix resultMatrix = new Matrix(matrixA.Rows, matrixB.Columns);

            List<Thread> threads = CreateThreads(matrixA, matrixB, resultMatrix, numberOfThreads);
            StartAndJoinThreads(threads);

            return resultMatrix;
        }

        private List<Thread> CreateThreads(Matrix matrixA, Matrix matrixB, Matrix resultMatrix, int numberOfThreads)
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < numberOfThreads; i++)
            {
                Thread thread = new Thread(() =>
                {
                    CalculateMatrixPart(matrixA, matrixB, resultMatrix);
                });
                thread.Start();
                threads.Add(thread);
            }

            return threads;
        }

        private void StartAndJoinThreads(List<Thread> threads)
        {
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }

        private void CalculateMatrixPart(Matrix matrixA, Matrix matrixB, Matrix resultMatrix)
        {
            int column;
            while ((column = GetNextColumn(resultMatrix.Columns)) < resultMatrix.Columns)
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
            }
        }

        private int GetNextColumn(int maxColumns)
        {
            lock (locker)
            {
                if (currentColumn < maxColumns)
                {
                    return currentColumn++;
                }
                else
                {
                    return maxColumns;
                }
            }
        }
    }
}

