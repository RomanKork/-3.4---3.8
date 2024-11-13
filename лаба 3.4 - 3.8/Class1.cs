using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace лаба_3._4___3._8
{
    public static class FileTasks
    {
        public static void GenerateBinaryFileWithRandomNumbers(string filePath, int count)
        {
            var random = new Random();
            var numbers = new List<int>(); 

            using (var writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                for (int i = 0; i < count; i++)
                {
                    int number = random.Next(-100, 101);
                    numbers.Add(number);  
                    writer.Write(number);
                }
            }

            Console.WriteLine("Сгенерированные числа:");
            Console.WriteLine(string.Join(", ", numbers));
        }


        public static int FindMaxOddIndexAbsoluteValue(string filePath)
        {
            int maxAbsValue = 0;
            using (var reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                int index = 1;
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    int value = reader.ReadInt32();
                    if (index % 2 != 0)
                    {
                        maxAbsValue = Math.Max(maxAbsValue, Math.Abs(value));
                    }
                    index++;
                }
            }
            return maxAbsValue;
        }
        public static void GenerateTextFileWithNumbers(string filePath, int count)
        {
            var random = new Random();
            using (var writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.WriteLine(random.Next(-100, 100));
                }
            }
        }

        public static double CalculateAverage(string filePath)
        {
            var numbers = File.ReadAllLines(filePath).Select(int.Parse);
            return numbers.Average();
        }

        public static void GenerateTextFileWithMultipleNumbersPerLine(string filePath, int lines, int numbersPerLine)
        {
            var random = new Random();
            using (var writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < lines; i++)
                {
                    var numbers = new int[numbersPerLine];
                    for (int j = 0; j < numbersPerLine; j++)
                    {
                        numbers[j] = random.Next(-20, 20);
                    }
                    writer.WriteLine(string.Join(" ", numbers));
                }
            }
        }

        public static long CalculateOddProduct(string filePath)
        {
            long product = 1;
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var numbers = line.Split(' ').Select(int.Parse);
                foreach (var number in numbers)
                {
                    if (number % 2 != 0)
                    {
                        product *= number;
                    }
                }
            }
            return product;
        }

        public static void CopyLinesWithoutLetters(string inputFilePath, string outputFilePath)
        {
            using (var reader = new StreamReader(inputFilePath))
            using (var writer = new StreamWriter(outputFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.Any(char.IsLetter))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
