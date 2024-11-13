using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
namespace лаба_3._4___3._8
{
    internal class Programm
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите количество чисел в файле, они сгенерируются автоматический: ");
            FileTasks.GenerateBinaryFileWithRandomNumbers("numbers.bin", Check());
            int maxAbsOdd = FileTasks.FindMaxOddIndexAbsoluteValue("numbers.bin");
            Console.WriteLine("Максимальный модуль числа: " + maxAbsOdd);

            Console.WriteLine("Введите количество чисел в файле, они сгенерируются автоматический: ");
            FileTasks.GenerateTextFileWithNumbers("C:\\Users\\User\\Desktop\\numbers.txt", Check());
            double average = FileTasks.CalculateAverage("C:\\Users\\User\\Desktop\\numbers.txt");
            Console.WriteLine("Среднее арифметическое чисел: " + average);

            Console.WriteLine("Введите количество строк и количество чисел в строке: ");
            FileTasks.GenerateTextFileWithMultipleNumbersPerLine("C:\\Users\\User\\Desktop\\multiple_numbers.txt", Check(), Check());
            long oddProduct = FileTasks.CalculateOddProduct("C:\\Users\\User\\Desktop\\multiple_numbers.txt");
            Console.WriteLine("Произведение всех нечётных чисел: " + oddProduct);

            FileTasks.CopyLinesWithoutLetters("C:\\Users\\User\\Desktop\\textfile.txt", "C:\\Users\\User\\Desktop\\outputfile.txt");
            Console.WriteLine("Новый файл создан.");


        }
        public static int Check()
        {
            int a;
            if (int.TryParse(Console.ReadLine(), out a) && a > 0)
            {
                return a;
            }
            Console.WriteLine("Вы ввели некорректное значение, введите значение вновь: ");
            return Check();
        }
    }
}
