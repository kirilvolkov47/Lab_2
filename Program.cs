using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class Program
    {
        static double[,] lab1Task = {
            {  2,  2,  1,  2,  1,  4 },
            {  2,  1,  0,  3,  2,  4 },
            {  3,  0,  1,  2,  5,  9 },
            { -1,  0,  0,  0, -3,  0 }
        };
        static List<string> lab1Rows = new List<string> { "y1", "y2", "y3", "Z" };
        static List<string> lab1Cols = new List<string> { "x1", "x2", "x3", "x4", "x5", "1" };
        static List<string> lab1DualRows = new List<string> { "u1", "u2", "u3", "1" };
        static List<string> lab1DualCols = new List<string> { "v1", "v2", "v3", "v4", "v5", "W" };

        // тест 1 (з методички)
        static double[,] test1 = {
            {  1,  1, -1, -2,  6 },
            { -1, -1, -1,  1, -5 },
            {  2, -1,  3,  4, 10 },
            { -1, -2,  1,  1,  0 }
        };
        static List<string> test1Rows = new List<string> { "y1", "y2", "y3", "Z" };
        static List<string> test1Cols = new List<string> { "x1", "x2", "x3", "x4", "1" };
        static List<string> test1DualRows = new List<string> { "u1", "u2", "u3", "1" };
        static List<string> test1DualCols = new List<string> { "v1", "v2", "v3", "v4", "W" };

        // тест 2 (з методички)
        static double[,] test2 = {
            { -3,  1,  4,  1,  1 },
            {  3, -2,  2, -2, -9 },
            { -2,  1,  1,  3,  2 },
            { -3,  2, -3,  0,  7 },
            {-10,  1, 42, 52,  0 }
        };
        static List<string> test2Rows = new List<string> { "y1", "y2", "y3", "y4", "Z" };
        static List<string> test2Cols = new List<string> { "x1", "x2", "x3", "x4", "1" };
        static List<string> test2DualRows = new List<string> { "u1", "u2", "u3", "u4", "1" };
        static List<string> test2DualCols = new List<string> { "v1", "v2", "v3", "v4", "W" };

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1 - Пара Z,W");
                Console.WriteLine("2 - Тест 1 (методичка)");
                Console.WriteLine("3 - Тест 2 (методичка)");
                Console.WriteLine("0 - Вихід");
                Console.Write(">> ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Задача з практичної роботи 1 part B:");
                            Console.WriteLine("  Z = x1 + 3x5 -> max");
                            Console.WriteLine("  2x1+2x2+x3+2x4+x5 <= 4");
                            Console.WriteLine("  2x1+x2+3x4+2x5 <= 4");
                            Console.WriteLine("  3x1+x3+2x4+5x5 <= 9");
                            Console.WriteLine("  xj >= 0, j=1..5");
                            Console.WriteLine();

                            double[,] tbl = MJV.CopyMatrix(lab1Task);
                            List<string> left = new List<string>(lab1Rows);
                            List<string> top = new List<string>(lab1Cols);
                            List<string> dleft = new List<string>(lab1DualRows);
                            List<string> dtop = new List<string>(lab1DualCols);
                            MJV.RunDual(tbl, left, top, dleft, dtop, 5, 3);
                            break;
                        }
                    case "2":
                        {
                            double[,] tbl = MJV.CopyMatrix(test1);
                            List<string> left = new List<string>(test1Rows);
                            List<string> top = new List<string>(test1Cols);
                            List<string> dleft = new List<string>(test1DualRows);
                            List<string> dtop = new List<string>(test1DualCols);
                            MJV.RunDual(tbl, left, top, dleft, dtop, 4, 3);
                            break;
                        }
                    case "3":
                        {
                            double[,] tbl = MJV.CopyMatrix(test2);
                            List<string> left = new List<string>(test2Rows);
                            List<string> top = new List<string>(test2Cols);
                            List<string> dleft = new List<string>(test2DualRows);
                            List<string> dtop = new List<string>(test2DualCols);
                            MJV.RunDual(tbl, left, top, dleft, dtop, 4, 4);
                            break;
                        }
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}