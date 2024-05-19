using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servise2
{
    internal class SparePart
    {
        public SparePart(string name, int prise)
        {
            Name = name;

            Price = prise;
        }

        public string Name { get; private set; }

        public int Price { get; private set; }
    }
}
