using System;
using System.Diagnostics;
using System.Threading.Tasks;
using THREADS;

    namespace THREADS
    {


        class Program
        {
            static void Main(string[] args)
            {
                int matrixSize = 3;
                int maxThreads = 1;


                Matrix matrixA = Matrix.GenerateRandomMatrix(matrixSize, matrixSize);
                Matrix matrixB = Matrix.GenerateRandomMatrix(matrixSize, matrixSize);

                MatrixCalculator calculator = new MatrixCalculator();

                Console.WriteLine("Before multiplication:");
                Console.WriteLine("Matrix A:");
                matrixA.Display();
                Console.WriteLine("Matrix B:");
                matrixB.Display();

                Stopwatch stopwatch = Stopwatch.StartNew();
                var resultMatrix = calculator.CalculateMatrix(matrixA, matrixB, maxThreads);
                stopwatch.Stop();

                Console.WriteLine("After multiplication:");
                resultMatrix.Display();


                Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }

