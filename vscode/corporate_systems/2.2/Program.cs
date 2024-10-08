using System;

namespace MatrixOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Matrix Operations Program");

            // Get matrix dimensions from user
            Console.Write("Enter number of rows (n): ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number of columns (m): ");
            int m = Convert.ToInt32(Console.ReadLine());

            // Create two matrices
            int[,] matrix1 = new int[n, m];
            int[,] matrix2 = new int[n, m];

            // Fill matrices with values
            Console.WriteLine("Choose a filling method:");
            Console.WriteLine("1. Keyboard input");
            Console.WriteLine("2. Random numbers");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                FillMatrixFromKeyboard(matrix1, "Matrix 1");
                FillMatrixFromKeyboard(matrix2, "Matrix 2");
            }
            else if (choice == 2)
            {
                Console.Write("Enter random number range (a): ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter random number range (b): ");
                int b = Convert.ToInt32(Console.ReadLine());
                FillMatrixWithRandomNumbers(matrix1, a, b, "Matrix 1");
                FillMatrixWithRandomNumbers(matrix2, a, b, "Matrix 2");
            }
            else
            {
                Console.WriteLine("Invalid choice. Exiting.");
                return;
            }

            // Display matrices
            Console.WriteLine("Matrix 1:");
            DisplayMatrix(matrix1);
            Console.WriteLine("Matrix 2:");
            DisplayMatrix(matrix2);

            // Perform operations
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Multiplication");
            Console.WriteLine("3. Calculate Determinant");
            Console.WriteLine("4. Find Inverse Matrix");
            Console.WriteLine("5. Transpose Matrix");
            Console.WriteLine("6. Solve System of Equations");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                if (CanAddMatrices(matrix1, matrix2))
                {
                    int[,] result = AddMatrices(matrix1, matrix2);
                    Console.WriteLine("Result:");
                    DisplayMatrix(result);
                }
                else
                {
                    Console.WriteLine("Matrices cannot be added.");
                }
            }
            else if (choice == 2)
            {
                if (CanMultiplyMatrices(matrix1, matrix2))
                {
                    int[,] result = MultiplyMatrices(matrix1, matrix2);
                    Console.WriteLine("Result:");
                    DisplayMatrix(result);
                }
                else
                {
                    Console.WriteLine("Matrices cannot be multiplied.");
                }
            }
            else if (choice == 3)
            {
                if (IsSquareMatrix(matrix1))
                {
                    double determinant = CalculateDeterminant(matrix1);
                    Console.WriteLine("Determinant: " + determinant);
                }
                else
                {
                    Console.WriteLine("Matrix is not square. Cannot calculate determinant.");
                }
            }
            else if (choice == 4)
            {
                if (IsSquareMatrix(matrix1) && CalculateDeterminant(matrix1) != 0)
                {
                    double[,] inverse = FindInverseMatrix(matrix1);
                    Console.WriteLine("Inverse Matrix:");
                    DisplayDoubleMatrix(inverse);
                }
                else
                {
                    Console.WriteLine("Matrix is not invertible.");
                }
            }
            else if (choice == 5)
            {
                double[,] transpose = TransposeMatrix(matrix1);
                Console.WriteLine("Transpose Matrix:");
                DisplayDoubleMatrix(transpose);
            }
             else if (choice == 6)
{
    if (IsSquareMatrix(matrix1))
    {
        double[] constants = new double[matrix1.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(1); i++)
    {
        Console.WriteLine("Enter the right side of the equation: ");
        int help = Convert.ToInt32(Console.ReadLine());
        constants[i] = help;
    }
        double[,] matrix = new double[matrix1.GetLength(0), matrix1.GetLength(1)];
        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix1.GetLength(1); j++)
            {
                matrix[i, j] = matrix1[i, j];
            }
        }
        double[] roots = SolveLinearEquations(matrix, constants);
        Console.WriteLine("Roots of the system:");
        for (int i = 0; i < roots.Length; i++)
        {
            Console.WriteLine($"x{i + 1} = {roots[i]}");
        }
    }
    else
    {
        Console.WriteLine("Matrix is not square. Cannot solve system of equations.");
    }
}
            else
            {
                Console.WriteLine("Invalid choice. Exiting.");
                return;
            }
        }

        static void FillMatrixFromKeyboard(int[,] matrix, string matrixName)
        {
            Console.WriteLine($"Enter values for {matrixName}:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"Element [{i},{j}]: ");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        static void FillMatrixWithRandomNumbers(int[,] matrix, int a, int b, string matrixName)
        {
            Random random = new Random();
            Console.WriteLine($"Filling {matrixName} with random numbers in range [{a}; {b}]:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(a, b + 1);
                }
            }
        }

        static void DisplayMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i ++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void DisplayDoubleMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool CanAddMatrices(int[,] matrix1, int[,] matrix2)
        {
            return matrix1.GetLength(0) == matrix2.GetLength(0) && matrix1.GetLength(1) == matrix2.GetLength(1);
        }

        static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
        {
            int[,] result = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return result;
        }

        static bool CanMultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            return matrix1.GetLength(1) == matrix2.GetLength(0);
        }

        static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }

        static bool IsSquareMatrix(int[,] matrix)
        {
            return matrix.GetLength(0) == matrix.GetLength(1);
        }

        static double CalculateDeterminant(int[,] matrix)
        {
            if (matrix.GetLength(0) == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                double det = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int[,] subMatrix = GetSubMatrix(matrix, 0, i);
                    det += Math.Pow(-1, i) * matrix[0, i] * CalculateDeterminant(subMatrix);
                }
                return det;
            }
        }

        static int[,] GetSubMatrix(int[,] matrix, int row, int col)
        {
            int[,] subMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int subRow = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == row) continue;
                int subCol = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == col) continue;
                    subMatrix[subRow, subCol] = matrix[i, j];
                    subCol++;
                }
                subRow++;
            }
            return subMatrix;
        }

        static double[,] FindInverseMatrix(int[,] matrix)
        {
            double det = CalculateDeterminant(matrix);
            double[,] inverse = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int[,] subMatrix = GetSubMatrix(matrix, i, j);
                    inverse[j, i] = Math.Pow(-1, i + j) * CalculateDeterminant(subMatrix) / det;
                }
            }
            return inverse;
        }

        static double[,] TransposeMatrix(int[,] matrix)
        {
            double[,] transpose = new double[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    transpose[j, i] = matrix[i, j];
                }
            }
            return transpose;
        }
        public static double[] SolveLinearEquations(double[,] matrix, double[] constants)
{
    int n = matrix.GetLength(0);
    double[] roots = new double[n];

    // Check if the matrix is square
    if (matrix.GetLength(1) != n)
    {
        throw new ArgumentException("Matrix must be square");
    }

    // Check if the constants array has the correct length
    if (constants.Length != n)
    {
        throw new ArgumentException("Constants array must have the same length as the matrix");
    }

    // Perform Gaussian elimination
    for (int i = 0; i < n; i++)
    {
        // Search for maximum in this column
        int max = i;
        for (int k = i + 1; k < n; k++)
        {
            if (Math.Abs(matrix[k, i]) > Math.Abs(matrix[max, i]))
            {
                max = k;
            }
        }

        // Swap maximum row with current row
        if (max != i)
        {
            SwapRows(matrix, constants, i, max);
        }

        // Make all rows below this one 0 in current column
        for (int k = i + 1; k < n; k++)
        {
            double factor = matrix[k, i] / matrix[i, i];
            for (int j = i; j < n; j++)
            {
                matrix[k, j] -= factor * matrix[i, j];
            }
            constants[k] -= factor * constants[i];
        }
    }

    // Solve equation Ax=b for an upper triangular matrix A
    for (int i = n - 1; i >= 0; i--)
    {
        roots[i] = constants[i];
        for (int j = i + 1; j < n; j++)
        {
            roots[i] -= matrix[i, j] * roots[j];
        }
        roots[i] /= matrix[i, i];
    }

    return roots;
}

private static void SwapRows(double[,] matrix, double[] constants, int i, int j)
{
    for (int k = 0; k < matrix.GetLength(1); k++)
    {
        double temp = matrix[i, k];
        matrix[i, k] = matrix[j, k];
        matrix[j, k] = temp;
    }
    double temp2 = constants[i];
    constants[i] = constants[j];
    constants[j] = temp2;
}
}
}
