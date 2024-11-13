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
            // Задание 4
            FileTasks.GenerateBinaryFileWithNumbers("numbers.bin", 100);
            int maxAbsOdd = FileTasks.FindMaxOddIndexAbsoluteValue("numbers.bin");

            // Задание 5
            var toys = new List<FileTasks.Toy>
{
    new FileTasks.Toy { Name = "Bear", Price = 500, MinAge = 2, MaxAge = 5 },
    new FileTasks.Toy { Name = "Car", Price = 300, MinAge = 4, MaxAge = 6 },
};
            FileTasks.GenerateBinaryFileWithToys("C:\\Users\\User\\Desktop\\toys.xml", toys);
            var toysForFourToFiveYears = FileTasks.GetToysForAgeRange("C:\\Users\\User\\Desktop\\toys.xml", 4, 5);

            // Задание 6
            Console.WriteLine("Введите количество чисел в файле, они сгенерируются автоматический: ");
           // FileTasks.GenerateTextFileWithNumbers("C:\\Users\\User\\Desktop\\numbers.txt", Check());
            double average = FileTasks.CalculateAverage("C:\\Users\\User\\Desktop\\numbers.txt");
            //Console.WriteLine("Среднее арифметическое чисел: " + average);

            // Задание 7
            Console.WriteLine("Введите количество строк и количество чисел в строке: ");
            FileTasks.GenerateTextFileWithMultipleNumbersPerLine("C:\\Users\\User\\Desktop\\multiple_numbers.txt", Check(), Check());
            long oddProduct = FileTasks.CalculateOddProduct("C:\\Users\\User\\Desktop\\multiple_numbers.txt");
            Console.WriteLine("Произведение всех нечётных чисел: " + oddProduct);

            // Задание 8
            FileTasks.CopyLinesWithoutLetters("C:\\Users\\User\\Desktop\\textfile.txt", "C:\\Users\\User\\Desktop\\outputfile.txt");

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