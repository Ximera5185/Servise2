using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servise2
{
    internal class Car
    {
        private List<SparePart> _brokenParts = new List<SparePart>();

        public Car(string name)
        {
            InstanceCounter++;

            Name = name + InstanceCounter;

            AddBrokenParts();
        }

        public int Count => _brokenParts.Count;

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



        public void RemovePart(int index)
        {
            _brokenParts.RemoveAt(index);
        }

        private void AddBrokenParts()
        {
            Database dataBase = new Database();

            int maxValueParts = 4;

            _brokenParts = Database.GetParts(maxValueParts);
        }
    }
}
