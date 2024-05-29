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
