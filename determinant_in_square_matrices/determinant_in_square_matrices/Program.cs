using System;
using System.Diagnostics;

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
            Stopwatch watch = new Stopwatch();
            watch.Start();

            //test
            int[,] matrix = matrix_random(10);
            matrix_write(matrix);
            Console.WriteLine("Determinant : " + recursive_det(matrix,matrix.GetLength(0)));

            watch.Stop();

            TimeSpan time = watch.Elapsed;
            string time_string = String.Format("{0:00}:{1:00}:{2:00}", time.Minutes, time.Seconds, time.Milliseconds / 10 );
            Console.WriteLine("Time : " + time_string);
            //test

            Console.Write("\nEnter matrix size : ");
            int length = Convert.ToInt32(Console.ReadLine());
            int[,] matrix_1 = matrix_init(length);
            matrix_write(matrix_1);
            Console.WriteLine("Determinant : " + recursive_det(matrix_1,length));
            Console.ReadLine();
        }
        static long recursive_det(int[,] matrix, int length)
        {
            long determinant = 0;
            int[] frekans = zero_frekans(matrix, length);
            if ( length == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else if ( Array.IndexOf(frekans,length) != -1)//is a row or column all zero?
            {
                return 0;
            }
            else 
            {   
                int cofaktor_i = 0;
                int cofaktor_j = 0;
                int temp1 = 0;
                int temp2 = 0;
                for (int i = 0; i < length; i++)
                {
                    if (temp1 < frekans[i])
                    {
                        temp1 = frekans[i];
                        cofaktor_i = i;
                    }
                }
                for (int j = length; j < 2*length; j++)
                {
                    if (temp2 < frekans[j])
                    {
                        temp2 = frekans[j];
                        cofaktor_j = j - length;
                    }
                        
                }

                if( temp1> temp2)
                {
                    //cofaktors are row
                    for (cofaktor_j = 0; cofaktor_j < length; cofaktor_j++)
                    {
                        if (matrix[cofaktor_i, cofaktor_j] == 0)
                            continue;
                        determinant += Convert.ToInt32(Math.Pow(-1, cofaktor_i + cofaktor_j)) *
                                        matrix[cofaktor_i, cofaktor_j] * recursive_det(minor(matrix, cofaktor_i, cofaktor_j, length - 1), length - 1);
                    }
                }
                else
                {
                    //cofaktors are column
                    for (cofaktor_i = 0; cofaktor_i < length; cofaktor_i++)
                    {
                        if (matrix[cofaktor_i, cofaktor_j] == 0)
                            continue;
                        determinant += Convert.ToInt32(Math.Pow(-1, cofaktor_i + cofaktor_j)) *
                                        matrix[cofaktor_i, cofaktor_j] * recursive_det(minor(matrix, cofaktor_i, cofaktor_j, length - 1), length - 1);
                    }
                }
            }
            return determinant;
        }

        static int[,] minor(int[,] matrix, int cofaktor_i, int cofaktor_j,int length)
        {
            int[,] minor = new int[ length, length];
            int minor_i = 0;
            int minor_j = 0;

            for (int i = 0; i < length+1; i++)
            {
                if (cofaktor_i != i)//excluding cofactor row
                {
                    for (int j = 0; j < length+1; j++)
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

        static int[] zero_frekans(int[,] matrix ,int length)
        {
            int[] count_row_col = new int[2*length];

            for (int i = 0; i < length; i++)
            {
                for (int j = 0;j < length; j++)
                {
                    if (matrix[i,j] == 0) 
                    {
                        count_row_col[i]++; //row frekans
                        count_row_col[length+j]++;//col frekans
                    }
                }
            }
            return count_row_col;
        }

        static int[,] matrix_random(int n)
        {
            Random random = new Random();
            int[,] matrix = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                   matrix[i, j] = random.Next(7)-3;
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
