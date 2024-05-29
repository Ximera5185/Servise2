using System;
using System.Collections.Generic;

namespace Servise2
{
    internal class Car
    {
        private List<SparePart> _brokenParts = new List<SparePart>();
        private List<SparePart> _newParts = new List<SparePart>();

        public Car(string name)
        {
            InstanceCounter++;

            Name = name + InstanceCounter;

            AddBrokenParts();
        }

        public int BrokenPartsCount => _brokenParts.Count;

        public static int InstanceCounter { get; private set; }

        public string Name { get; private set; }

        public void ShowBrokenParts()
        {
            Console.WriteLine($" Автомобиль {Name}\n" +
            $" Сломанные запчасти автомобиля : ");

            for (int i = 0; i < _brokenParts.Count; i++)
            {
                Console.WriteLine($"{i + 1} Запчасть - {_brokenParts [i].Name} Цена - {_brokenParts [i].Price}");
            }
        }

        public bool HaveBrokenPart(string partName)
        {
            foreach (SparePart part in _brokenParts)
            {
                if (part.Name == partName)
                {
                    return true;
                }
            }

            return false;
        }
        public bool GetNamePart()
        {
            if (_brokenParts.Count == 0)
            {
                return true;
            }

            return false;
        }

        public SparePart GetPart(int index)
        {
            return _brokenParts [index];
        }



        public void FixPart(SparePart newPart)
        {
            foreach (SparePart part in _brokenParts)
            {
                if (part.Name == newPart.Name)
                {
                    _brokenParts.Remove(part);

                    AddPart(newPart);

                    return;
                }
            }
        }

        public void AddPart(SparePart newPart)
        {
            _newParts.Add(newPart);
        }
        private void AddBrokenParts()
        {
            Database dataBase = new Database();

            int maxValueParts = 4;

            _brokenParts = Database.GetParts(maxValueParts);
        }
    }
}
