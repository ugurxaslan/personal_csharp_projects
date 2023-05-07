using System;
using System.IO;

namespace security_keyboard_and_security_password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This application is a program that calculates the number of seconds to " +
                "\nenter the security key given on the entered keyboard." +
                "\nRules :" +
                "\n1) It takes 0 seconds to press the start key or the same key." +
                "\n2) It takes 1 second to press the adjacent key." +
                "\n3) It takes 2 seconds to press the remote keys.");

            //getting keyboard input
            Console.Write("\nPlease enter 9 different digits keyboard (except 0)(for example : \"235981674\") : ");
            string keyboard_string = "";
            int[,] keyboard = new int[3, 3];
            int count = 0;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (count < 9 && key.Key != ConsoleKey.Backspace)
                {
                    int val = 0;
                    bool flag0 = keyboard_string.Contains(key.KeyChar.ToString());//Is it in string
                    bool flag = int.TryParse(key.KeyChar.ToString(), out val);//Is this a number
                    if (flag && !flag0 && val != 0)
                    {
                        keyboard_string += key.KeyChar;
                        Console.Write(key.KeyChar);
                        count++;
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && keyboard_string.Length > 0)
                    {
                        keyboard_string = keyboard_string.Substring(0, (keyboard_string.Length - 1));
                        Console.Write("\b \b");
                        count--;
                    }
                }
            }
            while (count <= 8 || key.Key != ConsoleKey.Enter);
            //getting keyboard input. finish

            Console.WriteLine("\n\n");

            //initialization of keys and drawing the keyboard
            int counter = 0;
            for (int i = 0; i < keyboard.GetLength(0); i++)
            {
                for (int j = 0; j < keyboard.GetLength(1); j++)
                {
                    keyboard[i, j] = keyboard_string[counter++] - '0';
                    Console.Write("\t" + keyboard[i, j]);
                }
                Console.WriteLine("\n\n");
            }
            //initialization of keys and drawing the keyboard.finish


            //get path of security key
            int time = 0;
            string path = "";
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            string securitykey = "";
            do
            {
                Console.Write("Please enter the integer security key path (for trial key: \"securitykey_true.txt\") : ");
                path = Console.ReadLine();
                flag1 = !File.Exists(path);
                flag2 = (".txt" != path.Substring(path.Length - 4, 4));
                if (flag1)
                {
                    Console.WriteLine("Error : address not available...\n");
                }
                else if (flag2)
                {
                    Console.WriteLine("Error : This file is not a .txt file...\n");
                }
                else
                {
                    securitykey = File.ReadAllText(path);

                    //time taken to enter password from keyboard provided
                    for (int i = 0; i < securitykey.Length - 1 - (2); i++)//last two characters not taken into account
                    {
                        int current = securitykey[i] - '0';
                        int next = securitykey[i + 1] - '0';

                        if (current < 1 && 9 < current && next < 1 && 9 < next)//Is there a key other than (1-9)
                        {
                            flag3 = true;
                            break;
                        }

                        int[] current_index = indexBul(current, keyboard);
                        int[] next_index = indexBul(next, keyboard);

                        int i_fark = next_index[0] - current_index[0];
                        int j_fark = next_index[1] - current_index[1];

                        if (i_fark == 2 || j_fark == 2 || i_fark == -2 || j_fark == -2)
                        {
                            time += 2;
                        }
                        else if (i_fark == 0 && j_fark == 0)
                        {
                            time += 0;
                        }
                        else
                        {
                            time += 1;
                        }
                    }
                    //time taken to enter password from keyboard provided.finish

                    if (flag3)
                        Console.WriteLine("Error : this .txt file contains characters other than numbers (1-9)...\n");
                }

            } while (flag1 || flag2 || flag3);
            //get path of security key.finish

            Console.WriteLine("The passing time : " + time + " seconds");
            Console.ReadKey();
        }

        static int[] indexBul(int x, int[,] matris)
        {
            int i;
            int j;
            int[] index = new int[2];
            for (i = 0; i < matris.GetLength(0); i++)
            {
                for (j = 0; j < matris.GetLength(1); j++)
                {
                    if (x == matris[i, j])
                    {
                        index[0] = i;
                        index[1] = j;
                        break;
                    }
                }
            }
            return index;
        }
    }
}
