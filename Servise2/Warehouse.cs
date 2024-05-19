using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servise2
{
    internal class Warehouse
    {
        private List<SparePart> _parts = new List<SparePart>();

        public Warehouse()
        {
            _parts = Database.GetParts();
        }

        public void Show()
        {
            Console.WriteLine("Запчасти на складе ");

            for (int i = 0; i < _parts.Count; i++)
            {
                Console.WriteLine($"{i + 1} Запчасть - {_parts [i].Name} Цена - {_parts [i].Price}");
            }

            Console.WriteLine();
        }

        public bool TryGetPart(int index, out SparePart part)
        {
            if (_parts.Count >= index)
            {
                part = _parts [index];

                _parts.Remove(part);

                return true;
            }
            else
            {
                part = null;

                return false;
            }

        }

        public bool TryGetParts(string name)
        {
            foreach (SparePart part in _parts)
            {
                if (name == part.Name)
                {
                    _parts.Remove(part);

                    return true;
                }
            }

            return false;
        }
    }
}
