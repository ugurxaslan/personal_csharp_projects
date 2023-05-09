using System;

namespace square_matrix_and_diagonals
{
    internal class Program
    {
        static int length;
        static void Main(string[] args)
        {
            length = 11;

            //The matrices in this program must be square matrices.
            int[,] matrix = matrix_create_random(length, length);

            Console.WriteLine("test_matrix");
            test(matrix);//please review

            Console.WriteLine("\nall_items");
            all_items(matrix);

            write_matrix(matrix);
            Console.WriteLine("\n\n");

            write_top_triangle(matrix);
            Console.WriteLine("\n\n");

            write_bottom_triangle(matrix);
            Console.WriteLine("\n\n");

            write_right_triangle(matrix);
            Console.WriteLine("\n\n");

            write_left_triangle(matrix);
            Console.WriteLine("\n\n");

            write_top_right_triangle(matrix);
            Console.WriteLine("\n\n");

            write_bottom_right_triangle(matrix);
            Console.WriteLine("\n\n");

            write_top_left_triangle(matrix);
            Console.WriteLine("\n\n");

            write_bottom_left_triangle(matrix);
            Console.WriteLine("\n\n");

            write_diagonal(matrix);
            Console.WriteLine("\n\n");

            write_reverse_diagonal(matrix);
            Console.WriteLine("\n\n");

            Console.ReadLine();
        }
        static void all_items(int[,] matrix)
        {
            int top, bottom, left, right, top_left, bottom_right, top_right, bottom_left,diagonal,reverse_diagonal;
            top = bottom = left = right = top_left = bottom_right = top_right = bottom_left = diagonal = reverse_diagonal = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i < j)
                    {
                        top_right += matrix[i, j];
                        if (i + j < length - 1) 
                            top += matrix[i, j];
                    }
                    else 
                    if (i > j)
                    {
                        bottom_left += matrix[i, j];
                        if (i + j > length - 1) 
                            bottom += matrix[i, j];
                    }
                    else//i==j
                    {
                        diagonal += matrix[i, j];
                    }



