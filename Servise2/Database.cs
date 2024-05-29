using System;
using System.Collections.Generic;

namespace Servise2
{
    internal class Database
    {
        private static int minbValuePrice = 100;
        private static int maxValuePrice = 900;

        private static List<SparePart> s_parts = new List<SparePart>()
        {
            new SparePart("Шаровая", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Крестовина", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Амортизатор", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Кардан", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Выхлопная труба", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Фара Левая", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Фара Правая", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Зеркало", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Бампер", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Крышка богажника", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Фаркоп", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Лючек бензобака", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Капот", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Поворотник Левый", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Поворотник Правый", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Дверь Левая передняя", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Дверь Правая передняя", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Дверь Левая Задняя", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice)),
            new SparePart("Дверь Правая Задняя", UserUtils.GetRandomNumber(minbValuePrice, maxValuePrice))
        };

        public static List<SparePart> GetParts()
        {
            List<SparePart> parts = new List<SparePart>(s_parts);

            return parts;
        }

        public static List<SparePart> GetParts(int numberParts)
        {
            List<SparePart> brokenParts = new List<SparePart>();

            List<SparePart> parts = new List<SparePart>(s_parts);

            int index;

            for (int i = 0; i < numberParts; i++)
            {
                index = UserUtils.GetRandomNumber(parts.Count);

                brokenParts.Add(parts [index]);

                parts.Remove(parts [index]);
            }

            return brokenParts;
        }

        public void Show()
        {
            foreach (SparePart part in s_parts)
            {
                Console.WriteLine($"Название {part.Name}");
            }
        }

        public static void RemovePart(int index)
        {
            s_parts.RemoveAt(index);
        }
    }
}
