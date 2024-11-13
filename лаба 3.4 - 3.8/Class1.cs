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
        // Задание 4: Заполнить бинарный файл случайными числами и найти наибольший модуль элемента с нечетным индексом
        public static void GenerateBinaryFileWithNumbers(string filePath, int count)
        {
            var random = new Random();
            using (var writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.Write(random.Next(-100, 100));
                }
            }
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

        // Задание 5: Структура "Игрушка" и бинарный файл с XML-сериализацией
        public struct Toy
        {
            public string Name;
            public int Price;
            public int MinAge;
            public int MaxAge;
        }

        public static void GenerateBinaryFileWithToys(string filePath, List<Toy> toys)
        {
            var serializer = new XmlSerializer(typeof(List<Toy>));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, toys);
            }
        }

        public static List<string> GetToysForAgeRange(string filePath, int minAge, int maxAge)
        {
            var result = new List<string>();
            var serializer = new XmlSerializer(typeof(List<Toy>));

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                var toys = (List<Toy>)serializer.Deserialize(stream);
                result.AddRange(toys.Where(toy => toy.MinAge <= maxAge && toy.MaxAge >= minAge)
                                    .Select(toy => toy.Name));
            }
            return result;
        }

        // Задание 6: Найти среднее арифметическое чисел в текстовом файле
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

        // Задание 7: Найти произведение нечетных чисел в текстовом файле
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

        // Задание 8: Переписать строки без букв в другой файл
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