                    if (i + j < length - 1)
                    {
                        top_left += matrix[i, j];
                        if (i > j)
                        {
                            left += matrix[i, j];
                        }
                    }
                    else
                    if (i + j > length - 1)
                    {
                        bottom_right += matrix[i, j];
                        if (i < j)
                        {
                            right += matrix[i, j];
                        }
                    }
                    else//i+j=length - 1
                    {
                        reverse_diagonal += matrix[i, j];
                    }
                }
            }

            Console.WriteLine("top \t\t: " + top + "\nbottom \t\t: " + bottom + "\nright \t\t: " + right + "\nleft \t\t: " + left +
                                "\ntop_right \t: " + top_right + "\nbottom_right \t: " + bottom_right +
                                "\ntop_left \t: " + top_left + "\nbottom_left \t: " + bottom_left + 
                                "\ndiagonal \t: " + diagonal + "\nrev_diagonal \t: " + reverse_diagonal);
        }
        static void test(int[,] matrix)
        {
           
            int rt, tt, lt, bt, brt, blt, tlt, trt, dia, rdia; //The letters R - L - T - B - Dia are abbreviations.right-left-top-bottom-diagonal-reversediagonal

            brt = blt = tlt = trt = length * (length - 1) / 2;

            dia = rdia= length;

            if (length % 2 == 0)
                tt = rt = lt = bt = (length / 2) * (length / 2 - 1);
            else
                tt = rt = lt = bt = (length / 2) * (length / 2);

            Console.WriteLine("top triangle \t\t: " + tt + " element\tfonk value : " + top_triangle(matrix));
            Console.WriteLine("bottom triangle \t: " + bt + " element\tfonk value : " + bottom_triangle(matrix));
            Console.WriteLine("right triangle \t\t: " + rt + " element\tfonk value : " + right_triangle(matrix));
            Console.WriteLine("left triangle \t\t: " + lt + " element\tfonk value : " + left_triangle(matrix));
            Console.WriteLine("top right triangle \t: " + trt + " element\tfonk value : " + top_right_triangle(matrix));
            Console.WriteLine("bottom right triangle \t: " + brt + " element\tfonk value : " + bottom_right_triangle(matrix));
            Console.WriteLine("top left triangle \t: " + tlt + " element\tfonk value : " + top_left_triangle(matrix));
            Console.WriteLine("bottom left triangle \t: " + blt + " element\tfonk value : " + bottom_left_triangle(matrix));
            Console.WriteLine("diagonal \t\t: " + dia + " element\tfonk value : " + diagonal(matrix));
            Console.WriteLine("reverse_diagonal \t: " + rdia + " element\tfonk value : " + reverse_diagonal(matrix));

        }
        static void write_matrix(int[,] matrix)
        {
            Console.WriteLine("\n----------write matrix ----------------\n");
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write("\t" + matrix[i,j]);
                }
                Console.WriteLine("\n\n");
            }
            Console.WriteLine("----------write matrix ----------------\n");
        }
        

        static int[,] matrix_create_random(int i,int j)
        {
            Random r = new Random();

            int[,] matrix = new int[i, j];

            for (int k = 0; k < i ; k++)
            {
                for(int l = 0; l < j; l++)
                {
                    matrix[k, l] = r.Next(10);
                }
            }
            return matrix;    
        }

        static int diagonal(int[,] matrix)
        {
            int d_sum = 0;
            for (int i = 0; i < length; i++)
            {
                d_sum += matrix[i, i];
            }
            return d_sum;
        }

        static void write_diagonal(int[,] matrix)
        {
            Console.WriteLine("\n---------write_diagonal----------------\n");
            int d_sum = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i == j) Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.WriteLine("\n\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n---------write_diagonal----------------\n");
        }

        static int reverse_diagonal(int[,] matrix)
        {
            int d_sum = 0;

            for (int i = 0; i < length; i++)
            {
                d_sum += matrix[i, length - 1 - i];
            }
            return d_sum;
        }

        static void write_reverse_diagonal(int[,] matrix)
        {
            Console.WriteLine("\n---------write_reverse_diagonal----------------\n");
            int d_sum = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i + j == length -1) Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.WriteLine("\n\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n---------write_reverse_diagonal----------------\n");
        }

        static int top_right_triangle(int [,] matrix)
        {
            int trt_sum = 0;//top_right_triangle_sum

            for (int i =0;i<length;i++)
            {
                for(int j = i+1; j < length; j++)
                {
                    trt_sum += matrix[i, j];
                }
            }
            return trt_sum;
        }

        static void write_top_right_triangle(int[,] matrix)
        {
            Console.WriteLine("\n---------write_top_right_triangle----------------\n");
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i < j) Console.ForegroundColor = ConsoleColor.Red;
                    else if (i == j) Console.ForegroundColor = ConsoleColor.Blue;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.WriteLine("\n\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n----------write_top_right_triangle----------------\n");
        }

        static int bottom_left_triangle(int[,] matrix)
        {
            int blt_sum = 0;// bottom_left_triangle_sum

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    blt_sum += matrix[i, j];
                }
            }
            return blt_sum;
        }

        static void write_bottom_left_triangle(int[,] matrix)
        {
            Console.WriteLine("\n----------write_bottom_left_triangle----------------\n");
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i > j) Console.ForegroundColor = ConsoleColor.Red;
                    else if (i == j) Console.ForegroundColor = ConsoleColor.Blue;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.WriteLine("\n\n");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n----------write_bottom_left_triangle----------------\n");
        }

        static int top_left_triangle(int[,] matrix)
        {
            int tlt_sum = 0;// top_left_triangle_sum

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; i+j<length -1; j++)
                {
                    tlt_sum += matrix[i, j];
                }
            }
            return tlt_sum;
        }

        static void write_top_left_triangle(int[,] matrix)
        {
            Console.WriteLine("\n---------- write_top_left_triangle----------------\n");
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i + j < length -1) Console.ForegroundColor = ConsoleColor.Red;
                    else if (i + j == length - 1) Console.ForegroundColor = ConsoleColor.Blue;
                    else Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("\t" + matrix[i, j]);
                }
                Console.WriteLine("\n\n");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n----------write top right triangle----------------\n");
        }

        static int bottom_right_triangle(int[,] matrix)
        {
            int brt_sum = 0;// bottom_right_triangle_sum

            for (int i = 0; i < length; i++)
            {
                for (int j = length -i ; j<length; j++)
                {
                    brt_sum += matrix[i, j];
                }
            }
            return brt_sum;
        }
        static void write_bottom_right_triangle(int[,] matrix)
        {
            Console.WriteLine("\n----------write_bottom_right_triangle----------------\n");
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i + j > length -1) Console.ForegroundColor = ConsoleColor.Red;
                    else if (i + j == length - 1) Console.ForegroundColor = ConsoleColor.Blue;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.WriteLine("\n\n");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n----------write_bottom_right_triangle----------------\n");
        }

        static int top_triangle(int[,] matrix)
        {
            int tt_sum = 0;// top_triangle_sum

            for (int i = 0; i < length / 2; i++)
            {
                for (int j = i + 1; i + j < length -1; j++)
                {
                    tt_sum += matrix[i, j];
                }
            }
            return tt_sum;
        }

        static void write_top_triangle(int[,] matrix)
        {
            Console.WriteLine("\n----------write_top_triangle----------------\n");
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i < j && i + j < length -1) Console.ForegroundColor = ConsoleColor.Red;
                    else if (i == j|| i + j== length -1) Console.ForegroundColor = ConsoleColor.Blue;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.WriteLine("\n\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n----------write_top_triangle----------------\n");
        }

        static int bottom_triangle(int[,] matrix)
        {
            int bt_sum = 0;// bottom_triangle_sum

            for (int i = length / 2 + 1; i < length; i++)
            {
                for (int j = length -i; i > j; j++)
                {
                    bt_sum += matrix[i, j];
                }
            }

            return bt_sum;
        }

        static void write_bottom_triangle(int[,] matrix)
        {
            Console.WriteLine("\n----------write_bottom_triangle----------------\n");
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i > j && i + j > length - 1) Console.ForegroundColor = ConsoleColor.Red;
                    else if (i == j || i + j == length - 1) Console.ForegroundColor = ConsoleColor.Blue;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.WriteLine("\n\n");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n----------write_bottom_triangle----------------\n");
        }

        static int left_triangle(int[,] matrix)
        {
            int lt_sum = 0;// left_triangle_sum

            for (int i = 1; i < length -1; i++)
            {
                for (int j = 0 ; i>j && i+j<length -1; j++)
                {
                    lt_sum += matrix[i, j];
                }
            }

            return lt_sum;
        }

        static void write_left_triangle(int[,] matrix)
        {
            Console.WriteLine("\n---------- write_left_triangle---------------\n");
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i > j && i + j < length - 1) Console.ForegroundColor = ConsoleColor.Red;
                    else if (i == j || i + j == length - 1) Console.ForegroundColor = ConsoleColor.Blue;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.WriteLine("\n\n");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n---------- write_left_triangle----------------\n");
        }

        static int right_triangle(int[,] matrix)
        {
            int rt_sum = 0;// right_triangle_sum

            for (int i = 1; i < length / 2; i++)
            {
                for (int j = length -i ; j < length ; j++)
                {
                    rt_sum += matrix[i, j];
                }
            }

            for (int i = length / 2; i < length - 1; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    rt_sum += matrix[i, j];
                }
            }

            return rt_sum;
        }

        static void write_right_triangle(int[,] matrix)
        {
            Console.WriteLine("\n----------write_right_triangle----------------\n");
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i < j && i + j > length - 1) Console.ForegroundColor = ConsoleColor.Red;
                    else if (i == j || i + j == length - 1) Console.ForegroundColor = ConsoleColor.Blue;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.WriteLine("\n\n");
            }

            Console.ForegroundColor= ConsoleColor.White;
            Console.Write("\n----------write_right_triangle----------------\n");
        }
    }
}