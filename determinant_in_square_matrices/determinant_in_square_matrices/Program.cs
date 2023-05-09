using System;
namespace determinant_in_square_matrices
{
    internal class Program
    {
        static int[,] matrix_init(int n)
        { 
            int[,] matrix = new int[n,n];
            
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Console.Write($"[{i},{j}] : ");
                    matrix[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return matrix;
        }
        
        static void Main(string[] args)
        {
            int[,] matrix = matrix_random(3);
            matrix_write(matrix);
            Console.WriteLine("Determinant : " + recursive_det(matrix));



            Console.Write("\nEnter matrix size : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] matrix_1 = matrix_init(n);
            matrix_write(matrix_1);
            Console.WriteLine("Determinant : " + recursive_det(matrix_1));
            Console.ReadLine();
        }
        static bool call = false;//control call for rows or columns
        static int recursive_det(int[,] matrix)
        {
            int determinant = 0;

            if (!call)
            {
                bool flag = is_row_column_zero(matrix);
                if (flag) return 0;
            }
                
           
            if (matrix.GetLength(0) == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                int cofaktor_i = 0;
                int cofaktor_j = 0;

                 //cofaktors are row
                for (cofaktor_j = 0; cofaktor_j < matrix.GetLength(0); cofaktor_j++)
                {
                    determinant += Convert.ToInt32(Math.Pow(-1, cofaktor_i + cofaktor_j)) *
                                    matrix[cofaktor_i, cofaktor_j] * recursive_det(minor(matrix, cofaktor_i, cofaktor_j));
                }

                /* //cofaktors are column
                determinant = 0;
                for (cofaktor_i = 0; cofaktor_i < matrix.GetLength(0); cofaktor_i++)
                {
                    determinant += Convert.ToInt32(Math.Pow(-1, cofaktor_i + cofaktor_j)) *
                                 matrix[cofaktor_i, cofaktor_j] * det(minor(matrix, cofaktor_i, cofaktor_j));
                }
                */
            }
            call = false;
            return determinant;
        }

        static int[,] minor(int[,] matrix, int cofaktor_i, int cofaktor_j)
        {
            int[,] minor = new int[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            int minor_i = 0;
            int minor_j = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (cofaktor_i != i)//excluding cofactor row
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if (cofaktor_j != j)//excluding cofactor column
                        {
                            minor[minor_i, minor_j] = matrix[i, j];
                            minor_j++;
                        }
                    }
                    minor_i++;
                    minor_j = 0;
                }
            }
            return minor;
        }

        static bool is_row_column_zero(int[,] matrix)
        {
            call = true;
            int count_row;
            int count_col;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                count_row = 0;
                count_col = 0;
                for (int j = 0;j < matrix.GetLength(0); j++)
                {
                    if (matrix[i,j] == 0) count_row++;
                    if (matrix[j,i] == 0) count_col++;
                }
                if (count_row == matrix.Length || count_col == matrix.Length)
                    return true;
            }
            return false;
        }

        static int[,] matrix_random(int n)
        {
            Random random = new Random();
            int[,] matrix = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    matrix[i, j] = random.Next(11)-5;
                }
            }
            return matrix;
        }

        static void matrix_write(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.WriteLine("\n\n");
            }
        }
    }
}
